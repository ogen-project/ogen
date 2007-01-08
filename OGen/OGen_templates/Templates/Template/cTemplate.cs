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
using System.Collections;

using OGen.lib.collections;

namespace OGen.lib.templates {
	public class cTemplate : cClaSS_noR, iClaSS_noR {
//		#region public cTemplate(...);
		public cTemplate(
			cTemplates parent_ref_in, 
			string name_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSS_noR...
			Name = name_in;
			ParserType = eParserType.aspx;
//			Type = eParserType.aspx;
			IterationType = string.Empty;
//			OutputType = eOutputType.File;
//			OutputTo = string.Empty;
//			OutputAndReplace = false;
			//---
			arguments_ = new cArguments(this);
			conditions_ = new cConditions(this);
			outputs_ = new cOutputs(this);
			dependencies_ = new cDependencies(this);
			//#endregion
		}
//		#endregion

		#region Implementing - iClaSS_noR...
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name: {2}", 
						this.GetType().Namespace,
						this.GetType().Name,
						name_in
					));
			}
		}
		#endregion

//		#region enums...
		#region public enum eParserType;
		public enum eParserType {
			aspx = 0, 
			xslt = 1, 
			none = 2, 

			invalid = 3
		}
		#endregion
//		#region public enum eOutputType;
//		public enum eOutputType {
//			File = 0,
//			FileCopy = 1, 
//			PostgreSQL_Function = 2, 
//			PostgreSQL_StoredProcedure = 3, 
//			PostgreSQL_View = 4, 
//			SQLServer_Function = 5, 
//			SQLServer_StoredProcedure = 6, 
//			SQLServer_View = 7
//		}
//		#endregion
//		#endregion

//		#region Properties - ClaSS_noR...
		#region public string Name { get; set; }
		public string Name {
			get { return base.Property_standard["name"]; }
			set { base.Property_standard["name"] = value; }
		}
		#endregion
		#region public eParserType ParserType { get; set; }

//		public eParserType Type {
//			get { return OGen.lib.templates.utils.TemplateType.Parse(base.Property_standard["type"]); }
//			set { base.Property_standard["type"] = value.ToString(); }
//		}
		public eParserType ParserType {
			get { return OGen.lib.templates.utils.TemplateType.Parse(base.Property_standard["parserType"]); }
			set { base.Property_standard["parserType"] = value.ToString(); }
		}

		#endregion
		#region public string IterationType { get; set; }
		public string IterationType {
			get { return base.Property_standard["iterationType"]; }
			set { base.Property_standard["iterationType"] = value; }
		}
		#endregion
//		#region public eOutputType OutputType { get; set; }
//		public eOutputType OutputType {
//			get { return OGen.lib.templates.utils.OutputType.Parse(base.Property_standard["outputType"]); }
//			set { base.Property_standard["outputType"] = value.ToString(); }
//		}
//		#endregion
//		#region public string OutputTo { get; set; }
//		public string OutputTo {
//			get { return base.Property_standard["outputTo"]; }
//			set { base.Property_standard["outputTo"] = value; }
//		}
//		#endregion
//		#region public bool OutputAndReplace { get; set; }
//		public bool OutputAndReplace {
//			get { return bool.Parse(base.Property_standard["outputAndReplace"]); }
//			set { base.Property_standard["outputAndReplace"] = value.ToString(); }
//		}
//		#endregion
		//---
		#region private cArguments arguments_ { get; set; }
		private cArguments arguments_ {
			get { return (cArguments)base.Property_aggregate["arguments"]; }
			set { base.Property_aggregate["arguments"] = value; }
		}
		#endregion
		#region private cConditions conditions_ { get; set; }
		private cConditions conditions_ {
			get { return (cConditions)base.Property_aggregate["conditions"]; }
			set { base.Property_aggregate["conditions"] = value; }
		}
		#endregion
		#region private cOutputs outputs_ { get; set; }
		private cOutputs outputs_ {
			get { return (cOutputs)base.Property_aggregate["outputs"]; }
			set { base.Property_aggregate["outputs"] = value; }
		}
		#endregion
		#region private cDependencies dependencies_ { get; set; }
		private cDependencies dependencies_ {
			get { return (cDependencies)base.Property_aggregate["dependencies"]; }
			set { base.Property_aggregate["dependencies"] = value; }
		}
		#endregion
