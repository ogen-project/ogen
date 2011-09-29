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
using System.Collections.Generic;
using System.Text;

namespace OGen.NTier.Kick.lib.businesslayer.shared {
	#region public class PseudoEnumItem { ... }
	public class PseudoEnumItem {
		public PseudoEnumItem(
			string name_in
		) {
			Name = name_in;
		}

		public string Name;
	}
	#endregion
	#region public class ErrorItem : PseudoEnumItem { ... }
	public class ErrorItem : PseudoEnumItem {
		public ErrorItem(
			string name_in,
			bool isError_notWarning_in
		) : base (
			name_in
		) {
			isError_notWarning = isError_notWarning_in;
		}

		public bool isError_notWarning;
	}
	#endregion

	public class ErrorType {
		#region public static Dictionary<int, OGen.NTier.Kick.lib.businesslayer.shared.ErrorItem> Items { get; }
		protected static readonly Dictionary<int, ErrorItem> items_;

		public static Dictionary<int, OGen.NTier.Kick.lib.businesslayer.shared.ErrorItem> Items {
			get {
				return items_;
			}
		} 
		#endregion

		#region public static string ErrorMessage(...);
		public static string ErrorMessage(
			string splitChar_in, 
			params int[] error_in
		) {
			if (error_in.Length > 0) {
				StringBuilder _sb = new StringBuilder();
				for (int i = 0; i < error_in.Length; i++) {
					_sb.Append(string.Format(
						"{0}{1}",
						(i == 0) ? "" : splitChar_in,
						ErrorType.Items[error_in[i]].Name
					));
				}

				return _sb.ToString();
			} else {
				return "";
			}
		}
		public static string ErrorMessage(
			int error_in
		) {
			return ErrorMessage(
				error_in,
				""
			);
		}
		public static string ErrorMessage(
			int error_in, 
			out bool isError_out
		) {
			return ErrorMessage(
				error_in,
				"", 
				out isError_out
			);
		}

		public static string ErrorMessage(
			int error_in,
			string aditionalInfo_in,
			params string[] args_in
		) {
			bool _iserror;
			return ErrorMessage(
				error_in,
				aditionalInfo_in,
				out _iserror, 
				args_in
			);
		}
		public static string ErrorMessage(
			int error_in,
			string aditionalInfo_in,
			out bool isError_out, 
			params string[] args_in
		) {
			aditionalInfo_in = aditionalInfo_in.Trim();

			OGen.NTier.Kick.lib.businesslayer.shared.ErrorItem _erroritem 
				= ErrorType.Items[
					error_in
				];

			if (!_erroritem.isError_notWarning) {
				isError_out = false;
				return string.Format(
					"{0}{1}",
					//_error.Replace(" - WARNING", ""),
					_erroritem.Name,
					(aditionalInfo_in == "") ? "" : string.Format(
						" " + aditionalInfo_in,
						args_in
					)
				);
			} else {
				isError_out = true;
				return string.Format(
					"{0}{1} [{2}]",
					//_error,
					_erroritem.Name,
					(aditionalInfo_in == "") ? "" : string.Format(
						" " + aditionalInfo_in,
						args_in
					),
					error_in
				);
			}
		}
		#endregion

		#region public static bool hasError(...);
		public static bool hasError(
			int error_in,
			params int[] errors_in
		) {
			if (
				(errors_in == null)
				||
				(errors_in.Length == 0)
			) {
				return false;
			}

			for (int i = 0; i < errors_in.Length; i++) {
				if (errors_in[i] == error_in) {
					return true;
				}
			}

			return false;
		}
		#endregion

		#region public static bool hasErrors(...);
		public delegate void hasErrors_errorFound(
			string message_in,
			bool isError_in
		);

