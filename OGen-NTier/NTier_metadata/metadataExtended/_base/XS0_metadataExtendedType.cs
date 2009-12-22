#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Xml.Serialization;
using System.Collections;

namespace OGen.NTier.lib.metadata.metadataExtended {
	#if NET_1_1
	public class XS0_metadataExtendedType {
	#else
	public partial class XS_metadataExtendedType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (dbs__ != null) dbs__.parent_ref = this;
				if (tables__ != null) tables__.parent_ref = this;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				root_ref_ = value;
				if (dbs__ != null) dbs__.root_ref = value;
				if (tables__ != null) tables__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string ApplicationName { get; set; }
		internal string applicationname_;

		[XmlAttribute("applicationName")]
		public string ApplicationName {
			get {
				return applicationname_;
			}
			set {
				applicationname_ = value;
			}
		}
		#endregion
		#region public string ApplicationNamespace { get; set; }
		internal string applicationnamespace_;

		[XmlAttribute("applicationNamespace")]
		public string ApplicationNamespace {
			get {
				return applicationnamespace_;
			}
			set {
				applicationnamespace_ = value;
			}
		}
		#endregion
		#region public string SubAppName { get; set; }
		internal string subappname_;

		[XmlAttribute("subAppName")]
		public string SubAppName {
			get {
				return subappname_;
			}
			set {
				subappname_ = value;
			}
		}
		#endregion
		#region public string PseudoReflectionable { get; set; }
		internal string pseudoreflectionable_;

		[XmlAttribute("pseudoReflectionable")]
		public string PseudoReflectionable {
			get {
				return pseudoreflectionable_;
			}
			set {
				pseudoreflectionable_ = value;
			}
		}
		#endregion
		#region public XS_SQLScriptOptionEnumeration SQLScriptOption { get; set; }
		internal XS_SQLScriptOptionEnumeration sqlscriptoption_;

		[XmlAttribute("sqlScriptOption")]
		public XS_SQLScriptOptionEnumeration SQLScriptOption {
			get {
				return sqlscriptoption_;
			}
			set {
				sqlscriptoption_ = value;
			}
		}
		#endregion
		#region public string GUIDDatalayer { get; set; }
		internal string guiddatalayer_;

		[XmlAttribute("guidDatalayer")]
		public string GUIDDatalayer {
			get {
				return guiddatalayer_;
			}
			set {
				guiddatalayer_ = value;
			}
		}
		#endregion
		#region public string GUIDDatalayer_proxy { get; set; }
		internal string guiddatalayer_proxy_;

		[XmlAttribute("guidDatalayer_proxy")]
		public string GUIDDatalayer_proxy {
			get {
				return guiddatalayer_proxy_;
			}
			set {
				guiddatalayer_proxy_ = value;
			}
		}
		#endregion
		#region public string GUIDDatalayer_UTs { get; set; }
		internal string guiddatalayer_uts_;

