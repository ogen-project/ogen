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
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table
	= _aux_db_metadata.Tables.TableCollection[
		_arg_TableName
	];
OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table
	= _aux_db_table.parallel_ref;

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

string _aux_xx_field_name;

OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update;

#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_ex_metadata.CopyrightText != string.Empty) && (_aux_ex_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_db_table.Name%> SerializableObject which provides fields access at <%=_aux_db_table.Name%> <%=(_aux_db_table.isVirtualTable) ? "view" : "table"%> at Database.
	/// </summary>
	public class SO0_<%=_aux_db_table.Name%> {
		#region public SO0_<%=_aux_db_table.Name%>();
		public SO0_<%=_aux_db_table.Name%>(
		) : this (<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			<%=(_aux_ex_field.DefaultValue == "") ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%><%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
		}%>
		) {
		}
		public SO0_<%=_aux_db_table.Name%>(<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
		}%>
		) {
			haschanges_ = false;
			//---<%
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			<%=_aux_db_field.Name.ToLower()%>_ = <%=_aux_db_field.Name%>_in;<%
			}%>
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		internal bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_<%=_aux_db_table.Name%> properties since last time getObject method was run.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_table.TableFields.TableFieldCollection[f];
			_aux_ex_field = _aux_db_field.parallel_ref;

			if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%>
		#region public bool <%=_aux_db_field.Name%>_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at <%=_aux_db_table.Name%>'s <%=_aux_db_field.Name%>.
		/// </summary>
		[XmlIgnore]
		public 
#if NET_1_1
			virtual 
#endif
		bool <%=_aux_db_field.Name%>_isNull {
			get { return (<%=_aux_db_field.Name.ToLower()%>_ == null); }<%
			// ToDos: here! fmonteiro
			if (true || !_aux_db_table.isVirtualTable) {%>
			set {
				//if (value) <%=_aux_db_field.Name.ToLower()%>_ = null;

				if ((value) && (<%=_aux_db_field.Name.ToLower()%>_ != null)) {
					<%=_aux_db_field.Name.ToLower()%>_ = null;
					haschanges_ = true;
				}
			}<%
			}%>
		}
		#endregion<%
			}%>
		#region public <%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%> { get; set; }
		internal <%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name.ToLower()%>_;// = <%=(_aux_ex_field.DefaultValue == "") ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%>;
		
		/// <summary>
		/// <%=_aux_db_table.Name%>'s <%=_aux_db_field.Name%>.
		/// </summary>
		[XmlElement("<%=_aux_db_field.Name%>")]
		[DOPropertyAttribute(
			"<%=_aux_db_field.Name%>", 
			"<%=_aux_ex_field.FriendlyName%>", 
			"<%=_aux_ex_field.ExtendedDescription%>", 
			<%=_aux_db_field.isPK.ToString().ToLower()%>, 
			<%=_aux_db_field.isIdentity.ToString().ToLower()%>, 
			<%=_aux_db_field.isNullable.ToString().ToLower()%>, 
			"<%=_aux_ex_field.DefaultValue%>", <%--
			<%=(_aux_ex_field.DefaultValue == string.Empty) ? "null" : _aux_ex_field.DefaultValue%>,
			<%=(_aux_ex_field.DefaultValue == string.Empty) ? "\"\"" : _aux_ex_field.DefaultValue%>, --%>
			"<%=_aux_db_field.FKTableName%>", 
			"<%=_aux_db_field.FKFieldName%>", 
			<%=_aux_ex_field.isConfig_Name.ToString().ToLower()%>, 
			<%=_aux_ex_field.isConfig_Config.ToString().ToLower()%>, 
			<%=_aux_ex_field.isConfig_Datatype.ToString().ToLower()%>, 
			<%=_aux_db_field.isBool.ToString().ToLower()%>, 
			<%=_aux_db_field.isDateTime.ToString().ToLower()%>, 
			<%=_aux_db_field.isInt.ToString().ToLower()%>, 
			<%=_aux_db_field.isDecimal.ToString().ToLower()%>, 
			<%=_aux_db_field.isText.ToString().ToLower()%>, 
			<%=_aux_ex_field.isListItemValue.ToString().ToLower()%>, 
			<%=_aux_ex_field.isListItemText.ToString().ToLower()%>, 
			<%=_aux_db_field.Size%>, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%> {
			get {<%
			if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%>
				return (<%=_aux_db_field.DBType_generic.FWType%>)((<%=_aux_db_field.Name.ToLower()%>_ == null) ? <%=(_aux_ex_field.DefaultValue == "") ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%> : <%=_aux_db_field.Name.ToLower()%>_);<%
			} else {%>
				return <%=_aux_db_field.Name.ToLower()%>_;<%
			}%>
			}
			set {
				if (<%
					if (_aux_db_field.DBType_generic.FWType.ToLower() == "string") {%>
					(value != null)
					&&<%
					}%>
					(!value.Equals(<%=_aux_db_field.Name.ToLower()%>_))
				) {
					<%=_aux_db_field.Name.ToLower()%>_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion<%
		}%>
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>