//		#endregion
//		#region Properties...
		#region public iTemplates Parent_ref { get; }
		private cTemplates parent_ref_;
		public iTemplates Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region public iArguments Arguments { get; }
		public iArguments Arguments {
			get { return arguments_; }
		}
		#endregion
		#region public iDependencies Dependencies { get; }
		public iDependencies Dependencies {
			get { return dependencies_; }
		}
		#endregion
		#region public iConditions Conditions { get; }
		public iConditions Conditions {
			get { return conditions_; }
		}
		#endregion
		#region public iOutputs Outputs { get; }
		public iOutputs Outputs {
			get { return outputs_; }
		}
		#endregion
		//---
//		#region public bool OutputType_isFile { get; }
//		public bool OutputType_isFile {
//			get {
//				return (
//					(OutputType == eOutputType.File)
//					||
//					(OutputType == eOutputType.FileCopy)
//				);
//			}
//		}
//		#endregion
//		#region public eDBServerTypes OutputType_DBServerType { get; }
//		public eDBServerTypes OutputType_DBServerType {
//			get {
//				switch(OutputType) {
//					case eOutputType.PostgreSQL_Function:
//					case eOutputType.PostgreSQL_StoredProcedure:
//						return eDBServerTypes.PostgreSQL;
//					case eOutputType.SQLServer_Function:
//					case eOutputType.SQLServer_StoredProcedure:
//						return eDBServerTypes.SQLServer;
//					default:
//						return eDBServerTypes.invalid;
//				}
//			}
//		}
//		#endregion
//		#region public string OutputTo_Translated { get; }
//		private bool outputto_beentranslated_ = false;
//		private string outputto_translated_ = "";
//		public string OutputTo_Translated {
//			get {
//				if (!outputto_beentranslated_) {
//					#region outputto_translated_ = ...;
//					outputto_translated_ = utils.Parse_configParams(
//						this.OutputTo, 
//
//						parent_ref_.OGenPath, 
//						parent_ref_.Documentation_FilePath, 
//						parent_ref_.ApplicationPath, 
//						parent_ref_.ApplicationName, 
//						parent_ref_.DBTypeName, 
//						tablename_, 
//						tablesearchname_, 
//						tablesearchupdatename_, 
//						tableupdatename_
//					);
//					#endregion
//					outputto_beentranslated_ = true;
//				}
//
//				return outputto_translated_;
//			}
//		}
//		#endregion
//		#region public string Output_Translated { get; }
//		private bool output_beentranslated_ = false;
//		private string output_translated_ = "";
//		private Hashtable templateargs_translated_ = null;
//		public string Output_Translated {
//			get {
//				if (!output_beentranslated_) {
//					if (OutputType != eOutputType.FileCopy) {
//						#region templateargs_translated_ = ...;
//						templateargs_translated_ = new Hashtable(arguments_.Count);
//						for (int a = 0; a < arguments_.Count; a++) {
//							templateargs_translated_.Add(
//								arguments_[a].Name, 
//								utils.Parse_configParams(
//									arguments_[a].Value, 
//
//									parent_ref_.OGenPath, 
//									parent_ref_.Documentation_FilePath, 
//									parent_ref_.ApplicationPath, 
//									parent_ref_.ApplicationName, 
//									parent_ref_.DBTypeName, 
//									tablename_, 
//									tablesearchname_, 
//									tablesearchupdatename_, 
//									tableupdatename_
//								)
//							);
//						}
//						#endregion
//						#region output_translated_ = cAspxParser.PageParse(...);
//						output_translated_ = cAspxParser.PageParse(
//							parent_ref_.TemplatesPath, 
//							this.Name, 
//							templateargs_translated_
//						);
//						#endregion
//					} else {
//						output_translated_ = string.Empty;
//					}
//					output_beentranslated_ = true;
//				}
//
//				return output_translated_;
//			}
//		}
//		#endregion
//		#endregion

//		#region Methods...
		#region public override string ToString();
		public override string ToString() {
			return Name;
		}
		#endregion
		//---
//		#region public void Bind_forTranslation(...);
//		private string tablename_;
//		private string tablesearchname_;
//		private string tablesearchupdatename_;
//		private string tableupdatename_;
//		public void Bind_forTranslation(
//			string tableName_in, 
//			string tableSearchName_in, 
//			string tableSearchUpdateName_in, 
//			string tableUpdateName_in
//		) {
//			tablename_ = tableName_in;
//			tablesearchname_ = tableSearchName_in;
//			tablesearchupdatename_ = tableSearchUpdateName_in;
//			tableupdatename_ = tableUpdateName_in;
//			//---
//			outputto_translated_ = ""; outputto_beentranslated_ = false;
//			templateargs_translated_ = null;
//			output_translated_ = ""; output_beentranslated_ = false;
//		}
//		#endregion
//		#endregion
	}
}