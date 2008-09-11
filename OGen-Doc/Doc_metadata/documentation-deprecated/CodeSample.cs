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
using System.Collections;
using System.Reflection;
using OGen.lib.collections;

namespace OGen.Doc.lib.metadata {
	public class CodeSample : cClaSSe {
		public CodeSample(
			CodeSamples aggregateloopback_ref_in, 
			string idCodeSample_in
		) : base (
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			idcodesample_ = idCodeSample_in;
			code_ = string.Empty;
			//#endregion
		}
		public override string root4xml {
			get {
				return DocMetadata.ROOT;
			}
		}

		#region Implementing - iClaSSe...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"invalid Name: {0}", 
						name_in
					));
			}
		}
		#endregion
		#region public PropertyInfo[] Properties { get; }
		private static PropertyInfo[] properties__ = null;
		public override PropertyInfo[] Properties {
			get {
				if (properties__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return properties__;
			}
		}
		#endregion
		#region public ClaSSPropertyAttribute[] Attributes { get; }
		private static ClaSSPropertyAttribute[] attributes__ = null;
		public override ClaSSPropertyAttribute[] Attributes {
			get {
				if (attributes__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return attributes__;
			}
		}
		#endregion
		#endregion

		#region public Properties - ClaSSe...
		#region public string IDCodeSample { get; set; }
		private string idcodesample_;

		[ClaSSPropertyAttribute("idCodeSample", ClaSSPropertyAttribute.eType.standard, true)]
		public string IDCodeSample {
			get { return idcodesample_; }
			set { idcodesample_ = value; }
		}
		#endregion
		#region public string Code { get; set; }
		private string code_;

		[ClaSSPropertyAttribute("codeSample", ClaSSPropertyAttribute.eType.standard, true)]
		public string Code {
			get { return code_; }
			set { code_ = value; }
		}
		#endregion
		#endregion
		#region public Properties...
		#region public CodeSamples Parent_ref { get; }
		public CodeSamples Parent_ref {
			get {
				return (CodeSamples)base.AggregateLoopback_ref;
			}
		}
		#endregion
		#endregion
	}
}
