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

namespace OGen.NTier.lib.metadata.metadataExtended {
	#if NET_1_1
	public class XS_tableFieldRefType : XS0_tableFieldRefType {
	#else
	public partial class XS_tableFieldRefType {
	#endif
		public XS_tableFieldRefType (
		) {
		}
		public XS_tableFieldRefType (
			string paramName_in
		) {
			paramname_ = paramName_in;
		}

		#region public XS_tableType Table_ref { get; }
		private XS_tableType table_ref__ = null;

		public XS_tableType Table_ref {
			get {
				if (table_ref__ == null) {
					#region Checking...
					if (TableName == string.Empty)
						throw new Exception(string.Format(
							"{0}.{1}.TableIndex(): - no ref present", 
							this.GetType().Namespace, 
							this.GetType().Name
						));
					#endregion

					table_ref__ = root_ref.MetadataExtendedCollection[0].Tables.TableCollection[TableName];
				}

				return table_ref__;
			}
		}
		#endregion
		#region public XS_tableFieldType TableField_ref { get; }
		private XS_tableFieldType tablefield_ref__ = null;

		public XS_tableFieldType TableField_ref {
			get {
				if (tablefield_ref__ == null) {
					#region Checking...
					if (
						(TableName == string.Empty)
						||
						(TableFieldName == string.Empty)
					)
						throw new Exception(string.Format(
							"{0}.{1}.FieldIndex(): - no ref present", 
							this.GetType().Namespace, 
							this.GetType().Name
						));
					#endregion

					tablefield_ref__ = table_ref__.TableFields.TableFieldCollection[TableFieldName];
				}

				return tablefield_ref__;
			}
		}
		#endregion
	}
}
