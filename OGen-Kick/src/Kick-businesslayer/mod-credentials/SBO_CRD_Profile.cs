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
using System.Configuration;
using System.Collections.Generic;
using System.Text;

using OGen.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.lib.crypt;

using OGen.NTier.Kick.lib.datalayer;
using OGen.NTier.Kick.lib.datalayer.shared;
using OGen.NTier.Kick.lib.datalayer.shared.structures;

using OGen.NTier.Kick.lib.businesslayer.shared;
//using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer {
	[BOClassAttribute("BO_CRD_Profile", "")]
	public static class SBO_CRD_Profile {
		#region public static SO_CRD_Profile getObject(...);
		[BOMethodAttribute("getObject", true, false, 1)]
		public static SO_CRD_Profile getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idProfile_in,

			out int[] errors_out
		) {
			SO_CRD_Profile _output = null;
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
			#region check Permitions . . .
			if (
				!_sessionuser.hasPermition(
					PermitionType.Profile__select
				)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_CRD_Profile.getObject(
				idProfile_in,

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

			SO_CRD_Profile profile_in,

			out Sessionuser sessionUser_out, 
			out List<int> errorlist_out
		) {
			Guid _sessionguid;

			#region check...
			int[] _errors_out;

			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out sessionUser_out,
				out errorlist_out,
				out _errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return false;
			}
			#endregion
			#region check Permitions...
			if (
				!sessionUser_out.hasPermition(
					false, 
					PermitionType.Profile__insert,
					PermitionType.Profile__update
				)
			) {
				errorlist_out.Add(ErrorType.profile__lack_of_permitions_to_write);
				return false;
			}
			#endregion
			if (profile_in != null) {
				#region check Profile...
				if (
					(profile_in.Name = profile_in.Name.Trim())
					==
					""
				) {
					errorlist_out.Add(ErrorType.profile__invalid_name);
					return false;
				}
				#endregion
			}

			return true;
		} 
		#endregion
		#region public static long insObject(...);
		[BOMethodAttribute("insObject", true, false, 1)]
		public static long insObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_CRD_Profile profile_in, 

			long[] idProfile_parent_in, 
//			long[] idUser_in, 
			long[] idPermition_in, 

			out int[] errors_out
		) {
			long _output = -1;
			List<int> _errorlist;
			Sessionuser _sessionuser;

			#region check...
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				profile_in,

				out _sessionuser, 
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
			} 
			#endregion
			if (profile_in == null) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			if (profile_in.IFApplication != _sessionuser.IDApplication) {
				_errorlist.Add(ErrorType.lack_of_permitions);
				errors_out = _errorlist.ToArray();
				return _output;
			}


			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				if (
					(
						(idProfile_parent_in != null)
						&&
						(idProfile_parent_in.Length > 0)
					)
					||
//					(
//						(idUser_in != null)
//						&&
//						(idUser_in.Length > 0)
//					)
//					||
					(
						(idPermition_in != null)
						&&
						(idPermition_in.Length > 0)
					)
				) {
					_con.Open();
					_con.Transaction.Begin();
				}


				_output = DO_CRD_Profile.insObject(
					profile_in,

					// if connection is open that means I'm doing operations on other tables 
					// and I will need the identity seed
					_con.isOpen, 

					_con
				);
				if (idProfile_parent_in != null) {
					for (int i = 0; i < idProfile_parent_in.Length; i++) {
						DO_CRD_ProfileProfile.setObject(
							new SO_CRD_ProfileProfile(
								_output,
								idProfile_parent_in[i]
							),
							true,
							_con
						);
					}
				}
//				if (idUser_in != null) {
//				for (int i = 0; i < idUser_in.Length; i++) {
//                    DO_CRD_UserProfile.setObject(
//                        new SO_CRD_UserProfile(
//                            _output,
//                            idUser_in[i]
//                        ),
//                        true,
//                        _con
//                    );
//                }
//                }
				if (idPermition_in != null) {
					for (int i = 0; i < idPermition_in.Length; i++) {
						DO_CRD_ProfilePermition.setObject(
							new SO_CRD_ProfilePermition(
								_output,
								idPermition_in[i]
							),
							true,
							_con
						);
					}
				}


				#region _con.Transaction.Commit();
				if (_con.Transaction.inTransaction) {
					_con.Transaction.Commit();
				}
				#endregion
				_errorlist.Add(ErrorType.profile__successfully_created__WARNING);
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
				#region SBO_LOG_Log.log(ErrorType.data);
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
		#region private static void updobject(...);
		private static void updobject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_CRD_Profile profile_in,
			bool updateObject_in, 

			long[] idProfile_parent_in,