		public static bool hasErrors(
			int[] errors_in
		) {
			return hasErrors(
				errors_in,
				null
			);
		}
		public static bool hasErrors(
			int[] errors_in,
			hasErrors_errorFound errorFound_in
		) {
			bool _output = false;

			if (errors_in != null) {
				bool _isError;
				for (int i = 0; i < errors_in.Length; i++ ) {
					if (errorFound_in != null) {
						errorFound_in(
							ErrorMessage(
								errors_in[i],
								out _isError
							),
							_isError
						);

						if (_isError)
							_output = true;
					} else {
						ErrorMessage(
							errors_in[i],
							out _isError
						);
						if (_isError)
							return true;
					}
				}
			}

			return _output;
		}
		#endregion

		static ErrorType() {
			items_ = new Dictionary<int, ErrorItem>();

			items_.Add(no_error, new ErrorItem("no error", false));
			items_.Add(lack_of_permitions, new ErrorItem("lack of permitions", true));
			items_.Add(lack_of_permitions__not_logged_in, new ErrorItem("lack of permitions - not logged in", true));
			items_.Add(data, new ErrorItem("data", true));
			items_.Add(data__not_found, new ErrorItem("data - not found", true));
			items_.Add(data__constraint_violation, new ErrorItem("data - constraint violation", true));
			items_.Add(data__can_not_delete__pending_references, new ErrorItem("data - can not delete - pending references", true));
			items_.Add(data__item_inserted__WARNING, new ErrorItem("data - item inserted", false));
			items_.Add(data__item_updated__WARNING, new ErrorItem("data - item updated", false));
			items_.Add(data__item_deleted__WARNING, new ErrorItem("data - item deleted", false));
			items_.Add(log__already_marked_read, new ErrorItem("log - already marked read", true));
			items_.Add(log__marked_read__WARNING, new ErrorItem("log - marked read", false));
			items_.Add(authentication, new ErrorItem("authentication", true));
			items_.Add(authentication__already_logged_in, new ErrorItem("authentication - already logged in", true));
			items_.Add(authentication__invalid_login, new ErrorItem("authentication - invalid login", true));
			items_.Add(profile__lack_of_permitions_to_read, new ErrorItem("profile - lack of permitions to read", true));
			items_.Add(profile__lack_of_permitions_to_write, new ErrorItem("profile - lack of permitions to write", true));
			items_.Add(profile__invalid_name, new ErrorItem("profile - invalid name", true));
			items_.Add(profile__successfully_created__WARNING, new ErrorItem("profile - successfully created", false));
			items_.Add(profile__successfully_updated__WARNING, new ErrorItem("profile - successfully updated", false));
			items_.Add(profile__lack_of_permitions_to_delete, new ErrorItem("profile - lack of permitions to delete", true));
			items_.Add(profile__successfully_deleted__WARNING, new ErrorItem("profile - successfully deleted", false));
			items_.Add(user__lack_of_permitions_to_read, new ErrorItem("user - lack of permitions to read", true));
			items_.Add(user__lack_of_permitions_to_write, new ErrorItem("user - lack of permitions to write", true));
			items_.Add(user__lack_of_permitions_to_delete, new ErrorItem("user - lack of permitions to delete", true));
			items_.Add(authentication__change_password__wrong_password, new ErrorItem("authentication - change password - wrong password", true));
			items_.Add(authentication__change_password__invalid_password, new ErrorItem("authentication - change password - invalid password", true));
			items_.Add(authentication__change_password__invalid_login, new ErrorItem("authentication - change password - invalid login", true));
			items_.Add(user_profile__successfully_set__WARNING, new ErrorItem("user profile - successfully set", false));
			items_.Add(log__lack_of_permitions_to_read, new ErrorItem("log - lack of permitions to read", true));
			items_.Add(permition__lack_of_permitions_to_read, new ErrorItem("permition - lack of permitions to read", true));
			items_.Add(profile_permition__successfully_set__WARNING, new ErrorItem("profile permition - successfully set", false));
			items_.Add(news__lack_of_permitions_to_delete, new ErrorItem("news - lack of permitions to delete", true));
			items_.Add(news__successfully_deleted__WARNING, new ErrorItem("news - successfully deleted", false));
			items_.Add(news__successfully_updated__WARNING, new ErrorItem("news - successfully updated", false));
			items_.Add(news__successfully_created__WARNING, new ErrorItem("news - successfully created", false));
			items_.Add(news__lack_of_permitions_to_write, new ErrorItem("news - lack of permitions to write", true));
			items_.Add(news__lack_of_permitions_to_read, new ErrorItem("news - lack of permitions to read", true));
			items_.Add(news__lack_of_permitions_to_approve, new ErrorItem("news - lack of permitions to approve", true));
			items_.Add(news__invalid_date, new ErrorItem("news - invalid date", true));
			items_.Add(tag__lack_of_permitions_to_read, new ErrorItem("tag - lack of permitions to read", true));
			items_.Add(tag__lack_of_permitions_to_read__not_approved, new ErrorItem("tag - lack of permitions to read - not approved", true));
			items_.Add(highlight__lack_of_permitions_to_read__not_approved, new ErrorItem("highlight - lack of permitions to read - not approved", true));
			items_.Add(highlight__lack_of_permitions_to_read, new ErrorItem("highlight - lack of permitions to read", true));
			items_.Add(source__lack_of_permitions_to_read, new ErrorItem("source - lack of permitions to read", true));
			items_.Add(source__lack_of_permitions_to_read__not_approved, new ErrorItem("source - lack of permitions to read - not approved", true));
			items_.Add(author__lack_of_permitions_to_read, new ErrorItem("author - lack of permitions to read", true));
			items_.Add(author__lack_of_permitions_to_read__not_approved, new ErrorItem("author - lack of permitions to read - not approved", true));
			items_.Add(news__profile__lack_of_permitions_to_read, new ErrorItem("news - profile - lack of permitions to read", true));
			items_.Add(news__profile__lack_of_permitions_to_write, new ErrorItem("news - profile - lack of permitions to write", true));
			items_.Add(news__profile__lack_of_permitions_to_delete, new ErrorItem("news - profile - lack of permitions to delete", true));
			items_.Add(author__lack_of_permitions_to_write, new ErrorItem("author - lack of permitions to write", true));
			items_.Add(author__successfully_created__WARNING, new ErrorItem("author - successfully created", false));
			items_.Add(author__lack_of_permitions_to_delete, new ErrorItem("author - lack of permitions to delete", true));
			items_.Add(author__lack_of_permitions_to_approve, new ErrorItem("author - lack of permitions to approve", true));
			items_.Add(author__lack_of_permitions_to_delete_approved, new ErrorItem("author - lack of permitions to delete approved", true));
			items_.Add(author__successfully_deleted__WARNING, new ErrorItem("author - successfully deleted", false));
			items_.Add(author__successfully_approved__WARNING, new ErrorItem("author - successfully approved", false));
			items_.Add(author__successfully_updated__WARNING, new ErrorItem("author - successfully updated", false));
			items_.Add(highlight__lack_of_permitions_to_write, new ErrorItem("highlight - lack of permitions to write", true));
			items_.Add(highlight__lack_of_permitions_to_approve, new ErrorItem("highlight - lack of permitions to approve", true));
			items_.Add(highlight__successfully_created__WARNING, new ErrorItem("highlight - successfully created", false));
			items_.Add(highlight__successfully_updated__WARNING, new ErrorItem("highlight - successfully updated", false));
			items_.Add(highlight__successfully_deleted__WARNING, new ErrorItem("highlight - successfully deleted", false));
			items_.Add(highlight__successfully_approved__WARNING, new ErrorItem("highlight - successfully approved", false));
			items_.Add(highlight__lack_of_permitions_to_delete, new ErrorItem("highlight - lack of permitions to delete", true));
			items_.Add(highlight__lack_of_permitions_to_delete_approved, new ErrorItem("highlight - lack of permitions to delete approved", true));
			items_.Add(highlight__invalid_name, new ErrorItem("highlight - invalid name", true));
			items_.Add(author__invalid_name, new ErrorItem("author - invalid name", true));
			items_.Add(source__lack_of_permitions_to_write, new ErrorItem("source - lack of permitions to write", true));
			items_.Add(source__lack_of_permitions_to_approve, new ErrorItem("source - lack of permitions to approve", true));
			items_.Add(source__invalid_name, new ErrorItem("source - invalid name", true));
			items_.Add(source__successfully_created__WARNING, new ErrorItem("source - successfully created", false));
			items_.Add(source__successfully_updated__WARNING, new ErrorItem("source - successfully updated", false));
			items_.Add(source__successfully_approved__WARNING, new ErrorItem("source - successfully approved", false));
			items_.Add(source__lack_of_permitions_to_delete, new ErrorItem("source - lack of permitions to delete", true));
			items_.Add(source__lack_of_permitions_to_delete_approved, new ErrorItem("source - lack of permitions to delete approved", true));
			items_.Add(source__successfully_deleted__WARNING, new ErrorItem("source - successfully deleted", false));
			items_.Add(news__profile__lack_of_permitions_to_delete_approved, new ErrorItem("news - profile - lack of permitions to delete approved", true));
			items_.Add(news__profile__successfully_deleted__WARNING, new ErrorItem("news - profile - successfully deleted", false));
			items_.Add(news__profile__lack_of_permitions_to_approve, new ErrorItem("news - profile - lack of permitions to approve", true));
			items_.Add(news__profile__invalid_name, new ErrorItem("news - profile - invalid name", true));
			items_.Add(news__profile__successfully_created__WARNING, new ErrorItem("news - profile - successfully created", false));
			items_.Add(news__profile__successfully_updated__WARNING, new ErrorItem("news - profile - successfully updated", false));
			items_.Add(news__profile__successfully_approved__WARNING, new ErrorItem("news - profile - successfully approved", false));
			items_.Add(tag__lack_of_permitions_to_write, new ErrorItem("tag - lack of permitions to write", true));
			items_.Add(tag__lack_of_permitions_to_approve, new ErrorItem("tag - lack of permitions to approve", true));
			items_.Add(tag__invalid_name, new ErrorItem("tag - invalid name", true));
			items_.Add(tag__successfully_created__WARNING, new ErrorItem("tag - successfully created", false));
			items_.Add(tag__successfully_updated__WARNING, new ErrorItem("tag - successfully updated", false));
			items_.Add(tag__successfully_approved__WARNING, new ErrorItem("tag - successfully approved", false));
			items_.Add(tag__lack_of_permitions_to_delete, new ErrorItem("tag - lack of permitions to delete", true));
			items_.Add(tag__lack_of_permitions_to_delete_approved, new ErrorItem("tag - lack of permitions to delete approved", true));
			items_.Add(tag__successfully_deleted__WARNING, new ErrorItem("tag - successfully deleted", false));
			items_.Add(news__attachment__successfully_created__WARNING, new ErrorItem("news - attachment - successfully created", false));
			items_.Add(news__attachment__successfully_updated__WARNING, new ErrorItem("news - attachment - successfully updated", false));
			items_.Add(news__attachment__lack_of_permitions_to_delete, new ErrorItem("news - attachment - lack of permitions to delete", true));
			items_.Add(news__attachment__successfully_deleted__WARNING, new ErrorItem("news - attachment - successfully deleted", false));
			items_.Add(forum__lack_of_permitions_to_read, new ErrorItem("forum - lack of permitions to read", true));
			items_.Add(forum__forum__lack_of_permitions_to_read, new ErrorItem("forum - forum - lack of permitions to read", true));
			items_.Add(forum__thread__lack_of_permitions_to_read, new ErrorItem("forum - thread - lack of permitions to read", true));
			items_.Add(forum__reply__lack_of_permitions_to_read_forum, new ErrorItem("forum - reply - lack of permitions to read forum", true));
			items_.Add(forum__lack_of_permitions_to_delete, new ErrorItem("forum - lack of permitions to delete", true));
			items_.Add(forum__forum__lack_of_permitions_to_delete, new ErrorItem("forum - forum - lack of permitions to delete", true));
			items_.Add(forum__thread__lack_of_permitions_to_delete, new ErrorItem("forum - thread - lack of permitions to delete", true));
			items_.Add(forum__reply__lack_of_permitions_to_delete, new ErrorItem("forum - reply - lack of permitions to delete", true));
			items_.Add(forum__forum__successfully_deleted__WARNING, new ErrorItem("forum - forum - successfully deleted", false));
			items_.Add(forum__thread__successfully_deleted__WARNING, new ErrorItem("forum - thread - successfully deleted", false));
			items_.Add(forum__reply__successfully_deleted__WARNING, new ErrorItem("forum - reply - successfully deleted", false));
			items_.Add(forum__thread__lack_of_permitions_to_insert, new ErrorItem("forum - thread - lack of permitions to insert", true));
			items_.Add(forum__reply__lack_of_permitions_to_insert, new ErrorItem("forum - reply - lack of permitions to insert", true));
			items_.Add(forum__forum__lack_of_permitions_to_insert, new ErrorItem("forum - forum - lack of permitions to insert", true));
			items_.Add(forum__invalid_subject, new ErrorItem("forum - invalid subject", true));
			items_.Add(forum__invalid_message, new ErrorItem("forum - invalid message", true));
			items_.Add(forum__forum__successfully_created__WARNING, new ErrorItem("forum - forum - successfully created", false));
			items_.Add(forum__thread__successfully_created__WARNING, new ErrorItem("forum - thread - successfully created", false));
			items_.Add(forum__reply__successfully_created__WARNING, new ErrorItem("forum - reply - successfully created", false));
			items_.Add(web__user__invalid_email, new ErrorItem("web - user - invalid email", true));
			items_.Add(web__user__updating_email__WARNING, new ErrorItem("web - user - updating email", false));
			items_.Add(web__user__can_not_send_mail, new ErrorItem("web - user - can not send mail", true));
			items_.Add(user__successfully_created__WARNING, new ErrorItem("user - successfully created", false));
			items_.Add(web__user__constraint_violation, new ErrorItem("web - user - constraint violation", true));
			items_.Add(encryption__failled_to_encrypt, new ErrorItem("encryption - failled to encrypt", true));
			items_.Add(encryption__failled_to_decrypt, new ErrorItem("encryption - failled to decrypt", true));
			items_.Add(encryption__failled_to_decrypt__expired, new ErrorItem("encryption - failled to decrypt - expired", true));
			items_.Add(web__user__invalid_name, new ErrorItem("web - user - invalid name", true));
			items_.Add(web__user__successfully_updated__WARNING, new ErrorItem("web - user - successfully updated", false));
			items_.Add(user__invalid_login, new ErrorItem("user - invalid login", true));
			items_.Add(business__this_should_never_happen, new ErrorItem("business - this should never happen", true));
			items_.Add(thread_service__too_slow, new ErrorItem("thread service - too slow", true));
			items_.Add(authentication__invalid_guid, new ErrorItem("authentication - invalid guid", true));
			items_.Add(authentication__invalid_email, new ErrorItem("authentication - invalid email", true));
			items_.Add(authentication__guid_not_yours, new ErrorItem("authentication - guid not yours", true));
			items_.Add(authentication__no_such_user, new ErrorItem("authentication - no such user", true));
			items_.Add(authentication__expired_guid, new ErrorItem("authentication - expired guid", true));

		}

