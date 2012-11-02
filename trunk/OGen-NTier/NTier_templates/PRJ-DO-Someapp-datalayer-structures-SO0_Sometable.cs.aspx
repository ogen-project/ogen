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
	true,
	false
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
}%>
namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.shared.structures {
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using OGen.NTier.lib.datalayer;

	/// <summary>
	/// <%=_aux_db_table.Name%> SerializableObject which provides fields access at <%=_aux_db_table.Name%> <%=(_aux_db_table.isVirtualTable) ? "view" : "table"%> at Database.
	/// </summary>
	[Serializable()]
	public class SO_<%=_aux_db_table.Name%> : 
		<%=_aux_isListItem ? "SO__ListItem<" + _aux_ex_table.ListItemValue.parallel_ref.DBType_generic.FWType + ", " + _aux_ex_table.ListItemText.parallel_ref.DBType_generic.FWType + ">, " : ""%>ISerializable
	{
		#region public SO_<%=_aux_db_table.Name%>();
		public SO_<%=_aux_db_table.Name%>(
		) {
			this.Clear();
		}
		public SO_<%=_aux_db_table.Name%>(<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
		}%>
		) {<%
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = <%=_aux_db_field.Name%>_in;<%
			}%>

			this.haschanges_ = false;
		}
		protected SO_<%=_aux_db_table.Name%>(
			SerializationInfo info,
			StreamingContext context
		) {<%
	for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
		_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
		if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
			this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ 
				= (info.GetValue("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>)) == null)
					? <%=_aux_db_field.DBType_generic.FWEmptyValue%>
					: (<%=_aux_db_field.DBType_generic.FWType%>)info.GetValue("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>));
			this.<%=_aux_db_field.Name%>_isNull = (bool)info.GetValue("<%=_aux_db_field.Name%>_isNull", typeof(bool));<%
		} else {%><%=""%>
			this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = (<%=_aux_db_field.DBType_generic.FWType%>)info.GetValue("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>));<%
		}
	}%>

			this.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_<%=_aux_db_table.Name%> properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion
<%
		if (_aux_isListItem) {%><%=""%>
		#region public override <%=_aux_ex_table.ListItemValue.parallel_ref.DBType_generic.FWType%> ListItem_Value { get; }
		public override <%=_aux_ex_table.ListItemValue.parallel_ref.DBType_generic.FWType%> ListItem_Value {
			get {<%
				if (_aux_ex_table.ListItemValue.parallel_ref.isNullable && !_aux_ex_table.ListItemValue.parallel_ref.isPK) {%>
				return this.<%=_aux_ex_table.ListItemValue.Name%>;<%
				} else {%>
				return this.<%=_aux_ex_table.ListItemValue.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_;<%
				}%>
			}
		}
		#endregion
		#region public override <%=_aux_ex_table.ListItemText.parallel_ref.DBType_generic.FWType%> ListItem_Text { get; }
		public override <%=_aux_ex_table.ListItemText.parallel_ref.DBType_generic.FWType%> ListItem_Text {
			get {<%
				if (_aux_ex_table.ListItemText.parallel_ref.isNullable && !_aux_ex_table.ListItemText.parallel_ref.isPK) {%>
				return this.<%=_aux_ex_table.ListItemText.Name%>;<%
				} else {%>
				return this.<%=_aux_ex_table.ListItemText.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_;<%
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
		private <%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_;// = <%=((_aux_ex_field == null) || (_aux_ex_field.DefaultValue == "")) ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%>;
		
		/// <summary>
		/// <%=_aux_db_table.Name%>'s <%=_aux_db_field.Name%>.
		/// </summary>
		[XmlElement("<%=_aux_db_field.Name%>")]
		[SoapElement("<%=_aux_db_field.Name%>")]
		[DOPropertyAttribute(
			"<%=_aux_db_field.Name%>", 
			"<%=(_aux_ex_field == null) ? "" : _aux_ex_field.FriendlyName%>", 
			"<%=(_aux_ex_field == null) ? "" : _aux_ex_field.ExtendedDescription%>", 
			<%=_aux_db_field.isPK.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.isIdentity.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.isNullable.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			"<%=(_aux_ex_field == null) ? "" : _aux_ex_field.DefaultValue%>", <%--
			<%=(_aux_ex_field.DefaultValue == string.Empty) ? "null" : _aux_ex_field.DefaultValue%>,
			<%=(_aux_ex_field.DefaultValue == string.Empty) ? "\"\"" : _aux_ex_field.DefaultValue%>, --%>
			"<%=_aux_db_field.FKTableName%>", 
			"<%=_aux_db_field.FKFieldName%>", 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isConfig_Name.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isConfig_Config.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isConfig_Datatype.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.isBool.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.isDateTime.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.isInt.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.isDecimal.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.isText.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isListItemValue.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=(_aux_ex_field == null) ? "false" : _aux_ex_field.isListItemText.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>, 
			<%=_aux_db_field.Size%>, 
			""
		)]
		public <%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%> {
			get {<%
			if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%>
				return (<%=_aux_db_field.DBType_generic.FWType%>)((this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ == null) ? <%=((_aux_ex_field == null) || (_aux_ex_field.DefaultValue == "")) ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%> : this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_);<%
			} else {%>
				return this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_;<%
			}%>
			}
			set {
				if (<%
					if (_aux_db_field.DBType_generic.FWType.Equals("string", StringComparison.CurrentCultureIgnoreCase)) {%>
					(value != null)
					&&<%
					}%>
					(!value.Equals(this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_))
				) {
					this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = value;
					this.haschanges_ = true;
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
			get { return (this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ == null); }<%
			// ToDos: here! fmonteiro
			if (true || !_aux_db_table.isVirtualTable) {%>
			set {
				//if (value) this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = null;

				if ((value) && (this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ != null)) {
					this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = null;
					this.haschanges_ = true;
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
			SO_<%=_aux_db_table.Name%>[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;
<%
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			DataColumn _dc_<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = new DataColumn("<%=_aux_db_field.Name%>", typeof(<%=_aux_db_field.DBType_generic.FWType%>));
			_output.Columns.Add(_dc_<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>);<%
			}%>

			foreach (SO_<%=_aux_db_table.Name%> _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();
<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
				_dr[_dc_<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>] = _serializableObject.<%=_aux_db_field.Name%>;<%
				}%>

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public void Clear();
		/// <summary>
		/// Clears SerializableObject's properties.
		/// </summary>
		public void Clear() {<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
			_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = <%=
				(
					(_aux_ex_field == null) 
					|| 
					(_aux_ex_field.DefaultValue == "")
				) 
					? _aux_db_field.DBType_generic.FWEmptyValue 
					: _aux_ex_field.DefaultValue%>;<%
		}%>

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
			info.AddValue("<%=_aux_db_field.Name%>", this.<%=_aux_db_field.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_);<%
			if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
			info.AddValue("<%=_aux_db_field.Name%>_isNull", this.<%=_aux_db_field.Name%>_isNull);<%
			}
		}%>
		}
		#endregion
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>