<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/plain" %>
<%//@ import namespace="OGen.Libraries.DataLayer" %>
<%@ import namespace="OGen.XSD.Libraries.Metadata" %>
<%@ import namespace="OGen.XSD.Libraries.Metadata.Schema" %>
<%@ import namespace="OGen.XSD.Libraries.Metadata.Metadata" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
string _arg_SchemaName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SchemaName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_rootmetadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);
XS_schemaType _aux_schema = _aux_rootmetadata.SchemaCollection[_arg_SchemaName];

string XS0_ = _aux_rootmetadata.MetadataCollection[0].PrefixGenerated;
string XS_ = _aux_rootmetadata.MetadataCollection[0].Prefix;
string XS0__ = _aux_rootmetadata.MetadataCollection[0].PrefixBaseGenerated;
string XS__ = _aux_rootmetadata.MetadataCollection[0].PrefixBase;

string _aux_namespace = _aux_rootmetadata.MetadataCollection[0].FullNamespaceForSchema(_arg_SchemaName);
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_rootmetadata.MetadataCollection[0].CopyrightText != string.Empty) && (_aux_rootmetadata.MetadataCollection[0].CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_rootmetadata.MetadataCollection[0].CopyrightText%>
/*

<%=_aux_rootmetadata.MetadataCollection[0].CopyrightTextLong%>

*/
#endregion
<%
}%>

namespace <%=_aux_namespace%> {
	using System;
	using System.IO;
	using System.Xml.Serialization;

	using OGen.Libraries.Generator;

	#if NET_1_1
	public class <%=XS0__%><%=_aux_schema.Element.Name%> : <%=XS_%><%=_aux_schema.Element.Type%>, IMetadata {
	#else
	public partial class <%=XS__%><%=_aux_schema.Element.Name%> : <%=XS_%><%=_aux_schema.Element.Type%>, IMetadata {
	#endif

		public const string <%=_aux_schema.Element.Name.ToUpper()%> = "<%=_aux_schema.Element.Name%>";
		public const string ROOT = "ROOT";
		public const string ROOT_<%=_aux_schema.Element.Name.ToUpper()%> = ROOT + "." + <%=_aux_schema.Element.Name.ToUpper()%>;
		#region public string Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%> { get; }
		protected string root_<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = null;

		[XmlIgnore()]
		public string Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%> {
			get { return this.root_<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_; }
		}
		#endregion<%--

		#region //public <%=XS_%><%=_aux_schema.Element.Type%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%> { get; set; }
//		private <%=XS_%><%=_aux_schema.Element.Type%> <%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__;
//
//		[XmlIgnore()]
//		public <%=XS_%><%=_aux_schema.Element.Type%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%> {
//			get {
//				if (<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__ == null) {
//					<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__ = new <%=XS_%><%=_aux_schema.Element.Type%>();
//				}
//				return <%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__;
//			}
//			set {
//				<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__ = value;
//			}
//		}
//
//		[XmlElement("<%=_aux_schema.Element.Name%>")]
//		public <%=XS_%><%=_aux_schema.Element.Type%> <%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__xml {
//			get { return <%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__; }
//			set { <%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>__ = value; }
//		}
		#endregion--%>

		#region public static <%=XS__%><%=_aux_schema.Element.Name%>[] Load_fromFile(...);
		public static <%=XS__%><%=_aux_schema.Element.Name%>[] Load_fromFile(
			params string[] filePath_in
		) {<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%>
			return Load_fromFile(
				null, 
				filePath_in
			);
		}
		public static <%=XS__%><%=_aux_schema.Element.Name%>[] Load_fromFile(
			<%=XS__%>RootMetadata root_ref_in, 
			params string[] filePath_in
		) {<%
}%>
			FileStream _stream;
			<%=XS__%><%=_aux_schema.Element.Name%>[] _output 
				= new <%=XS__%><%=_aux_schema.Element.Name%>[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				_stream = new FileStream(
					filePath_in[i],
					FileMode.Open,
					FileAccess.Read,
					FileShare.Read
				);

				try {
					_output[i] = (<%=XS__%><%=_aux_schema.Element.Name%>)new XmlSerializer(typeof(<%=XS__%><%=_aux_schema.Element.Name%>)).Deserialize(
						_stream
					);
					_stream.Close();
#if !NET_1_1
					_stream.Dispose();
#endif
				} catch (Exception _ex) {
					throw new Exception(string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"\n---\n{0}.{1}.Load_fromFile():\nERROR READING XML:\n{2}\n---\n{3}\n---\n{4}\n---\n",
						typeof(<%=XS__%><%=_aux_schema.Element.Name%>).Namespace, 
						typeof(<%=XS__%><%=_aux_schema.Element.Name%>).Name, 
						filePath_in[i],
						_ex.Message,
						_ex.InnerException
					));
				}
				_output[i].root_<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = ROOT + "." + <%=_aux_schema.Element.Name.ToUpper()%> + "[" + i + "]";<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%>

