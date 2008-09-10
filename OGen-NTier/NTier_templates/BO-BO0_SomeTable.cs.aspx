<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
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

bool isListItem = _aux_table.isListItem();

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

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
using OGen.NTier.lib.businesslayer;

using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer {
	/// <summary>
	/// <%=_aux_db_table.Name%> BusinessObject which provides access to <see cref="<%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.DO_<%=_aux_db_table.Name%>">DO_<%=_aux_db_table.Name%></see> for the Business Layer.<%--
#if NET_1_1
	/// <note type="implementnotes">
	/// Access must be made via <see cref="BO_<%=_aux_db_table.Name%>">BO_<%=_aux_db_table.Name%></see>.
	/// </note>
#endif--%>
	/// </summary>
	[DOClassAttribute("<%=_aux_db_table.Name%>", "<%=_aux_table.FriendlyName%>", "<%=_aux_table.DBDescription%>", "<%=_aux_table.ExtendedDescription%>", <%=_aux_db_table.isVirtualTable.ToString().ToLower()%>, <%=_aux_table.isConfig.ToString().ToLower()%>)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		BO_<%=_aux_db_table.Name%> 
#else
		BO0_<%=_aux_db_table.Name%> 
#endif
		: BO__base<%=(isListItem) ? ", iListItem" : ""%> {
		#region public BO_<%=_aux_db_table.Name%>(...);
#if NET_1_1
		internal BO0_<%=_aux_db_table.Name%>() {}
#endif

		///
#if !NET_1_1
		~BO_<%=_aux_db_table.Name%>
#else
		~BO0_<%=_aux_db_table.Name%>
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_<%=_aux_db_table.Name%> mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_<%=_aux_db_table.Name%> mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_<%=_aux_db_table.Name%>();
				}
				return mainaggregate__;
			}
		}
		#endregion
		#region public Properties...
		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public override iRecordObject Record {
			get { return mainAggregate.Record; }
		}

		public SO0_<%=_aux_db_table.Name%> Fields {
			get { return mainAggregate.Fields; }
		}<%
		if (isListItem) { %>
		#region public string ListItemValue { get; set; }
		/// <summary>
		/// List Item Value.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
			string ListItemValue {
			get { return <%=_aux_table.ListItemValue.Name%><%=(_aux_table.ListItemValue.DBType_generic.FWType != "string") ? ".ToString()" : ""%>; }
		}
		#endregion
		#region public string ListItemText { get; }
		/// <summary>
		/// List Item Text.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
			string ListItemText {
			get { return <%=_aux_table.ListItemText.Name%><%=(_aux_table.ListItemText.DBType_generic.FWType != "string") ? ".ToString()" : ""%>; }
		}
		#endregion
		//---<%
		}
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_field = _aux_db_table.TableFields.TableFieldCollection[f];

			if (_aux_field.isNullable && !_aux_field.isPK) {%>
		#region public bool <%=_aux_field.Name%>_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at <%=_aux_db_table.Name%>'s <%=_aux_field.Name%>.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool <%=_aux_field.Name%>_isNull {
			get { return mainAggregate.Fields.<%=_aux_field.Name%>_isNull; }
			set { mainAggregate.Fields.<%=_aux_field.Name%>_isNull = value; }
		}
		#endregion<%
			}%>
		#region public <%=_aux_field.DBType_generic.FWType%> <%=_aux_field.Name%> { get; set; }
		/// <summary>
		/// <%=_aux_db_table.Name%>'s <%=_aux_field.Name%>.
		/// </summary>
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
			<%=_aux_db_field.isDecimal.ToString().ToLower()%>, 
			<%=_aux_field.isText.ToString().ToLower()%>, 
			<%=_aux_field.isListItemValue.ToString().ToLower()%>, 
			<%=_aux_field.isListItemText.ToString().ToLower()%>, 
			<%=_aux_db_field.Size%>, 
			"<%=_aux_field.AditionalInfo%>"
		)]
		public 
#if NET_1_1
			virtual 
#endif
		<%=_aux_field.DBType_generic.FWType%> <%=_aux_field.Name%> {
			get { return mainAggregate.Fields.<%=_aux_field.Name%>; }
			set { mainAggregate.Fields.<%=_aux_field.Name%> = value; }
		}
		#endregion<%
		}%>
		#endregion

		#region public Methods...
		#region public SC0_<%=_aux_db_table.Name%> Serialize();
		public SO0_<%=_aux_db_table.Name%> Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO0_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in);
		public void Deserialize(SO0_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in) {
			mainAggregate.Fields = <%=_aux_db_table.Name%>_in;
		}
		#endregion
		#region public SC0_<%=_aux_db_table.Name%> Record_Serialize();
		public SC0_<%=_aux_db_table.Name%> Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>