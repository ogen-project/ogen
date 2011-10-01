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

namespace OGen.XSD.lib.metadata.schema {
	#if NET_1_1
	public class XS_complexTypeType : XS0_complexTypeType {
	#else
	public partial class XS_complexTypeType {
	#endif
		public XS_complexTypeType (
		) {
		}
		public XS_complexTypeType (
			string name_in
		) {
			name_ = name_in;
		}

		#region public bool mustImplementCollection(...);
		public bool mustImplementCollection(
			string schemaName_in, 
			out ComplexTypeItem[] complexTypeCollection_out
		) {
			complexTypeCollection_out = null;
			int _index = -1;
			OGen.XSD.lib.metadata.metadata.XS_complexTypeType _complextype;

			XS__schema _schema = root_ref_.SchemaCollection[schemaName_in];
			for (int c = 0; c < _schema.ComplexTypeCollection.Count; c++) {
				for (int e = 0; e < _schema.ComplexTypeCollection[c].Sequence.ElementCollection.Count; e++) {
					if (
						// if there's an Element pointing this ComplexType
						(_schema.ComplexTypeCollection[c].Sequence.ElementCollection[e].Type == Name)
						&&
						// and if this Element occurance is unbounded
						(_schema.ComplexTypeCollection[c].Sequence.ElementCollection[e].MaxOccurs
							== XS_MaxOccursType.unbounded)
					) {
						// then this ComplexType must implement a Collection

						#region _complextype = ...;
						#region _index = ...;
						if (schemaName_in != string.Empty)
							_index = root_ref_.MetadataCollection[0].MetadataIndexCollection.Search(schemaName_in);
						else
							_index = -1;
						#endregion
						if (_index != -1)
							// note: if not found null will be returned! 
							// so don't glue this if block with the next
							// or have this in consideration when you do it
							_complextype
								= root_ref_.MetadataCollection[0].MetadataIndexCollection[_index].ComplexTypeCollection[
									Name
								];
						else
							_complextype = null;

						if (_complextype == null)
							_complextype
								= root_ref_.MetadataCollection[0].ComplexTypeCollection[
									Name
								];
						#endregion
						if (_complextype != null) {
							complexTypeCollection_out = new ComplexTypeItem[_complextype.ComplexTypeKeyCollection.Count];
							for (int k = 0; k < _complextype.ComplexTypeKeyCollection.Count; k++) {
								for (int a = 0; a < AttributeCollection.Count; a++) {
									if (
										AttributeCollection[a].Name 
										== 
										_complextype.ComplexTypeKeyCollection[k].Name
									) {
										complexTypeCollection_out[k] = new ComplexTypeItem(
											AttributeCollection[a].Name,
											AttributeCollection[a].NType(schemaName_in),
											_complextype.ComplexTypeKeyCollection[k].caseSensitive
										);
										break;
									}
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
