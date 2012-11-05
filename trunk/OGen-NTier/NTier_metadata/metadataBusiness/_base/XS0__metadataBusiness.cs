#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.Libraries.Metadata.MetadataBusiness {
	using System;
	using System.IO;
	using System.Xml.Serialization;

	using OGen.Libraries.Generator;

	#if NET_1_1
	public class XS0__metadataBusiness : XS_metadataBusinessType, MetadataInterface {
	#else
	public partial class XS__metadataBusiness : XS_metadataBusinessType, MetadataInterface {
	#endif

		public const string METADATABUSINESS = "metadataBusiness";
		public const string ROOT = "ROOT";
		public const string ROOT_METADATABUSINESS = ROOT + "." + METADATABUSINESS;
		#region public string Root_MetadataBusiness { get; }
		protected string root_metadatabusiness_ = null;

		[XmlIgnore()]
		public string Root_MetadataBusiness {
			get { return this.root_metadatabusiness_; }
		}
		#endregion

		#region public static XS__metadataBusiness[] Load_fromFile(...);
		public static XS__metadataBusiness[] Load_fromFile(
			params string[] filePath_in
		) {
			return Load_fromFile(
				null, 
				filePath_in
			);
		}
		public static XS__metadataBusiness[] Load_fromFile(
			XS__RootMetadata root_ref_in, 
			params string[] filePath_in
		) {
			FileStream _stream;
			XS__metadataBusiness[] _output 
				= new XS__metadataBusiness[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				_stream = new FileStream(
					filePath_in[i],
					FileMode.Open,
					FileAccess.Read,
					FileShare.Read
				);

				try {
					_output[i] = (XS__metadataBusiness)new XmlSerializer(typeof(XS__metadataBusiness)).Deserialize(
						_stream
					);
					_stream.Close();
#if !NET_1_1
					_stream.Dispose();
#endif
				} catch (Exception _ex) {
					throw new Exception(string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"\n---\n{0}.{1}.Load_fromFile():\nERROR READING XML:\n{2}\n---\n{3}\n---\n{4}\n---\n",
						typeof(XS__metadataBusiness).Namespace, 
						typeof(XS__metadataBusiness).Name, 
						filePath_in[i],
						_ex.Message,
						_ex.InnerException
					));
				}
				_output[i].root_metadatabusiness_ = ROOT + "." + METADATABUSINESS + "[" + i + "]";

				_output[i].parent_ref = root_ref_in; // ToDos: now!
				if (root_ref_in != null) _output[i].root_ref = root_ref_in;
			}
			return _output;
		}
		#endregion
		#region public static XS__metadataBusiness[] Load_fromURI(...);
		public static XS__metadataBusiness[] Load_fromURI(
			params Uri[] filePath_in
		) {
			return Load_fromURI(
				null, 
				filePath_in
			);
		}
		public static XS__metadataBusiness[] Load_fromURI(
			XS__RootMetadata root_ref_in, 
			params Uri[] filePath_in
		) {
			XS__metadataBusiness[] _output 
				= new XS__metadataBusiness[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				if (filePath_in[i].IsFile) {
					_output[i] = XS__metadataBusiness.Load_fromFile(
						filePath_in[i].LocalPath
					)[0];
					// no need! everything's been taken care at: XS__metadataBusiness.Load_fromFile(...)
					//_output[i].root_metadatabusiness_ = ROOT + "." + METADATABUSINESS + "[" + i + "]";
					//_output[i].parent_ref = root_ref_in; // ToDos: now!
					//if (root_ref_in != null) _output[i].root_ref = root_ref_in;
				} else {
					try {
						_output[i] = (XS__metadataBusiness)new XmlSerializer(typeof(XS__metadataBusiness)).Deserialize(
							OGen.Libraries.PresentationLayer.WebForms.Utilities.ReadURL(
								filePath_in[i].ToString()
							)
						);
					} catch (Exception _ex) {
						throw new Exception(string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"\n---\n{0}.{1}.Load_fromURI():\nERROR READING XML:\n{2}\n---\n{3}",
							typeof(XS__metadataBusiness).Namespace, 
							typeof(XS__metadataBusiness).Name, 
							//(filePath_in[i].IsFile)
							//	? filePath_in[i].LocalPath
							//	: 
							filePath_in[i].ToString(),
							_ex.Message
						));
					}
					_output[i].root_metadatabusiness_ = ROOT + "." + METADATABUSINESS + "[" + i + "]";
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
			new XmlSerializer(typeof(XS__metadataBusiness)).Serialize(
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
			return OGen.Libraries.Generator.Utilities.ReflectThrough(
				this, 
				this.Root_MetadataBusiness, 
				null, 
				what_in, 
				this.Root_MetadataBusiness, 
				true, 
				true
			);
		}
		#endregion
		#region public void IterateThrough_fromRoot(...);
		public void IterateThrough_fromRoot(
			string iteration_in, 
			OGen.Libraries.Generator.Utilities.IterationFoundDelegate iteration_found_in,
			ref bool valueHasBeenFound_out
		) {
			OGen.Libraries.Generator.Utilities.ReflectThrough(
				this, 
				this.Root_MetadataBusiness, 
				iteration_found_in, 
				iteration_in, 
				this.Root_MetadataBusiness, 
				false, 
				true, 
				ref valueHasBeenFound_out
			);
		}
		#endregion
	}
}