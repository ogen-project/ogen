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
	using OGen.lib.datalayer;

	#if NET_1_1
	public class XS_dbsType : XS0_dbsType {
	#else
	public partial class XS_dbsType {
	#endif

		#region public bool supports_SQLServer { get; }
		[XmlIgnore()]
		[XmlAttribute("supports_SQLServer")]
		public bool Supports_SQLServer {
			get {
				for (int d = 0; d < this.DBCollection.Count; d++) {
					if (this.DBCollection[d].DBServerType == DBServerTypes.SQLServer.ToString()) {
						return true;
					}
				}
				return false;
			}
		}
		#endregion
		#region public bool supports_PostgreSQL { get; }
		[XmlIgnore()]
		[XmlAttribute("supports_PostgreSQL")]
		public bool Supports_PostgreSQL {
			get {
#if PostgreSQL
				for (int d = 0; d < this.DBCollection.Count; d++) {
					if (this.DBCollection[d].DBServerType == DBServerTypes.PostgreSQL.ToString()) {
						return true;
					}
				}
#endif
				return false;
			}
		}
		#endregion
		#region public bool supports_MySQL { get; }
		[XmlIgnore()]
		[XmlAttribute("supports_MySQL")]
		public bool Supports_MySQL {
			get {
#if MySQL
				for (int d = 0; d < DBCollection.Count; d++) {
					if (DBCollection[d].DBServerType == DBServerTypes.MySQL.ToString()) {
						return true;
					}
				}
#endif
				return false;
			}
		}
		#endregion

		#region public string[] SupportedDBServerTypes();
		public string[] SupportedDBServerTypes() {
			ArrayList _dbservertypes = new ArrayList();
			for (int d = 0; d < this.DBCollection.Count; d++) {
				if (!_dbservertypes.Contains(
					this.DBCollection[d].DBServerType
				))
					_dbservertypes.Add(this.DBCollection[d].DBServerType);
			}

			return (string[])_dbservertypes.ToArray(typeof(string));
		}
		#endregion
	}
}
