﻿#region Copyright (C) 2002 Francisco Monteiro
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
	[BOClassAttribute("BO_NWS_Tag", "")]
	public static class SBO_NWS_Tag {
		#region public static SO_NWS_Tag getObject(...);
		[BOMethodAttribute("getObject", true, false, 1)]
		public static SO_NWS_Tag getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idTag_in,

			out int[] errors_out
		) {
			SO_NWS_Tag _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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

				return _output;
			}
			#endregion
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.Tag__select
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_NWS_Tag.getObject(
				idTag_in, 

				null
			);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Tag getObject_byTag_andLanguage(...);
		[BOMethodAttribute("getObject_byTag_andLanguage", true, false, 1)]
		public static SO_vNWS_Tag getObject_byTag_andLanguage(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idTag_in,
			int idLanguage_in, 

			out int[] errors_out
		) {
			SO_vNWS_Tag _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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

				return _output;
			}
			#endregion
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.Tag__select
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_vNWS_Tag.getObject_byTag_andL(
				idTag_in, 
				idLanguage_in, 

				null
			);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Tag[] getRecord_byTag(...);
		[BOMethodAttribute("getRecord_byTag", true, false, 1)]
		public static SO_vNWS_Tag[] getRecord_byTag(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idTag_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
			SO_vNWS_Tag[] _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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

				return _output;
			}
			#endregion
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.Tag__select_notApproved
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_read__not_approved);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Tag.getRecord_byTag(
					idTag_in,

					page_orderBy_in,
					page_in,
					page_itemsPerPage_in,
					out page_itemsCount_out, 

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region private static bool check(...);
		private static bool check(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			ref SO_NWS_Tag tag_ref,
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in,

			out Guid sessionGuid_out,
			out Sessionuser sessionUser_out,
			out List<int> errorlist_out
		) {
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out sessionGuid_out,
				out sessionUser_out,
				out errorlist_out
			)) {
				return false;
			}
			#endregion
			#region check Permissions . . .
			if (
				!sessionUser_out.hasPermission(
					false, 
					PermissionType.Tag__insert,
					PermissionType.Tag__update
				)
			) {
				errorlist_out.Add(ErrorType.tag__lack_of_permissions_to_write);
				return false;
			}

			if (
				!sessionUser_out.hasPermission(PermissionType.Tag__approve)
				&&
				(
					!tag_ref.Approved_date_isNull
					||
					!tag_ref.IFUser__Approved_isNull
				)
			) {
				errorlist_out.Add(ErrorType.tag__lack_of_permissions_to_approve);
				return false;
			}
			#endregion

			// ToDos: here! check parent existence
			// ToDos: here! check if parent within same application
			// ToDos: here! check if any other checkings needed ...
			if (tag_ref.IFTag__parent <= 0) {
				tag_ref.IFTag__parent_isNull = true;
			}

			#region check Tag ...
			if (
				(tx_Name_in == null)
				||
				(tx_Name_in.Length == 0)
			) {
				errorlist_out.Add(ErrorType.tag__invalid_name);
				return false;
			} else {
				foreach (SO_DIC__TextLanguage _tx_name in tx_Name_in) {
					if (
						(_tx_name.Text = _tx_name.Text.Trim()).Length == 0
					) {
						errorlist_out.Add(ErrorType.tag__invalid_name);
						return false;
					}
				}
			}
			#endregion

			return true;
		} 
		#endregion
		#region public static int insObject(...);
		[BOMethodAttribute("insObject", true, false, 1)]
		public static long insObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Tag tag_in,
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in,

			bool selectIdentity_in, 

			out int[] errors_out
		) {
			long _output = -1L;
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				ref tag_in, 
				tx_Name_in, 

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
			} 
			#endregion

			if (_sessionuser.hasPermission(PermissionType.Tag__approve)) {
				tag_in.Approved_date = DateTime.Now;
				tag_in.IFUser__Approved = _sessionuser.IDUser;
			} else {
				tag_in.Approved_date_isNull = true;
				tag_in.IFUser__Approved_isNull = true;
			}

			tag_in.IFApplication = _sessionuser.IDApplication;

			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				_con.Open();
				_con.Transaction.Begin();

				long _tx_name = SBO_DIC_Dic.insObject(
					_con,
					_sessionuser.IDApplication,
					TableFieldSource.NWS_TAG__TX_NAME,
					tx_Name_in
				);

				tag_in.TX_Name = _tx_name;
				_output = DO_NWS_Tag.insObject(
					tag_in,
					selectIdentity_in,

					_con
				);
				_errorlist.Add(ErrorType.tag__successfully_created__WARNING);

				#region _con.Transaction.Commit();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Commit();
				}
				#endregion
			} catch (Exception _ex) {
				#region _con.Transaction.Rollback();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Rollback();
				}
				#endregion

			    _exception = _ex;
			} finally {
				#region _con.Transaction.Terminate(); _con.Close(); _con.Dispose();
				if (_con.isOpen) {
					if (_con.Transaction.inTransaction) {
						_con.Transaction.Terminate();
					}
					_con.Close();
				}

				_con.Dispose();
				#endregion
			}
			if (_exception != null) {
				#region SBO_LOG_Log.Log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L,
					_sessionuser.IDApplication,
					"{0}",
					new string[] {
			            _exception.Message
			        }
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
		#region public static void updObject(...);
		[BOMethodAttribute("updObject", true, false, 1)]
		public static void updObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Tag tag_in,
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in,

			out int[] errors_out
		) {
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				ref tag_in,
				tx_Name_in, 

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return;
			} 
			#endregion
			#region check existence . . .
			SO_NWS_Tag _tag;
			if (
				tag_in.IDTag <= 0
				||
				(
					(_tag = DO_NWS_Tag.getObject(
						tag_in.IDTag
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			if (
				_tag.IFUser__Approved_isNull
				||
				_tag.Approved_date_isNull
			) {
				if (_sessionuser.hasPermission(PermissionType.Tag__approve)) {
					tag_in.Approved_date = DateTime.Now;
					tag_in.IFUser__Approved = _sessionuser.IDUser;
				} else {
					tag_in.Approved_date_isNull = true;
					tag_in.IFUser__Approved_isNull = true;
				}
			} else {
				tag_in.Approved_date = _tag.Approved_date;
				tag_in.IFUser__Approved = _tag.IFUser__Approved;
			}

			tag_in.IFApplication = _tag.IFApplication;

			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				_con.Open();
				_con.Transaction.Begin();

				#region TX_Name . . .
				if ((tx_Name_in != null) && (tx_Name_in.Length != 0)) {
					SBO_DIC_Dic.updObject(
						_con,
						_tag.TX_Name,
						tx_Name_in
					);
				}
				#endregion
				tag_in.TX_Name = _tag.TX_Name;

				DO_NWS_Tag.updObject(
					tag_in,
					true,

					_con
				);
				_errorlist.Add(ErrorType.tag__successfully_updated__WARNING);

				#region _con.Transaction.Commit();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Commit();
				}
				#endregion
			} catch (Exception _ex) {
				#region _con.Transaction.Rollback();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Rollback();
				}
				#endregion

			    _exception = _ex;
			} finally {
				#region _con.Transaction.Terminate(); _con.Close(); _con.Dispose();
				if (_con.isOpen) {
					if (_con.Transaction.inTransaction) {
						_con.Transaction.Terminate();
					}
					_con.Close();
				}

				_con.Dispose();
				#endregion
			}
			if (_exception != null) {
				#region SBO_LOG_Log.Log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L,
					_sessionuser.IDApplication,
					"{0}",
					new string[] {
			            _exception.Message
			        }
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void updObject_Approve(...);
		[BOMethodAttribute("updObject_Approve", true, false, 1)]
		public static void updObject_Approve(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idTag_in,

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.Tag__approve
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_approve);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Tag _tag;
			if (
				idTag_in <= 0
				||
				(
					(_tag = DO_NWS_Tag.getObject(
						idTag_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			_tag.Approved_date = DateTime.Now;
			_tag.IFUser__Approved = _sessionuser.IDUser;
			DO_NWS_Tag.updObject(
				_tag,
				true,

				null
			);
			_errorlist.Add(ErrorType.tag__successfully_approved__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void delObject(...);
		//private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		[BOMethodAttribute("delObject", true, false, 1)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idTag_in,

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.Tag__delete
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Tag _tag;
			if (
				idTag_in <= 0
				||
				(
					(_tag = DO_NWS_Tag.getObject(
						idTag_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check Permissions . . . (more)
			if (
				// is approved
				(
					!_tag.IFUser__Approved_isNull
					||
					!_tag.Approved_date_isNull
				)
				&&
				// and no permission to approve
				!_sessionuser.hasPermission(
					PermissionType.Tag__approve
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_delete_approved);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check References . . .
			if (
				(DO_NWS_ContentTag.getCount_inRecord_byTag(
					idTag_in
				) > 0)
				||
				(DO_NWS_Tag.getCount_inRecord_byParent(
					idTag_in, 
					_sessionuser.IDApplication // ToDos: here! this should not be needed!
				) > 0)
			) {
				_errorlist.Add(ErrorType.data__constraint_violation);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				_con.Open();
				_con.Transaction.Begin();

				DO_NWS_Tag.delObject(
					idTag_in,

					_con
				);

				SBO_DIC_Dic.delObject(
					_con,

					_tag.TX_Name
				);

				_errorlist.Add(ErrorType.tag__successfully_deleted__WARNING);

				#region _con.Transaction.Commit();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Commit();
				}
				#endregion
			} catch (Exception _ex) {
				#region _con.Transaction.Rollback();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Rollback();
				}
				#endregion

			    _exception = _ex;
			} finally {
				#region _con.Transaction.Terminate(); _con.Close(); _con.Dispose();
				if (_con.isOpen) {
					if (_con.Transaction.inTransaction) {
						_con.Transaction.Terminate();
					}
					_con.Close();
				}

				_con.Dispose();
				#endregion
			}
			if (_exception != null) {
				#region SBO_LOG_Log.Log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L,
					_sessionuser.IDApplication,
					"{0}",
					new string[] {
			            _exception.Message
			        }
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static SO_vNWS_Tag[] getRecord_Approved_byLang(...);
		[BOMethodAttribute("getRecord_Approved_byLang", true, false, 1)]
		public static SO_vNWS_Tag[] getRecord_Approved_byLang(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int idLanguage_search_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
			SO_vNWS_Tag[] _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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

				return _output;
			}
			#endregion
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.Tag__select
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Tag.getRecord_Approved_byLang(
					_sessionuser.IDApplication, 
					idLanguage_search_in,

					page_orderBy_in,
					page_in,
					page_itemsPerPage_in,
					out page_itemsCount_out, 

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Tag[] getRecord_byLang(...);
		[BOMethodAttribute("getRecord_byLang", true, false, 1)]
		public static SO_vNWS_Tag[] getRecord_byLang(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int idLanguage_search_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
			SO_vNWS_Tag[] _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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

				return _output;
			}
			#endregion
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.Tag__select_notApproved
				)
			) {
				_errorlist.Add(ErrorType.tag__lack_of_permissions_to_read__not_approved);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Tag.getRecord_byLang(
					_sessionuser.IDApplication, 
					idLanguage_search_in,

					page_orderBy_in,
					page_in,
					page_itemsPerPage_in,
					out page_itemsCount_out,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region public static SO_NWS_ContentTag[] getRecord_byContent(...);
		[BOMethodAttribute("getRecord_byContent", true, false, 1)]
		public static SO_NWS_ContentTag[] getRecord_byContent(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_search_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
			SO_NWS_ContentTag[] _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

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

				return _output;
			}
			#endregion
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					false,
					PermissionType.News__select_OffSchedule,
					PermissionType.News__select_OnSchedule
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_NWS_ContentTag.getRecord_byContent(
					idContent_search_in,

					page_orderBy_in,
					page_in,
					page_itemsPerPage_in,
					out page_itemsCount_out,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
		#region //public static SO_NWS_ContentTag[] getRecord_byContent_withDetails(...);
		//[BOMethodAttribute("getRecord_byContent_withDetails", true)]
		//public static SO_NWS_ContentTag[] getRecord_byContent_withDetails(
		//    #region params...
		//    string credentials_in,

		//    long idContent_search_in,
		//    int idLanguage_in, 

		//    long page_in,
		//    int page_itemsPerPage_in,

		//    out int[] errors_out
		//    #endregion
		//) {
		//    SO_NWS_ContentTag[] _output = null;
		//    List<int> _errors;

		//    #region ServerCredentials _credentials = ...;
		//    ServerCredentials _credentials
		//        = new ServerCredentials(
		//            credentials_in,
		//            out _errors
		//        );
		//    if (_errors.Count != 0) {
		//        errors_out = _errors.ToArray();
		//        return _output;
		//    }
		//    #endregion
		//    #region check Permissions . . .
		//    if (
		//        !_credentials.hasPermission(
		//            false,
		//            PermissionType.News__select_OffSchedule,
		//            PermissionType.News__select_OnSchedule
		//        )
		//    ) {
		//        _errors.Add(ErrorType.news__lack_of_permissions_to_read);
		//        errors_out = _errors.ToArray();
		//        return _output;
		//    }
		//    #endregion

		//    _output
		//        = DO_vNWS_Tag.getRecord_byContent_andL(
		//            idContent_search_in,

		//            page_in,
		//            page_itemsPerPage_in,

		//            null
		//        );

		//    errors_out = _errors.ToArray();
		//    return _output;
		//} 
		#endregion
	}
}