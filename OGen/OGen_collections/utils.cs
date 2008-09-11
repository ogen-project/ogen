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

namespace OGen.lib.collections {
	public class utils { private utils() {}

		//public class convert { private convert() {}
		//
		//	// ...
		//}

//		public class ClaSSeGen { private ClaSSeGen() {}
//
//			public class Field { private Field() {}
//
//				public class FieldTypes { private FieldTypes() {}
//
//					public class convert { private convert() {}
//
//						#region public static cClaSSeGen_Field.eFieldTypes FromName(...);
//						public static cClaSSeGen_Field.eFieldTypes FromName(string Name_) {
//							for (int i = 0;; i++) {
//								if (((cClaSSeGen_Field.eFieldTypes)i).ToString() == Name_) {
//									return (cClaSSeGen_Field.eFieldTypes)i;
//								} else if (((cClaSSeGen_Field.eFieldTypes)i).ToString() == cClaSSeGen_Field.eFieldTypes.invalid.ToString()) {
//									return cClaSSeGen_Field.eFieldTypes.invalid;
//								}
//							}
//						}
//						#endregion
//					}
//				}
//			}
//		}

		public class ClaSS { private ClaSS() {}

			public class PropertyTypes { private PropertyTypes() {}

				public class convert { private convert() {}

					#region public static ClaSSPropertyAttribute.eType FromName(...);
					public static ClaSSPropertyAttribute.eType FromName(string Name_) {
						for (int i = 0;; i++) {
							if (((ClaSSPropertyAttribute.eType)i).ToString() == Name_) {
								return (ClaSSPropertyAttribute.eType)i;
							} else if (((ClaSSPropertyAttribute.eType)i).ToString() == ClaSSPropertyAttribute.eType.invalid.ToString()) {
								return ClaSSPropertyAttribute.eType.invalid;
							}
						}
					}
					#endregion
				}
			}
		}
	}
}
