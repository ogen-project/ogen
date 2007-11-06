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
	public class XS0_dbType {
	#else
	public partial class XS_dbType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (dbconnections__ != null) dbconnections__.parent_ref = this;
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
				if (dbconnections__ != null) dbconnections__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string DBServerType { get; set; }
		internal string dbservertype_;

		[XmlAttribute("dbServerType")]
		public string DBServerType {
			get {
				return dbservertype_;
			}
			set {
				dbservertype_ = value;
			}
		}
		#endregion
		#region public XS_dbConnectionsType DBConnections { get; set; }
		internal XS_dbConnectionsType dbconnections__;

		[XmlIgnore()]
		public XS_dbConnectionsType DBConnections {
			get {
				if (dbconnections__ == null) {
					dbconnections__ = new XS_dbConnectionsType();
				}
				return dbconnections__;
			}
			set {
				dbconnections__ = value;
			}
		}

		[XmlElement("dbConnections")]
		public XS_dbConnectionsType dbconnections__xml {
			get { return dbconnections__; }
			set { dbconnections__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_dbType dbType_in) {
			int _index = -1;

			dbservertype_ = dbType_in.dbservertype_;
			if (dbType_in.dbconnections__ != null) dbconnections__.CopyFrom(dbType_in.dbconnections__);
		}
		#endregion
	}
}