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
using System.IO;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;
using OGen.lib.generator;

namespace OGen.lib.metadata {
	[System.Xml.Serialization.XmlRootAttribute("metadatas")]
	public class Metadatas : iClaSSe_metadata {
		//public Metadatas() {
		//}

		public const string METADATA = "metadatas";
		public const string ROOT_METADATA = "ROOT." + Metadatas.METADATA;

		#region public ... MetadataFiles { get; }
#if !NET_1_1
		private 
			OGenSimpleCollection<Metadata> metadatacollection_
				= new OGenSimpleCollection<Metadata>();
#else
		private MetadataCollection metadatacollection_
			= new MetadataCollection();
#endif

		[XmlElement("metadata")]
		public Metadata[] metadatafiles__xml {
			get { return metadatacollection_.cols__; }
			set { metadatacollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public
#if !NET_1_1
			OGenSimpleCollection<Metadata>
#else
			MetadataCollection
#endif
		MetadataFiles {
			get { return metadatacollection_; }
		}
		#endregion

		#region public static Metadatas Load_fromFile(...);
		public static Metadatas Load_fromFile(
			string filePath_in
		) {
			FileStream _stream = new FileStream(
				filePath_in,
				FileMode.Open,
				FileAccess.Read,
				FileShare.Read
			);

			Metadatas _output;
			try {
				_output = (Metadatas)new XmlSerializer(typeof(Metadatas)).Deserialize(
					_stream
				);
			} catch (Exception _ex) {
				throw new Exception(string.Format(
					"\n---\n{0}.{1}.Load_fromFile(): - ERROR READING XML:\n{2}\n---\n{3}",
					typeof(Metadatas).Namespace, 
					typeof(Metadatas).Name, 
					filePath_in,
					_ex.Message
				));
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
			new XmlSerializer(typeof(Metadatas)).Serialize(
				_file,
				this
			);
			_file.Flush();
			_file.Close();
		}
		#endregion

		public string Read_fromRoot(string what_in) {
			return OGen.lib.generator.utils.ReflectThrough(
				this, 
				ROOT_METADATA, 
				null, 
				what_in, 
				ROOT_METADATA, 
				true, 
				true
			);
		}

		public void IterateThrough_fromRoot(
			string iteration_in, 
			cClaSSe.dIteration_found iteration_found_in
		) {
			OGen.lib.generator.utils.ReflectThrough(
				this, 
				ROOT_METADATA, 
				iteration_found_in, 
				iteration_in, 
				ROOT_METADATA, 
				false, 
				true
			);
		}
	}
}
