#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Text.RegularExpressions;

using System.Configuration;
using System.Net.Mail;

namespace OGen.lib.mail {
	public static class utils {
		static utils() {
			smtpserver_ = new SmtpClient();
			smtpserver_.Host = System.Configuration.ConfigurationManager.AppSettings[
				"SMTP_ServerName"
			];
			smtpserver_.Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings[
				"SMTP_ServerPort"
			]);
			smtpserver_.UseDefaultCredentials = false;
			smtpserver_.Credentials = new System.Net.NetworkCredential(
				System.Configuration.ConfigurationManager.AppSettings[
					"SMTP_User"
				],
				System.Configuration.ConfigurationManager.AppSettings[
					"SMTP_Password"
				]
			);
			//smtpserver_.EnableSsl = true;

			from_ = new MailAddress(
				System.Configuration.ConfigurationManager.AppSettings[
					"SMTP_FROM_EMail"
				],
				System.Configuration.ConfigurationManager.AppSettings[
					"SMTP_FROM_Name"
				]
			);
		}

		#region	public static bool isEMail_valid(...);
		#region private static Regex regex { get; }
		private static Regex regex__ = null;

		private static Regex regex {
			get {
				if (regex__ == null) {
					regex__ = new Regex(
						// @"^(([^<>()[\]\\.,;:\s@\""]+"
						//+ @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
						//+ @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
						//+ @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
						//+ @"[a-zA-Z]{2,}))$",

						@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", 
					   RegexOptions.Compiled
				   );
				}
				return regex__;
			}
		}
		#endregion

		public static bool isEMail_valid(
			string email_in
		) {
			return regex__.IsMatch(email_in);
		}
		#endregion

		public static MailAddress[] ParseMailAddress(string mailAddress_in) {
			if (mailAddress_in == "") return null;

			string[] _mailaddress = mailAddress_in.Split(',');

			MailAddress[] _output = new MailAddress[_mailaddress.Length];
			for (int i = 0; i < _mailaddress.Length; i++) {
				_output[i] = new MailAddress(_mailaddress[i].Trim());
			}

			return _output;
		}

		private static SmtpClient smtpserver_;
		private static MailAddress from_;

		public static void MailSend(
			MailAddress[] to_in,
			MailAddress[] cc_in,
			MailAddress[] bcc_in,
			string subject_in,
			string body_in
		) {
			MailSend(
				from_, 
				to_in,
				cc_in,
				bcc_in,
				subject_in,
				body_in
			);
		}

		public static void MailSend(
			MailAddress from_in,
			MailAddress[] to_in, 
			MailAddress[] cc_in, 
			MailAddress[] bcc_in, 
			string subject_in,
			string body_in
		) {
			MailSend(
				from_in,
				to_in, 
				cc_in, 
				bcc_in, 
				subject_in,
				body_in,
				""
			);
		}

		public static void MailSend(
			MailAddress from_in,
			MailAddress[] to_in,
			MailAddress[] cc_in,
			MailAddress[] bcc_in,
			string subject_in,
			string body_in,
			string ics_in
		) {
			MailSend(
				from_in,
				to_in,
				cc_in,
				bcc_in,
				subject_in,
				body_in,
				ics_in, 
				false, 
				new string[] {}
			);
		}
		public static void MailSend(
			MailAddress from_in,
			MailAddress[] to_in,
			MailAddress[] cc_in,
			MailAddress[] bcc_in,
			string subject_in,
			string body_in,
			string ics_in,
			bool isBodyHtml_in, 
			string[] attachments_in
		) {
			MailMessage _mail2 = new MailMessage();
			_mail2.From = from_in;
			#region _mail2.To = to_in;
			for (int i = 0; (to_in != null) && (i < to_in.Length); i++) {
				_mail2.To.Add(
					to_in[i]
				);
			}
			#endregion
			#region _mail2.CC = cc_in;
			for (int i = 0; (cc_in != null) && (i < cc_in.Length); i++) {
				_mail2.CC.Add(
					cc_in[i]
				);
			} 
			#endregion
			#region _mail2.Bcc = bcc_in;
			for (int i = 0; (bcc_in != null) && (i < bcc_in.Length); i++) {
				_mail2.Bcc.Add(
					bcc_in[i]
				);
			} 
			#endregion
			_mail2.Subject = subject_in;
			_mail2.Body = body_in;

			_mail2.IsBodyHtml = isBodyHtml_in;

			_mail2.Priority = MailPriority.Normal;

			for (int i = 0; i < attachments_in.Length; i++) {
				_mail2.Attachments.Add(new Attachment(
					attachments_in[i]
				));
			}

			if (ics_in != "") {
				#region // ...
				//System.Net.Mime.ContentType _ct = new System.Net.Mime.ContentType("text/calendar");
				//AlternateView _av = AlternateView.CreateAlternateViewFromString(
				//    body_in, 
				//    _ct
				//);
				//_mail2.AlternateViews.Add(
				//    _av
				//);

				////_contenttype = new System.Net.Mime.ContentType(string.Format(
				////    "text/calendar;", // method=REQUEST; name=\"{0}\"",
				////    System.IO.Path.GetFileName(attachmentpath_in)
				////));
				////_contenttype.Parameters.Add("method", "REQUEST");
				////_contenttype.Parameters.Add("name", System.IO.Path.GetFileName(attachmentpath_in));

				//_mail2.Attachments.Add(new Attachment(
				//    attachmentpath_in,
				//    _ct//_contenttype
				//));
				#endregion

				Attachment _att = Attachment.CreateAttachmentFromString(
					ics_in,
					new System.Net.Mime.ContentType("text/calendar")
				);
				_att.ContentType.Parameters.Add("method", "REQUEST");

				_att.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
				_att.Name = "alert.ics";

				_mail2.Attachments.Add(_att);
			}

			smtpserver_.Send(_mail2);


			//System.Web.Mail.MailMessage _mail = new System.Web.Mail.MailMessage();
			//_mail.From = System.Configuration.ConfigurationManager.AppSettings["Mail_From"];
			//_mail.To = to_in;
			//_mail.Subject = subject_in;
			//_mail.Body = body_in;
			//_mail.BodyFormat = System.Web.Mail.MailFormat.Text;
			//_mail.Priority = System.Web.Mail.MailPriority.Normal;

			//System.Web.Mail.SmtpMail.Send(_mail);
		}

		public static void MailSend(
			MailMessage mailMessage_in
		) {
			smtpserver_.Send(
				mailMessage_in
			);
		}
	}
}