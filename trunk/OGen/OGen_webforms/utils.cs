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
using System.Web;
using System.IO;
using System.Net;
using System.Collections;

namespace OGen.lib.presentationlayer.webforms {
#if NET_1_1
	public class utils { private utils() { }
#else
	public static class utils {
#endif

		#region public static string ConcatenateURLParams(Hashtable parameters_in);
		public static string ConcatenateURLParams(
			Hashtable parameters_in
		) {
			return ConcatenateURLParams(parameters_in, false);
		}
		public static string ConcatenateURLParams(
			Hashtable parameters_in, 
			bool addQuestionmarkSeparator_in
		) {
			string ConcatenateURLParams_out = "";
			string _separator = (addQuestionmarkSeparator_in) ? "?" : "";

			IDictionaryEnumerator _denum = parameters_in.GetEnumerator();
			_denum.Reset();
			while (_denum.MoveNext()) {
				ConcatenateURLParams_out += string.Format(
					"{0}{1}={2}", 
					/*00*/(string.IsNullOrEmpty(ConcatenateURLParams_out)) ? _separator : "&", 
					/*01*/_denum.Key.ToString(), 
					/*02*/System.Web.HttpUtility.UrlEncode(
						_denum.Value.ToString()
					)
				);
			}

			return ConcatenateURLParams_out;
		}
		#endregion

		#region public static string Replace_RN_BR(...);
		public static string Replace_RN_BR(
			string value_in
		) {
			return value_in.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
		}
		#endregion

		#region public static System.IO.Stream ReadURL(...) { ... }
		public static System.IO.Stream ReadURL(
			string url_in, 
			Hashtable parameters_in
		) {
			return ReadURL(
				url_in 
				+ ConcatenateURLParams(parameters_in, true)
			);
		}
		public static System.IO.Stream ReadURL(
			string url_in
		) {
			WebRequest webrequest = System.Net.HttpWebRequest.Create(url_in);
			WebResponse webresponse;
			try {
				webresponse = webrequest.GetResponse();
			} catch (Exception e) {
				throw new Exception(string.Format(
					"\n\n---\n{0}\n{1}\n---\n",
					//e.StackTrace
					e.Message,
					url_in
					//e.ToString()
					//webrequest.Headers.Keys[0].ToString()
				));
			}

			//webrequest.Credentials = new System.Net.WebRequest() .credentials Credentials

			return ((System.IO.Stream)webresponse.GetResponseStream());
		}
		#endregion
		#region public static string ReadURL_ToString(...) { ... }
//#if !(NET_1_0 || NET_1_1)
//        public static string ReadURL_ToString(
//            string url_in,
//            System.Collections.Generic.Dictionary<string, string> parameters_in
//        ) {
//            return ReadURL_ToString(
//                url_in
//                + ConcatenateURLParams(parameters_in, true)
//            );
//        }
//#endif
		public static string ReadURL_ToString(
			string url_in, 
			Hashtable parameters_in
		) {
			return ReadURL_ToString(
				url_in 
				+ ConcatenateURLParams(parameters_in, true)
			);
		}
		public static string ReadURL_ToString(
			string url_in
		) {
			StreamReader streamreader = new StreamReader(
				ReadURL(url_in)
			);
			return streamreader.ReadToEnd();
		}
		#endregion

		#region public class Pager { ... }
#if NET_1_1
		public class Pager { private Pager() { }
#else
		public static class Pager {
#endif

			public const int ITEMSPERPAGE_DEFAULT = 10;

			#region public static long PageNum { get; }
			public static long PageNum {
				get {
					long _output;
					if (!long.TryParse(System.Web.HttpContext.Current.Request.QueryString["page"], out _output)) {
						_output = 1L;
					}

					return _output;
				}
			}
			#endregion

