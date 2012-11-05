<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.Libraries.DataLayer" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataExtended" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataDB" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataBusiness" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableType _aux_db_table;
	//= _aux_db_metadata.Tables.TableCollection[
	//    _arg_TableName
	//];
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableType _aux_ex_table;
	//= _aux_db_table.parallel_ref;

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableFieldType _aux_ex_field;

string _aux_xx_field_name;

OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableUpdateType _aux_ex_update;

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
}%>
namespace <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.DataLayer {
	using System;

	using OGen.Libraries.DataLayer;<%
	for (int d = 0; d < _aux_ex_metadata.DBs.DBCollection.Count; d++) {
		string _dbservertype = _aux_ex_metadata.DBs.DBCollection[d].DBServerType.ToString();%>
	#if <%=_dbservertype%>
	using OGen.Libraries.DataLayer.<%=_dbservertype%>;
	#endif
	<%
	}%>
	using OGen.NTier.Libraries.DataLayer;

	/// <summary>
	/// Utilities DataObject which works as a repository of useful Properties and Methods for DataObjects at <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.DataLayer namespace.
	/// </summary>
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial class DO__Utilities 
#else
		abstract class DO0__Utilities 
#endif
	{

		/// <summary>
		/// Application's Name
		/// </summary>
		public const string ApplicationName = "<%=_aux_ex_metadata.ApplicationName%>";

		#region public static Properties...
		#region public static string DBServerType { get; }
		private static string dbservertype__ = string.Empty;

		/// <summary>
		/// DB Server Type.
		/// </summary>
		public static string DBServerType {
			get {
				if (string.IsNullOrEmpty(dbservertype__)) {
					DBServerType_read(false);
				}
				return dbservertype__;
			}
		}
		#endregion
		#region public static string DBConnectionstring { get; }
		private static string dbconnectionstring__ = null;

		/// <summary>
		/// Connection String.
		/// </summary>
		public static string DBConnectionstring {
			get {
				if (string.IsNullOrEmpty(dbconnectionstring__)) {
					DBConnectionstring_read(false);
				}
				return dbconnectionstring__;
			}
		}
		#endregion
		#region public static string DBLogfile { get; }
		private static string dblogfile__ = string.Empty;

		/// <summary>
		/// Database Operation's Log File
		/// </summary>
		public static string DBLogfile {
			get {
				if (string.IsNullOrEmpty(dblogfile__)) {
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
						dblogfile__ = 
#if !NET_1_1
							System.Configuration.ConfigurationManager.AppSettings
#else
							System.Configuration.ConfigurationSettings.AppSettings
#endif
								["DBLogfile"];
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
		/// Forces Database's ConnectionString to be re-read from config file.
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
		/// Forces Database's Server Type to be re-read from config file.
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

			// first db server type is the Default db server type!
			Config_DBConnectionstring _con = _dbconnectionstrings[
				_dbservertypes[0]
			];
			dbservertype__ = _dbservertypes[0];
			dbconnectionstring__ = _con.Connectionstring;
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
						(DBServerTypes)Enum.Parse(typeof(DBServerTypes), _aux_ex_metadata.DBs.DBCollection[0].DBServerType), 
						_aux_ex_metadata.DBs.DBCollection[0].ConnectionString
					);
					ConfigTable = connection.Execute_SQLQuery_returnDataTable(
						string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
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
		private static bool <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = false;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = false; }
		private static bool <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = true;
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static bool <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (!<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = bool.Parse(<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%>);
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;
					#endregion
					// ToDos: here! if second assembly instance, one cache could override data from the other
					//<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = true;
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%> = value.ToString();
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.setObject(false);
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = value;
				<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = true;
				#endregion
			}
		}
		#endregion<%
								break;
							case 4:
								%>
		#region public static int <%=ConfigTable.Rows[r][NameField]%> { get; }
		private static int <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>;
		private static bool <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = false;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = false; }
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static int <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (!<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = int.Parse(<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%>, System.Globalization.CultureInfo.CurrentCulture);
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;
					#endregion
					// ToDos: here! if second assembly instance, one cache could override data from the other
					//<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = true;
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%> = value.ToString();
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.setObject(false);
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = value;
				<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_beenRead = true;
				#endregion
			}
		}
		#endregion<%
								break;
							case 2:
								%>
		#region public static string <%=ConfigTable.Rows[r][NameField]%> { get; }
		private static string <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null; }
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static string <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (
					// ToDos: here! if second assembly instance, one cache could override data from the other
					true
					||
					(<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> == null)
				) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%>;
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;
					#endregion
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%> = value;
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.setObject(false);
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = value;
				#endregion
			}
		}
		#endregion<%
								break;
							case 3:
								%>
		#region public static string[] <%=ConfigTable.Rows[r][NameField]%> { get; }
		private static string[] <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;
		/// <summary>
		/// Forces <%=ConfigTable.Rows[r][NameField]%> config to be re-read from Database.
		/// </summary>
		public static void <%=ConfigTable.Rows[r][NameField]%>_reset() { <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null; }
		/// <summary>
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_db_table.Name%> at Database.
		/// </summary>
		public static string[] <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (
					// ToDos: here! if second assembly instance, one cache could override data from the other
					true
					||
					(<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> == null)
				) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = DO_<%=_aux_db_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%>.Split((char)10);
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;
					#endregion
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = DO_<%=_aux_db_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DO_<%=_aux_db_table.Name%>();
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");


				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%> = string.Empty;
				for (int i = 0; i < value.Length; i++) {
					<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Fields.<%=ConfigField%> += string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"{0}{1}",
						(i != 0) ? ((char)10).ToString() : string.Empty, 
						value[i]
					);
				}


				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.setObject(false);
				<%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>.Dispose(); <%=_aux_db_table.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = null;

				<%=((string)ConfigTable.Rows[r][NameField]).ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = value;
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