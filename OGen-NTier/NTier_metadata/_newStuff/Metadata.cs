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
//using System.Collections.Generic;
//using System.Text;
//using System.Xml;
using System.Xml.Serialization;

namespace OGen.NTier.lib.metadata {
	[XmlRoot("metadata")]
	public class Metadata {
//		#region	public Metadata(...);
		public Metadata(
		) {
		}
//		#endregion

		#region public string ApplicationName { get; set; }
		private string applicationname_;

		[XmlElement("applicationName")]
		public string ApplicationName {
			get { return applicationname_; }
			set { applicationname_ = value; }
		}
		#endregion
		#region public string Namespace { get; set; }
		private string namespace_;

		[XmlElement("namespace")]
		public string Namespace {
			get { return namespace_; }
			set { namespace_ = value; }
		}
		#endregion
		#region public string SubAppName { get; set; }
		private string subappname_;

		[XmlElement("subAppName")]
		public string SubAppName {
			get { return subappname_; }
			set { subappname_ = value; }
		}
		#endregion
		#region public eSQLScriptOptions SQLScriptOption { get; set; }
		private eSQLScriptOptions sqlscriptoption_;

		[XmlElement("sqlScriptOption")]
		public eSQLScriptOptions SQLScriptOption {
			get { return sqlscriptoption_; }
			set { sqlscriptoption_ = value; }
		}
		#endregion
		#region public string GUIDDatalayer { get; set; }
		private string guiddatalayer_;

		[XmlElement("guidDatalayer")]
		public string GUIDDatalayer {
			get { return guiddatalayer_; }
			set { guiddatalayer_ = value; }
		}
		#endregion
		#region public string GUIDDatalayer_UTs { get; set; }
		private string guiddatalayer_uts_;

		[XmlElement("guidDatalayer_UTs")]
		public string GUIDDatalayer_UTs {
			get { return guiddatalayer_uts_; }
			set { guiddatalayer_uts_ = value; }
		}
		#endregion
		#region public string GUIDBusinesslayer { get; set; }
		private string guidbusinesslayer_;

		[XmlElement("guidBusinesslayer")]
		public string GUIDBusinesslayer {
			get { return guidbusinesslayer_; }
			set { guidbusinesslayer_ = value; }
		}
		#endregion
		#region public string GUIDBusinesslayer_UTs { get; set; }
		private string guidbusinesslayer_uts_;

		[XmlElement("guidBusinesslayer_UTs")]
		public string GUIDBusinesslayer_UTs {
			get { return guidbusinesslayer_uts_; }
			set { guidbusinesslayer_uts_ = value; }
		}
		#endregion
		#region public string GUIDTest { get; set; }
		private string guidtest_;

		[XmlElement("guidTest")]
		public string GUIDTest {
			get { return guidtest_; }
			set { guidtest_ = value; }
		}
		#endregion
		#region public string FeedbackEmailAddress { get; set; }
		private string feedbackemailaddress_;

		[XmlElement("feedbackEmailAddress")]
		public string FeedbackEmailAddress {
			get { return feedbackemailaddress_; }
			set { feedbackemailaddress_ = value; }
		}
		#endregion
		#region public string CopyrightText { get; set; }
		private string copyrighttext_;

		[XmlElement("copyrightText")]
		public string CopyrightText {
			get { return copyrighttext_; }
			set { copyrighttext_ = value; }
		}
		#endregion
		#region public string CopyrightTextLong { get; set; }
		private string copyrighttextlong_;

		[XmlElement("copyrightTextLong")]
		public string CopyrightTextLong {
			get { return copyrighttextlong_; }
			set { copyrighttextlong_ = value; }
		}
		#endregion
	}
}