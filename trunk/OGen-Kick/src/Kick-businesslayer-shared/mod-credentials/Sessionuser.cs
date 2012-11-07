﻿#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.BusinessLayer.Shared {
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Sessionuser {
		public Sessionuser(
			long idUser_in,
			long[] idPermissions_in
		) {
			this.IDUser = idUser_in;
			this.IDPermissions = idPermissions_in;
		}

		public long IDUser;
		public long[] IDPermissions;

		#region public bool hasPermission(...);
		public bool hasPermission(
			long idPermission_in
		) {
			return this.hasPermission(
				false,
				idPermission_in
			);
		}

		public bool hasPermission(
			bool forAll_notJustOne_in,
			params long[] idPermissions_in
		) {
			int _total = 0;
			for (int j = 0; j < idPermissions_in.Length; j++) {
				for (int i = 0; i < this.IDPermissions.Length; i++) {
					if (
						this.IDPermissions[i]
						==
						idPermissions_in[j]
					) {
						if (!forAll_notJustOne_in)
							return true;
						_total++;
						break;
					}
				}
				if (_total == idPermissions_in.Length)
					return true;
			}

			return false;
		}
		#endregion
		#region public static bool Guid_TryParse(string guid_in, out Guid guid_out);
		public static bool Guid_TryParse(string guid_in, out Guid guid_out) {
			try {
				guid_out = new Guid(guid_in);
				return true;
			} catch {
				guid_out = Guid.Empty;
				return false;
			}
		}
		#endregion

		#region public static bool checkLogin(string login_in, List<int> errors_in);
		public static bool checkLogin(
			string login_in,
			ref List<int> errors_in
		) {
			if (
				((login_in = login_in.Trim()).Length < 3)
				||
				(login_in.Length > 255)
			) {
				errors_in.Add(ErrorType.user__invalid_login);
				return false;
			}

			for (int i = 0; i < login_in.Length; i++) {
				switch (login_in[i]) {
					case '@':
					case '<':
					case '>':
						errors_in.Add(ErrorType.user__invalid_login);
						return false;
				}
			}

			return true;
		}
		#endregion
	}
}