		public const int no_error = 0;

		public const int lack_of_permitions = 1;
		public const int lack_of_permitions__not_logged_in = 2;

		public const int data = 3;
		public const int data__not_found = 4;
		public const int data__constraint_violation = 5;
		public const int data__can_not_delete__pending_references = 6;
		public const int data__item_inserted__WARNING = 7;
		public const int data__item_updated__WARNING = 8;
		public const int data__item_deleted__WARNING = 9;

		public const int business__this_should_never_happen = 128;

		public const int thread_service__too_slow = 129;

		public const int log__already_marked_read = 10;
		public const int log__marked_read__WARNING = 11;
		public const int log__lack_of_permitions_to_read = 29;

		public const int authentication = 12;
		public const int authentication__already_logged_in = 13;
		public const int authentication__invalid_login = 14;
		public const int authentication__invalid_guid = 130;
		public const int authentication__invalid_email = 131;
		public const int authentication__guid_not_yours = 132;
		public const int authentication__no_such_user = 133;
		public const int authentication__change_password__wrong_password = 25;
		public const int authentication__change_password__invalid_password = 26;
		public const int authentication__change_password__invalid_login = 27;
		public const int authentication__expired_guid = 134;

		public const int profile__lack_of_permitions_to_read = 15;
		public const int profile__lack_of_permitions_to_write = 16;
		public const int profile__invalid_name = 17;
		public const int profile__successfully_created__WARNING = 18;
		public const int profile__successfully_updated__WARNING = 19;
		public const int profile__lack_of_permitions_to_delete = 20;
		public const int profile__successfully_deleted__WARNING = 21;

