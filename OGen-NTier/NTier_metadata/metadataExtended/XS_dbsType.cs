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
using OGen.lib.datalayer;

namespace OGen.NTier.lib.metadata.metadataExtended {
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
				for (int d = 0; d < DBCollection.Count; d++) {
					if (DBCollection[d].DBServerType == DBServerTypes.SQLServer.ToString()) {
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
				for (int d = 0; d < DBCollection.Count; d++) {
					if (DBCollection[d].DBServerType == DBServerTypes.PostgreSQL.ToString()) {
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

		#region public XS_dbType DBConnection_FirstDefaultAvailable { get; }
		private XS_dbConnectionType dbconnection_firstdefaultavailable__ = null;

		public XS_dbConnectionType DBConnection_FirstDefaultAvailable {
			get {
				if (dbconnection_firstdefaultavailable__ == null) {
					for (int d = 0; d < DBCollection.Count; d++) {
						for (int dd = 0; dd < DBCollection[d].DBConnections.DBConnectionCollection.Count; dd++) {
							if (DBCollection[d].DBConnections.DBConnectionCollection[dd].isDefault) {
								db_firstdefaultavailable__ 
									= DBCollection[d];
								dbconnection_firstdefaultavailable__ 
									= DBCollection[d].DBConnections.DBConnectionCollection[dd];

								return dbconnection_firstdefaultavailable__;
							}
						}
					}
				}

				return dbconnection_firstdefaultavailable__;
			}
		}
		#endregion
		#region public XS_dbType DB_FirstDefaultAvailable { get; }
		private XS_dbType db_firstdefaultavailable__ = null;

		public XS_dbType DB_FirstDefaultAvailable {
			get {
				if (db_firstdefaultavailable__ == null) {
					XS_dbConnectionType _aux = DBConnection_FirstDefaultAvailable;
				}

				return db_firstdefaultavailable__;
			}
		}
		#endregion

		#region public string[] ConfigModes();
		public string[] ConfigModes() {
			string _configmodes = string.Empty;

			for (int i = 0; i < DBCollection.Count; i++) {
				for (int j = 0; j < DBCollection[i].DBConnections.DBConnectionCollection.Count; j++) {
					if (_configmodes.IndexOf(string.Format(
						"{0}:",
						DBCollection[i].DBConnections.DBConnectionCollection[j].ConfigMode
					)) < 0) {
						_configmodes += string.Format(
							"{0}:",
							DBCollection[i].DBConnections.DBConnectionCollection[j].ConfigMode
						);
					}
				}
			}
			if (_configmodes.Length > 0)
				_configmodes = _configmodes.Substring(0, _configmodes.Length - 1);

			return _configmodes.Split(':');
		}
		#endregion
	}
}
