/*
 * Created by SharpDevelop.
 * User: civerson
 * Date: 12/13/2016
 * Time: 10:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace Yubikey_Password_Manager
{
	/// <summary>
	/// Description of YubikeyWriter.
	/// </summary>
	public class YubikeyWriter
	{
		private const string alphanumeric = "abcdefghijklmnopqrstuvwxyz1234567890";
		private const string shiftalpha   = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()";
		private const string symbols      = " -=[]\\X;'`,./";
		private const string shiftsymbols = " _+{}|X:\"~<>?";
		private const string tabCode = "2b";

		private string username = "";
		private string password = "";
		private string theCode = "";
		bool bIncludeUsername { get; set; }
		bool bAppendCr { get; set;}
		
		public YubikeyWriter(string newUsername, string newPassword, bool includeUsername, bool appendCr)
		{
			username = convertToUSBScanCode(newUsername);
			password = convertToUSBScanCode(newPassword);
			bIncludeUsername = includeUsername;
			bAppendCr = appendCr;
			
			theCode = (bIncludeUsername) ? username + tabCode + password : password;
		}
		
		private string convertToUSBScanCode(string text)
		{
			string fullCode = "";
			int code = 0;
			
			for(int x = 0; x < text.Length; x++)
			{
				char c = text[x];
				code = 0;
				
				int a = alphanumeric.IndexOf(c);
				if(a > -1) 
				{
					code = a + 4;
					goto doNext;
				}
				
				a = shiftalpha.IndexOf(c);
				if(a > -1)
				{
					code = (a + 4) | 0x80;
					goto doNext;
				}
				
				a = symbols.IndexOf(c);
				if(a > -1)
				{
					code = a + 44;
					goto doNext;
				}
				
				a = shiftsymbols.IndexOf(c);
				if(a > -1)
				{
					code = (a + 44) | 0x80;
					goto doNext;
				}
				
			doNext:
				
				string temp = "00" + code.ToString("x");
				fullCode += temp.Substring(temp.Length - 2);
			}
			
			return fullCode;
		}
		
		public string getCode()
		{
			return theCode;
		}
		
		public void write()
		{
			string cmdLine = "-2 -oshort-ticket -o-static-ticket -y -ofixed=h:";
			
			string oFixed = "00000000000000000000000000000000";
			string oUid = "000000000000";
			string key = "00000000000000000000000000000000";
			const string disableAppendCr = " -o-append-cr ";
			
			
			int lenCode = theCode.Length;
			
			if(lenCode < 33)
			{
				oFixed = (theCode + oFixed).Substring(0, 32);
			}
			else if (lenCode < 45)
			{
				oFixed = theCode.Substring(0, 32);
				oUid = (theCode.Substring(32) + oUid).Substring(0, 12);
			}
			else
			{
				oFixed = theCode.Substring(0, 32);
				oUid = theCode.Substring(32, 12);
				key = (theCode.Substring(44) + key).Substring(0, 32);
			}
			
			
			cmdLine += oFixed + " -ouid=" + oUid + " -a" + key;
			if(!bAppendCr) cmdLine += disableAppendCr;
			
			ProcessStartInfo psi = new ProcessStartInfo();
			
			psi.Arguments = cmdLine;
			psi.FileName = "ykpersonalize.exe";
			
			psi.CreateNoWindow = true;
			psi.WindowStyle = ProcessWindowStyle.Hidden;
			Process.Start(psi);
		}
	}
}