		public const int profile_permition__successfully_set__WARNING = 31;

		public const int user__lack_of_permitions_to_read = 22;
		public const int user__lack_of_permitions_to_write = 23;
		public const int user__lack_of_permitions_to_delete = 24;
		public const int user__successfully_created__WARNING = 120;
		public const int user__invalid_login = 127;

		public const int user_profile__successfully_set__WARNING = 28;

		public const int permition__lack_of_permitions_to_read = 30;

		public const int news__lack_of_permitions_to_delete = 32;
		public const int news__successfully_deleted__WARNING = 33;
		public const int news__successfully_updated__WARNING = 34;
		public const int news__successfully_created__WARNING = 35;
		public const int news__lack_of_permitions_to_write = 36;
		public const int news__lack_of_permitions_to_read = 37;
		public const int news__lack_of_permitions_to_approve = 38;
		public const int news__invalid_date = 39;

		public const int tag__lack_of_permitions_to_read = 40;
		public const int tag__lack_of_permitions_to_read__not_approved = 41;
		public const int tag__lack_of_permitions_to_write = 85;
		public const int tag__lack_of_permitions_to_approve = 86;
		public const int tag__invalid_name = 87;
		public const int tag__successfully_created__WARNING = 88;
		public const int tag__successfully_updated__WARNING = 89;
		public const int tag__successfully_approved__WARNING = 90;
		public const int tag__lack_of_permitions_to_delete = 91;
		public const int tag__lack_of_permitions_to_delete_approved = 92;
		public const int tag__successfully_deleted__WARNING = 93;

