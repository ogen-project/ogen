#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
#if !NET_1_1

namespace OGen.lib.parser {
	using System;
	using System.Collections;
	using System.IO;
	using System.Web;
	using System.Web.Hosting;

	public static class ParserASPX {

		private static System.Collections.Generic.Dictionary<string, MyHost> myhost_ = new System.Collections.Generic.Dictionary<string, MyHost>();
		private static object myhost_locker = new object();

		private class MyHost : MarshalByRefObject, IRegisteredObject {
			public override object InitializeLifetimeService() {
				return null; // never expires, default is 5 minutes
			}

			public void Stop(bool immediate) {
				HostingEnvironment.UnregisterObject(this);
			}

			#region public void RunRequest(...);
			public void RunRequest(string page_in, string queryString_in, ref TextWriter output_ref) {
				output_ref = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);

				HttpRuntime.ProcessRequest(
					new SimpleWorkerRequest(
						page_in,
						queryString_in,
						output_ref
					)
				);
			}
			#endregion
		}

		#region public static void Parse(...);
		#region private static void Parse(string appPath_in, string aspxFile_in, Hashtable parameters_in, ref TextWriter textwriter_out);
		private static void Parse(
			string appPath_in, 
			string aspxFile_in,
			Hashtable parameters_in,
			ref TextWriter textwriter_out
		) {

			// check before lock
			if (!myhost_.ContainsKey(appPath_in)) {

				lock (myhost_locker) {

					// --- performance hack! keeping host static, 
					// instantiating only one host per Physical/Application Path

					// double check, thread safer!
					if (!myhost_.ContainsKey(appPath_in)) {

						// initialization...
						string _appId = string.Concat("ParserASPX_", Guid.NewGuid().GetHashCode().ToString("x", System.Globalization.CultureInfo.CurrentCulture));
						string _virtualPath = "/";

						// ...attribution (last thing before unlock)
						myhost_.Add(
							appPath_in,
							(MyHost)ApplicationManager.GetApplicationManager().CreateObject(
								_appId,
								typeof(MyHost),
								_virtualPath,
								appPath_in,
								false//true
							)
						);
					}
				}
			}

			myhost_[appPath_in].RunRequest(
				aspxFile_in,
				OGen.lib.presentationlayer.webforms.utils.ConcatenateURLParams(parameters_in),
				ref textwriter_out
			);
		}
		#endregion

		/// <summary>
		/// Parses aspx files
		/// </summary>
		/// <param name="appPath_in"></param>
		/// <param name="aspxFile_in"></param>
		/// <param name="parameters_in"></param>
		/// <param name="result_out">output result</param>
		public static void Parse(
			string appPath_in,
			string aspxFile_in,
			Hashtable parameters_in,
			out string result_out
		) {
			#region Parse(appPath_in, aspxFile_in, parameters_in, ref _textwriter); result_out = _textwriter.ToString();
			TextWriter _textwriter = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
			Parse(appPath_in, aspxFile_in, parameters_in, ref _textwriter);

			result_out = _textwriter.ToString();

			_textwriter.Close();
			_textwriter.Dispose(); _textwriter = null;
			#endregion
		}

		/// <summary>
		/// Parses aspx files
		/// </summary>
		/// <param name="appPath_in"></param>
		/// <param name="aspxFile_in"></param>
		/// <param name="parameters_in"></param>
		/// <param name="outputfile_in">output file</param>
		public static void Parse(
			string appPath_in,
			string aspxFile_in,
			Hashtable parameters_in,
			string outputfile_in
		) {
			#region Parse(appPath_in, aspxFile_in, parameters_in, ref new StreamWriter(outputfile_in));
			// ToDos: here! i don't like this...

			TextWriter _stringwriter = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
			Parse(appPath_in, aspxFile_in, parameters_in, ref _stringwriter);
			_stringwriter.Flush();
			_stringwriter.Close();

			StreamWriter _streamwriter = new StreamWriter(
				outputfile_in,
				false
			);
			_streamwriter.Write(_stringwriter.ToString());
			_streamwriter.Flush();
			_streamwriter.Close();
			_streamwriter.Dispose(); _streamwriter = null;

			_stringwriter.Dispose(); _stringwriter = null;
			#endregion
		}
		#endregion
	}
}
#endif