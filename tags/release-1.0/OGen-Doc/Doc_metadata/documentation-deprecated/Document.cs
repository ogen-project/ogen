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
	public class Document : cClaSSe {
		public Document(
			Documents aggregateloopback_ref_in, 
			string iddocument_in
		) : base (
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			iddocument_ = iddocument_in;
			name_ = string.Empty;
			description_ = string.Empty;
			article_idauthor_ = string.Empty;
			article_date_ = string.Empty;
			text_ = string.Empty;
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
		#region public string IDDocument { get; set; }
		private string iddocument_;

		[ClaSSPropertyAttribute("idDocument", ClaSSPropertyAttribute.eType.standard, true)]
		public string IDDocument {
			get { return iddocument_; }
			set { iddocument_ = value; }
		}
		#endregion
		#region public string Name { get; set; }
		private string name_;

		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard, true)]
		public string Name {
			get { return name_; }
			set { name_ = value; }
		}
		#endregion
		#region public string Description { get; set; }
		private string description_;

		[ClaSSPropertyAttribute("description", ClaSSPropertyAttribute.eType.standard, true)]
		public string Description {
			get { return description_; }
			set { description_ = value; }
		}
		#endregion
		#region public string Article_IDAuthor { get; set; }
		private string article_idauthor_;

		[ClaSSPropertyAttribute("article_idAuthor", ClaSSPropertyAttribute.eType.standard, true)]
		public string Article_IDAuthor {
			get { return article_idauthor_; }
			set { article_idauthor_ = value; }
		}
		#endregion
		#region public string Article_Date { get; set; }
		private string article_date_;

		[ClaSSPropertyAttribute("article_date", ClaSSPropertyAttribute.eType.standard, true)]
		public string Article_Date {
			get { return article_date_; }
			set { article_date_ = value; }
		}
		#endregion
		#region public string Text { get; set; }
		private string text_;

		[ClaSSPropertyAttribute("document", ClaSSPropertyAttribute.eType.standard, true)]
		public string Text {
			get { return text_; }
			set { text_ = value; }
		}
		#endregion
		#endregion
		#region public Properties...
		#region public Documents Parent_ref { get; }
		public Documents Parent_ref {
			get {
				return (Documents)base.AggregateLoopback_ref;
			}
		}
		#endregion
		#endregion
	}
}