		public const int highlight__invalid_name = 67;
		public const int highlight__lack_of_permitions_to_read__not_approved = 42;
		public const int highlight__lack_of_permitions_to_read = 43;
		public const int highlight__lack_of_permitions_to_write = 59;
		public const int highlight__lack_of_permitions_to_approve = 60;
		public const int highlight__lack_of_permitions_to_delete = 65;
		public const int highlight__lack_of_permitions_to_delete_approved = 66;
		public const int highlight__successfully_created__WARNING = 61;
		public const int highlight__successfully_updated__WARNING = 62;
		public const int highlight__successfully_deleted__WARNING = 63;
		public const int highlight__successfully_approved__WARNING = 64;

		public const int source__lack_of_permitions_to_read = 44;
		public const int source__lack_of_permitions_to_read__not_approved = 45;
		public const int source__lack_of_permitions_to_write = 69;
		public const int source__lack_of_permitions_to_approve = 70;
		public const int source__invalid_name = 71;
		public const int source__successfully_created__WARNING = 72;
		public const int source__successfully_updated__WARNING = 73;
		public const int source__successfully_approved__WARNING = 74;
		public const int source__lack_of_permitions_to_delete = 75;
		public const int source__lack_of_permitions_to_delete_approved = 76;
		public const int source__successfully_deleted__WARNING = 77;

