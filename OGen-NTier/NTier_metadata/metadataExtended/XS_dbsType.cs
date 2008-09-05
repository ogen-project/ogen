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

namespace OGen.NTier.lib.metadata.metadataExtended {
	#if NET_1_1
	public class XS_dbsType : XS0_dbsType {
	#else
	public partial class XS_dbsType {
	#endif

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