			#region private static void link_set(...);
			private static void link_set(
				System.Web.UI.WebControls.Label label_in, 
				System.Web.UI.HtmlControls.HtmlAnchor anchor_in,
				long page_in
			) {
				label_in.Visible = true;
				link_set(
					anchor_in, 
					page_in
				);
			}
			private static void link_set(
				System.Web.UI.HtmlControls.HtmlAnchor anchor_in, 
				long page_in
			) {
				anchor_in.InnerText = page_in.ToString();
				anchor_in.HRef = string.Format("?page={0}", page_in);
				anchor_in.Visible = true;
			}
			#endregion

			#region public static void Bind(...);
			public static void Bind(
				long totalItems_in,

				System.Web.UI.WebControls.Label lbl_pageSeparator_left_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_2_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_3_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_4_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_right_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_5_in,

				System.Web.UI.HtmlControls.HtmlAnchor a_page_1_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_2_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_3_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_4_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_5_in
			) {
				Bind(
					totalItems_in,
					ITEMSPERPAGE_DEFAULT, 

					lbl_pageSeparator_left_in,
					lbl_pageSeparator_2_in,
					lbl_pageSeparator_3_in,
					lbl_pageSeparator_4_in,
					lbl_pageSeparator_right_in,
					lbl_pageSeparator_5_in,

					a_page_1_in,
					a_page_2_in,
					a_page_3_in,
					a_page_4_in,
					a_page_5_in
				);
			}
			public static void Bind(
				long totalItems_in,
				int itemsPerPage_in, 

				//System.Web.UI.WebControls.Label lbl_pageSeparator_1_in, 
				System.Web.UI.WebControls.Label lbl_pageSeparator_left_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_2_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_3_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_4_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_right_in,
				System.Web.UI.WebControls.Label lbl_pageSeparator_5_in,

				System.Web.UI.HtmlControls.HtmlAnchor a_page_1_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_2_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_3_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_4_in,
				System.Web.UI.HtmlControls.HtmlAnchor a_page_5_in
			) {
				a_page_1_in.Visible = false;
				a_page_2_in.Visible = false;
				a_page_3_in.Visible = false;
				a_page_4_in.Visible = false;
				a_page_5_in.Visible = false;

				lbl_pageSeparator_left_in.Visible = false;
				lbl_pageSeparator_2_in.Visible = false;
				lbl_pageSeparator_3_in.Visible = false;
				lbl_pageSeparator_4_in.Visible = false;
				lbl_pageSeparator_right_in.Visible = false;
				lbl_pageSeparator_5_in.Visible = false;

				a_page_1_in.HRef = "?page=1";
				a_page_1_in.InnerText = "1";

				lbl_pageSeparator_left_in.Text = "&nbsp;&nbsp;...";
				lbl_pageSeparator_2_in.Text = "&nbsp;&nbsp;";
				lbl_pageSeparator_3_in.Text = "&nbsp;&nbsp;";
				lbl_pageSeparator_4_in.Text = "&nbsp;&nbsp;";
				lbl_pageSeparator_right_in.Text = "&nbsp;&nbsp;...";
				lbl_pageSeparator_5_in.Text = "&nbsp;&nbsp;";


				int _pagetotal = ((int)totalItems_in / itemsPerPage_in) + ((totalItems_in % itemsPerPage_in > 0) ? 1 : 0);
				switch (_pagetotal) {
					case 0:
					//	break;
					case 1:
					//	link_set(lbl_pageSeparator_3_in, a_page_3_in, 1);
						break;
					case 2:
						switch (PageNum) {
							case 1:
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 1);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 2);
								break;
							case 2:
								link_set(lbl_pageSeparator_2_in, a_page_2_in, 1);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 2);
								break;
						}