		public const int author__invalid_name = 68;
		public const int author__lack_of_permitions_to_read = 46;
		public const int author__lack_of_permitions_to_read__not_approved = 47;
		public const int author__lack_of_permitions_to_write = 51;
		public const int author__lack_of_permitions_to_delete = 53;
		public const int author__lack_of_permitions_to_delete_approved = 55;
		public const int author__lack_of_permitions_to_approve = 54;
		public const int author__successfully_created__WARNING = 52;
		public const int author__successfully_deleted__WARNING = 56;
		public const int author__successfully_approved__WARNING = 57;
		public const int author__successfully_updated__WARNING = 58;

		public const int news__profile__lack_of_permitions_to_read = 48;
		public const int news__profile__lack_of_permitions_to_write = 49;
		public const int news__profile__lack_of_permitions_to_delete = 50;
		public const int news__profile__lack_of_permitions_to_delete_approved = 78;
		public const int news__profile__successfully_deleted__WARNING = 79;
		public const int news__profile__lack_of_permitions_to_approve = 80;
		public const int news__profile__invalid_name = 81;
		public const int news__profile__successfully_created__WARNING = 82;
		public const int news__profile__successfully_updated__WARNING = 83;
		public const int news__profile__successfully_approved__WARNING = 84;

		public const int news__attachment__successfully_created__WARNING = 94;
		public const int news__attachment__successfully_updated__WARNING = 95;
		public const int news__attachment__lack_of_permitions_to_delete = 96;
		public const int news__attachment__successfully_deleted__WARNING = 97;

