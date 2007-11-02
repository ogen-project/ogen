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

using OGen.lib.collections;

namespace OGen.NTier.lib.metadata.metadataDB {
	public class XS_tableFieldType : XS0_tableFieldType {
		#region public XS_tableFieldType(...);
		public XS_tableFieldType(
		) : base (
		) {
		}
		public XS_tableFieldType(
			string name_in
		) : base (
			name_in
		) {
		}
		#endregion

		#region public bool isBool { get; }
		[XmlIgnore()]
		public bool isBool {
			get {
//				return OGen.lib.datalayer.utils.isBool(DBType_generic.Value);
				return TableFieldDBs.TableFieldDBCollection[0].isBool;
			}
		}
		#endregion
		#region public bool isDateTime { get; }
		[XmlIgnore()]
		public bool isDateTime {
			get {
//				return OGen.lib.datalayer.utils.isDateTime(DBType_generic.Value);
				return TableFieldDBs.TableFieldDBCollection[0].isDateTime;
			}
		}
		#endregion
		#region public bool isInt { get; }
		[XmlIgnore()]
		public bool isInt {
			get {
//				return OGen.lib.datalayer.utils.isInt(DBType_generic.Value);
				return TableFieldDBs.TableFieldDBCollection[0].isInt;
			}
		}
		#endregion
		#region public bool isDecimal { get; }
		[XmlIgnore()]
		public bool isDecimal {
			get {
//				return OGen.lib.datalayer.utils.isDecimal(DBType_generic.Value);
				return TableFieldDBs.TableFieldDBCollection[0].isDecimal;
			}
		}
		#endregion
		#region public bool isText { get; }
		[XmlIgnore()]
		public bool isText {
			get {
//				return OGen.lib.datalayer.utils.isText(DBType_generic.Value);
				return TableFieldDBs.TableFieldDBCollection[0].isText;
			}
		}
		#endregion

		#region public bool canBeConfig_... { get; }
		[XmlIgnore()]
		public bool canBeConfig_Name {
			get { return isText && isPK; }
		}

		[XmlIgnore()]
		public bool canBeConfig_Config {
			get { return isText && !isPK; }
		}

		[XmlIgnore()]
		public bool canBeConfig_Type {
			get { return isInt && !isPK; }
		}
		#endregion
	}
}
