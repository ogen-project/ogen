#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.XSD.Libraries.Metadata.Schema {
	using System;
	using System.Xml.Serialization;

#if NET_1_1
	public struct ComplexTypeItem {
#else
	public struct ComplexTypeItem : IEquatable<ComplexTypeItem> {
#endif
		public ComplexTypeItem(
			string name_in,
			string nType_in,
			bool caseSensitive_in
		) {
			this.Name = name_in;
			this.NType = nType_in;
			this.CaseSensitive = caseSensitive_in;
		}

		public string NType;
		public string Name;
		public bool CaseSensitive;

#if NET_1_1
#else
		public override int GetHashCode() {
			unchecked {
				int _output = 17;
				_output = _output * 23 + this.NType.GetHashCode();
				_output = _output * 23 + this.Name.GetHashCode();
				_output = _output * 23 + this.CaseSensitive.GetHashCode();
				return _output;
			}
		}
		public bool Equals(ComplexTypeItem other) {
			return
				(other.NType.Equals(this.NType)) &&
				(other.Name.Equals(this.Name)) &&
				(other.CaseSensitive.Equals(this.CaseSensitive));
		}
		public override bool Equals(object obj) {
			if (!(obj is ComplexTypeItem))
				return false;

			return Equals((ComplexTypeItem)obj);
		}

		public static bool operator ==(ComplexTypeItem aux1, ComplexTypeItem aux2) {
			return aux1.Equals(aux2);
		}

		public static bool operator !=(ComplexTypeItem aux1, ComplexTypeItem aux2) {
			return !aux1.Equals(aux2);
		}
#endif
	}

	#if NET_1_1
	public class XS_elementType : XS0_elementType {
	#else
	public partial class XS_elementType {
	#endif
		public XS_elementType (
		) {
		}
		public XS_elementType (
			string name_in
		) {
			this.name_ = name_in;
		}

		#region public bool isCollection(...);
		public bool isCollection(
			string schemaName_in, 
			out ComplexTypeItem[] complexTypeCollection_out
		) {
			complexTypeCollection_out = null;

			OGen.XSD.Libraries.Metadata.Metadata.XS_complexTypeType _complextype
				= this.root_ref.MetadataCollection[0].ComplexTypeCollection[
					this.Type
				];

			if (_complextype != null) {
				XS__schema _schema = this.root_ref_.SchemaCollection[schemaName_in];

				for (int c = 0; c < _schema.ComplexTypeCollection.Count; c++) {
					if (
						_schema.ComplexTypeCollection[c].Name
						==
						_complextype.Name
					) {
						complexTypeCollection_out = new ComplexTypeItem[_complextype.ComplexTypeKeyCollection.Count];
						for (int k = 0; k < _complextype.ComplexTypeKeyCollection.Count; k++) {
							for (int a = 0; a < _schema.ComplexTypeCollection[c].AttributeCollection.Count; a++) {
								if (
									_schema.ComplexTypeCollection[c].AttributeCollection[a].Name 
									== 
									_complextype.ComplexTypeKeyCollection[k].Name
								) {
									complexTypeCollection_out[k] = new ComplexTypeItem(
										_schema.ComplexTypeCollection[c].AttributeCollection[a].Name,
										_schema.ComplexTypeCollection[c].AttributeCollection[a].NType(schemaName_in),
										_complextype.ComplexTypeKeyCollection[k].caseSensitive
									);
									break;
								}
							}
						}
						return true;
					}
				}
			}
			return false;
		}
		#endregion
	}
}
