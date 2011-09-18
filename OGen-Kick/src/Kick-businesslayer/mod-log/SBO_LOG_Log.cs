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

using OGen.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.lib.crypt;
using OGen.NTier.Kick.lib.datalayer;
using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
//using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer {
	[BOClassAttribute("BO_LOG_Log", "")]
	public static class SBO_LOG_Log {

		#region public static int MessageSize { get; }
		private static int messagesize__ = -2;

		public static int MessageSize {
			get {
				if (messagesize__ == -2) {
					OGen.NTier.lib.datalayer.DOPropertyAttribute _att = (OGen.NTier.lib.datalayer.DOPropertyAttribute)Attribute.GetCustomAttribute(
						typeof(SO_LOG_Log).GetProperty("Message"),
						typeof(OGen.NTier.lib.datalayer.DOPropertyAttribute),
						true
					);
					messagesize__ = _att.Size;
				}

				return messagesize__;
			}
		} 
		#endregion

		#region public static void Log(...);
		#region internal static void log(...);
		internal static void log(
			utils.Sessionuser usersession_in,

			int logtype_in,
			int errortype_in,
			long idPermition_in, 

			int idApplication_in,

			string format_in,
			params string[] args_in
		) {
			SO_LOG_Log _log = new SO_LOG_Log();

			#region _log.Message = ...;
			_log.Message = string.Format(format_in, args_in);
			if (_log.Message.Length > MessageSize) {
				_log.Message = _log.Message.Substring(0, MessageSize);
			}
			#endregion
			#region _log.IDUser = ...;
			if (
				(usersession_in == null)
				||
				(usersession_in.IDUser <= 0)
			) {
				_log.IFUser_isNull = true;
			} else {
				_log.IFUser = usersession_in.IDUser;
			}
			#endregion
			_log.IFLogtype = logtype_in;
			#region _log.IDErrortype = ...;
			if (errortype_in == ErrorType.no_error) {
				_log.IFErrortype_isNull = true;
			} else {
				_log.IFErrortype = errortype_in;
			} 
			#endregion
			#region _log.IFPermition = ...;
			if (idPermition_in <= 0) {
				_log.IFPermition_isNull = true;
			} else {
				_log.IFPermition = idPermition_in;
			}
			#endregion
			_log.Stamp = DateTime.Now;
			_log.IFUser__read_isNull = true;
			_log.Stamp__read_isNull = true;
			#region _log.IFApplication = ...;
			if (idApplication_in <= 0) {
				_log.IFApplication_isNull = true;
			} else {
				_log.IFApplication = idApplication_in;
			} 
			#endregion

			DO_LOG_Log.insObject(
				_log,
				false,
				null
			);


#if DEBUG
			Console.WriteLine(
			    ".--- Log ---\n{0}{1}{2}|message: {3}\n'-----------",
				LogType.Items.ContainsKey(logtype_in) ? string.Format(
					"|log type: {0}\n", 
					LogType.Items[logtype_in].Name
				) : "", 
				ErrorType.Items.ContainsKey(errortype_in) ? string.Format(
					"|error type: {0}\n", 
					ErrorType.Items[errortype_in].Name
				) : "", 
				!_log.IFUser_isNull ? string.Format(
					"|user: {0}\n", 
					_log.IFUser.ToString()
				) : "", 
				_log.Message
			);
#endif
		}
		#endregion

		[BOMethodAttribute("Log", true, false, 1)]
		public static void Log(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int logtype_in,
			int errortype_in,
			long idPermition_in, 

			int idApplication_in,

			string format_in,
			string[] args_in
		) {
			int[] _errors;
			List<int> _errorlist;
			Guid _sessionguid;
			utils.Sessionuser _sessionuser;

			if (
				(sessionGuid_in != "") 
				&& 
				SBO_CRD_Authentication.isSessionGuid_valid(
					sessionGuid_in,
					ip_forLogPurposes_in, 
					out _sessionguid,
					out _sessionuser,
					out _errorlist,
					out _errors
				)
			) {
				log(
					_sessionuser,

					logtype_in,
					errortype_in,
					idPermition_in,

					_sessionuser.IDApplication,

					format_in,
					args_in
				);
			} else {
				log(
					null,

					logtype_in,
					errortype_in,
					idPermition_in, 

					idApplication_in,

					format_in,
					args_in
				);
			}
		}
		#endregion

		#region public static void MarkRead(...);
		[BOMethodAttribute("MarkRead", true, false, 1)]
		public static void MarkRead(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int idLog_in,

			out int[] errors_out
		) {
			List<int> _errorlist = new List<int>();
			Guid _sessionguid;
			utils.Sessionuser _sessionuser;

			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in, 
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return;
			}
			#endregion
			#region check permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.Log__mark_read)
			) {
				_errorlist.Add(ErrorType.lack_of_permitions);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			SO_LOG_Log _log = DO_LOG_Log.getObject(
				idLog_in,
				null
			);
			if (_log == null) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			} else if (
				!_log.IFUser__read_isNull
				||
				!_log.Stamp__read_isNull
			) {
				_errorlist.Add(ErrorType.log__already_marked_read);
				errors_out = _errorlist.ToArray();
				return;
			} else {
				_log.IFUser__read = _sessionuser.IDUser;
				_log.Stamp__read = DateTime.Now;
				DO_LOG_Log.updObject(
					_log,
					true, 

					null
				);

				_errorlist.Add(ErrorType.log__marked_read__WARNING);
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void delRecord_Error_Read_andDeprecated(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		//[BOMethodAttribute("delRecord_Error_Read_andDeprecated", true)]
		public static void delRecord_Error_Read_andDeprecated(
		) {
			DO_LOG_Log.delRecord_generic(
				LogType.error,
				-1,
				-1,
				datetime_minvalue_, // DateTime.MinValue,
				DateTime.Now.AddDays(-2),
				true, 

				null // on every application
			);
		}
		#endregion
		#region public static void delRecord_Debug_byDeprecated(...);
		//[BOMethodAttribute("delRecord_Debug_byDeprecated", true)]
		public static void delRecord_Debug_byDeprecated(
		) {
			DO_LOG_Log.delRecord_generic(
				LogType.debug,
				-1,
				-1,
				datetime_minvalue_, // DateTime.MinValue,
				DateTime.Now.AddDays(-1),
				false,

				null // on every application
			);
			DO_LOG_Log.delRecord_generic(
				LogType.debug,
				-1,
				-1,
				datetime_minvalue_, // DateTime.MinValue,
				DateTime.Now.AddDays(2), // DateTime.MaxValue,
				true,

				null // on every application
			);
		}
		#endregion

		#region //public static SO_Log[] getRecord_byLogtype_andUser(...);
		//[BOMethodAttribute("getRecord_byLogtype_andUser", true)]
		//public static SO_Log[] getRecord_byLogtype_andUser(
		//    string credentials_in,

		//    Logtype Logtype_search_in,
		//    object IDUser_search_in,

		//    int page_in,
		//    int page_numRecords_in,

		//    out int error_out
		//) {
		//    error_out = ErrorType.no_error;

		//    ServerCredentials _credentials;
		//    if (
		//        (credentials_in != "")
		//        &&
		//        ((_credentials = new ServerCredentials(credentials_in)).IDUser > 0)
		//    ) {
		//        if (
		//            !_credentials.hasPermition((int)PermitionType.Admin)
		//        ) {
		//            error_out = ErrorType.lack_of_permitions;
		//            return null;
		//        }

		//        return DO_Log.getRecord_byLogtype_andUser(
		//            (int)Logtype_search_in,
		//            null,

		//            page_in,
		//            page_numRecords_in
		//        );

		//    } else {
		//        error_out = ErrorType.lack_of_permitions__not_logged_in;
		//        return null;
		//    }
		//} 
		#endregion

		#region public static SO_LOG_Log[] getRecord_generic(...);
		[BOMethodAttribute("getRecord_generic", true, false, 1)]
		public static SO_LOG_Log[] getRecord_generic(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			int IDLogtype_search_in,
			long IDUser_search_in,
			int IDErrortype_search_in,
			DateTime Stamp_begin_search_in,
			DateTime Stamp_end_search_in,

			bool Read_search_in,
			bool Read_search_isNull_in,

			int idApplication_in,
			bool idApplication_isNull_in, 

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			utils.Sessionuser _sessionuser;

			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in, 
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return null;
			}
			#endregion
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.Log__read)
			) {
				_errorlist.Add(ErrorType.log__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return null;
			}
			#endregion

			return DO_LOG_Log.getRecord_generic(
				IDLogtype_search_in,
				IDUser_search_in,
				IDErrortype_search_in,
				Stamp_begin_search_in,
				Stamp_end_search_in,
				Read_search_isNull_in 
					? null
					: (object)Read_search_in,
				idApplication_isNull_in 
					? null 
					: (object)idApplication_in, 

				page_in,
				page_numRecords_in,

				null
			);
		}
		#endregion
	}
}