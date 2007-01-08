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
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
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
cDBMetadata_Table _aux_table = _aux_metadata.Tables[_arg_TableName];
int _aux_table_hasidentitykey = _aux_table.hasIdentityKey();
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
string _aux_field_name;
cDBMetadata_Update _aux_update;
int firstKey = _aux_table.firstKey();
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
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;

namespace <%=_aux_metadata.Namespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_table.Name%> SerializableObject which provides fields access at <%=_aux_table.Name%> <%=(_aux_table.isVirtualTable) ? "view" : "table"%> at Database.
	/// </summary>
	public class SO0_<%=_aux_table.Name%> {
		#region public SO0_<%=_aux_table.Name%>();
		public SO0_<%=_aux_table.Name%>(
		) : this (<%
		for (int f = 0; f < _aux_table.Fields.Count; f++) {
			_aux_field = _aux_table.Fields[f];%><%=""%>
			<%=(_aux_field.DefaultValue == "") ? _aux_field.DBType_generic.FWEmptyValue : _aux_field.DefaultValue%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
		}%>
		) {
		}
		public SO0_<%=_aux_table.Name%>(<%
		for (int f = 0; f < _aux_table.Fields.Count; f++) {
			_aux_field = _aux_table.Fields[f];%><%=""%>
			<%=_aux_field.DBType_generic.FWType%> <%=_aux_field.Name%>_in<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
		}%>
		) {
			haschanges_ = false;
			//---<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%><%=""%>
			<%=_aux_field.Name.ToLower()%>_ = <%=_aux_field.Name%>_in;<%
			}%>
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		internal bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_<%=_aux_table.Name%> properties since last time getObject method was run.
		/// </summary>
		public 
#if !NET20
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---<%
		for (int f = 0; f < _aux_table.Fields.Count; f++) {
			_aux_field = _aux_table.Fields[f];

			if (_aux_field.isNullable && !_aux_field.isPK) {%>
		#region public bool <%=_aux_field.Name%>_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at <%=_aux_table.Name%>'s <%=_aux_field.Name%>.
		/// </summary>
		[XmlIgnore]
		public 
#if !NET20
			virtual 
#endif
		bool <%=_aux_field.Name%>_isNull {
			get { return (<%=_aux_field.Name.ToLower()%>_ == null); }<%
			// ToDos: here! fmonteiro
			if (true || !_aux_table.isVirtualTable) {%>
			set {
				//if (value) <%=_aux_field.Name.ToLower()%>_ = null;

				if ((value) && (<%=_aux_field.Name.ToLower()%>_ != null)) {
					<%=_aux_field.Name.ToLower()%>_ = null;
					haschanges_ = true;
				}
			}<%
			}%>
		}
		#endregion<%
			}%>
		#region public <%=_aux_field.DBType_generic.FWType%> <%=_aux_field.Name%> { get; set; }
		internal <%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field.Name.ToLower()%>_;// = <%=(_aux_field.DefaultValue == "") ? _aux_field.DBType_generic.FWEmptyValue : _aux_field.DefaultValue%>;
		
		/// <summary>
		/// <%=_aux_table.Name%>'s <%=_aux_field.Name%>.
		/// </summary>
		[XmlElement("<%=_aux_field.Name%>")]
		[DOPropertyAttribute(
			"<%=_aux_field.Name%>", 
			"<%=_aux_field.FriendlyName%>", 
			"<%=_aux_field.ExtendedDescription%>", 
			<%=_aux_field.isPK.ToString().ToLower()%>, 
			<%=_aux_field.isIdentity.ToString().ToLower()%>, 
			<%=_aux_field.isNullable.ToString().ToLower()%>, 
			"<%=_aux_field.DefaultValue%>", <%--
			<%=(_aux_field.DefaultValue == string.Empty) ? "null" : _aux_field.DefaultValue%>,
			<%=(_aux_field.DefaultValue == string.Empty) ? "\"\"" : _aux_field.DefaultValue%>, --%>
			"<%=_aux_field.FK_TableName%>", 
			"<%=_aux_field.FK_FieldName%>", 
			<%=_aux_field.isConfig_Name.ToString().ToLower()%>, 
			<%=_aux_field.isConfig_Config.ToString().ToLower()%>, 
			<%=_aux_field.isConfig_Datatype.ToString().ToLower()%>, 
			<%=_aux_field.isBool.ToString().ToLower()%>, 
			<%=_aux_field.isDateTime.ToString().ToLower()%>, 
			<%=_aux_field.isInt.ToString().ToLower()%>, 
			<%=_aux_field.isDecimal.ToString().ToLower()%>, 
			<%=_aux_field.isText.ToString().ToLower()%>, 
			<%=_aux_field.isListItemValue.ToString().ToLower()%>, 
			<%=_aux_field.isListItemText.ToString().ToLower()%>, 
			<%=_aux_field.Size%>, 
			"<%=_aux_field.AditionalInfo%>"
		)]
		public 
#if !NET20
			virtual 
#endif
		<%=_aux_field.DBType_generic.FWType%> <%=_aux_field.Name%> {
			get {<%
			if (_aux_field.isNullable && !_aux_field.isPK) {%>
				return (<%=_aux_field.DBType_generic.FWType%>)((<%=_aux_field.Name.ToLower()%>_ == null) ? <%=(_aux_field.DefaultValue == "") ? _aux_field.DBType_generic.FWEmptyValue : _aux_field.DefaultValue%> : <%=_aux_field.Name.ToLower()%>_);<%
			} else {%>
				return <%=_aux_field.Name.ToLower()%>_;<%
			}%>
			}
			set {
				if (<%
					if (_aux_field.DBType_generic.FWType.ToLower() == "string") {%>
					(value != null)
					&&<%
					}%>
					(!value.Equals(<%=_aux_field.Name.ToLower()%>_))
				) {
					<%=_aux_field.Name.ToLower()%>_ = value;
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