		[XmlAttribute("guidDatalayer_UTs")]
		public string GUIDDatalayer_UTs {
			get {
				return guiddatalayer_uts_;
			}
			set {
				guiddatalayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUIDBusinesslayer { get; set; }
		internal string guidbusinesslayer_;

		[XmlAttribute("guidBusinesslayer")]
		public string GUIDBusinesslayer {
			get {
				return guidbusinesslayer_;
			}
			set {
				guidbusinesslayer_ = value;
			}
		}
		#endregion
		#region public string GUIDBusinesslayer_proxy { get; set; }
		internal string guidbusinesslayer_proxy_;

		[XmlAttribute("guidBusinesslayer_proxy")]
		public string GUIDBusinesslayer_proxy {
			get {
				return guidbusinesslayer_proxy_;
			}
			set {
				guidbusinesslayer_proxy_ = value;
			}
		}
		#endregion
		#region public string GUIDBusinesslayer_UTs { get; set; }
		internal string guidbusinesslayer_uts_;

		[XmlAttribute("guidBusinesslayer_UTs")]
		public string GUIDBusinesslayer_UTs {
			get {
				return guidbusinesslayer_uts_;
			}
			set {
				guidbusinesslayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUIDBusiness_client { get; set; }
		internal string guidbusiness_client_;

		[XmlAttribute("guidBusiness_client")]
		public string GUIDBusiness_client {
			get {
				return guidbusiness_client_;
			}
			set {
				guidbusiness_client_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_webservices_server { get; set; }
		internal string guiddistributedlayer_webservices_server_;

		[XmlAttribute("guidDistributedlayer_webservices_server")]
		public string GUIDDistributedlayer_webservices_server {
			get {
				return guiddistributedlayer_webservices_server_;
			}
			set {
				guiddistributedlayer_webservices_server_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_webservices_client { get; set; }
		internal string guiddistributedlayer_webservices_client_;

		[XmlAttribute("guidDistributedlayer_webservices_client")]
		public string GUIDDistributedlayer_webservices_client {
			get {
				return guiddistributedlayer_webservices_client_;
			}
			set {
				guiddistributedlayer_webservices_client_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_remoting_server { get; set; }
		internal string guiddistributedlayer_remoting_server_;

		[XmlAttribute("guidDistributedlayer_remoting_server")]
		public string GUIDDistributedlayer_remoting_server {
			get {
				return guiddistributedlayer_remoting_server_;
			}
			set {
				guiddistributedlayer_remoting_server_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_remoting_client { get; set; }
		internal string guiddistributedlayer_remoting_client_;

		[XmlAttribute("guidDistributedlayer_remoting_client")]
		public string GUIDDistributedlayer_remoting_client {
			get {
				return guiddistributedlayer_remoting_client_;
			}
			set {
				guiddistributedlayer_remoting_client_ = value;
			}
		}
		#endregion
		#region public string GUIDTest { get; set; }
		internal string guidtest_;

		[XmlAttribute("guidTest")]
		public string GUIDTest {
			get {
				return guidtest_;
			}
			set {
				guidtest_ = value;
			}
		}
		#endregion
		#region public string GUID_datalayer { get; set; }
		internal string guid_datalayer_;

		[XmlAttribute("guid_datalayer")]
		public string GUID_datalayer {
			get {
				return guid_datalayer_;
			}
			set {
				guid_datalayer_ = value;
			}
		}
		#endregion
		#region public string GUID_datalayer_structures { get; set; }
		internal string guid_datalayer_structures_;

		[XmlAttribute("guid_datalayer_structures")]
		public string GUID_datalayer_structures {
			get {
				return guid_datalayer_structures_;
			}
			set {
				guid_datalayer_structures_ = value;
			}
		}
		#endregion
		#region public string GUID_datalayer_uts { get; set; }
		internal string guid_datalayer_uts_;

		[XmlAttribute("guid_datalayer_uts")]
		public string GUID_datalayer_uts {
			get {
				return guid_datalayer_uts_;
			}
			set {
				guid_datalayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer { get; set; }
		internal string guid_businesslayer_;

		[XmlAttribute("guid_businesslayer")]
		public string GUID_businesslayer {
			get {
				return guid_businesslayer_;
			}
			set {
				guid_businesslayer_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_structures { get; set; }
		internal string guid_businesslayer_structures_;

		[XmlAttribute("guid_businesslayer_structures")]
		public string GUID_businesslayer_structures {
			get {
				return guid_businesslayer_structures_;
			}
			set {
				guid_businesslayer_structures_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_shared { get; set; }
		internal string guid_businesslayer_shared_;

		[XmlAttribute("guid_businesslayer_shared")]
		public string GUID_businesslayer_shared {
			get {
				return guid_businesslayer_shared_;
			}
			set {
				guid_businesslayer_shared_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_instances { get; set; }
		internal string guid_businesslayer_instances_;

		[XmlAttribute("guid_businesslayer_instances")]
		public string GUID_businesslayer_instances {
			get {
				return guid_businesslayer_instances_;
			}
			set {
				guid_businesslayer_instances_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_uts { get; set; }
		internal string guid_businesslayer_uts_;

		[XmlAttribute("guid_businesslayer_uts")]
		public string GUID_businesslayer_uts {
			get {
				return guid_businesslayer_uts_;
			}
			set {
				guid_businesslayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUID_remoting_server { get; set; }
		internal string guid_remoting_server_;

		[XmlAttribute("guid_remoting_server")]
		public string GUID_remoting_server {
			get {
				return guid_remoting_server_;
			}
			set {
				guid_remoting_server_ = value;
			}
		}
		#endregion
		#region public string GUID_remoting_simpleserver { get; set; }
		internal string guid_remoting_simpleserver_;

		[XmlAttribute("guid_remoting_simpleserver")]
		public string GUID_remoting_simpleserver {
			get {
				return guid_remoting_simpleserver_;
			}
			set {
				guid_remoting_simpleserver_ = value;
			}
		}
		#endregion
		#region public string GUID_remoting_client { get; set; }
		internal string guid_remoting_client_;

		[XmlAttribute("guid_remoting_client")]
		public string GUID_remoting_client {
			get {
				return guid_remoting_client_;
			}
			set {
				guid_remoting_client_ = value;
			}
		}
		#endregion
		#region public string GUID_webservices_server { get; set; }
		internal string guid_webservices_server_;

		[XmlAttribute("guid_webservices_server")]
		public string GUID_webservices_server {
			get {
				return guid_webservices_server_;
			}
			set {
				guid_webservices_server_ = value;
			}
		}
		#endregion
		#region public string GUID_webservices_client { get; set; }
		internal string guid_webservices_client_;

		[XmlAttribute("guid_webservices_client")]
		public string GUID_webservices_client {
			get {
				return guid_webservices_client_;
			}
			set {
				guid_webservices_client_ = value;
			}
		}
		#endregion
		#region public string GUID_test { get; set; }
		internal string guid_test_;

		[XmlAttribute("guid_test")]
		public string GUID_test {
			get {
				return guid_test_;
			}
			set {
				guid_test_ = value;
			}
		}
		#endregion
		#region public string FeedbackEmailAddress { get; set; }
		internal string feedbackemailaddress_;

		[XmlAttribute("feedbackEmailAddress")]
		public string FeedbackEmailAddress {
			get {
				return feedbackemailaddress_;
			}
			set {
				feedbackemailaddress_ = value;
			}
		}
		#endregion
		#region public string CopyrightText { get; set; }
		internal string copyrighttext_;

		[XmlAttribute("copyrightText")]
		public string CopyrightText {
			get {
				return copyrighttext_;
			}
			set {
				copyrighttext_ = value;
			}
		}
		#endregion
		#region public string CopyrightTextLong { get; set; }
		internal string copyrighttextlong_;

		[XmlElement("copyrightTextLong")]
		public string CopyrightTextLong {
			get {
// ToDos: here!
				return (copyrighttextlong_.IndexOf("\r\n") >= 0)
					? copyrighttextlong_
					: copyrighttextlong_.Replace("\n", "\r\n");
			}
			set { copyrighttextlong_ = value; }
		}
		#endregion
		#region public XS_dbsType DBs { get; set; }
		internal XS_dbsType dbs__;

		[XmlIgnore()]
		public XS_dbsType DBs {
			get {
				if (dbs__ == null) {
					dbs__ = new XS_dbsType();
				}
				return dbs__;
			}
			set {
				dbs__ = value;
			}
		}

		[XmlElement("dbs")]
		public XS_dbsType dbs__xml {
			get { return dbs__; }
			set { dbs__ = value; }
		}
		#endregion
		#region public XS_tablesType Tables { get; set; }
		internal XS_tablesType tables__;

		[XmlIgnore()]
		public XS_tablesType Tables {
			get {
				if (tables__ == null) {
					tables__ = new XS_tablesType();
				}
				return tables__;
			}
			set {
				tables__ = value;
			}
		}

		[XmlElement("tables")]
		public XS_tablesType tables__xml {
			get { return tables__; }
			set { tables__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_metadataExtendedType metadataExtendedType_in) {
			int _index = -1;

			applicationname_ = metadataExtendedType_in.applicationname_;
			applicationnamespace_ = metadataExtendedType_in.applicationnamespace_;
			subappname_ = metadataExtendedType_in.subappname_;
			pseudoreflectionable_ = metadataExtendedType_in.pseudoreflectionable_;
			sqlscriptoption_ = metadataExtendedType_in.sqlscriptoption_;
			guiddatalayer_ = metadataExtendedType_in.guiddatalayer_;
			guiddatalayer_proxy_ = metadataExtendedType_in.guiddatalayer_proxy_;
			guiddatalayer_uts_ = metadataExtendedType_in.guiddatalayer_uts_;
			guidbusinesslayer_ = metadataExtendedType_in.guidbusinesslayer_;
			guidbusinesslayer_proxy_ = metadataExtendedType_in.guidbusinesslayer_proxy_;
			guidbusinesslayer_uts_ = metadataExtendedType_in.guidbusinesslayer_uts_;
			guidbusiness_client_ = metadataExtendedType_in.guidbusiness_client_;
			guiddistributedlayer_webservices_server_ = metadataExtendedType_in.guiddistributedlayer_webservices_server_;
			guiddistributedlayer_webservices_client_ = metadataExtendedType_in.guiddistributedlayer_webservices_client_;
			guiddistributedlayer_remoting_server_ = metadataExtendedType_in.guiddistributedlayer_remoting_server_;
			guiddistributedlayer_remoting_client_ = metadataExtendedType_in.guiddistributedlayer_remoting_client_;
			guidtest_ = metadataExtendedType_in.guidtest_;
			guid_datalayer_ = metadataExtendedType_in.guid_datalayer_;
			guid_datalayer_structures_ = metadataExtendedType_in.guid_datalayer_structures_;
			guid_datalayer_uts_ = metadataExtendedType_in.guid_datalayer_uts_;
			guid_businesslayer_ = metadataExtendedType_in.guid_businesslayer_;
			guid_businesslayer_structures_ = metadataExtendedType_in.guid_businesslayer_structures_;
			guid_businesslayer_shared_ = metadataExtendedType_in.guid_businesslayer_shared_;
			guid_businesslayer_instances_ = metadataExtendedType_in.guid_businesslayer_instances_;
			guid_businesslayer_uts_ = metadataExtendedType_in.guid_businesslayer_uts_;
			guid_remoting_server_ = metadataExtendedType_in.guid_remoting_server_;
			guid_remoting_simpleserver_ = metadataExtendedType_in.guid_remoting_simpleserver_;
			guid_remoting_client_ = metadataExtendedType_in.guid_remoting_client_;
			guid_webservices_server_ = metadataExtendedType_in.guid_webservices_server_;
			guid_webservices_client_ = metadataExtendedType_in.guid_webservices_client_;
			guid_test_ = metadataExtendedType_in.guid_test_;
			feedbackemailaddress_ = metadataExtendedType_in.feedbackemailaddress_;
			copyrighttext_ = metadataExtendedType_in.copyrighttext_;copyrighttextlong_ = metadataExtendedType_in.copyrighttextlong_;
			if (metadataExtendedType_in.dbs__ != null) dbs__.CopyFrom(metadataExtendedType_in.dbs__);
			if (metadataExtendedType_in.tables__ != null) tables__.CopyFrom(metadataExtendedType_in.tables__);
		}
		#endregion
	}
}