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
using OGen.lib.generator;
using OGen.Doc.lib.metadata;
using OGen.Doc.lib.generator;

namespace OGen.Doc.presentationlayer.console {
	class MainClass {
		[STAThread]
		static void Main(string[] args_in) {
			#region Console.WriteLine("Copyright (C) 2002 Francisco Monteiro");
			Console.WriteLine(
				@"

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

"
			);
			#endregion
			if (args_in.Length == 1) {
				if (File.Exists(args_in[0])) {
					DoIt(args_in[0]);
				} else {
					Console.WriteLine("file doesn't exist");
				}
			} else {
#if DEBUG
				long _begin_ticks = DateTime.Now.Ticks;

				DoIt(
					//@"\\127.0.0.1\OGen_source$\OGen-NTier\OGen-NTier-Doc\OGenDoc-metadatas\MD_OGen-NTier.OGenDoc-metadata.xml"

					System.IO.Path.Combine(
						#if !NET_1_1
						System.Configuration.ConfigurationManager.AppSettings
						#else
						System.Configuration.ConfigurationSettings.AppSettings
						#endif
							["ogenPath"],

						@"..\..\doc\OGen-Doc-metadatas\MD_OGen.OGenDoc-metadata.xml"
					)
				);

				Console.WriteLine("time: {0}", new DateTime(DateTime.Now.Ticks - _begin_ticks).ToString("HH'H' mm'm' ss's' fff"));
#else
				Console.WriteLine("must provide xml file");
#endif
			}
		}

		static void DoIt(string filePath_in) {
			cFGenerator _generator = new cFGenerator();
			_generator.Open(
				filePath_in, 
				true, 
				new cFGenerator.dNotifyBack(
					Notify
				)
			);
			_generator.Build(new cGenerator.dBuild(Notify));

		}
		#region private static void Notify(string message_in, bool onANewLine_in);
		private static void Notify(string message_in, bool onANewLine_in) {
			if (onANewLine_in) {
				Console.WriteLine(message_in);
			} else {
				Console.Write(message_in);
			}
		}
		#endregion
	}
}