//			long[] idUser_in,
			long[] idPermition_in,
			
			out int[] errors_out
		) {
			List<int> _errorlist;
			Sessionuser _sessionuser;


			// if (idProfile_parent_in == null) nothing is done on CRD_ProfileProfile
			// if (idProfile_parent_in != null) {
			//		if (idProfile_parent_in.length == 0) all relations are deleted
			//		if (idProfile_parent_in.length != 0) {
			//			all relations are deleted
			//			and new ones are set
			//		}
			// }
			// SAME WITH idUser_in and idPermition_in


			#region check...
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in,

				updateObject_in ? profile_in : null,
				out _sessionuser, 

				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence...
			SO_CRD_Profile _profile = DO_CRD_Profile.getObject(profile_in.IDProfile);
			if (_profile == null) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			//profile_in.IFApplication = _profile.IFApplication;
			if (
				(profile_in.IFApplication != _profile.IFApplication)
				||
				(_profile.IFApplication != _sessionuser.IDApplication)
			) {
				_errorlist.Add(ErrorType.lack_of_permitions);
				errors_out = _errorlist.ToArray();
				return;
			}


			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				if (
					(idProfile_parent_in != null)
					||
//					(idUser_in != null)
//					||
					(idPermition_in != null)
				) {
					_con.Open();
					_con.Transaction.Begin();
				}


				DO_CRD_Profile.updObject(
					profile_in,
					true,

					_con
				);

				if (idProfile_parent_in != null) {
					DO_CRD_ProfileProfile.delRecord_byProfile(
						profile_in.IDProfile,
						_con
					);

					for (int i = 0; i < idProfile_parent_in.Length; i++) {
						DO_CRD_ProfileProfile.setObject(
							new SO_CRD_ProfileProfile(
								profile_in.IDProfile,
								idProfile_parent_in[i]
							),
							true,
							_con
						);
					}
				}
//				if (idUser_in != null) {
//                    DO_CRD_UserProfile.delRecord_byProfile(
//                        profile_in.IDProfile,
//                        _con
//                    );

//                    for (int i = 0; i < idUser_in.Length; i++) {
//                        DO_CRD_UserProfile.setObject(
//                            new SO_CRD_UserProfile(
//                                idUser_in[i], 
//                                profile_in.IDProfile
//                            ),
//                            true,
//                            _con
//                        );
//                    }
//                }
				if (idPermition_in != null) {
					DO_CRD_ProfilePermition.delRecord_byProfile(
						profile_in.IDProfile,
						_con
					);

					for (int i = 0; i < idPermition_in.Length; i++) {
						DO_CRD_ProfilePermition.setObject(
							new SO_CRD_ProfilePermition(
								profile_in.IDProfile,
								idPermition_in[i]
							),
							true,
							_con
						);
					}
				}


				#region _con.Transaction.Commit();
				if (_con.Transaction.inTransaction) {
					_con.Transaction.Commit();
				}
				#endregion
				_errorlist.Add(ErrorType.profile__successfully_updated__WARNING);
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
				#region SBO_LOG_Log.log(ErrorType.data);
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

		[BOMethodAttribute("updObject", true, false, 1)]
		public static void updObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_CRD_Profile profile_in,

			long[] idProfile_parent_in,
//			long[] idUser_in,
			long[] idPermition_in,
			
			out int[] errors_out
		) {
			updobject(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				profile_in,
				true, 

				idProfile_parent_in,
//				idUser_in,
				idPermition_in,
			
				out errors_out
			);
		}
		#endregion
		#region public static void updObject_relationsOnly(...);
		[BOMethodAttribute("updObject_relationsOnly", true, false, 1)]
		public static void updObject_relationsOnly(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			long idProfile_in,

			long[] idProfile_parent_in,
//			long[] idUser_in,
			long[] idPermition_in,

			out int[] errors_out
		) {
			updobject(
				sessionGuid_in,
				ip_forLogPurposes_in,

				new SO_CRD_Profile(
					idProfile_in, 
					"", 
					-1
				),
				false,

				idProfile_parent_in,
//				idUser_in,
				idPermition_in,

				out errors_out
			);
		}
		#endregion

		#region public static void delObject(...);
		[BOMethodAttribute("delObject", true, false, 1)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idProfile_in,

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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(
					PermitionType.Profile__delete
				)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_delete);
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

