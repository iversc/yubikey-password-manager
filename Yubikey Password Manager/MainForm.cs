/*
 * Created by SharpDevelop.
 * User: civerson
 * Date: 12/13/2016
 * Time: 11:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using System.Management;

namespace Yubikey_Password_Manager
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public delegate void EnableYubikey();
		public delegate void DisableYubikey();
		
		private FileInfo dataFile;
		private BackgroundWorker bw;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
						
			dataFile = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YubiPM\\data.dat");
			if(File.Exists(dataFile.FullName))
			{
				//Load file
				FileStream fs = dataFile.OpenRead();
				byte[] fileData = new byte[fs.Length];
				fs.Read(fileData, 0, (int)fs.Length);
				fs.Close();
				
				byte[] data = ProtectedData.Unprotect(fileData, null, DataProtectionScope.CurrentUser);
				string list = Encoding.Unicode.GetString(data);
				
				while(list.Length > 0)
				{
					int len;
					int.TryParse(list.Substring(0, list.IndexOf("|")), out len);
					list = list.Substring(list.IndexOf("|") + 1);
					string credentialName = list.Substring(0, len);
					list = list.Substring(list.IndexOf("|") + 1);
					
					int.TryParse(list.Substring(0, list.IndexOf("|")), out len);
					list = list.Substring(list.IndexOf("|") + 1);
					string userName = list.Substring(0, len);
					list = list.Substring(list.IndexOf("|") + 1);
					
					int.TryParse(list.Substring(0, list.IndexOf("|")), out len);
					list = list.Substring(list.IndexOf("|") + 1);
					string password = list.Substring(0, len);
					list = list.Substring(list.IndexOf("|") + 1);
					
					lstAccounts.Items.Add(new Credential(credentialName, userName, password));
				}
			}
			else 
			{
				dataFile.Directory.Create();
			}
			
			
			bw = new BackgroundWorker();
			bw.DoWork += backgroundWorker1_DoWork;
			bw.RunWorkerAsync();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void copyToClipboard(string text, string valueName)
		{
			if(text == "") return;
			
			try
			{
				Clipboard.SetText( text );
			} 
			catch (ExternalException ex)
			{
				MessageBoxEx.Show(this, "Failed to copy " + valueName + " to clipboard.\nPlease try again.\n\n" + ex.Message,
				                  "Copy failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
			}
		}
		
		void BtnUsernameClick(object sender, EventArgs e)
		{
			copyToClipboard(tbUsername.Text, "username");
		}
		
		void BtnPasswordClick(object sender, EventArgs e)
		{
			copyToClipboard(tbPassword.Text, "password");
		}
		
		
		
		private void writeToYubikey(string username, string password, bool bIncludeUsername)
		{
			new YubikeyWriter(username, password, bIncludeUsername, cbAppendCr.Checked).write();
		}
		
		void BtnWriteUsernameClick(object sender, EventArgs e)
		{
			writeToYubikey("", tbUsername.Text, false);
		}
		
		void BtnWritePasswordClick(object sender, EventArgs e)
		{
			writeToYubikey("", tbPassword.Text, false);
		}
		
		void BtnWriteBothClick(object sender, EventArgs e)
		{
			writeToYubikey(tbUsername.Text, tbPassword.Text, true);
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			string credName = tbCredentialName.Text;
			string username = tbUsername.Text;
			string password = tbPassword.Text;
			if(username == "" || password == "") return;
			
			lstAccounts.Items.Add(new Credential(credName, username, password));
			tbCredentialName.Text = "";
			tbUsername.Text = "";
			tbPassword.Text = "";
			tbCredentialName.Focus();
		}
		
		void LstAccountsSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lstAccounts.SelectedIndex == -1) return;
			Credential cred = (Credential)lstAccounts.SelectedItem;
			tbCredentialName.Text = cred.CredentialName;
			tbUsername.Text = cred.Username;
			tbPassword.Text = cred.Password;
		}
		
		void BtnRemoveClick(object sender, EventArgs e)
		{
			if(lstAccounts.SelectedIndex == -1) return;
			lstAccounts.Items.Remove(lstAccounts.SelectedItem);
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			string list = "";
			foreach(Credential c in lstAccounts.Items)
			{
				list += (c.CredentialName.Length).ToString();
				list += "|";
				list += c.CredentialName;
				list += "|";
				list += (c.Username.Length).ToString();
				list += "|";
				list += c.Username;
				list += "|";
				list += (c.Password.Length).ToString();
				list += "|";
				list += c.Password;
				list += "|";
			}
			
			byte[] procData = ProtectedData.Protect(Encoding.Unicode.GetBytes(list), null, DataProtectionScope.CurrentUser);
			
			FileStream fs = dataFile.OpenWrite();
			fs.Write(procData, 0, procData.Length);
			fs.Close();
		}
		
		public void EnableYubikeyMethod()
		{
			gbYubikey.Enabled = true;
		}
		
		public void DisableYubikeyMethod()
		{
			gbYubikey.Enabled = false;
		}
			
		private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
		{
			
		    ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
		    if(instance["DeviceID"].ToString().Contains("VID_1050")){
		    	gbYubikey.BeginInvoke(new EnableYubikey(EnableYubikeyMethod));
		    }
		    
		}
	
		private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
		{
		    ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
		    if(instance["DeviceID"].ToString().Contains("VID_1050")){
		    	gbYubikey.BeginInvoke(new DisableYubikey(DisableYubikeyMethod));
		    }
		}            
		
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
		    WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
		
		    ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
		    insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
		    insertWatcher.Start();
		
		    WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
		    ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
		    removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
		    removeWatcher.Start();
		
		    // Do something while waiting for events
		    System.Threading.Thread.Sleep(200000000);
		}
	}
	
	class Credential {
		public string Username {get; private set;}
		public string Password {get; private set;}
		public string CredentialName {get; private set;}
		
		public Credential(string newCredName, string newUsername, string newPassword)
		{
			CredentialName = newCredName;
			Username = newUsername;
			Password = newPassword;
		}
		
		public override string ToString()
		{
			return (CredentialName == "") ? Username : CredentialName;
		}
	}
}
