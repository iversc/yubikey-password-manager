/*
 * Created by SharpDevelop.
 * User: civerson
 * Date: 12/13/2016
 * Time: 11:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Yubikey_Password_Manager
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListBox lstAccounts;
		private System.Windows.Forms.TextBox tbUsername;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnPassword;
		private System.Windows.Forms.Button btnUsername;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cbAppendCr;
		private System.Windows.Forms.Button btnWriteBoth;
		private System.Windows.Forms.Button btnWritePassword;
		private System.Windows.Forms.Button btnWriteUsername;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.TextBox tbCredentialName;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstAccounts = new System.Windows.Forms.ListBox();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnPassword = new System.Windows.Forms.Button();
			this.btnUsername = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbAppendCr = new System.Windows.Forms.CheckBox();
			this.btnWriteBoth = new System.Windows.Forms.Button();
			this.btnWritePassword = new System.Windows.Forms.Button();
			this.btnWriteUsername = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.tbCredentialName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstAccounts
			// 
			this.lstAccounts.FormattingEnabled = true;
			this.lstAccounts.Location = new System.Drawing.Point(12, 12);
			this.lstAccounts.Name = "lstAccounts";
			this.lstAccounts.Size = new System.Drawing.Size(260, 108);
			this.lstAccounts.TabIndex = 0;
			this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.LstAccountsSelectedIndexChanged);
			// 
			// tbUsername
			// 
			this.tbUsername.Location = new System.Drawing.Point(122, 152);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(150, 20);
			this.tbUsername.TabIndex = 2;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(122, 178);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(150, 20);
			this.tbPassword.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 155);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 181);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Password:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnPassword);
			this.groupBox1.Controls.Add(this.btnUsername);
			this.groupBox1.Location = new System.Drawing.Point(12, 236);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 54);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Copy";
			// 
			// btnPassword
			// 
			this.btnPassword.Location = new System.Drawing.Point(145, 19);
			this.btnPassword.Name = "btnPassword";
			this.btnPassword.Size = new System.Drawing.Size(105, 23);
			this.btnPassword.TabIndex = 1;
			this.btnPassword.Text = "Copy Password";
			this.btnPassword.UseVisualStyleBackColor = true;
			this.btnPassword.Click += new System.EventHandler(this.BtnPasswordClick);
			// 
			// btnUsername
			// 
			this.btnUsername.Location = new System.Drawing.Point(6, 19);
			this.btnUsername.Name = "btnUsername";
			this.btnUsername.Size = new System.Drawing.Size(105, 23);
			this.btnUsername.TabIndex = 0;
			this.btnUsername.Text = "Copy Username";
			this.btnUsername.UseVisualStyleBackColor = true;
			this.btnUsername.Click += new System.EventHandler(this.BtnUsernameClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbAppendCr);
			this.groupBox2.Controls.Add(this.btnWriteBoth);
			this.groupBox2.Controls.Add(this.btnWritePassword);
			this.groupBox2.Controls.Add(this.btnWriteUsername);
			this.groupBox2.Location = new System.Drawing.Point(12, 296);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(260, 110);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Yubikey";
			// 
			// cbAppendCr
			// 
			this.cbAppendCr.Checked = true;
			this.cbAppendCr.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAppendCr.Location = new System.Drawing.Point(6, 19);
			this.cbAppendCr.Name = "cbAppendCr";
			this.cbAppendCr.Size = new System.Drawing.Size(244, 24);
			this.cbAppendCr.TabIndex = 3;
			this.cbAppendCr.Text = "Include Enter/Return Key";
			this.cbAppendCr.UseVisualStyleBackColor = true;
			// 
			// btnWriteBoth
			// 
			this.btnWriteBoth.Location = new System.Drawing.Point(6, 78);
			this.btnWriteBoth.Name = "btnWriteBoth";
			this.btnWriteBoth.Size = new System.Drawing.Size(244, 23);
			this.btnWriteBoth.TabIndex = 2;
			this.btnWriteBoth.Text = "Write Username && Password";
			this.btnWriteBoth.UseVisualStyleBackColor = true;
			this.btnWriteBoth.Click += new System.EventHandler(this.BtnWriteBothClick);
			// 
			// btnWritePassword
			// 
			this.btnWritePassword.Location = new System.Drawing.Point(145, 49);
			this.btnWritePassword.Name = "btnWritePassword";
			this.btnWritePassword.Size = new System.Drawing.Size(105, 23);
			this.btnWritePassword.TabIndex = 1;
			this.btnWritePassword.Text = "Write Password";
			this.btnWritePassword.UseVisualStyleBackColor = true;
			this.btnWritePassword.Click += new System.EventHandler(this.BtnWritePasswordClick);
			// 
			// btnWriteUsername
			// 
			this.btnWriteUsername.Location = new System.Drawing.Point(6, 49);
			this.btnWriteUsername.Name = "btnWriteUsername";
			this.btnWriteUsername.Size = new System.Drawing.Size(105, 23);
			this.btnWriteUsername.TabIndex = 0;
			this.btnWriteUsername.Text = "Write Username";
			this.btnWriteUsername.UseVisualStyleBackColor = true;
			this.btnWriteUsername.Click += new System.EventHandler(this.BtnWriteUsernameClick);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(12, 207);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(111, 23);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = "Add Account";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(157, 207);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(115, 23);
			this.btnRemove.TabIndex = 8;
			this.btnRemove.Text = "Remove Account";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
			// 
			// tbCredentialName
			// 
			this.tbCredentialName.Location = new System.Drawing.Point(122, 126);
			this.tbCredentialName.Name = "tbCredentialName";
			this.tbCredentialName.Size = new System.Drawing.Size(150, 20);
			this.tbCredentialName.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "Credential Name:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 418);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbCredentialName);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.lstAccounts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "Yubikey Password Manager";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
