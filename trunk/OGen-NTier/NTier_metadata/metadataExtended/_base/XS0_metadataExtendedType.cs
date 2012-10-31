#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.lib.metadata.metadataExtended {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

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
				this.parent_ref_ = value;
				if (this.dbs__ != null) this.dbs__.parent_ref = this;
				if (this.tables__ != null) this.tables__.parent_ref = this;
			}
			get { return this.parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				this.root_ref_ = value;
				if (this.dbs__ != null) this.dbs__.root_ref = value;
				if (this.tables__ != null) this.tables__.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string ApplicationName { get; set; }
		internal string applicationname_;

		[XmlAttribute("applicationName")]
		public string ApplicationName {
			get {
				return this.applicationname_;
			}
			set {
				this.applicationname_ = value;
			}
		}
		#endregion
		#region public string ApplicationNamespace { get; set; }
		internal string applicationnamespace_;

		[XmlAttribute("applicationNamespace")]
		public string ApplicationNamespace {
			get {
				return this.applicationnamespace_;
			}
			set {
				this.applicationnamespace_ = value;
			}
		}
		#endregion
		#region public string SubAppName { get; set; }
		internal string subappname_;

		[XmlAttribute("subAppName")]
		public string SubAppName {
			get {
				return this.subappname_;
			}
			set {
				this.subappname_ = value;
			}
		}
		#endregion
		#region public string PseudoReflectionable { get; set; }
		internal string pseudoreflectionable_;

		[XmlAttribute("pseudoReflectionable")]
		public string PseudoReflectionable {
			get {
				return this.pseudoreflectionable_;
			}
			set {
				this.pseudoreflectionable_ = value;
			}
		}
		#endregion
		#region public XS_SQLScriptOptionEnumeration SQLScriptOption { get; set; }
		internal XS_SQLScriptOptionEnumeration sqlscriptoption_;

		[XmlAttribute("sqlScriptOption")]
		public XS_SQLScriptOptionEnumeration SQLScriptOption {
			get {
				return this.sqlscriptoption_;
			}
			set {
				this.sqlscriptoption_ = value;
			}
		}
		#endregion
		#region public string GUIDDatalayer { get; set; }
		internal string guiddatalayer_;

		[XmlAttribute("guidDatalayer")]
		public string GUIDDatalayer {
			get {
				return this.guiddatalayer_;
			}
			set {
				this.guiddatalayer_ = value;
			}
		}
		#endregion
		#region public string GUIDDatalayer_proxy { get; set; }
		internal string guiddatalayer_proxy_;

		[XmlAttribute("guidDatalayer_proxy")]
		public string GUIDDatalayer_proxy {
			get {
				return this.guiddatalayer_proxy_;
			}
			set {
				this.guiddatalayer_proxy_ = value;
			}
		}
		#endregion
		#region public string GUIDDatalayer_UTs { get; set; }
		internal string guiddatalayer_uts_;

		[XmlAttribute("guidDatalayer_UTs")]
		public string GUIDDatalayer_UTs {
			get {
				return this.guiddatalayer_uts_;
			}
			set {
				this.guiddatalayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUIDBusinesslayer { get; set; }
		internal string guidbusinesslayer_;

		[XmlAttribute("guidBusinesslayer")]
		public string GUIDBusinesslayer {
			get {
				return this.guidbusinesslayer_;
			}
			set {
				this.guidbusinesslayer_ = value;
			}
		}
		#endregion
		#region public string GUIDBusinesslayer_proxy { get; set; }
		internal string guidbusinesslayer_proxy_;

		[XmlAttribute("guidBusinesslayer_proxy")]
		public string GUIDBusinesslayer_proxy {
			get {
				return this.guidbusinesslayer_proxy_;
			}
			set {
				this.guidbusinesslayer_proxy_ = value;
			}
		}
		#endregion
		#region public string GUIDBusinesslayer_UTs { get; set; }
		internal string guidbusinesslayer_uts_;

		[XmlAttribute("guidBusinesslayer_UTs")]
		public string GUIDBusinesslayer_UTs {
			get {
				return this.guidbusinesslayer_uts_;
			}
			set {
				this.guidbusinesslayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUIDBusiness_client { get; set; }
		internal string guidbusiness_client_;

		[XmlAttribute("guidBusiness_client")]
		public string GUIDBusiness_client {
			get {
				return this.guidbusiness_client_;
			}
			set {
				this.guidbusiness_client_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_webservices_server { get; set; }
		internal string guiddistributedlayer_webservices_server_;

		[XmlAttribute("guidDistributedlayer_webservices_server")]
		public string GUIDDistributedlayer_webservices_server {
			get {
				return this.guiddistributedlayer_webservices_server_;
			}
			set {
				this.guiddistributedlayer_webservices_server_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_webservices_client { get; set; }
		internal string guiddistributedlayer_webservices_client_;

		[XmlAttribute("guidDistributedlayer_webservices_client")]
		public string GUIDDistributedlayer_webservices_client {
			get {
				return this.guiddistributedlayer_webservices_client_;
			}
			set {
				this.guiddistributedlayer_webservices_client_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_remoting_server { get; set; }
		internal string guiddistributedlayer_remoting_server_;

		[XmlAttribute("guidDistributedlayer_remoting_server")]
		public string GUIDDistributedlayer_remoting_server {
			get {
				return this.guiddistributedlayer_remoting_server_;
			}
			set {
				this.guiddistributedlayer_remoting_server_ = value;
			}
		}
		#endregion
		#region public string GUIDDistributedlayer_remoting_client { get; set; }
		internal string guiddistributedlayer_remoting_client_;

		[XmlAttribute("guidDistributedlayer_remoting_client")]
		public string GUIDDistributedlayer_remoting_client {
			get {
				return this.guiddistributedlayer_remoting_client_;
			}
			set {
				this.guiddistributedlayer_remoting_client_ = value;
			}
		}
		#endregion
		#region public string GUIDTest { get; set; }
		internal string guidtest_;

		[XmlAttribute("guidTest")]
		public string GUIDTest {
			get {
				return this.guidtest_;
			}
			set {
				this.guidtest_ = value;
			}
		}
		#endregion
		#region public string GUID_datalayer { get; set; }
		internal string guid_datalayer_;

		[XmlAttribute("guid_datalayer")]
		public string GUID_datalayer {
			get {
				return this.guid_datalayer_;
			}
			set {
				this.guid_datalayer_ = value;
			}
		}
		#endregion
		#region public string GUID_datalayer_structures { get; set; }
		internal string guid_datalayer_structures_;

		[XmlAttribute("guid_datalayer_structures")]
		public string GUID_datalayer_structures {
			get {
				return this.guid_datalayer_structures_;
			}
			set {
				this.guid_datalayer_structures_ = value;
			}
		}
		#endregion
		#region public string GUID_datalayer_uts { get; set; }
		internal string guid_datalayer_uts_;

		[XmlAttribute("guid_datalayer_uts")]
		public string GUID_datalayer_uts {
			get {
				return this.guid_datalayer_uts_;
			}
			set {
				this.guid_datalayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer { get; set; }
		internal string guid_businesslayer_;

		[XmlAttribute("guid_businesslayer")]
		public string GUID_businesslayer {
			get {
				return this.guid_businesslayer_;
			}
			set {
				this.guid_businesslayer_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_structures { get; set; }
		internal string guid_businesslayer_structures_;

		[XmlAttribute("guid_businesslayer_structures")]
		public string GUID_businesslayer_structures {
			get {
				return this.guid_businesslayer_structures_;
			}
			set {
				this.guid_businesslayer_structures_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_shared { get; set; }
		internal string guid_businesslayer_shared_;

		[XmlAttribute("guid_businesslayer_shared")]
		public string GUID_businesslayer_shared {
			get {
				return this.guid_businesslayer_shared_;
			}
			set {
				this.guid_businesslayer_shared_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_instances { get; set; }
		internal string guid_businesslayer_instances_;

		[XmlAttribute("guid_businesslayer_instances")]
		public string GUID_businesslayer_instances {
			get {
				return this.guid_businesslayer_instances_;
			}
			set {
				this.guid_businesslayer_instances_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_instances_remotingclient { get; set; }
		internal string guid_businesslayer_instances_remotingclient_;

		[XmlAttribute("guid_businesslayer_instances_remotingclient")]
		public string GUID_businesslayer_instances_remotingclient {
			get {
				return this.guid_businesslayer_instances_remotingclient_;
			}
			set {
				this.guid_businesslayer_instances_remotingclient_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_instances_webservicesclient { get; set; }
		internal string guid_businesslayer_instances_webservicesclient_;

		[XmlAttribute("guid_businesslayer_instances_webservicesclient")]
		public string GUID_businesslayer_instances_webservicesclient {
			get {
				return this.guid_businesslayer_instances_webservicesclient_;
			}
			set {
				this.guid_businesslayer_instances_webservicesclient_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_instances_businessobject { get; set; }
		internal string guid_businesslayer_instances_businessobject_;

		[XmlAttribute("guid_businesslayer_instances_businessobject")]
		public string GUID_businesslayer_instances_businessobject {
			get {
				return this.guid_businesslayer_instances_businessobject_;
			}
			set {
				this.guid_businesslayer_instances_businessobject_ = value;
			}
		}
		#endregion
		#region public string GUID_businesslayer_uts { get; set; }
		internal string guid_businesslayer_uts_;

		[XmlAttribute("guid_businesslayer_uts")]
		public string GUID_businesslayer_uts {
			get {
				return this.guid_businesslayer_uts_;
			}
			set {
				this.guid_businesslayer_uts_ = value;
			}
		}
		#endregion
		#region public string GUID_remoting_server { get; set; }
		internal string guid_remoting_server_;

		[XmlAttribute("guid_remoting_server")]
		public string GUID_remoting_server {
			get {
				return this.guid_remoting_server_;
			}
			set {
				this.guid_remoting_server_ = value;
			}
		}
		#endregion
		#region public string GUID_remoting_simpleserver { get; set; }
		internal string guid_remoting_simpleserver_;

		[XmlAttribute("guid_remoting_simpleserver")]
		public string GUID_remoting_simpleserver {
			get {
				return this.guid_remoting_simpleserver_;
			}
			set {
				this.guid_remoting_simpleserver_ = value;
			}
		}
		#endregion
		#region public string GUID_remoting_client { get; set; }
		internal string guid_remoting_client_;

		[XmlAttribute("guid_remoting_client")]
		public string GUID_remoting_client {
			get {
				return this.guid_remoting_client_;
			}
			set {
				this.guid_remoting_client_ = value;
			}
		}
		#endregion
		#region public string GUID_webservices_server { get; set; }
		internal string guid_webservices_server_;

		[XmlAttribute("guid_webservices_server")]
		public string GUID_webservices_server {
			get {
				return this.guid_webservices_server_;
			}
			set {
				this.guid_webservices_server_ = value;
			}
		}
		#endregion
		#region public string GUID_webservices_client { get; set; }
		internal string guid_webservices_client_;

		[XmlAttribute("guid_webservices_client")]
		public string GUID_webservices_client {
			get {
				return this.guid_webservices_client_;
			}
			set {
				this.guid_webservices_client_ = value;
			}
		}
		#endregion
		#region public string GUID_test { get; set; }
		internal string guid_test_;

		[XmlAttribute("guid_test")]
		public string GUID_test {
			get {
				return this.guid_test_;
			}
			set {
				this.guid_test_ = value;
			}
		}
		#endregion
		#region public string RemotingServer_ServerURI { get; set; }
		internal string remotingserver_serveruri_;

		[XmlAttribute("remotingServer_ServerURI")]
		public string RemotingServer_ServerURI {
			get {
				return this.remotingserver_serveruri_;
			}
			set {
				this.remotingserver_serveruri_ = value;
			}
		}
		#endregion
		#region public string RemotingServer_ServerPort { get; set; }
		internal string remotingserver_serverport_;

		[XmlAttribute("remotingServer_ServerPort")]
		public string RemotingServer_ServerPort {
			get {
				return this.remotingserver_serverport_;
			}
			set {
				this.remotingserver_serverport_ = value;
			}
		}
		#endregion
		#region public string Webservices_ServerURI { get; set; }
		internal string webservices_serveruri_;

		[XmlAttribute("webservices_ServerURI")]
		public string Webservices_ServerURI {
			get {
				return this.webservices_serveruri_;
			}
			set {
				this.webservices_serveruri_ = value;
			}
		}
		#endregion
		#region public string Webservices_ServerPort { get; set; }
		internal string webservices_serverport_;

		[XmlAttribute("webservices_ServerPort")]
		public string Webservices_ServerPort {
			get {
				return this.webservices_serverport_;
			}
			set {
				this.webservices_serverport_ = value;
			}
		}
		#endregion
		#region public string FeedbackEmailAddress { get; set; }
		internal string feedbackemailaddress_;

		[XmlAttribute("feedbackEmailAddress")]
		public string FeedbackEmailAddress {
			get {
				return this.feedbackemailaddress_;
			}
			set {
				this.feedbackemailaddress_ = value;
			}
		}
		#endregion
		#region public string CopyrightText { get; set; }
		internal string copyrighttext_;

		[XmlAttribute("copyrightText")]
		public string CopyrightText {
			get {
				return this.copyrighttext_;
			}
			set {
				this.copyrighttext_ = value;
			}
		}
		#endregion
		#region public string CopyrightTextLong { get; set; }
		internal string copyrighttextlong_;

		[XmlElement("copyrightTextLong")]
		public string CopyrightTextLong {
			get {
// ToDos: here!
				return (this.copyrighttextlong_.IndexOf("\r\n") >= 0)
					? this.copyrighttextlong_
					: this.copyrighttextlong_.Replace("\n", "\r\n");
			}
			set { this.copyrighttextlong_ = value; }
		}
		#endregion
		#region public XS_dbsType DBs { get; set; }
		internal XS_dbsType dbs__;
		internal object dbs__locker = new object();

		[XmlIgnore()]
		public XS_dbsType DBs {
			get {

				// check before lock
				if (this.dbs__ == null) {

					lock (this.dbs__locker) {

						// double check, thread safer!
						if (this.dbs__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.dbs__ = new XS_dbsType();
						}
					}
				}

				return this.dbs__;
			}
			set {
				this.dbs__ = value;
			}
		}

		[XmlElement("dbs")]
		public XS_dbsType dbs__xml {
			get { return this.dbs__; }
			set { this.dbs__ = value; }
		}
		#endregion
		#region public XS_tablesType Tables { get; set; }
		internal XS_tablesType tables__;
		internal object tables__locker = new object();

		[XmlIgnore()]
		public XS_tablesType Tables {
			get {

				// check before lock
				if (this.tables__ == null) {

					lock (this.tables__locker) {

						// double check, thread safer!
						if (this.tables__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tables__ = new XS_tablesType();
						}
					}
				}

				return this.tables__;
			}
			set {
				this.tables__ = value;
			}
		}

		[XmlElement("tables")]
		public XS_tablesType tables__xml {
			get { return this.tables__; }
			set { this.tables__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_metadataExtendedType metadataExtendedType_in) {
			this.applicationname_ = metadataExtendedType_in.applicationname_;
			this.applicationnamespace_ = metadataExtendedType_in.applicationnamespace_;
			this.subappname_ = metadataExtendedType_in.subappname_;
			this.pseudoreflectionable_ = metadataExtendedType_in.pseudoreflectionable_;
			this.sqlscriptoption_ = metadataExtendedType_in.sqlscriptoption_;
			this.guiddatalayer_ = metadataExtendedType_in.guiddatalayer_;
			this.guiddatalayer_proxy_ = metadataExtendedType_in.guiddatalayer_proxy_;
			this.guiddatalayer_uts_ = metadataExtendedType_in.guiddatalayer_uts_;
			this.guidbusinesslayer_ = metadataExtendedType_in.guidbusinesslayer_;
			this.guidbusinesslayer_proxy_ = metadataExtendedType_in.guidbusinesslayer_proxy_;
			this.guidbusinesslayer_uts_ = metadataExtendedType_in.guidbusinesslayer_uts_;
			this.guidbusiness_client_ = metadataExtendedType_in.guidbusiness_client_;
			this.guiddistributedlayer_webservices_server_ = metadataExtendedType_in.guiddistributedlayer_webservices_server_;
			this.guiddistributedlayer_webservices_client_ = metadataExtendedType_in.guiddistributedlayer_webservices_client_;
			this.guiddistributedlayer_remoting_server_ = metadataExtendedType_in.guiddistributedlayer_remoting_server_;
			this.guiddistributedlayer_remoting_client_ = metadataExtendedType_in.guiddistributedlayer_remoting_client_;
			this.guidtest_ = metadataExtendedType_in.guidtest_;
			this.guid_datalayer_ = metadataExtendedType_in.guid_datalayer_;
			this.guid_datalayer_structures_ = metadataExtendedType_in.guid_datalayer_structures_;
			this.guid_datalayer_uts_ = metadataExtendedType_in.guid_datalayer_uts_;
			this.guid_businesslayer_ = metadataExtendedType_in.guid_businesslayer_;
			this.guid_businesslayer_structures_ = metadataExtendedType_in.guid_businesslayer_structures_;
			this.guid_businesslayer_shared_ = metadataExtendedType_in.guid_businesslayer_shared_;
			this.guid_businesslayer_instances_ = metadataExtendedType_in.guid_businesslayer_instances_;
			this.guid_businesslayer_instances_remotingclient_ = metadataExtendedType_in.guid_businesslayer_instances_remotingclient_;
			this.guid_businesslayer_instances_webservicesclient_ = metadataExtendedType_in.guid_businesslayer_instances_webservicesclient_;
			this.guid_businesslayer_instances_businessobject_ = metadataExtendedType_in.guid_businesslayer_instances_businessobject_;
			this.guid_businesslayer_uts_ = metadataExtendedType_in.guid_businesslayer_uts_;
			this.guid_remoting_server_ = metadataExtendedType_in.guid_remoting_server_;
			this.guid_remoting_simpleserver_ = metadataExtendedType_in.guid_remoting_simpleserver_;
			this.guid_remoting_client_ = metadataExtendedType_in.guid_remoting_client_;
			this.guid_webservices_server_ = metadataExtendedType_in.guid_webservices_server_;
			this.guid_webservices_client_ = metadataExtendedType_in.guid_webservices_client_;
			this.guid_test_ = metadataExtendedType_in.guid_test_;
			this.remotingserver_serveruri_ = metadataExtendedType_in.remotingserver_serveruri_;
			this.remotingserver_serverport_ = metadataExtendedType_in.remotingserver_serverport_;
			this.webservices_serveruri_ = metadataExtendedType_in.webservices_serveruri_;
			this.webservices_serverport_ = metadataExtendedType_in.webservices_serverport_;
			this.feedbackemailaddress_ = metadataExtendedType_in.feedbackemailaddress_;
			this.copyrighttext_ = metadataExtendedType_in.copyrighttext_;
			this.copyrighttextlong_ = metadataExtendedType_in.copyrighttextlong_;
			if (metadataExtendedType_in.dbs__ != null) this.dbs__.CopyFrom(metadataExtendedType_in.dbs__);
			if (metadataExtendedType_in.tables__ != null) this.tables__.CopyFrom(metadataExtendedType_in.tables__);
		}
		#endregion
	}
}