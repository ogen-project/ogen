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
using System.Xml.Serialization;

using OGen.lib.generator;

namespace OGen.Doc.lib.documentation {
	#if NET_1_1
	public class XS0__documentation : XS_chaptersType, MetadataInterface {
	#else
	public partial class XS__documentation : XS_chaptersType, MetadataInterface {
	#endif

		public const string DOCUMENTATION = "documentation";
		public const string ROOT = "ROOT";
		public const string ROOT_DOCUMENTATION = ROOT + "." + DOCUMENTATION;
		#region public string Root_Documentation { get; }
		protected string root_documentation_ = null;

		[XmlIgnore()]
		public string Root_Documentation {
			get { return root_documentation_; }
		}
		#endregion

		#region public static XS__documentation[] Load_fromFile(...);
		public static XS__documentation[] Load_fromFile(
			params string[] filePath_in
		) {
			FileStream _stream;
			XS__documentation[] _output 
				= new XS__documentation[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				_stream = new FileStream(
					filePath_in[i],
					FileMode.Open,
					FileAccess.Read,
					FileShare.Read
				);

				try {
					_output[i] = (XS__documentation)new XmlSerializer(typeof(XS__documentation)).Deserialize(
						_stream
					);
					_stream.Close();
					_stream.Dispose();
				} catch (Exception _ex) {
					throw new Exception(string.Format(
						"\n---\n{0}.{1}.Load_fromFile():\nERROR READING XML:\n{2}\n---\n{3}\n---\n{4}\n---\n",
						typeof(XS__documentation).Namespace, 
						typeof(XS__documentation).Name, 
						filePath_in[i],
						_ex.Message,
						_ex.InnerException
					));
				}
				_output[i].root_documentation_ = ROOT + "." + DOCUMENTATION + "[" + i + "]";
			}
			return _output;
		}
		#endregion
		#region public static XS__documentation[] Load_fromURI(...);
		public static XS__documentation[] Load_fromURI(
			params Uri[] filePath_in
		) {
			XS__documentation[] _output 
				= new XS__documentation[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				if (filePath_in[i].IsFile) {
					_output[i] = XS__documentation.Load_fromFile(
						filePath_in[i].LocalPath
					)[0];
					// no need! everything's been taken care at: XS__documentation.Load_fromFile(...)
					//_output[i].root_documentation_ = ROOT + "." + DOCUMENTATION + "[" + i + "]";
				} else {
					try {
						_output[i] = (XS__documentation)new XmlSerializer(typeof(XS__documentation)).Deserialize(
							OGen.lib.presentationlayer.webforms.utils.ReadURL(
								filePath_in[i].ToString()
							)
						);
					} catch (Exception _ex) {
						throw new Exception(string.Format(
							"\n---\n{0}.{1}.Load_fromURI():\nERROR READING XML:\n{2}\n---\n{3}",
							typeof(XS__documentation).Namespace, 
							typeof(XS__documentation).Name, 
							//(filePath_in[i].IsFile)
							//	? filePath_in[i].LocalPath
							//	: 
							filePath_in[i].ToString(),
							_ex.Message
						));
					}
					_output[i].root_documentation_ = ROOT + "." + DOCUMENTATION + "[" + i + "]";
				}
			}

			return _output;
		}
		#endregion
		#region public void SaveState_toFile(string filePath_in);
		public void SaveState_toFile(string filePath_in) {
			FileStream _file = new FileStream(
				filePath_in,
				FileMode.Create,
				FileAccess.Write,
				FileShare.ReadWrite
			);
			new XmlSerializer(typeof(XS__documentation)).Serialize(
				_file,
				this
			);
			_file.Flush();
			_file.Close();
			_file.Dispose();
		}
		#endregion
		#region public string Read_fromRoot(string what_in);
		public string Read_fromRoot(string what_in) {
			return OGen.lib.generator.utils.ReflectThrough(
				this, 
				Root_Documentation, 
				null, 
				what_in, 
				Root_Documentation, 
				true, 
				true
			);
		}
		#endregion
		#region public void IterateThrough_fromRoot(...);
		public void IterateThrough_fromRoot(
			string iteration_in, 
			OGen.lib.generator.utils.IterationFoundDelegate iteration_found_in,
			ref bool valueHasBeenFound_out
		) {
			OGen.lib.generator.utils.ReflectThrough(
				this, 
				Root_Documentation, 
				iteration_found_in, 
				iteration_in, 
				Root_Documentation, 
				false, 
				true, 
				ref valueHasBeenFound_out
			);
		}
		#endregion
	}
}