				_output[i].parent_ref = root_ref_in; // ToDos: now!
				if (root_ref_in != null) _output[i].root_ref = root_ref_in;<%
}%>
			}
			return _output;
		}
		#endregion
		#region public static <%=XS__%><%=_aux_schema.Element.Name%>[] Load_fromURI(...);
		public static <%=XS__%><%=_aux_schema.Element.Name%>[] Load_fromURI(
			params Uri[] filePath_in
		) {<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%>
			return Load_fromURI(
				null, 
				filePath_in
			);
		}
		public static <%=XS__%><%=_aux_schema.Element.Name%>[] Load_fromURI(
			<%=XS__%>RootMetadata root_ref_in, 
			params Uri[] filePath_in
		) {<%
}%><%=""%>
			<%=XS__%><%=_aux_schema.Element.Name%>[] _output 
				= new <%=XS__%><%=_aux_schema.Element.Name%>[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				if (filePath_in[i].IsFile) {
					_output[i] = <%=XS__%><%=_aux_schema.Element.Name%>.Load_fromFile(
						filePath_in[i].LocalPath
					)[0];
					// no need! everything's been taken care at: <%=XS__%><%=_aux_schema.Element.Name%>.Load_fromFile(...)
					//_output[i].root_<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = ROOT + "." + <%=_aux_schema.Element.Name.ToUpper()%> + "[" + i + "]";<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%>
					//_output[i].parent_ref = root_ref_in; // ToDos: now!
					//if (root_ref_in != null) _output[i].root_ref = root_ref_in;<%
}%>
				} else {
					try {
						_output[i] = (<%=XS__%><%=_aux_schema.Element.Name%>)new XmlSerializer(typeof(<%=XS__%><%=_aux_schema.Element.Name%>)).Deserialize(
							OGen.Libraries.PresentationLayer.WebForms.Utilities.ReadURL(
								filePath_in[i].ToString()
							)
						);
					} catch (Exception _ex) {
						throw new Exception(string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"\n---\n{0}.{1}.Load_fromURI():\nERROR READING XML:\n{2}\n---\n{3}",
							typeof(<%=XS__%><%=_aux_schema.Element.Name%>).Namespace, 
							typeof(<%=XS__%><%=_aux_schema.Element.Name%>).Name, 
							//(filePath_in[i].IsFile)
							//	? filePath_in[i].LocalPath
							//	: 
							filePath_in[i].ToString(),
							_ex.Message
						));
					}
					_output[i].root_<%=_aux_schema.Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>_ = ROOT + "." + <%=_aux_schema.Element.Name.ToUpper()%> + "[" + i + "]";<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%>
					_output[i].parent_ref = root_ref_in; // ToDos: now!
					if (root_ref_in != null) _output[i].root_ref = root_ref_in;<%
}%>
				}
			}

			return _output;
		}
		#endregion
		#region public void SaveState_toFile(string filePath_in);
		public void SaveState_toFile(string filePath_in) {
			FileStream _file = new FileStream(
				filePath_in,
				FileMode.Create,
				FileAccess.Write,
				FileShare.ReadWrite
			);
			new XmlSerializer(typeof(<%=XS__%><%=_aux_schema.Element.Name%>)).Serialize(
				_file,
				this
			);
			_file.Flush();
			_file.Close();
#if !NET_1_1
			_file.Dispose();
#endif
		}
		#endregion
		#region public string Read_fromRoot(string what_in);
		public string Read_fromRoot(string what_in) {
			return OGen.Libraries.Generator.Utilities.ReflectThrough(
				this, <%--
				// ROOT_<%=_aux_schema.Element.Name.ToUpper()%>,
				--%>
				this.Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%>, 
				null, 
				what_in, <%--
				// ROOT_<%=_aux_schema.Element.Name.ToUpper()%>,
				--%>
				this.Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%>, 
				true, 
				true
			);
		}
		#endregion
		#region public void IterateThrough_fromRoot(...);
		public void IterateThrough_fromRoot(
			string iteration_in, 
			OGen.Libraries.Generator.IterationFound iteration_found_in,
			ref bool valueHasBeenFound_out
		) {
			OGen.Libraries.Generator.Utilities.ReflectThrough(
				this, <%--
				// ROOT_<%=_aux_schema.Element.Name.ToUpper()%>,
				--%>
				this.Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%>, 
				iteration_found_in, 
				iteration_in, <%--
				// ROOT_<%=_aux_schema.Element.Name.ToUpper()%>,
				--%>
				this.Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_schema.Element.Name, _arg_SchemaName)%>, 
				false, 
				true, 
				ref valueHasBeenFound_out
			);
		}
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>