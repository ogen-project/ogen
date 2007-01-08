#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

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