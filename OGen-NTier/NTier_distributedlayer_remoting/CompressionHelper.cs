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

namespace OGen.NTier.lib.distributedlayer.remoting {
	public class CompressionHelper {
		public const string X_COMPRESS = "X-Compress";

		#region public static Stream GetCompressedStreamCopy(...);
		public static Stream GetCompressedStreamCopy(
			Stream stream_in
		) {
#if DEBUG
Console.WriteLine("compressing...");
#endif
			MemoryStream _output_stream = new MemoryStream();
			byte[] _buf = new byte[1000];
			int _count;
#if DEBUG
int _total = 0;
#endif
			while ((_count = stream_in.Read(_buf, 0, 1000)) > 0) {
#if DEBUG
_total += _count;
#endif
				_output_stream.Write(_buf, 0, _count);
			}
			_output_stream.Flush();
			_output_stream.Seek(0, SeekOrigin.Begin);

#if DEBUG
			_output_stream = SevenZip.Compression.LZMA.SevenZipHelper.Compress(
				_output_stream
			);
Console.WriteLine("compress: size before: {0}", _total);
Console.WriteLine("compress: size after: {0}", _output_stream.Length);
			return _output_stream;
#else
			return SevenZip.Compression.LZMA.SevenZipHelper.Compress(
				_output_stream
			);
#endif

			#region // old stuff...
			//Stream outStream = new System.IO.MemoryStream();
			//NZlib.Streams.DeflaterOutputStream compressStream = new NZlib.Streams.DeflaterOutputStream(
			//    outStream,
			//    new NZlib.Compression.Deflater(NZlib.Compression.Deflater.BEST_COMPRESSION)
			//);


			//byte[] buf = new Byte[1000];
			//int cnt = stream_in.Read(buf, 0, 1000);
			//while (cnt > 0) {
			//    compressStream.Write(buf, 0, cnt);
			//    cnt = stream_in.Read(buf, 0, 1000);
			//}
			//compressStream.Finish();
			//compressStream.Flush();
			//return outStream;


			//Stream _output = new System.IO.MemoryStream();
			//ICSharpCode.SharpZipLib.BZip2.BZip2.Compress(
			//    stream_in,
			//    _output,
			//    9
			//);
			//return _output;

			//Stream _output = new System.IO.MemoryStream();
			//using (stream_in) {
			//    using (ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream bzos
			//        = new ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream(
			//            _output, 
			//            9
			//        )
			//) {
			//        int ch = stream_in.ReadByte();
			//        while (ch != -1) {
			//            bzos.WriteByte((byte)ch);
			//            ch = stream_in.ReadByte();
			//        }
			//    }
			//}
			//return _output;

			//ICSharpCode.SharpZipLib.BZip2.BZip2.Compress(
			//    stream_in,
			//    _output,
			//    9
			//);
			//return _output;

			//Stream _output = new System.IO.MemoryStream();
			//ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream _compressStream
			//    = new ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream(
			//        _output
			//    );
			//byte[] _buffer = new byte[1000];

			//int _count;
			//while (
			//    (_count = stream_in.Read(_buffer, 0, 1000))
			//        > 0
			//) {
			//    _compressStream.Write(_buffer, 0, _count);
			//}
			//_compressStream.Flush();
			//_output.Seek(0, SeekOrigin.Begin);

			//return _output; 
			#endregion
		} 
		#endregion
		#region public static Stream GetUncompressedStreamCopy(...);
		public static Stream GetUncompressedStreamCopy(
			Stream stream_in
		) {
#if DEBUG
Console.WriteLine("decompressing...");
#endif
			MemoryStream _output_stream = new MemoryStream();
			byte[] _buf = new byte[1000];
			int _count;
#if DEBUG
int _total = 0;
#endif
			while ((_count = stream_in.Read(_buf, 0, 1000)) > 0) {
#if DEBUG
_total += _count;
#endif
				_output_stream.Write(_buf, 0, _count);
			}
			_output_stream.Flush();
			_output_stream.Seek(0, SeekOrigin.Begin);

#if DEBUG
			_output_stream = SevenZip.Compression.LZMA.SevenZipHelper.Decompress(
				_output_stream
			);
Console.WriteLine("decompress: size before: {0}", _total);
Console.WriteLine("decompress: size after: {0}", _output_stream.Length);
			return _output_stream;
#else
			return SevenZip.Compression.LZMA.SevenZipHelper.Decompress(
				_output_stream
			);
#endif

			#region // old stuff...
			//return new NZlib.Streams.InflaterInputStream(stream_in);

			//return GetCompressedStreamCopy(
			//    stream_in
			//);


			//string _xxx = new StreamReader(stream_in, System.Text.Encoding.Default).ReadToEnd();
			//byte[] _yyy = new byte[_xxx.Length];
			//for (int i = 0; i < _xxx.Length; i++) {
			//    _yyy[i] = (byte)_xxx[i];
			//}
			//return SevenZip.Compression.LZMA.SevenZipHelper.DecompressXXX(
			//    _yyy
			//);

			//return SevenZip.Compression.LZMA.SevenZipHelper.Decompress(
			//    stream_in
			//);

	
			//Stream _output = new System.IO.MemoryStream();
			//SevenZip.Compression.LZMA.Decoder _dec = new SevenZip.Compression.LZMA.Decoder();
			//_dec.Code(
			//    stream_in,
			//    _output,
			//    -1,
			//    -1,
			//    null
			//);
			//return _output;

			//MemoryStream _output = new MemoryStream();
			//ICSharpCode.SharpZipLib.BZip2.BZip2.Decompress(
			//    stream_in,
			//    _output
			//);
			//return _output;

			//MemoryStream _output = new MemoryStream();
			//stream_in
			//    = new ICSharpCode.SharpZipLib.BZip2.BZip2InputStream(
			//        stream_in
			//    );

			//byte[] _buffer = new byte[1000];

			//int _count;
			//while (
			//    (_count = stream_in.Read(_buffer, 0, 1000))
			//        > 0
			//) {
			//    _output.Write(_buffer, 0, _count);
			//}
			//_output.Seek(0, SeekOrigin.Begin);

			//return _output;
			#endregion
		} 
		#endregion
	}
}