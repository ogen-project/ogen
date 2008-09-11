#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.IO;
using System.Collections;
using System.Xml;

namespace OGen.lib.collections {
	public abstract class cClaSS__base : iClaSS {
		public abstract object Property_new(string name_in);

		#region public void SaveState_toFile(string fileName_in, string objectName_in);
		public void SaveState_toFile(string fileName_in, string objectName_in) {
			#region Directory.CreateDirectory(fileName_in);
			string _directory = System.IO.Path.GetDirectoryName(fileName_in);
			if (!System.IO.Directory.Exists(_directory)) {
				System.IO.Directory.CreateDirectory(
					_directory
				);
			}
			#endregion

			XmlDocument _xmlDoc = new XmlDocument();
			_xmlDoc.AppendChild(
				SaveState_toFile(_xmlDoc, objectName_in)
			);
			#region _xmlDoc.Save(new FileStream(fileName_in));
			XmlTextWriter _xmlFile = new XmlTextWriter(
				fileName_in,
				System.Text.Encoding.UTF8
			);
			//FileStream _xmlFile = new FileStream(
			//    fileName_in,
			//    FileMode.Create,
			//    FileAccess.Write,
			//    FileShare.ReadWrite
			//);
			_xmlDoc.Save(_xmlFile);
			_xmlFile.Close(); _xmlFile = null;
			#endregion
			_xmlDoc = null;
		}
		#endregion
		public abstract XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in);

		#region private void LoadState_from(string objectName_in, XmlDocument xmlDoc_in);
		private void LoadState_from(string objectName_in, XmlDocument xmlDoc_in) {
			XmlNodeList _list = xmlDoc_in.GetElementsByTagName(
				objectName_in
			);
			for (int l = 0; l < _list.Count; l++) {
				LoadState_fromFile(_list[l]);
			}
		}
		#endregion
		#region public void LoadState_fromXML(string stream_in, string objectName_in);
		public void LoadState_fromXML(string stream_in, string objectName_in) {
			#region _xmlDoc.LoadXml(stream_in);
			XmlDocument _xmlDoc = new XmlDocument();
			_xmlDoc.LoadXml(stream_in);
			#endregion

			#region //oldstuff...
//			XmlNodeList _list = _xmlDoc.GetElementsByTagName(objectName_in);
//			for (int l = 0; l < _list.Count; l++) {
//				LoadState_fromFile(_list[l]);
//			}
//			_xmlDoc = null;
			#endregion
			LoadState_from(objectName_in, _xmlDoc);
		}
		#endregion
		#region public void LoadState_fromFile(string fileName_in, string objectName_in);
		public void LoadState_fromFile(string fileName_in, string objectName_in) {
			#region _xmlDoc.Load(fileName_in);
			XmlDocument _xmlDoc = new XmlDocument();

			//XmlTextReader _xmlFile = new XmlTextReader(
			//	fileName_in
			//);
			FileStream _xmlFile = new FileStream(
				fileName_in,
				FileMode.Open,
				FileAccess.Read,
				FileShare.ReadWrite
			);
			_xmlDoc.Load(_xmlFile);
			_xmlFile.Close(); _xmlFile = null;
			#endregion

			#region //oldstuff...
//			XmlNodeList _list = _xmlDoc.GetElementsByTagName(objectName_in);
//			for (int l = 0; l < _list.Count; l++) {
//				LoadState_fromFile(_list[l]);
//			}
//			_xmlDoc = null;
			#endregion
			LoadState_from(objectName_in, _xmlDoc);
		}
		#endregion
		public abstract void LoadState_fromFile(XmlNode node_in);
	}
}