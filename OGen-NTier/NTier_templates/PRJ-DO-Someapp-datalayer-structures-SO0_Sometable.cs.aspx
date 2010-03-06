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
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

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

bool _aux_isListItem = (
	(_aux_ex_table.ListItemValue != null)
	&&
	(_aux_ex_table.ListItemText != null)
);
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
using System.Data;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.shared.structures {
	/// <summary>
	/// <%=_aux_db_table.Name%> SerializableObject which provides fields access at <%=_aux_db_table.Name%> <%=(_aux_db_table.isVirtualTable) ? "view" : "table"%> at Database.
	/// </summary>
	[Serializable()]
	public class SO_<%=_aux_db_table.Name%> : 
		<%=_aux_isListItem ? "SO__ListItem<" + _aux_ex_table.ListItemValue.parallel_ref.DBType_generic.FWType + ", " + _aux_ex_table.ListItemText.parallel_ref.DBType_generic.FWType + ">" : "SO__base"%> 
	{
		#region public SO_<%=_aux_db_table.Name%>();
		public SO_<%=_aux_db_table.Name%>(
		) {
			Clear();
		}
		public SO_<%=_aux_db_table.Name%>(<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
		}%>
		) {
			haschanges_ = false;
<%
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			<%=_aux_db_field.Name.ToLower()%>_ = <%=_aux_db_field.Name%>_in;<%
			}%>
		}
		public SO_<%=_aux_db_table.Name%>(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;
<%
	for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
		_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
		if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
			<%=_aux_db_field.Name.ToLower()%>_ 
				= (info_in.GetValue("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>)) == null)
					? <%=_aux_db_field.DBType_generic.FWEmptyValue%>
					: (<%=_aux_db_field.DBType_generic.FWType%>)info_in.GetValue("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>));
			<%=_aux_db_field.Name%>_isNull = (bool)info_in.GetValue("<%=_aux_db_field.Name%>_isNull", typeof(bool));<%
		} else {%><%=""%>
			<%=_aux_db_field.Name.ToLower()%>_ = (<%=_aux_db_field.DBType_generic.FWType%>)info_in.GetValue("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>));<%
		}
	}%>
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_<%=_aux_db_table.Name%> properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
<%
		if (_aux_isListItem) {%><%=""%>
		#region public override <%=_aux_ex_table.ListItemValue.parallel_ref.DBType_generic.FWType%> ListItem_Value { get; }
		public override <%=_aux_ex_table.ListItemValue.parallel_ref.DBType_generic.FWType%> ListItem_Value {
			get {<%
				if (_aux_ex_table.ListItemValue.parallel_ref.isNullable && !_aux_ex_table.ListItemValue.parallel_ref.isPK) {%>
				return <%=_aux_ex_table.ListItemValue.Name%>;<%
				} else {%>
				return <%=_aux_ex_table.ListItemValue.Name.ToLower()%>_;<%
				}%>
			}
		}
		#endregion
		#region public override <%=_aux_ex_table.ListItemText.parallel_ref.DBType_generic.FWType%> ListItem_Text { get; }
		public override <%=_aux_ex_table.ListItemText.parallel_ref.DBType_generic.FWType%> ListItem_Text {
			get {<%
				if (_aux_ex_table.ListItemText.parallel_ref.isNullable && !_aux_ex_table.ListItemText.parallel_ref.isPK) {%>
				return <%=_aux_ex_table.ListItemText.Name%>;<%
				} else {%>
				return <%=_aux_ex_table.ListItemText.Name.ToLower()%>_;<%
				}%>
			}
		} 
		#endregion
<%
		}
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
			_aux_ex_field = _aux_db_field.parallel_ref;%>
		#region public <%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%> { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public <%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name.ToLower()%>_;// = <%=((_aux_ex_field == null) || (_aux_ex_field.DefaultValue == "")) ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%>;
		
		/// <summary>
		/// <%=_aux_db_table.Name%>'s <%=_aux_db_field.Name%>.
		/// </summary>
		[XmlElement("<%=_aux_db_field.Name%>")]
		[SoapElement("<%=_aux_db_field.Name%>")]
		[DOPropertyAttribute(
			"<%=_aux_db_field.Name%>", 
			"<%=(_aux_ex_field == null) ? "" : _aux_ex_field.FriendlyName%>", 
			"<%=(_aux_ex_field == null) ? "" : _aux_ex_field.ExtendedDescription%>", 
			<%=_aux_db_field.isPK.ToString().ToLower()%>, 
			<%=_aux_db_field.isIdentity.ToString().ToLower()%>, 
			<%=_aux_db_field.isNullable.ToString().ToLower()%>, 
			"<%=(_aux_ex_field == null) ? "" : _aux_ex_field.DefaultValue%>", <%--
			<%=(_aux_ex_field.DefaultValue == string.Empty) ? "null" : _aux_ex_field.DefaultValue%>,
			<%=(_aux_ex_field.DefaultValue == string.Empty) ? "\"\"" : _aux_ex_field.DefaultValue%>, --%>
			"<%=_aux_db_field.FKTableName%>", 
			"<%=_aux_db_field.FKFieldName%>", 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isConfig_Name.ToString().ToLower()%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isConfig_Config.ToString().ToLower()%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isConfig_Datatype.ToString().ToLower()%>, 
			<%=_aux_db_field.isBool.ToString().ToLower()%>, 
			<%=_aux_db_field.isDateTime.ToString().ToLower()%>, 
			<%=_aux_db_field.isInt.ToString().ToLower()%>, 
			<%=_aux_db_field.isDecimal.ToString().ToLower()%>, 
			<%=_aux_db_field.isText.ToString().ToLower()%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isListItemValue.ToString().ToLower()%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isListItemText.ToString().ToLower()%>, 
			<%=_aux_db_field.Size%>, 
			""
		)]
		public <%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%> {
			get {<%
			if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%>
				return (<%=_aux_db_field.DBType_generic.FWType%>)((<%=_aux_db_field.Name.ToLower()%>_ == null) ? <%=((_aux_ex_field == null) || (_aux_ex_field.DefaultValue == "")) ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%> : <%=_aux_db_field.Name.ToLower()%>_);<%
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
			if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%>
		#region public bool <%=_aux_db_field.Name%>_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at <%=_aux_db_table.Name%>'s <%=_aux_db_field.Name%>.
		/// </summary>
		[XmlElement("<%=_aux_db_field.Name%>_isNull")]
		[SoapElement("<%=_aux_db_field.Name%>_isNull")]
		public bool <%=_aux_db_field.Name%>_isNull {
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
			}
		}%>
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_<%=_aux_db_table.Name%>[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;
<%
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			DataColumn _dc_<%=_aux_db_field.Name.ToLower()%> = new DataColumn("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>));
			_output.Columns.Add(_dc_<%=_aux_db_field.Name.ToLower()%>);<%
			}%>

			foreach (SO_<%=_aux_db_table.Name%> _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();
<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
				_dr[_dc_<%=_aux_db_field.Name.ToLower()%>] = _serializableobject.<%=_aux_db_field.Name%>;<%
				}%>

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;
<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
			_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.Name.ToLower()%>_ = <%=
				(
					(_aux_ex_field == null) 
					|| 
					(_aux_ex_field.DefaultValue == "")
				) 
					? _aux_db_field.DBType_generic.FWEmptyValue 
					: _aux_ex_field.DefaultValue%>;<%
		}%>
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			info_in.AddValue("<%=_aux_db_field.Name%>", <%=_aux_db_field.Name.ToLower()%>_);<%
			if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
			info_in.AddValue("<%=_aux_db_field.Name%>_isNull", <%=_aux_db_field.Name%>_isNull);<%
			}
		}%>
		}
		#endregion
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>