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
using System.IO;
using System.Reflection;

namespace OGen.NTier.UTs.lib.business.client {
	public class utils {
		private utils() {}

		#region public static string Assembly_GetDirectoryName { get; }
		private static string assembly_getdirectoryname__;

		public static string Assembly_GetDirectoryName {
			get {
				if (assembly_getdirectoryname__ == null) {
					assembly_getdirectoryname__ = string.Format(
						"{0}{1}{2}",
						Path.GetDirectoryName(
							Assembly.GetExecutingAssembly().GetFiles()[0].Name
						), 
						Path.DirectorySeparatorChar, 
						#if NET_1_1
						"OGen.NTier.UTs.lib.businesslayer-1.1.dll"
						#elif NET_2_0
						"OGen.NTier.UTs.lib.businesslayer-2.0.dll"
						#elif NET_3_0
						"OGen.NTier.UTs.lib.businesslayer-3.0.dll"
						#elif NET_3_5
						"OGen.NTier.UTs.lib.businesslayer-3.5.dll"
						#endif
					);
				}

				return assembly_getdirectoryname__;
			}
		}
		#endregion
		#region public static Assembly BusinessAssembly { get; }
		private static Assembly businessassembly__;

		public static Assembly BusinessAssembly {
			get {
				if (businessassembly__ == null) {
					businessassembly__ = Assembly.LoadFrom(
						Assembly_GetDirectoryName
					);
				}

				return businessassembly__;
			}
		}
		#endregion
	}
}