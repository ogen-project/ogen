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
	using System.Xml.Serialization;

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
			this.paramname_ = paramName_in;
		}

		#region public XS_tableType Table_ref { get; }
		private XS_tableType table_ref__ = null;
		private object table_ref__locker = new object();

		public XS_tableType Table_ref {
			get {

				// check before lock
				if (this.table_ref__ == null) {

					lock (this.table_ref__locker) {

						// double check, thread safer!
						if (this.table_ref__ == null) {

							// initialization...
							#region Checking...
							if (string.IsNullOrEmpty(this.TableName))
								throw new Exception(string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"{0}.{1}.TableIndex(): - no ref present",
									this.GetType().Namespace,
									this.GetType().Name
								));
							#endregion

							// ...attribution (last thing before unlock)
							this.table_ref__
								= this.root_ref.MetadataExtendedCollection[0].Tables.TableCollection[
									this.TableName
								];
						}
					}
				}

				return this.table_ref__;
			}
		}
		#endregion
		#region public XS_tableFieldType TableField_ref { get; }
		private XS_tableFieldType tablefield_ref__ = null;
		private object tablefield_ref__locker = new object();

		public XS_tableFieldType TableField_ref {
			get {

				// check before lock
				if (this.tablefield_ref__ == null) {

					lock (this.tablefield_ref__locker) {

						// double check, thread safer!
						if (this.tablefield_ref__ == null) {

							// initialization...
							#region Checking...
							if (
								string.IsNullOrEmpty(this.TableName)
								||
								string.IsNullOrEmpty(this.TableFieldName)
							)
								throw new Exception(string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"{0}.{1}.FieldIndex(): - no ref present",
									this.GetType().Namespace,
									this.GetType().Name
								));
							#endregion

							// ...attribution (last thing before unlock)
							this.tablefield_ref__
								= this.Table_ref.TableFields.TableFieldCollection[
									this.TableFieldName
								];
						}
					}
				}

				return this.tablefield_ref__;
			}
		}
		#endregion
	}
}
