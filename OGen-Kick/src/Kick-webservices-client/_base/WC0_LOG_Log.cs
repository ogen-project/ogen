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
using System.Web.Services;
using System.Web.Services.Protocols;

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.distributedlayer.webservices.client {
	/// <summary>
	/// LOG_Log web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_LOG_LogSoap",
		Namespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server"
	)]
	public class WC_LOG_Log : 
		SoapHttpClientProtocol, 
		IBO_LOG_Log
	{
		public WC_LOG_Log() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				"{0}:{1}/WS_LOG_Log.asmx",
				#if NET_1_1
				System.Configuration.ConfigurationSettings.AppSettings["Webservices_ServerURI"], 
				System.Configuration.ConfigurationSettings.AppSettings["Webservices_ServerPort"]
				#else
				System.Configuration.ConfigurationManager.AppSettings["Webservices_ServerURI"], 
				System.Configuration.ConfigurationManager.AppSettings["Webservices_ServerPort"]
				#endif
			);
		}
		#endregion

		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_LOG_Log[] getRecord_generic(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_generic",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_LOG_Log[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int IDLogtype_search_in, 
			long IDUser_search_in, 
			int IDErrortype_search_in, 
			System.DateTime Stamp_begin_search_in, 
			System.DateTime Stamp_end_search_in, 
			bool Read_search_in, 
			bool Read_search_isNull_in, 
			int idApplication_in, 
			bool idApplication_isNull_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_generic", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					IDLogtype_search_in,
					IDUser_search_in,
					IDErrortype_search_in,
					Stamp_begin_search_in,
					Stamp_end_search_in,
					Read_search_in,
					Read_search_isNull_in,
					idApplication_in,
					idApplication_isNull_in,
					page_in,
					page_numRecords_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_LOG_Log[])results[0];
		}
		#endregion
		#region public void Log(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/Log",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Log(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int logtype_in, 
			int errortype_in, 
			long idPermition_in, 
			int idApplication_in, 
			string format_in, 
			System.String[] args_in
		) {
			object[] results = this.Invoke(
				"Log", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					logtype_in,
					errortype_in,
					idPermition_in,
					idApplication_in,
					format_in,
					args_in
				}
			);
		}
		#endregion
		#region public void MarkRead(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/MarkRead",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void MarkRead(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLog_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"MarkRead", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLog_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
	}
}