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

OGen.NTier.lib.metadata.metadataBusiness.XS_classType _aux_class;

XS_methodType _aux_method;
XS_parameterType _aux_parameter;

string _aux_str1;
string _aux_str2;
string _aux_str3;
int _aux_int1;
int _aux_int2;
int _aux_int3;
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
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.shared.structures;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared.structures;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared.instances;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.presentationlayer.weblayer {
	public class <%=_aux_ex_metadata.ApplicationName%>ListControl {
		public <%=_aux_ex_metadata.ApplicationName%>ListControl(
			IXXXListControl listitemcollection_ref_in
		) {
			listitemcollection_ref_ = listitemcollection_ref_in;
		}

		protected IXXXListControl listitemcollection_ref_;<%
		for (int c = 0; c < _aux_business_metadata.Classes.ClassCollection.Count; c++) {
			_aux_class = _aux_business_metadata.Classes.ClassCollection[c];
			for (int m = 0; m < _aux_class.Methods.MethodCollection.Count; m++) {
				_aux_method = _aux_class.Methods.MethodCollection[m];
				if (!_aux_method.isSearch) continue;%><%=""%>

		#region public void Bind_<%=_aux_class.Name%>_<%=_aux_method.Name%>(...);
		public void Bind_<%=_aux_class.Name%>_<%=_aux_method.Name%>(
			string selectedValue_in,
			bool allowNull_in<%
			for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
				_aux_parameter = _aux_method.Parameters.ParameterCollection[p];%>, 
			<%=_aux_parameter.isOut ? "out " : ""%><%=_aux_parameter.isRef ? "ref " : ""%><%=_aux_parameter.isParams ? "params " : ""%><%=_aux_parameter.Type%><%=_aux_parameter.isParams ? "[]" : ""%> <%=_aux_parameter.Name%><%
			}%>
		) {
			<%=_aux_method.OutputType%> _items 
				= <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared.instances.<%=_aux_class.Name%>.InstanceClient.<%=_aux_method.Name%>(<%
					for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
						_aux_parameter = _aux_method.Parameters.ParameterCollection[p];%><%=""%>
					<%=_aux_parameter.isOut ? "out " : ""%><%=_aux_parameter.isRef ? "ref " : ""%><%=_aux_parameter.isParams ? "params " : ""%><%=_aux_parameter.Name%><%=(p == _aux_method.Parameters.ParameterCollection.Count - 1) ? "" : ", "%><%
					}%>
				);
			if (_items != null) {
				bind_pre(
					allowNull_in
				);

				foreach (<%=_aux_method.OutputType.Replace("[]", "")%> _item in _items) {
					listitemcollection_ref_.Add(

//_item.Name,
//_item.IDTasktype.ToString()
"",
""

					);
				}

				SelectedValue__set(
					selectedValue_in
				);
			}
		}
		#endregion
		#region public void SelectedValues__set_<%=_aux_class.Name%>_<%=_aux_method.Name%>(...);
		public void SelectedValues__set_<%=_aux_class.Name%>_<%=_aux_method.Name%>(
			long idCoworker_search_in<%
			for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
				_aux_parameter = _aux_method.Parameters.ParameterCollection[p];%>, 
			<%=_aux_parameter.isOut ? "out " : ""%><%=_aux_parameter.isRef ? "ref " : ""%><%=_aux_parameter.isParams ? "params " : ""%><%=_aux_parameter.Type%><%=_aux_parameter.isParams ? "[]" : ""%> <%=_aux_parameter.Name%><%
			}%>
		) {
			<%=_aux_method.OutputType%> _items 
			= <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared.instances.<%=_aux_class.Name%>.InstanceClient.<%=_aux_method.Name%>(<%			
				for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
					_aux_parameter = _aux_method.Parameters.ParameterCollection[p];%><%=""%>
				<%=_aux_parameter.isOut ? "out " : ""%><%=_aux_parameter.isRef ? "ref " : ""%><%=_aux_parameter.isParams ? "params " : ""%><%=_aux_parameter.Name%><%=(p == _aux_method.Parameters.ParameterCollection.Count - 1) ? "" : ", "%><%
				}%>
			);
			if (_items != null) {
				string[] _selection = new string[_items.Length];
				for (int i = 0; i < _items.Length; i++) {

//_selection[i] = _items[i].IDTasktype.ToString();
_selection[i] = "";

				}
			}
		}
		#endregion<%
			 }
		}%>

		#region public void Bind__Enum(...);
		#region private void bind__enum_post(...);
		private void bind__enum_post(
			string[] enumItems_in,
			Type enumType_in,

			string selectedValue_in,
			bool allowNull_in
		) {
			bind_pre(
				allowNull_in
			);

			long _value;
			foreach (string _enumItem in enumItems_in) {
				_value = (long)Enum.Parse(enumType_in, _enumItem);

				if (_value >= 0) {
					listitemcollection_ref_.Add(
						_enumItem.Replace("__", " - ").Replace('_', ' '),
						_value.ToString()
					);
				}
			}

			SelectedValue__set(
				selectedValue_in
			);
		}
		#endregion

		public void Bind__Enum(
			string selectedValue_in,
			bool allowNull_in,

			bool sortByName_in,

			Type enumType_in
		) {
			string[] _enumItems = Enum.GetNames(enumType_in);

			if (sortByName_in) {
				Array.Sort(_enumItems);
			}

			bind__enum_post(
				_enumItems,
				enumType_in,

				selectedValue_in,
				allowNull_in
			);
		}
		#endregion

		#region public void Bind__Copy(...);
		public void Bind__Copy(
			ExcellencerListBox from_in,

			string selectedValue_in,
			bool allowNull_in
		) {
			if (
				allowNull_in
				//&&
				//!(
				//    (from_in.Items.Count != 0)
				//    &&
				//    (from_in.Items[0].Value == "")
				//)
			) {
				bind_pre(
					allowNull_in
				);
			} else {
				listitemcollection_ref_.Clear();
			}

			for (int i = 0; i < from_in.Items.Count; i++) {
				if (from_in.Items[i].Value == "") continue;

				listitemcollection_ref_.Add(
					from_in.Items[i].Text,
					from_in.Items[i].Value
				);
			}

			SelectedValue__set(
				selectedValue_in
			);
		}
		#endregion

		#region private void bind_pre(...);
		private void bind_pre(
			bool allowNull_in
		) {
			listitemcollection_ref_.Clear();
			if (allowNull_in) {
				listitemcollection_ref_.Add("-- undefined --", "");
			}
		}
		#endregion

		#region public void SelectedValue__set(...);
		public void SelectedValue__set(
			string[] selectedValue_in
		) {
			for (int i = 0; i < listitemcollection_ref_.Count; i++) {
				listitemcollection_ref_[i].Selected = false;
				for (int j = 0; j < selectedValue_in.Length; j++) {
					if (listitemcollection_ref_[i].Value == selectedValue_in[j]) {
						listitemcollection_ref_[i].Selected = true;
						break;
					}
				}
			}
		}

		public void SelectedValue__set(
			string selectedValue_in
		) {
			if (selectedValue_in == "") {
				for (int i = 0; i < listitemcollection_ref_.Count; i++) {
					listitemcollection_ref_[i].Selected = false;
				}
			} else {
				string[] _selectedValues
					= selectedValue_in.Split('|');

				SelectedValue__set(
					_selectedValues
				);
			}
		}
		#endregion
		#region public string[] SelectedValue__get(...);
		public T[] SelectedValue__get<T>(
		) {
			List<T> _output = new List<T>(listitemcollection_ref_.Count);
			for (int i = 0; i < listitemcollection_ref_.Count; i++) {
				if (listitemcollection_ref_[i].Selected) {
					_output.Add(
						(T)Convert.ChangeType(
							listitemcollection_ref_[i].Value,
							typeof(T)
						)
					);
				}
			}

			return _output.ToArray();
		}
		#endregion
	}
}