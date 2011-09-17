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
using System.Collections.Generic;
using System.Text;

namespace OGen.NTier.Kick.lib.businesslayer {
	public static class utils {
		public class Sessionuser {
			public Sessionuser(
				DateTime sessionstart_in,
				long idUser_in,
				long[] idPermitions_in
			) {
				Sessionstart = sessionstart_in;
				IDUser = idUser_in;
				IDPermitions = idPermitions_in;
			}

			public DateTime Sessionstart;
			public long IDUser;
			public long[] IDPermitions;

			#region public bool hasPermition(...);
			public bool hasPermition(
				long idPermition_in
			) {
				return hasPermition(
					false,
					idPermition_in
				);
			}

			public bool hasPermition(
				bool forAll_notJustOne_in,
				params long[] idPermitions_in
			) {
				int _total = 0;
				for (int j = 0; j < idPermitions_in.Length; j++) {
					for (int i = 0; i < IDPermitions.Length; i++) {
						if (
							IDPermitions[i]
							==
							idPermitions_in[j]
						) {
							if (!forAll_notJustOne_in)
								return true;
							_total++;
							break;
						}
					}
					if (_total == idPermitions_in.Length)
						return true;
				}

				return false;
			}
			#endregion
		}

		public static bool Guid_TryParse(string guid_in, out Guid guid_out) {
			try {
				guid_out = new Guid(guid_in);
				return true;
			} catch {
				guid_out = Guid.Empty;
				return false;
			}
		}
	}
}