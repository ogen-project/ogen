<%--

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

--%><%@ Page language="c#" contenttype="text/html" %>
<%//@ assembly name="OGen.lib.datalayer, Version=0.1.2033.30004, Culture=neutral,PublicKeyToken=66a788813bfe4b51" %>
<%//@ assembly name="OGen.NTier.lib.metadata, Version=0.1.2033.30005, Culture=neutral,PublicKeyToken=66a788813bfe4b51" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
#endregion

#region varaux...
cDBMetadata _aux_metadata;
if (cDBMetadata.Metacache.Contains(_arg_MetadataFilepath)) {
	_aux_metadata = (cDBMetadata)cDBMetadata.Metacache[_arg_MetadataFilepath];
} else {
	_aux_metadata = new cDBMetadata();
	_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);
	cDBMetadata.Metacache.Add(_arg_MetadataFilepath, _aux_metadata);
}

cDBMetadata_Table _aux_table;
cDBMetadata_Table_Field _aux_field;
int _aux_table_hasidentitykey;
string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_metadata.CopyrightText != string.Empty) && (_aux_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_metadata.CopyrightText%>
/*

<%=_aux_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Data;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

namespace <%=_aux_metadata.Namespace%>.lib.datalayer {
	/// <summary>
	/// utils DataObject which works as a repository of useful Properties and Methods for DataObjects at <%=_aux_metadata.Namespace%>.lib.datalayer namespace.<%--
#if !NET20
	/// <note type="implementnotes">
	/// Access must be made via <see cref="DO__utils">DO__utils</see>.
	/// </note>
#endif--%>
	/// </summary>
	public 
#if NET20
		partial class DO__utils 
#else
		abstract class DO0__utils 
#endif
	{
		#region public DO__utils(...);
#if NET20
		///
		public DO__utils
#else
		internal DO0__utils
#endif
		() {
		}
		#endregion
		#region static DO__utils();
		static 
#if NET20
			DO__utils
#else
			DO0__utils
#endif
		() {
			dbservertype__ = eDBServerTypes.invalid;
			dbconnectionstring__ = null;
			dblogfile__ = string.Empty;
		}
		#endregion

		/// <summary>
		/// Application's Name
		/// </summary>
		public const string ApplicationName = "<%=_aux_metadata.ApplicationName%>";

		#region public static Properties...
		#region public static eDBServerTypes DBServerType { get; }
		private static eDBServerTypes dbservertype__;
		/// <summary>
		/// DB Server Type.
		/// </summary>
		public static eDBServerTypes DBServerType {
			get {
				if (dbservertype__ == eDBServerTypes.invalid) {
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
					if (System.Configuration.ConfigurationSettings.AppSettings["DBLogfile"] == null) {
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
			dbservertype__ = eDBServerTypes.invalid;
			dbconnectionstring__ = null;

			Config_DBConnectionstring _con;
			for (int _db = 0; _db < Config_DBConnectionstrings.DBServerTypes(ApplicationName).Length; _db++) {
				_con = Config_DBConnectionstrings.DBConnectionstrings(ApplicationName)[
					Config_DBConnectionstrings.DBServerTypes(ApplicationName)[_db],<%
					for (int cm = 0; cm < _aux_configmodes.Length; cm++) {%>
#<%=(cm == 0) ? "" : "el"%>if <%=_aux_configmodes[cm]%>
					"<%=_aux_configmodes[cm]%>"<%
					}%>
#endif
				];
				if (_con.isDefault) {
					dbservertype__ = Config_DBConnectionstrings.DBServerTypes(ApplicationName)[_db];
					dbconnectionstring__ = _con.Connectionstring;
					return;
				}
			}
		}
		#endregion
		#endregion<%
		if (_aux_metadata.PseudoReflectionable) {%>

		public static pr<%=_aux_metadata.ApplicationName%> pReflection;<%
		}%><%

		if (true) { // new scope!
			string NameField;
			string ConfigField;
			string DatatypeField;
			System.Data.DataTable ConfigTable;
			for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
				_aux_table = _aux_metadata.Tables[t];
				if (_aux_table.isConfig) {%>
		#region public static Methods - DB.<%=_aux_table.Name%>...<%
					NameField = "";
					ConfigField = "";
					DatatypeField = "";
					for (int f = 0; f < _aux_table.Fields.Count; f++) {
						_aux_field = _aux_table.Fields[f];
						if (_aux_field.isConfig_Name) {
							NameField = _aux_field.Name;
							continue;
						}
						if (_aux_field.isConfig_Config) {
							ConfigField = _aux_field.Name;
							continue;
						}
						if (_aux_field.isConfig_Datatype) {
							DatatypeField = _aux_field.Name;
							continue;
						}
					}
					cDBConnection connection = new cDBConnection(
						_aux_metadata.DBs.FirstDefaultAvailable_DBServerType(), 
						_aux_metadata.DBs.FirstDefaultAvailable_Connectionstring()
					);
					ConfigTable = connection.Execute_SQLQuery_returnDataTable(
						string.Format(
							"SELECT {4}{0}{4}, {4}{1}{4}, {4}{2}{4} FROM {4}{3}{4} ORDER BY {4}{0}{4}",
							/*00*/ NameField,
							/*01*/ ConfigField,
							/*02*/ DatatypeField,
							/*03*/ _aux_table.Name, 
							/*04*/ (_aux_metadata.DBs.FirstDefaultAvailable_DBServerType() == eDBServerTypes.MySQL) ? "`" :"\""
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
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_table.Name%> at Database.
		/// </summary>
		public static bool <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (!<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_ = DO_<%=_aux_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
					<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_ = bool.Parse(<%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%>);
					<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;
					#endregion
					// ToDos: here! if second assembly instance, one cache could override data from the other
					//<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = true;
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
				<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%> = value.ToString();
				<%=_aux_table.Name.ToLower()%>.setObject(false);
				<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;

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
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_table.Name%> at Database.
		/// </summary>
		public static int <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (!<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
					<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = int.Parse(<%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%>);
					<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;
					#endregion
					// ToDos: here! if second assembly instance, one cache could override data from the other
					//<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>_beenRead = true;
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
				<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%> = value.ToString();
				<%=_aux_table.Name.ToLower()%>.setObject(false);
				<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;

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
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_table.Name%> at Database.
		/// </summary>
		public static string <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (
					// ToDos: here! if second assembly instance, one cache could override data from the other
					true
					||
					(<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> == null)
				) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
					<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = <%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%>;
					<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;
					#endregion
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
				<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
				<%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%> = value;
				<%=_aux_table.Name.ToLower()%>.setObject(false);
				<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;

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
		/// <%=ConfigTable.Rows[r][NameField]%> config which provides access to table <%=_aux_table.Name%> at Database.
		/// </summary>
		public static string[] <%=ConfigTable.Rows[r][NameField]%> {
			get {
				if (
					// ToDos: here! if second assembly instance, one cache could override data from the other
					true
					||
					(<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> == null)
				) {
					#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_table.Name%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
					<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");
					<%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = <%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%>.Split((char)10);
					<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;
					#endregion
				}
				return <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%>;
			}
			set {
				#region <%=((string)ConfigTable.Rows[r][NameField]).ToLower()%> = DO_<%=_aux_table.Name%>.<%=ConfigField%> = value;
				DO_<%=_aux_table.Name%> <%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
				<%=_aux_table.Name.ToLower()%>.getObject("<%=ConfigTable.Rows[r][NameField]%>");


				<%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%> = string.Empty;
				for (int i = 0; i < value.Length; i++) {
					<%=_aux_table.Name.ToLower()%>.Fields.<%=ConfigField%> += string.Format(
						"{0}{1}",
						(i != 0) ? ((char)10).ToString() : string.Empty, 
						value[i]
					);
				}


				<%=_aux_table.Name.ToLower()%>.setObject(false);
				<%=_aux_table.Name.ToLower()%>.Dispose(); <%=_aux_table.Name.ToLower()%> = null;

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
	<%
	if (_aux_metadata.PseudoReflectionable) {
	for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
		_aux_table = _aux_metadata.Tables[t];
		_aux_table_hasidentitykey = _aux_table.hasIdentityKey();
		for (int f = 0; f < _aux_table.Fields.Count; f++) {
			_aux_field = _aux_table.Fields[f];%>
	#region public struct pr<%=_aux_metadata.ApplicationName%>_<%=_aux_table.Name%>_<%=_aux_field.Name%> : ...;
	public struct pr<%=_aux_metadata.ApplicationName%>_<%=_aux_table.Name%>_<%=_aux_field.Name%> : iprField {
		public string Name { get { return "<%=_aux_field.Name%>"; } }
		public int Size { get { return <%=_aux_field.Size%>; } }
		public bool isNullable { get { return <%=_aux_field.isNullable.ToString().ToLower()%>; } }

		public bool isIdentity { get { return <%=_aux_field.isIdentity.ToString().ToLower()%>; } }
		public bool isPK { get { return <%=_aux_field.isPK.ToString().ToLower()%>; } }

		public bool isBool { get { return <%=_aux_field.isBool.ToString().ToLower()%>; } }
		public bool isDateTime { get { return <%=_aux_field.isDateTime.ToString().ToLower()%>; } }
		public bool isInt { get { return <%=_aux_field.isInt.ToString().ToLower()%>; } }
		public bool isDecimal { get { return <%=_aux_field.isDecimal.ToString().ToLower()%>; } }
		public bool isText { get { return <%=_aux_field.isText.ToString().ToLower()%>; } }

		public DbType DBType_generic { get { return DbType.<%=_aux_field.DBType_generic.Value%>; } }<%
		//public object DBType_inDB { get { return < %=_aux_field.DBType_inDB% >; } }%>

		public iprTable FK_Table { get { return <%=(_aux_field.FK.TableName == "") ? "null" : "DO__utils.pReflection.Tables[\"" + _aux_field.FK.TableName + "\"]"%>; } }
		public iprField FK_Field { get { return <%=(_aux_field.FK.TableName == "") ? "null" : "DO_" + _aux_field.FK.TableName + ".pReflection.Fields[\"" + _aux_field.FK.FieldName + "\"]"%>; } }

		public Type TypeOf { get { return typeof(<%=_aux_field.DBType_generic.FWType%>); } }
		public /*<%=_aux_field.DBType_generic.FWType%> */object EmptyValue { get { return <%=_aux_field.DBType_generic.FWEmptyValue%>; } }
		//public /*<%=_aux_field.DBType_generic.FWType%> */object DefaultValue { get { return <%=_aux_field.DBType_generic.FWEmptyValue%>; } }

		//public <%=_aux_field.DBType_generic.FWType%> getValueIn(DO_<%=_aux_table.Name%> <%=_aux_table.Name%>_) {
		//	return <%=_aux_table.Name%>_.<%=_aux_field.Name%>;
		//}
		//public void setValueIn(DO_<%=_aux_table.Name%> <%=_aux_table.Name%>_, <%=_aux_field.DBType_generic.FWType%> Value_) {
		//	<%=_aux_table.Name%>_.<%=_aux_field.Name%> = Value_;
		//}
		//public void setObject_withEmptyValue(DO_<%=_aux_table.Name%> <%=_aux_table.Name%>_) {
		//	<%=_aux_table.Name%>_.<%=_aux_field.Name%> = <%=_aux_field.DBType_generic.FWEmptyValue%>;
		//}
		////public void setObject_withDefaultValue(DO_<%=_aux_table.Name%> <%=_aux_table.Name%>_) {
		////	<%=_aux_table.Name%>_.<%=_aux_field.Name%> = <%=_aux_field.DBType_generic.FWEmptyValue%>;
		////}
	}
	#endregion<%
		}%>
	#region public struct pr<%=_aux_metadata.ApplicationName%>_<%=_aux_table.Name%>;
	public struct pr<%=_aux_metadata.ApplicationName%>_<%=_aux_table.Name%> : iprTable {
		#region public sFields Fields { get; }
		#region public struct sFields;
		public struct sFields : iprFields {
			public int Count { get { return <%=_aux_table.Fields.Count%>; } }<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%>
			public pr<%=_aux_metadata.ApplicationName%>_<%=_aux_table.Name%>_<%=_aux_field.Name%> <%=_aux_field.Name%>;<%
			}
			%>

			#region public iprField this[int Index_] { get; }
			public iprField this[int Index_] {
				get {
					switch (Index_) {<%
						for (int f = 0; f < _aux_table.Fields.Count; f++) {
							_aux_field = _aux_table.Fields[f];%>
						case <%=f%>:
							return <%=_aux_field.Name%>;<%
						}%>
						default:
							return null;
					}
				}
			}
			#endregion
			#region public iprField this[string Name_] { get; }
			public iprField this[string Name_] {
				get {
					switch (Name_) {<%
						for (int f = 0; f < _aux_table.Fields.Count; f++) {
							_aux_field = _aux_table.Fields[f];%>
						case "<%=_aux_field.Name%>":
							return <%=_aux_field.Name%>;<%
						}%>
						default:
							return null;
					}
				}
			}
			#endregion
		}
		#endregion

		private static sFields fields;
		public iprFields Fields {
			get { return fields; }
		}
		#endregion

		public string Name { get { return "<%=_aux_table.Name%>"; } }
		#region public iprField IdentityKey { get; }
		public iprField IdentityKey {
			get { return <%=(_aux_table_hasidentitykey == -1) ? "null" : "fields[" + _aux_table.hasIdentityKey() + "]"%>; }
		}
		#endregion
	}
	#endregion<%
	}%>
	#region public struct pr<%=_aux_metadata.ApplicationName%>;
	public struct pr<%=_aux_metadata.ApplicationName%> {
		#region public sTables Tables { get; }
		#region public struct sTables;
		public struct sTables {
			<%for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
				_aux_table = _aux_metadata.Tables[t];%>
			public pr<%=_aux_metadata.ApplicationName%>_<%=_aux_table.Name%> <%=_aux_table.Name%>;<%
			}%>

			public int Count { get { return <%=_aux_metadata.Tables.Count%>; } }
			#region public iprTable this[int Index_] { get; }
			public iprTable this[int Index_] {
				get {
					switch (Index_) {<%
						for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
							_aux_table = _aux_metadata.Tables[t];%>
						case <%=t%>:
							return <%=_aux_table.Name%>;<%
						}%>
						default:
							return null;
					}
				}
			}
			#endregion
			#region public iprTable this[string Name_] { get; }
			public iprTable this[string Name_] {
				get {
					switch (Name_) {<%
						for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
							_aux_table = _aux_metadata.Tables[t];%>
						case "<%=_aux_table.Name%>":
							return <%=_aux_table.Name%>;<%
						}%>
						default:
							return null;
					}
				}
			}
			#endregion
		}
		#endregion
		public sTables Tables;
		#endregion
	}
	#endregion<%
	}%>
}<%
//-----------------------------------------------------------------------------------------
%>