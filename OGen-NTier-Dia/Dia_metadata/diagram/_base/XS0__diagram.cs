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

namespace OGen.NTier.Dia.lib.metadata.diagram {
	#if NET_1_1
	public class XS0__diagram : XS_diagramType, MetadataInterface {
	#else
	public partial class XS__diagram : XS_diagramType, MetadataInterface {
	#endif

		public const string DIAGRAM = "diagram";
		public const string ROOT = "ROOT";
		public const string ROOT_DIAGRAM = ROOT + "." + DIAGRAM;
		#region public string Root_Diagram { get; }
		protected string root_diagram_ = null;

		[XmlIgnore()]
		public string Root_Diagram {
			get { return root_diagram_; }
		}
		#endregion

		#region public static XS__diagram[] Load_fromFile(...);
		public static XS__diagram[] Load_fromFile(
			params string[] filePath_in
		) {
			return Load_fromFile(
				null, 
				filePath_in
			);
		}
		public static XS__diagram[] Load_fromFile(
			XS__RootMetadata root_ref_in, 
			params string[] filePath_in
		) {
			FileStream _stream;
			XS__diagram[] _output 
				= new XS__diagram[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				_stream = new FileStream(
					filePath_in[i],
					FileMode.Open,
					FileAccess.Read,
					FileShare.Read
				);

				try {
					_output[i] = (XS__diagram)new XmlSerializer(typeof(XS__diagram)).Deserialize(
						_stream
					);
					_stream.Close();
#if !NET_1_1
					_stream.Dispose();
#endif
				} catch (Exception _ex) {
					throw new Exception(string.Format(
						"\n---\n{0}.{1}.Load_fromFile():\nERROR READING XML:\n{2}\n---\n{3}\n---\n{4}\n---\n",
						typeof(XS__diagram).Namespace, 
						typeof(XS__diagram).Name, 
						filePath_in[i],
						_ex.Message,
						_ex.InnerException
					));
				}
				_output[i].root_diagram_ = ROOT + "." + DIAGRAM + "[" + i + "]";

				_output[i].parent_ref = root_ref_in; // ToDos: now!
				if (root_ref_in != null) _output[i].root_ref = root_ref_in;
			}
			return _output;
		}
		#endregion
		#region public static XS__diagram[] Load_fromURI(...);
		public static XS__diagram[] Load_fromURI(
			params Uri[] filePath_in
		) {
			return Load_fromURI(
				null, 
				filePath_in
			);
		}
		public static XS__diagram[] Load_fromURI(
			XS__RootMetadata root_ref_in, 
			params Uri[] filePath_in
		) {
			XS__diagram[] _output 
				= new XS__diagram[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				if (filePath_in[i].IsFile) {
					_output[i] = XS__diagram.Load_fromFile(
						filePath_in[i].LocalPath
					)[0];
					// no need! everything's been taken care at: XS__diagram.Load_fromFile(...)
					//_output[i].root_diagram_ = ROOT + "." + DIAGRAM + "[" + i + "]";
					//_output[i].parent_ref = root_ref_in; // ToDos: now!
					//if (root_ref_in != null) _output[i].root_ref = root_ref_in;
				} else {
					try {
						_output[i] = (XS__diagram)new XmlSerializer(typeof(XS__diagram)).Deserialize(
							OGen.lib.presentationlayer.webforms.utils.ReadURL(
								filePath_in[i].ToString()
							)
						);
					} catch (Exception _ex) {
						throw new Exception(string.Format(
							"\n---\n{0}.{1}.Load_fromURI():\nERROR READING XML:\n{2}\n---\n{3}",
							typeof(XS__diagram).Namespace, 
							typeof(XS__diagram).Name, 
							//(filePath_in[i].IsFile)
							//	? filePath_in[i].LocalPath
							//	: 
							filePath_in[i].ToString(),
							_ex.Message
						));
					}
					_output[i].root_diagram_ = ROOT + "." + DIAGRAM + "[" + i + "]";
					_output[i].parent_ref = root_ref_in; // ToDos: now!
					if (root_ref_in != null) _output[i].root_ref = root_ref_in;
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
			new XmlSerializer(typeof(XS__diagram)).Serialize(
				_file,
				this
			);
			_file.Flush();
			_file.Close();
#if !NET_1_1
			_file.Dispose();
#endif
		}
		#endregion
		#region public string Read_fromRoot(string what_in);
		public string Read_fromRoot(string what_in) {
			return OGen.lib.generator.utils.ReflectThrough(
				this, 
				Root_Diagram, 
				null, 
				what_in, 
				Root_Diagram, 
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
				Root_Diagram, 
				iteration_found_in, 
				iteration_in, 
				Root_Diagram, 
				false, 
				true, 
				ref valueHasBeenFound_out
			);
		}
		#endregion
	}
}