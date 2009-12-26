<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataExtended" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataBusiness" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table;
	//= _aux_db_metadata.Tables.TableCollection[
	//    _arg_TableName
	//];
OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table;
	//= _aux_db_table.parallel_ref;

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

string _aux_xx_field_name;

OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update;

string[] _aux_configmodes = _aux_ex_metadata.DBs.ConfigModes();
string[] _aux_supportedDBServerTypes = _aux_ex_metadata.DBs.SupportedDBServerTypes();

#endregion
//-----------------------------------------------------------------------------------------
if (_aux_ex_metadata.CopyrightText != string.Empty) {
	if (_aux_ex_metadata.CopyrightTextLong == string.Empty) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
#endregion
<%
	} else {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
	}
}%>using System;

using OGen.lib.datalayer;<%
for (int d = 0; d < _aux_ex_metadata.DBs.DBCollection.Count; d++) {
    string _dbservertype = _aux_ex_metadata.DBs.DBCollection[d].DBServerType.ToString();%>
#if <%=_dbservertype%>
using OGen.lib.datalayer.<%=_dbservertype%>;
#endif
<%
}%>
using OGen.NTier.lib.datalayer;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer {
	/// <summary>
	/// utils DataObject which works as a repository of useful Properties and Methods for DataObjects at <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer namespace.
	/// </summary>
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial class DO__utils 
#else
		abstract class DO0__utils 
#endif
	{
		static 
#if USE_PARTIAL_CLASSES && !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
		(
		) {
			dbservertype__ = string.Empty;
			dbconnectionstring__ = null;
			dblogfile__ = string.Empty;
		}

		/// <summary>
		/// Application's Name
		/// </summary>
		public const string ApplicationName = "<%=_aux_ex_metadata.ApplicationName%>";

		#region public static Properties...
		#region public static string DBServerType { get; }
		private static string dbservertype__;
		/// <summary>
		/// DB Server Type.
		/// </summary>
		public static string DBServerType {
			get {
				if (dbservertype__ == string.Empty) {
					DBServerType_read(false);
				}
				return dbservertype__;
			}
		}
		#endregion
		#region public static string DBConnectionstring { get; }
		private static string dbconnectionstring__;
		/// <summary>
		/// Connection String.
		/// </summary>
		public static string DBConnectionstring {
			get {
				if (dbconnectionstring__ == null) {
					DBConnectionstring_read(false);
				}
				return dbconnectionstring__;
			}
		}
		#endregion
		#region public static string DBLogfile { get; }
		private static string dblogfile__;

		/// <summary>
		/// DataBase Operation's Log File
		/// </summary>
		public static string DBLogfile {
			get {
				if (dblogfile__ == string.Empty) {
					if (
						#if !NET_1_1
						System.Configuration.ConfigurationManager.AppSettings
						#else
						System.Configuration.ConfigurationSettings.AppSettings
						#endif
							["DBLogfile"] == null
					) {
						dblogfile__ = null;
					} else {
						dblogfile__ = System.Configuration.ConfigurationSettings.AppSettings["DBLogfile"];
					}
					
				}
				return dblogfile__;
			}
		}
		#endregion
		#endregion

		#region public static Methods...
		public static DBConnection DBConnection_createInstance(
			string dbServerType_in, 
			string connectionstring_in, 
			string logfile_in
		) {
			switch (dbServerType_in) {<%

			//for (int d = 0; d < _aux_ex_metadata.DBs.DBCollection.Count; d++) {
			//	string _dbservertype = _aux_ex_metadata.DBs.DBCollection[d].DBServerType.ToString();

			for (int i = 0; i < _aux_supportedDBServerTypes.Length; i++) {%>
#if <%=_aux_supportedDBServerTypes[i]%>
				case "<%=_aux_supportedDBServerTypes[i]%>":
					return new DBConnection_<%=_aux_supportedDBServerTypes[i]%>(
						connectionstring_in, 
						logfile_in
					);
#endif<%
			}%>
			}

			throw new Exception(
				"unsuported db server type"
			);
		}
		#region public static void DBConnectionstring_reset();
		/// <summary>
		/// Forces DataBase's ConnectionString to be re-read from config file.
		/// </summary>
		public static void DBConnectionstring_reset() {
			Config_DBConnectionstrings.Reset();
		}
		#endregion
		#region private static void DBConnectionstring_read(bool andReset_in);
		private static void DBConnectionstring_read(bool andReset_in) {
			DBServerType_read(andReset_in);
		}
		#endregion
		#region public static void DBServerType_reset();
		/// <summary>
		/// Forces DataBase's Server Type to be re-read from config file.
		/// </summary>
		public static void DBServerType_reset() {
			Config_DBConnectionstrings.Reset();
		}
		#endregion
		#region private static void DBServerType_read(bool andReset_in);
		private static void DBServerType_read(bool andReset_in) {
			if (andReset_in) {
				DBServerType_reset();
			}
			dbservertype__ = string.Empty;
			dbconnectionstring__ = null;

			string[] _dbservertypes = Config_DBConnectionstrings.DBServerTypes(ApplicationName);
			Config_DBConnectionstrings _dbconnectionstrings = Config_DBConnectionstrings.DBConnectionstrings(ApplicationName);
			Config_DBConnectionstring _con;
			for (int _db = 0; _db < _dbservertypes.Length; _db++) {
				_con = _dbconnectionstrings[
					_dbservertypes[_db],<%
					for (int cm = 0; cm < _aux_configmodes.Length; cm++) {%>
#<%=(cm == 0) ? "" : "el"%>if <%=_aux_configmodes[cm]%>
					"<%=_aux_configmodes[cm]%>"<%
					}%>
#endif
				];
				if (_con.isDefault) {
					dbservertype__ = _dbservertypes[_db];
					dbconnectionstring__ = _con.Connectionstring;
					return;
				}
			}
		}
		#endregion
		#endregion<%

		if (true) { // new scope!
			string NameField;
			string ConfigField;
			string DatatypeField;
			System.Data.DataTable ConfigTable;
			for (int t = 0; t < _aux_ex_metadata.Tables.TableCollection.Count; t++) {
				_aux_ex_table = _aux_ex_metadata.Tables.TableCollection[t];
				_aux_db_table = _aux_ex_table.parallel_ref;
				if (_aux_ex_table.isConfig) {%>
		#region public static Methods - DB.<%=_aux_db_table.Name%>...<%
					NameField = "";
					ConfigField = "";
					DatatypeField = "";
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;
						if (_aux_ex_field.isConfig_Name) {
							NameField = _aux_db_field.Name;
							continue;
						}
						if (_aux_ex_field.isConfig_Config) {
							ConfigField = _aux_db_field.Name;
							continue;
						}
						if (_aux_ex_field.isConfig_Datatype) {
							DatatypeField = _aux_db_field.Name;
							continue;
						}
					}
					DBConnection connection = DBConnectionsupport.CreateInstance(
						// ToDos: here! .net fw 2.0 specific
						(DBServerTypes)Enum.Parse(typeof(DBServerTypes), _aux_ex_metadata.DBs.DB_FirstDefaultAvailable.DBServerType), 
						_aux_ex_metadata.DBs.DBConnection_FirstDefaultAvailable.Connectionstring
					);
					ConfigTable = connection.Execute_SQLQuery_returnDataTable(
						string.Format(
							"SELECT {4}{0}{4}, {4}{1}{4}, {4}{2}{4} FROM {4}{3}{4} ORDER BY {4}{0}{4}",
							/*00*/ NameField,
							/*01*/ ConfigField,
							/*02*/ DatatypeField,
							/*03*/ _aux_ex_table.Name, 
#if MySQL
							/*04*/ (_aux_ex_metadata.DBs.DBCollection.FirstDefaultAvailable_DBServerType() == DBServerTypes.MySQL) ? "`" :"\""
#else
							/*04*/ "\""
#endif
						)
					);
					for (int r = 0; r < ConfigTable.Rows.Count; r++) {
						switch ((int)ConfigTable.Rows[r][DatatypeField]) {
							case 1:
								%>
		#region public static bool <%=ConfigTable.Rows[r][NameField]%> { get; }
		private static bool <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = false;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = false; }
		private static bool <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_ = true;
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static bool <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (!<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_ = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_ = bool.Parse(<%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%>);
					<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;
					#endregion
					// ToDos: here! if second assembly instance, one cache could override data from the other
					//<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = true;
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%> = value.ToString();
				<%=_aux_db_table.Name.ToLower()%>.setObject(false);
				<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_ = value;
				<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = true;
				#endregion
			}
		}
		#endregion<%
								break;
							case 4:
								%>
		#region public static int <%=ConfigTable.Rows[r][NameField]%> { get; }
		private static int <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>;
		private static bool <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = false;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = false; }
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static int <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (!<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = int.Parse(<%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%>);
					<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;
					#endregion
					// ToDos: here! if second assembly instance, one cache could override data from the other
					//<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = true;
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%> = value.ToString();
				<%=_aux_db_table.Name.ToLower()%>.setObject(false);
				<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = value;
				<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = true;
				#endregion
			}
		}
		#endregion<%
								break;
							case 2:
								%>
		#region public static string <%=ConfigTable.Rows[r][NameField]%> { get; }
		private static string <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = null;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = null; }
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static string <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (
					// ToDos: here! if second assembly instance, one cache could override data from the other
					true
					||
					(<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> == null)
				) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = <%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%>;
					<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;
					#endregion
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%> = value;
				<%=_aux_db_table.Name.ToLower()%>.setObject(false);
				<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = value;
				#endregion
			}
		}
		#endregion<%
								break;
							case 3:
								%>
		#region public static string[] <%=ConfigTable.Rows[r][NameField]%> { get; }
		private static string[] <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = null;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = null; }
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static string[] <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (
					// ToDos: here! if second assembly instance, one cache could override data from the other
					true
					||
					(<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> == null)
				) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = <%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%>.Split((char)10);
					<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;
					#endregion
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");


				<%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%> = string.Empty;
				for (int i = 0; i < value.Length; i++) {
					<%=_aux_db_table.Name.ToLower()%>.Fields.<%=ConfigField%> += string.Format(
						"{0}{1}",
						(i != 0) ? ((char)10).ToString() : string.Empty, 
						value[i]
					);
				}


				<%=_aux_db_table.Name.ToLower()%>.setObject(false);
				<%=_aux_db_table.Name.ToLower()%>.Dispose(); <%=_aux_db_table.Name.ToLower()%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = value;
				#endregion
			}
		}
		#endregion<%
								break;
						}
					}
					connection.Dispose(); connection = null;%>
		#endregion<%
				}
			}
		}%>
	}
}