		public const int forum__lack_of_permitions_to_read = 98;
		public const int forum__forum__lack_of_permitions_to_read = 99;
		public const int forum__thread__lack_of_permitions_to_read = 100;
		public const int forum__reply__lack_of_permitions_to_read_forum = 101;
		public const int forum__lack_of_permitions_to_delete = 102;
		public const int forum__forum__lack_of_permitions_to_delete = 103;
		public const int forum__thread__lack_of_permitions_to_delete = 104;
		public const int forum__reply__lack_of_permitions_to_delete = 105;
		public const int forum__forum__successfully_deleted__WARNING = 106;
		public const int forum__thread__successfully_deleted__WARNING = 107;
		public const int forum__reply__successfully_deleted__WARNING = 108;
		public const int forum__thread__lack_of_permitions_to_insert = 109;
		public const int forum__reply__lack_of_permitions_to_insert = 110;
		public const int forum__forum__lack_of_permitions_to_insert = 111;
		public const int forum__invalid_subject = 112;
		public const int forum__invalid_message = 113;
		public const int forum__forum__successfully_created__WARNING = 114;
		public const int forum__thread__successfully_created__WARNING = 115;
		public const int forum__reply__successfully_created__WARNING = 116;

		public const int web__user__invalid_email = 117;
		public const int web__user__invalid_name = 125;
		public const int web__user__updating_email__WARNING = 118;
		public const int web__user__can_not_send_mail = 119;
		public const int web__user__constraint_violation = 121;
		public const int web__user__successfully_updated__WARNING = 126;

		public const int encryption__failled_to_encrypt = 122;
		public const int encryption__failled_to_decrypt = 123;
		public const int encryption__failled_to_decrypt__expired = 124;
	}
}