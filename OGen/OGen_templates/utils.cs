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

namespace OGen.lib.templates {
	public class utils { private utils() {}

		public class OutputMode { private OutputMode() {}
			public static cOutput.eMode Parse_NEW(string outputMode_in) {
				for (int i = 0;; i++) {
					if (((cOutput.eMode)i).ToString() == outputMode_in) {
						return (cOutput.eMode)i;
					} else if (
						(((cOutput.eMode)i) == cOutput.eMode.invalid)
						||
						(((cOutput.eMode)i).ToString() == string.Empty)
					) {
						return cOutput.eMode.invalid;
					}
				}
			}
		}

		public class OutputType { private OutputType() {}
			//public class convert { private convert() {}
			//}

//			#region public static cTemplate.eOutputType Parse(string outputType_in);
//			public static cTemplate.eOutputType Parse(string outputType_in) {
//				for (int i = 0;; i++) {
//					if (((cTemplate.eOutputType)i).ToString() == outputType_in) {
//						return (cTemplate.eOutputType)i;
//					} else if (((cTemplate.eOutputType)i).ToString() == string.Empty) {
//						return cTemplate.eOutputType.File;
//					}
//				}
//			}
			public static cOutput.eType Parse_NEW(string outputType_in) {
				for (int i = 0;; i++) {
					if (((cOutput.eType)i).ToString() == outputType_in) {
						return (cOutput.eType)i;
					} else if (
						(((cOutput.eType)i) == cOutput.eType.invalid)
						||
						(((cOutput.eType)i).ToString() == string.Empty)
					) {
						return cOutput.eType.invalid;
					}
				}
			}
//			#endregion
		}

		public class TemplateType { private TemplateType() {}
			//public class convert { private convert() {}
			//}

			#region public static cTemplate.eParserType Parse(string templateType_in);
			public static cTemplate.eParserType Parse(string templateType_in) {
				for (int i = 0;; i++) {
					if (((cTemplate.eParserType)i).ToString() == templateType_in) {
						return (cTemplate.eParserType)i;
					} else if (
						((cTemplate.eParserType)i == cTemplate.eParserType.invalid)
						||
						(((cTemplate.eParserType)i).ToString() == string.Empty)
					) {
						return cTemplate.eParserType.invalid;
					}
				}
			}
			#endregion
		}
	}
}