#if MOD_WEB
				DO_NET_Defaultprofile.delObject_byProfile(
					idProfile_in,

					_con
				);
#endif
#if MOD_NEWS
				DO_NWS_Profile.delObject(
					idProfile_in,

					_con
				);
#endif
				DO_CRD_ProfileProfile.delRecord_byProfile(
					idProfile_in,

					_con
				);
				DO_CRD_ProfilePermition.delRecord_byProfile(
					idProfile_in,

					_con
				);
				DO_CRD_UserProfile.delRecord_byProfile(
					idProfile_in,

					_con
				);
				DO_CRD_Profile.delObject(
					idProfile_in,

					_con
				);

				_errorlist.Add(ErrorType.profile__successfully_deleted__WARNING);
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

		#region public static SO_CRD_Profile[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true, false, 1)]
		public static SO_CRD_Profile[] getRecord_all(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			bool allProfiles_notJustApplication_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_CRD_Profile[] _output = null;
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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__select)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_CRD_Profile.getRecord_all(
					(allProfiles_notJustApplication_in)
						? null
						: (object)_sessionuser.IDApplication, 
					page_in,
					page_numRecords_in, 
					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_CRD_ProfileProfile[] getRecord_byProfile(...);
		[BOMethodAttribute("getRecord_byProfile", true, false, 1)]
		public static SO_CRD_ProfileProfile[] getRecord_byProfile(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			long idProfile_in, 

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_CRD_ProfileProfile[] _output = null;
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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__select)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_CRD_ProfileProfile.getRecord_byProfile(
					idProfile_in, 
					page_in,
					page_numRecords_in,
					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region public static void setUserProfiles(...);
		[BOMethodAttribute("setUserProfiles", true, false, 1)]
		public static void setUserProfiles(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idUser_in,
			long[] idProfiles_in,

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
			#region check permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.User__insert)
				&&
				!_sessionuser.hasPermition(PermitionType.User__update)
			) {
				_errorlist.Add(ErrorType.lack_of_permitions);
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

				DO_CRD_UserProfile.delRecord_byUser(
					idUser_in,

					_con
				);
				foreach (long _idprofile in idProfiles_in) {
					DO_CRD_UserProfile.setObject(
						new SO_CRD_UserProfile(
							idUser_in,
							_idprofile
						),
						true,

						_con
					);
				}

				_errorlist.Add(ErrorType.user_profile__successfully_set__WARNING);
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
				#region SBO_LOG_Log.log(ErrorType.data);
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

		#region public static SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(...);
		[BOMethodAttribute("getRecord_ofUserProfile_byUser", true, false, 1)]
		public static SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long IDUser_search_in,
			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_vCRD_UserProfile[] _output = null;
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
			#region check Permitions...
			if (
				(IDUser_search_in != _sessionuser.IDUser)
				&&
				!_sessionuser.hasPermition(PermitionType.User__select)
			) {
				_errorlist.Add(ErrorType.user__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_vCRD_UserProfile.getRecord_byUser(
					IDUser_search_in,
					page_in,
					page_numRecords_in
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vCRD_ProfilePermition[] getRecord_ofProfilePermition_byProfile(...);
		[BOMethodAttribute("getRecord_ofProfilePermition_byProfile", true, false, 1)]
		public static SO_vCRD_ProfilePermition[] getRecord_ofProfilePermition_byProfile(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long IDProfile_search_in,
			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_vCRD_ProfilePermition[] _output = null;
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
			#region check Admin . . .
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__select)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_vCRD_ProfilePermition.getRecord_byProfile(
					IDProfile_search_in,
					page_in,
					page_numRecords_in
				);

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
	}
}