						break;
					case 3:
						switch (PageNum) {
							case 1:
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 1);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 2);
								link_set(lbl_pageSeparator_5_in, a_page_5_in, 3);
								break;
							case 2:
								link_set(lbl_pageSeparator_2_in, a_page_2_in, 1);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 2);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 3);
								break;
							case 3:
								link_set(a_page_1_in, 1);
								link_set(lbl_pageSeparator_2_in, a_page_2_in, 2);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 3);
								break;
						}
						break;
					case 4:
						switch (PageNum) {
							case 1:
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 1);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 2);

								lbl_pageSeparator_right_in.Visible = true;

								link_set(lbl_pageSeparator_5_in, a_page_5_in, 4);
								break;
							case 2:
								link_set(lbl_pageSeparator_2_in, a_page_2_in, 1);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 2);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 3);
								link_set(lbl_pageSeparator_5_in, a_page_5_in, 4);
								break;
							case 3:
								link_set(a_page_1_in, 1);
								link_set(lbl_pageSeparator_2_in, a_page_2_in, 2);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 3);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 4);
								break;
							case 4:
								link_set(a_page_1_in, 1);

								lbl_pageSeparator_left_in.Visible = true;

								link_set(lbl_pageSeparator_2_in, a_page_2_in, 3);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 4);
								break;
						}
						break;
					case 5:
						switch (PageNum) {
							case 1:
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 1);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 2);

								lbl_pageSeparator_right_in.Visible = true;

								link_set(lbl_pageSeparator_5_in, a_page_5_in, 5);
								break;
							case 2:
								link_set(lbl_pageSeparator_2_in, a_page_2_in, 1);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 2);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 3);

								lbl_pageSeparator_right_in.Visible = true;

								link_set(lbl_pageSeparator_5_in, a_page_5_in, 5);
								break;
							case 3:
								link_set(a_page_1_in, 1);
								link_set(lbl_pageSeparator_2_in, a_page_2_in, 2);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 3);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 4);
								link_set(lbl_pageSeparator_5_in, a_page_5_in, 5);
								break;
							case 4:
								link_set(a_page_1_in, 1);

								lbl_pageSeparator_left_in.Visible = true;

								link_set(lbl_pageSeparator_2_in, a_page_2_in, 3);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 4);
								link_set(lbl_pageSeparator_4_in, a_page_4_in, 5);
								break;
							case 5:
								link_set(a_page_1_in, 1);

								lbl_pageSeparator_left_in.Visible = true;

								link_set(lbl_pageSeparator_2_in, a_page_2_in, 4);
								link_set(lbl_pageSeparator_3_in, a_page_3_in, 5);
								break;
						}
						break;
					default:
						link_set(lbl_pageSeparator_2_in, a_page_2_in, PageNum - 1);
						link_set(lbl_pageSeparator_3_in, a_page_3_in, PageNum);
						link_set(lbl_pageSeparator_4_in, a_page_4_in, PageNum + 1);
						link_set(lbl_pageSeparator_5_in, a_page_5_in, _pagetotal);

						
						lbl_pageSeparator_left_in.Visible = true;
						lbl_pageSeparator_right_in.Visible = true;

						switch (PageNum) {
							case 1:
								a_page_1_in.Visible = false;
								lbl_pageSeparator_left_in.Visible = false;

								a_page_2_in.Visible = false;
								lbl_pageSeparator_2_in.Visible = false;
								break;
							case 2:
								a_page_1_in.Visible = false;
								lbl_pageSeparator_left_in.Visible = false;
								break;
							case 3:
								a_page_1_in.Visible = true;
								lbl_pageSeparator_left_in.Visible = false;
								break;
							default:
								a_page_1_in.Visible = true;
								break;
						}
						if (PageNum == _pagetotal - 2) {
							lbl_pageSeparator_right_in.Visible = false;
						} else if (PageNum == _pagetotal - 1) {
							lbl_pageSeparator_right_in.Visible = false;

							lbl_pageSeparator_5_in.Visible = false;
							a_page_5_in.Visible = false;
						} else if (PageNum == _pagetotal) {
							lbl_pageSeparator_4_in.Visible = false;
							a_page_4_in.Visible = false;

							lbl_pageSeparator_right_in.Visible = false;

							lbl_pageSeparator_5_in.Visible = false;
							a_page_5_in.Visible = false;
						}
						break;
				}
			}
			#endregion
		}
		#endregion
	}
}