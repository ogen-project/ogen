#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Instances.Utilities {
	using System;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Instances;

#if NET_1_1
	public class Config { private Config() { }
#else
	public static class Config {
#endif

		public static void ReConfig() {
			CRD_Authentication.ReConfig();
			CRD_Permission.ReConfig();
			CRD_Profile.ReConfig();
			CRD_User.ReConfig();
			DIC_Dic.ReConfig();
			LOG_Log.ReConfig();
			NWS_Attachment.ReConfig();
			NWS_Author.ReConfig();
			NWS_Highlight.ReConfig();
			NWS_News.ReConfig();
			NWS_Profile.ReConfig();
			NWS_Source.ReConfig();
			NWS_Tag.ReConfig();
			WEB_DefaultProfile.ReConfig();
			WEB_User.ReConfig();
		}
	}
}