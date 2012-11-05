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

using OGen.Libraries.DataLayer;
using OGen.NTier.Libraries.BusinessLayer;

using OGen.Libraries.Crypt;
using OGen.NTier.Kick.Libraries.DataLayer;
using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;
using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
//using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;

namespace OGen.NTier.Kick.Libraries.BusinessLayer {
	[BOClassAttribute("BO_NWS_News", "")]
	public static class SBO_NWS_News {
		#region private static SO_vNWS_Content[] getrecord_bycontent_andlanguage(...);
		private static SO_vNWS_Content[] getrecord_bycontent_andlanguage(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in, 
			int idLanguage_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
			SO_vNWS_Content[] _output = null;
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
			bool _news__select_OnSchedule = _sessionuser.hasPermission(PermissionType.News__select_OnSchedule);
			bool _news__select_OffSchedule = _sessionuser.hasPermission(PermissionType.News__select_OffSchedule);
			if (
				!(
					_news__select_OnSchedule
					||
					_news__select_OffSchedule
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			if (idLanguage_in > 0) {
				_output = DO_vNWS_Content.getRecord_byContent_andL(
					idContent_in, 
					idLanguage_in,

					page_orderBy_in,
					page_in,
					page_itemsPerPage_in,
					out page_itemsCount_out, 

					null
				);
			} else {
				_output = DO_vNWS_Content.getRecord_byContent(
					idContent_in,

					page_orderBy_in,
					page_in,
					page_itemsPerPage_in,
					out page_itemsCount_out, 

					null
				);
			}

#if !DEBUG
			// ToDos: here!
			 _content__select_OnSchedule;
			 _content__select_OffSchedule;
#endif

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Content getObject(...);
		[BOMethodAttribute("getObject", true, false, 1)]
		public static SO_vNWS_Content getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,
			int idLanguage_in,

			out int[] errors_out
		) {
			long _count;
			SO_vNWS_Content[] _output = getrecord_bycontent_andlanguage(
				sessionGuid_in, 
				ip_forLogPurposes_in, 

				idContent_in, 
				idLanguage_in, 

				-1, -1, -1, out _count, 

				out errors_out
			);

			if (
				(_output != null)
				&&
				(_output.Length == 1)
			) {
				return _output[0];
			} else {
				return null;
			}
		}
		#endregion
		#region public static SO_vNWS_Content[] getRecord_byContent(...);
		[BOMethodAttribute("getRecord_byContent", true, false, 1)]
		public static SO_vNWS_Content[] getRecord_byContent(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			return getrecord_bycontent_andlanguage(
				sessionGuid_in, 
				ip_forLogPurposes_in,

				idContent_in,
				-1,

				page_orderBy_in,
				page_in,
				page_itemsPerPage_in,
				out page_itemsCount_out, 

				out errors_out
			);
		}
		#endregion

		#region public static void updObject_Approve(...);
		[BOMethodAttribute("updObject_Approve", true, false, 1)]
		public static void updObject_Approve(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,

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
			bool _content__approve = _sessionuser.hasPermission(PermissionType.News__approve);
			if (
				!(
					_content__approve
				// ||
				// ...
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permissions_to_approve);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check Existence . . .
			SO_NWS_Content _content;
			if (
				(idContent_in <= 0)
				||
				(
					(_content = DO_NWS_Content.getObject(idContent_in))
					==
					null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			_content.Approved_date = DateTime.Now;
			_content.IFUser__Approved = _sessionuser.IDUser;
			DO_NWS_Content.updObject(
				_content,
				true
			);

			errors_out = _errorlist.ToArray();
		}
		#endregion

//		#region private static bool check(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		private static bool check(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			ref SO_NWS_Content content_ref,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in,

			//bool andApprove_in, 

			out Guid sessionGuid_out,
			out Sessionuser sessionUser_out,
			out List<int> errorlist_out
			#endregion
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
			bool _news__insert = sessionUser_out.hasPermission(PermissionType.News__insert);
			bool _news__update_Approved = sessionUser_out.hasPermission(PermissionType.News__update_Approved);
			bool _news__update_Mine_notApproved = sessionUser_out.hasPermission(PermissionType.News__update_Mine_notApproved);
			if (
				!(
					_news__insert
					||
					_news__update_Approved
					||
					_news__update_Mine_notApproved
				)
			) {
				errorlist_out.Add(ErrorType.news__lack_of_permissions_to_write);
				return false;
			}
			#endregion

//			#region check Content ...
#if !DEBUG
			if (
(profile_ref.Name = profile_ref.Name.Trim()).Length == 0
			) {
errors_out.Add(ErrorType.profile__invalid_name);
				return false;
			}
#endif

			//if (andApprove_in) {
			//    if (
			//        content_ref.Begin_date_isNull
			//        ||
			//        content_ref.End_date_isNull
			//        ||
			//        (content_ref.Begin_date < content_ref.End_date)
			//    ) {
			//        errors_out.Add(ErrorType.news__invalid_date);
			//        return false;
			//    } else if (credentials_out.hasPermission(PermissionType.News__approve)) {
			//        errors_out.Add(ErrorType.news__lack_of_permissions_to_approve);
			//        return false;
			//    } else {
			//        content_ref.IFUser__Approved = credentials_out.IDUser;
			//        content_ref.Approved_date = DateTime.Now;
			//        //content_in.Begin_date
			//        //content_in.End_date
			//    }
			//} else {
			//    content_ref.IFUser__Approved_isNull = true;
			//    content_ref.Approved_date_isNull = true;
			//    content_ref.Begin_date
			//        = content_ref.End_date
			//        = datetime_minvalue_;
			//}
//			#endregion

			return true;
		} 
//		#endregion
		#region private static void relate(...);
		private static void relate(
			long[] idTags_in,
			long[] idAuthors_in,
			long[] idSources_in,
			long[] idHighlights_in, 
			long[] idProfiles_in, 

			long idContent_in,

			DBConnection con_in
		) {
			#region Tags . . .
			foreach (int _idtag in idTags_in) {
				DO_NWS_ContentTag.setObject(
					new SO_NWS_ContentTag(
						idContent_in,
						_idtag
					),
					true,

					con_in
				);
			}
			#endregion
			#region Authors . . .
			foreach (int _idauthor in idAuthors_in) {
				DO_NWS_ContentAuthor.setObject(
					new SO_NWS_ContentAuthor(
						idContent_in,
						_idauthor
					),
					true,

					con_in
				);
			}
			#endregion
			#region Sources . . .
			foreach (int _idsource in idSources_in) {
				DO_NWS_ContentSource.setObject(
					new SO_NWS_ContentSource(
						idContent_in,
						_idsource
					),
					true,

					con_in
				);
			}
			#endregion
			#region Highlights . . .
			foreach (int _idhighlight in idHighlights_in) {
				SO_NWS_ContentHighlight _highlight 
					= new SO_NWS_ContentHighlight(
						idContent_in,
						_idhighlight, 
						datetime_minvalue_, 
						datetime_minvalue_
					);
				_highlight.Begin_date_isNull = true;
				_highlight.End_date_isNull = true;

				DO_NWS_ContentHighlight.setObject(
					_highlight,
					true,

					con_in
				);
			}
			#endregion
			#region Profiles . . .
			foreach (int _idprofile in idProfiles_in) {
				DO_NWS_ContentProfile.setObject(
					new SO_NWS_ContentProfile(
						idContent_in,
						_idprofile
					),
					true,

					con_in
				);
			}
			#endregion
		} 
		#endregion
//		#region public static long insObject(...);
		[BOMethodAttribute("insObject", true, false, 1)]
		public static long insObject(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Content content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in,

			long[] idTags_in,
			long[] idAuthors_in,
			long[] idSources_in,
			long[] idHighlights_in, 
			long[] idProfiles_in, 

			//bool andApprove_in, 

			out int[] errors_out
			#endregion
		) {
			long _output = -1L;

			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				ref content_in,
				tx_Title_in,
				tx_Content_in,
				tx_Subtitle_in,
				tx_Summary_in, 

				//andApprove_in, 

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
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

				#region content_in.TX_Title = ...;
				if (
					(tx_Title_in == null)
					||
					(tx_Title_in.Length == 0)
				) {
					content_in.TX_Title_isNull = true;
				} else {
					content_in.TX_Title = SBO_DIC_Dic.insObject(
						_con,

						_sessionuser.IDApplication,
						OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_TITLE,

						tx_Title_in
					);
				}
				#endregion
				#region content_in.TX_Content = ...;
				if (
					(tx_Content_in == null)
					||
					(tx_Content_in.Length == 0)
				) {
					content_in.TX_Content_isNull = true;
				} else {
					content_in.TX_Content = SBO_DIC_Dic.insObject(
						_con,

						_sessionuser.IDApplication,
						OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_CONTENT,

						tx_Content_in
					);
				}
				#endregion
				#region content_in.TX_Subtitle = ...;
				if (
					(tx_Subtitle_in == null)
					||
					(tx_Subtitle_in.Length == 0)
				) {
					content_in.TX_Subtitle_isNull = true;
				} else {
					content_in.TX_Subtitle = SBO_DIC_Dic.insObject(
						_con,

						_sessionuser.IDApplication,
						OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_SUBTITLE,

						tx_Subtitle_in
					);
				}
				#endregion
				#region content_in.TX_Summary = ...;
				if (
					(tx_Summary_in == null)
					||
					(tx_Summary_in.Length == 0)
				) {
					content_in.TX_Summary_isNull = true;
				} else {
					content_in.TX_Summary = SBO_DIC_Dic.insObject(
						_con,

						_sessionuser.IDApplication,
						OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_SUMMARY,

						tx_Summary_in
					);
				}
				#endregion

				content_in.IFUser__Approved_isNull = true;
				content_in.Approved_date_isNull = true;
				content_in.Begin_date
					= content_in.End_date
					= datetime_minvalue_;

				content_in.IFApplication = _sessionuser.IDApplication;
				content_in.IFUser__Publisher = _sessionuser.IDUser;
				content_in.Publish_date = DateTime.Now;
				content_in.Newslettersent_date_isNull = true;
				content_in.IsNews_notForum = true;

				_output = DO_NWS_Content.insObject(
					content_in,
					true,

					_con
				);
				relate(
					idTags_in,
					idAuthors_in,
					idSources_in,
					idHighlights_in, 
					idProfiles_in, 

					_output,

					_con
				);

				_errorlist.Add(ErrorType.news__successfully_created__WARNING);
				_con.Transaction.Commit();
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
				OGen.NTier.Kick.Libraries.BusinessLayer.SBO_LOG_Log.log(
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
//		#endregion
//		#region public static void updObject(...);
		private static void updObject(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			bool updateContent_in,
			SO_NWS_Content content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in,

			bool updateTags_in, 
			long[] idTags_in,

			bool updateAuthors_in, 
			long[] idAuthors_in,

			bool updateSources_in, 
			long[] idSources_in,

			bool updateHighlights_in, 
			long[] idHighlights_in, 

			bool updateProfiles_in, 
			long[] idProfiles_in, 

			//bool andApprove_in, 

			out int[] errors_out 
			#endregion
		) {
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				ref content_in,
				tx_Title_in,
				tx_Content_in,
				tx_Subtitle_in,
				tx_Summary_in, 

				//andApprove_in, 

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return;
			} 
			#endregion
			#region check Existence . . .
			SO_NWS_Content _content;
			if (
				(content_in.IDContent <= 0)
				||
				(
					(
						_content 
							= DO_NWS_Content.getObject(
								content_in.IDContent
							)
					) == null)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

#if !DEBUG
			if (
				(_content.IFUser__Publisher != content_in.IFUser__Publisher)
				&&
				!_sessionuser.hasPermission(PermissionType.Content__update_????????)
			) {
				_errorlist.Add(ErrorType.content__lack_of_permissions_to_write_?????????????);
				errors_out = _errorlist.ToArray();
				return;
			}
#endif

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


				if (updateContent_in) {
					#region TX_Title . . .
					if ((tx_Title_in != null) && (tx_Title_in.Length != 0)) {
						if (_content.TX_Title_isNull) {
							_content.TX_Title = SBO_DIC_Dic.insObject(
								_con,
								_sessionuser.IDApplication,
								OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_TITLE,
								tx_Title_in
							);
						} else {
							SBO_DIC_Dic.updObject(
								_con,
								_content.TX_Title,
								tx_Title_in
							);
						}
					}
					#endregion
					#region TX_Content . . .
					if ((tx_Content_in != null) && (tx_Content_in.Length != 0)) {
						if (_content.TX_Content_isNull) {
							_content.TX_Content = SBO_DIC_Dic.insObject(
								_con,
								_sessionuser.IDApplication,
								OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_CONTENT,
								tx_Content_in
							);
						} else {
							SBO_DIC_Dic.updObject(
								_con,
								_content.TX_Content,
								tx_Content_in
							);
						}
					}
					#endregion
					#region TX_Subtitle . . .
					if ((tx_Subtitle_in != null) && (tx_Subtitle_in.Length != 0)) {
						if (_content.TX_Subtitle_isNull) {
							_content.TX_Subtitle = SBO_DIC_Dic.insObject(
								_con,
								_sessionuser.IDApplication,
								OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_SUBTITLE,
								tx_Subtitle_in
							);
						} else {
							SBO_DIC_Dic.updObject(
								_con,
								_content.TX_Subtitle,
								tx_Subtitle_in
							);
						}
					}
					#endregion
					#region TX_Summary . . .
					if ((tx_Summary_in != null) && (tx_Summary_in.Length != 0)) {
						if (_content.TX_Summary_isNull) {
							_content.TX_Summary = SBO_DIC_Dic.insObject(
								_con,
								_sessionuser.IDApplication,
								OGen.NTier.Kick.Libraries.BusinessLayer.Shared.TableFieldSource.NWS_CONTENT__TX_SUMMARY,
								tx_Summary_in
							);
						} else {
							SBO_DIC_Dic.updObject(
								_con,
								_content.TX_Summary,
								tx_Summary_in
							);
						}
					}
					#endregion

					// preserve these:
					#region //content_in.IFUser__Approved = _content.IFUser__Approved;
					//if (_content.IFUser__Approved_isNull) {
					//    content_in.IFUser__Approved_isNull = true;
					//} else {
					//    content_in.IFUser__Approved = _content.IFUser__Approved;
					//} 
					#endregion
					#region //content_in.Approved_date = _content.Approved_date;
					//if (_content.Approved_date_isNull) {
					//    content_in.Approved_date_isNull = true;
					//} else {
					//    content_in.Approved_date = _content.Approved_date;
					//} 
					#endregion
					#region //content_in.Begin_date = _content.Begin_date;
					//if (_content.Begin_date_isNull) {
					//    content_in.Begin_date_isNull = true;
					//} else {
					//    content_in.Begin_date = _content.Begin_date;
					//} 
					#endregion
					#region //content_in.End_date = _content.End_date;
					//if (_content.End_date_isNull) {
					//    content_in.End_date_isNull = true;
					//} else {
					//    content_in.End_date = _content.End_date;
					//}
					#endregion

					//content_in.IFApplication = _content.IFApplication;
					//content_in.IFUser__Publisher = _content.IFUser__Publisher;
					//content_in.Publish_date = _content.Publish_date;
					#region //content_in.Newslettersent_date = _content.Newslettersent_date;
					//if (_content.Newslettersent_date_isNull) {
					//    content_in.Newslettersent_date_isNull = true;
					//} else {
					//    content_in.Newslettersent_date = _content.Newslettersent_date;
					//} 
					#endregion
					//content_in.IsNews_notForum = true;

					DO_NWS_Content.updObject(
						_content,
						true,

						_con
					);
				}

				if (updateTags_in) DO_NWS_ContentTag.delRecord_byContent(content_in.IDContent, _con);
				if (updateAuthors_in) DO_NWS_ContentAuthor.delRecord_byContent(content_in.IDContent, _con);
				if (updateSources_in) DO_NWS_ContentSource.delRecord_byContent(content_in.IDContent, _con);
				if (updateHighlights_in) DO_NWS_ContentHighlight.delRecord_byContent(content_in.IDContent, _con);
				if (updateProfiles_in) DO_NWS_ContentProfile.delRecord_byContent(content_in.IDContent, _con);
				relate(
					idTags_in,
					idAuthors_in,
					idSources_in,
					idHighlights_in, 
					idProfiles_in, 

					content_in.IDContent,

					_con
				);

				_errorlist.Add(ErrorType.news__successfully_updated__WARNING);
				_con.Transaction.Commit();
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
				OGen.NTier.Kick.Libraries.BusinessLayer.SBO_LOG_Log.log(
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
//		#endregion
		#region public static void updObject(...);
		[BOMethodAttribute("updObject", true, false, 1)]
		public static void updObject(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Content content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in,

			long[] idTags_in,
			long[] idAuthors_in,
			long[] idSources_in,
			long[] idHighlights_in, 
			long[] idProfiles_in, 

			//bool andApprove_in,

			out int[] errors_out
			#endregion
		) {
			updObject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				true,
				content_in,
				tx_Title_in,
				tx_Content_in,
				tx_Subtitle_in,
				tx_Summary_in,

				true,
				idTags_in,

				true,
				idAuthors_in,

				true,
				idSources_in,

				true, 
				idHighlights_in, 

				true, 
				idProfiles_in, 

				//andApprove_in,

				out errors_out
			);
		} 
		#endregion
		#region public static void updObject_Content(...);
		[BOMethodAttribute("updObject_Content", true, false, 1)]
		public static void updObject_Content(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Content content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in,
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in,

			//bool andApprove_in,

			out int[] errors_out
			#endregion
		) {
			updObject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				true,
				content_in,
				tx_Title_in,
				tx_Content_in,
				tx_Subtitle_in,
				tx_Summary_in,

				false,
				new long[] { },

				false,
				new long[] { },

				false,
				new long[] { },

				false, 
				new long[] { },

				false,
				new long[] { },

				//andApprove_in,

				out errors_out
			);
		} 
		#endregion
		#region public static void updObject_Tags(...);
		[BOMethodAttribute("updObject_Tags", true, false, 1)]
		public static void updObject_Tags(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,
			long[] idTags_in,

			//bool andApprove_in,

			out int[] errors_out
			#endregion
		) {
			updObject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				false,
				new SO_NWS_Content(
					idContent_in, 

					// since this is an update, there's no need to pass IDApplication, 
					// update executes a select prior to updating
					-1, 

					-1L, 
					datetime_minvalue_, 
					-1L, 
					datetime_minvalue_, 
					datetime_minvalue_, 
					datetime_minvalue_, 
					-1L, 
					-1L, 
					-1L, 
					-1L, 
					datetime_minvalue_, 
					true
				), 
				null,
				null,
				null,
				null,

				true,
				idTags_in,

				false,
				new long[] { },

				false,
				new long[] { },

				false,
				new long[] { },

				false,
				new long[] { },

				//andApprove_in,

				out errors_out
			);
		} 
		#endregion
		#region public static void updObject_Authors(...);
		[BOMethodAttribute("updObject_Authors", true, false, 1)]
		public static void updObject_Authors(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,
			long[] idAuthors_in,

			//bool andApprove_in,

			out int[] errors_out
			#endregion
		) {
			updObject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				false,
				new SO_NWS_Content(
					idContent_in,

					// since this is an update, there's no need to pass IDApplication, 
					// update executes a select prior to updating
					-1, 

					-1L,
					datetime_minvalue_,
					-1L,
					datetime_minvalue_,
					datetime_minvalue_,
					datetime_minvalue_,
					-1L,
					-1L,
					-1L,
					-1L,
					datetime_minvalue_,
					true
				),
				null,
				null,
				null,
				null,

				false,
				new long[] { },

				true,
				idAuthors_in,

				false,
				new long[] { },

				false,
				new long[] { },

				false,
				new long[] { },

				//andApprove_in,

				out errors_out
			);
		} 
		#endregion
		#region public static void updObject_Sources(...);
		[BOMethodAttribute("updObject_Sources", true, false, 1)]
		public static void updObject_Sources(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,
			long[] idSources_in,

			//bool andApprove_in,

			out int[] errors_out
			#endregion
		) {
			updObject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				false,
				new SO_NWS_Content(
					idContent_in,

					// since this is an update, there's no need to pass IDApplication, 
					// update executes a select prior to updating
					-1, 

					-1L,
					datetime_minvalue_,
					-1L,
					datetime_minvalue_,
					datetime_minvalue_,
					datetime_minvalue_,
					-1L,
					-1L,
					-1L,
					-1L,
					datetime_minvalue_,
					true
				),
				null,
				null,
				null,
				null,

				false,
				new long[] { },

				false,
				new long[] { },

				true,
				idSources_in,

				false,
				new long[] { },

				false,
				new long[] { },

				//andApprove_in,

				out errors_out
			);
		} 
		#endregion
		#region public static void updObject_Profiles(...);
		[BOMethodAttribute("updObject_Profiles", true, false, 1)]
		public static void updObject_Profiles(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,
			long[] idProfiles_in,

			//bool andApprove_in,

			out int[] errors_out
			#endregion
		) {
			updObject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				false,
				new SO_NWS_Content(
					idContent_in,

					// since this is an update, there's no need to pass IDApplication, 
					// update executes a select prior to updating
					-1, 

					-1L,
					datetime_minvalue_,
					-1L,
					datetime_minvalue_,
					datetime_minvalue_,
					datetime_minvalue_,
					-1L,
					-1L,
					-1L,
					-1L,
					datetime_minvalue_,
					true
				),
				null,
				null,
				null,
				null,

				false,
				new long[] { },

				false,
				new long[] { },

				false,
				new long[] { },

				false,
				new long[] { },

				true,
				idProfiles_in,

				//andApprove_in,

				out errors_out
			);
		} 
		#endregion
		#region public static void updObject_Highlights(...);
		[BOMethodAttribute("updObject_Highlights", true, false, 1)]
		public static void updObject_Highlights(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,
			long[] idHighlights_in,

			//bool andApprove_in,

			out int[] errors_out
			#endregion
		) {
			updObject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				false,
				new SO_NWS_Content(
					idContent_in, 

					// since this is an update, there's no need to pass IDApplication, 
					// update executes a select prior to updating
					-1, 

					-1L, 
					datetime_minvalue_, 
					-1L, 
					datetime_minvalue_, 
					datetime_minvalue_, 
					datetime_minvalue_, 
					-1L, 
					-1L, 
					-1L, 
					-1L, 
					datetime_minvalue_, 
					true
				), 
				null,
				null,
				null,
				null,

				false,
				new long[] { },

				false,
				new long[] { },

				false,
				new long[] { },

				true,
				idHighlights_in,

				false,
				new long[] { },

				//andApprove_in,

				out errors_out
			);
		} 
		#endregion
		//#region public static void updObject_Approve(...);
		//[BOMethodAttribute("updObject_Approve", true)]
		//public static void updObject_Approve(
		//    #region params...
		//    string credentials_in,

		//    long idContent_in,

		//    int idApplication_in,

		//    out int[] errors_out
		//    #endregion
		//) {
		//    if (
		//        content_ref.Begin_date_isNull
		//        ||
		//        content_ref.End_date_isNull
		//        ||
		//        (content_ref.Begin_date < content_ref.End_date)
		//    ) {
		//        errors_out.Add(ErrorType.news__invalid_date);
		//        return false;
		//    } else if (credentials_out.hasPermission(PermissionType.News__approve)) {
		//        errors_out.Add(ErrorType.news__lack_of_permissions_to_approve);
		//        return false;
		//    } else {
		//        content_ref.IFUser__Approved = credentials_out.IDUser;
		//        content_ref.Approved_date = DateTime.Now;
		//        //content_in.Begin_date
		//        //content_in.End_date
		//    }
		//}
		//#endregion

		#region public static void delObject(...);
		[BOMethodAttribute("delObject", true, false, 1)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_in,

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
			bool _content__delete_Approved = _sessionuser.hasPermission(PermissionType.News__delete_Approved);
			bool _content__delete_Mine_notApproved = _sessionuser.hasPermission(PermissionType.News__delete_Mine_notApproved);
			if (
				!(
					_content__delete_Approved
					||
					_content__delete_Mine_notApproved
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permissions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check Existence . . .
			SO_NWS_Content _content;
			if (
				(idContent_in <= 0)
				||
				(
					(_content = DO_NWS_Content.getObject(idContent_in))
					==
					null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check Permissions . . . (more)
			if (
				// been approved
				!_content.IFUser__Approved_isNull
				&&
				// no permission to delete approved
				!_content__delete_Approved
			) {
				_errorlist.Add(ErrorType.news__lack_of_permissions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check References . . .
			long _count;
			SO_NWS_Attachment[] _attachments = DO_NWS_Attachment.getRecord_byContent(
				idContent_in,
				-1, 0, 0, out _count
			);
			if (
				(DO_NWS_ContentHighlight.getCount_inRecord_byContent(idContent_in) > 0)
				//	||
				//	...
			) {
				_errorlist.Add(ErrorType.data__can_not_delete__pending_references);
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


				#region DO_NWS_Attachment.delRecord_byContent(...);
				DO_NWS_Attachment.delRecord_byContent(
					idContent_in,

					_con
				);
				foreach (SO_NWS_Attachment _attachment in _attachments) {
					#region SBO_DIC_Dic.delObject(_con, _photo.TX_Name);
					if (
						(_attachment.TX_Name > 0)
						&&
						(!_attachment.TX_Name_isNull)
					) {
						SBO_DIC_Dic.delObject(
							_con,
							_attachment.TX_Name
						);
					}
					#endregion
					#region SBO_DIC_Dic.delObject(_con, _photo.TX_Description);
					if (
						(_attachment.TX_Description > 0)
						&&
						(!_attachment.TX_Description_isNull)
					) {
						SBO_DIC_Dic.delObject(
							_con,
							_attachment.TX_Description
						);
					}
					#endregion
				}
				#endregion
				// ToDos: here! should delete from file system

				DO_NWS_ContentTag.delRecord_byContent(
					idContent_in, 
					_con
				);
				DO_NWS_ContentAuthor.delRecord_byContent(
					idContent_in,
					_con
				);
				DO_NWS_ContentSource.delRecord_byContent(
					idContent_in,
					_con
				);
				DO_NWS_ContentProfile.delRecord_byContent(
					idContent_in, 
					_con
				);

				DO_NWS_Content.delObject(
					idContent_in,

					_con
				);

				#region SBO_DIC_Dic.delObject(_con, _content.TX_Title);
				if (
					(_content.TX_Title > 0)
					&&
					(!_content.TX_Title_isNull)
				) {
					SBO_DIC_Dic.delObject(
						_con,
						_content.TX_Title
					);
				}
				#endregion
				#region SBO_DIC_Dic.delObject(_con, _content.TX_Content);
				if (
					(_content.TX_Content > 0)
					&&
					(!_content.TX_Content_isNull)
				) {
					SBO_DIC_Dic.delObject(
						_con,
						_content.TX_Content
					);
				}
				#endregion
				#region SBO_DIC_Dic.delObject(_con, _content.TX_Subtitle);
				if (
					(_content.TX_Subtitle > 0)
					&&
					(!_content.TX_Subtitle_isNull)
				) {
					SBO_DIC_Dic.delObject(
						_con,
						_content.TX_Subtitle
					);
				}
				#endregion
				#region SBO_DIC_Dic.delObject(_con, _content.TX_Summary);
				if (
					(_content.TX_Summary > 0)
					&&
					(!_content.TX_Summary_isNull)
				) {
					SBO_DIC_Dic.delObject(
						_con,
						_content.TX_Summary
					);
				}
				#endregion

				_errorlist.Add(ErrorType.news__successfully_deleted__WARNING);
				_con.Transaction.Commit();
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
				OGen.NTier.Kick.Libraries.BusinessLayer.SBO_LOG_Log.log(
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


		#region public static SO_vNWS_Content[] getRecord_generic(...);
		[BOMethodAttribute("getRecord_generic", true, false, 1)]
		public static SO_vNWS_Content[] getRecord_generic(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long IDUser__Publisher_search_in,

			long IDUser__Approved_search_in,

			DateTime Begin_date_search_in,
			DateTime End_date_search_in,

			long[] idTags_search_in,
			long[] idAuthors_search_in,
			long[] idSources_search_in,
			long[] idHighlights_search_in,
			long[] idProfiles_search_in,

			string text__small_search_in,
			int IDLanguage_search_in,
			bool isAND_notOR_search_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
			SO_vNWS_Content[] _output = null;
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
				= DO_vNWS_Content.getRecord_generic(
					_sessionuser.IDApplication, 
					IDUser__Publisher_search_in,
					IDUser__Approved_search_in, 
					(Begin_date_search_in <= datetime_minvalue_) ? null : (object)Begin_date_search_in,
					(End_date_search_in <= datetime_minvalue_) ? null : (object)End_date_search_in,
					(idTags_search_in == null) ? "" : OGen.Libraries.utils.Array_Join<long>(",", idTags_search_in),
					(idAuthors_search_in == null) ? "" : OGen.Libraries.utils.Array_Join<long>(",", idAuthors_search_in),
					(idSources_search_in == null) ? "" : OGen.Libraries.utils.Array_Join<long>(",", idSources_search_in),
					(idHighlights_search_in == null) ? "" : OGen.Libraries.utils.Array_Join<long>(",", idHighlights_search_in),
					(idProfiles_search_in == null) ? "" : OGen.Libraries.utils.Array_Join<long>(",", idProfiles_search_in),
					text__small_search_in, 
					IDLanguage_search_in, 
					isAND_notOR_search_in,

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
	}
}