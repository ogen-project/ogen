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