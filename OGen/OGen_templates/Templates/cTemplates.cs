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
	public class cTemplates : cClaSS_noR, iClaSS_noR, iTemplates {
		#region public cTemplates(...);
		public cTemplates(
			string			applicationPath_in, 
			string			applicationName_in, 
			string			ogenPath_in, 
			string			templatesPath_in
		) {
			//#region ClaSS_noR...
			templates_ = new ArrayList();
			//#endregion

			applicationpath_ = applicationPath_in;
			applicationname_ = applicationName_in;
			ogenpath_ = ogenPath_in;
			templatespath_ = templatesPath_in;
		}
		public cTemplates(
			string xmlFileName_in, 
			string xmlObjectName_in
		) : this (
			new Uri(xmlFileName_in), 
			xmlObjectName_in
		) {}
		public cTemplates(
			Uri xmlFileURI_in, 
			string xmlObjectName_in
		) : this (
			string.Empty, 
			string.Empty, 
			string.Empty, 
			string.Empty
		) {
			if (xmlFileURI_in.IsFile) {
				LoadState_fromFile(
					xmlFileURI_in.LocalPath, 
					xmlObjectName_in
				);
			} else {
				LoadState_fromXML(
					OGen.lib.presentationlayer.webforms.utils.ReadURL(
						xmlFileURI_in.ToString()
					), 
					xmlObjectName_in
				);
			}
		}
		#endregion

		#region Implementing - iClaSS_noR...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "template":
					return new cTemplate(this, "");
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

		#region Properties - ClaSS_noR...
		#region private ArrayList templates_ { get; set; }
		private ArrayList templates_ {
			get { return base.Property_aggregate_collection["template"]; }
			set { base.Property_aggregate_collection["template"] = value; }
		}
		#endregion
		#endregion
		#region Properties...
		public const string root4xml = "templates";
		#region public int Count { get; }
		public int Count {
			get { return templates_.Count; }
		}
		#endregion
		#region public cTemplate this[...] { get; }
		public cTemplate this[int index_in] {
			get {
				return (cTemplate)templates_[index_in];
			}
		}
		public cTemplate this[string name_in] {
			get {
				int _ti = Search(name_in);
				return (_ti >= 0) ?
					(cTemplate)templates_[_ti] :
					null;
			}
		}
		#endregion
		//---
		#region public string ApplicationPath { get; }
		private string applicationpath_;
		public string ApplicationPath {
			get { return applicationpath_; }
		}
		#endregion
		#region public string ApplicationName { get; }
		private string applicationname_;
		public string ApplicationName {
			get { return applicationname_; }
		}
		#endregion
		#region public string OGenPath { get; }
		private string ogenpath_;
		public string OGenPath {
			get { return ogenpath_; }
		}
		#endregion
		#region public string TemplatesPath { get; }
		private string templatespath_;
		public string TemplatesPath {
			get { return templatespath_; }
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear(...);
		public void Clear() {
			templates_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(string name_in, bool verifyExistenz_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(name_in);
				if (_ti != -1)
					return _ti;
			}

			return templates_.Add(
				new cTemplate(
					this, 
					name_in
				)
			); // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(string name_in) {
			for (int t = 0; t < templates_.Count; t++)
				if (((cTemplate)templates_[t]).Name == name_in) // already exists!
					return t; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}