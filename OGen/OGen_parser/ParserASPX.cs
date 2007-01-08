#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

    Free Software Foundation, Inc., 
    59 Temple Place, Suite 330, 
    Boston, MA 02111-1307 USA 

                            - or -

    http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Web;
using System.Web.Hosting;
using System.IO;
using System.Text;
using System.Collections;
using OGen.lib.presentationlayer.webforms;

namespace OGen.lib.parser {
    public class ParserASPX { private ParserASPX() {}
        #region static ParserASPX();
        static ParserASPX() {
            serverlist_ = new Hashtable();
        }
        #endregion

        #region private class _aux_SimpleWorkerRequest : SimpleWorkerRequest;
        private class _aux_SimpleWorkerRequest : SimpleWorkerRequest {
            public _aux_SimpleWorkerRequest(
                string page_in, 
                string query_in, 
                System.IO.TextWriter output_in
            ) : base(
                page_in, 
                query_in, 
                output_in
            ) {}

            #region public HttpServerUtility Server { get; }
            private HttpServerUtility server_;
            public HttpServerUtility Server {
                get { return server_; }
            }
            #endregion

            public override void SetEndOfSendNotification(
                EndOfSendNotification callback_in, 
                object extraData_in
            ) {
                base.SetEndOfSendNotification(callback_in, extraData_in);
                server_ = ((HttpContext)extraData_in).Server;
            }
        }
        #endregion
        #region private class _aux_HttpRuntime : MarshalByRefObject;
        private class _aux_HttpRuntime : MarshalByRefObject {
            public bool ProcessRequest(
//string appVirtualDir_in, 
//string appPhysicalDir_in, 
                string		aspxFile_in, 
                string		parameters_in, 
                TextWriter	textwriter_in
            ) {
                _aux_SimpleWorkerRequest _simpleworkerrequest = 
                    new _aux_SimpleWorkerRequest(
//appVirtualDir_in, 
//appPhysicalDir_in, 
                        aspxFile_in, 
                        parameters_in, 
                        textwriter_in
                    );
                HttpRuntime.ProcessRequest(
                    _simpleworkerrequest
                );
                if (
                    (_simpleworkerrequest.Server != null)
                    &&
                    (_simpleworkerrequest.Server.GetLastError() != null)
                ) {
                    _simpleworkerrequest.Server.ClearError();
                    return false;
                }
                return true;
            }
        }
        #endregion
        public static void Parse(
            string appPath_in, 
//string appVirtualPath_in, 
//string hostingVirtualPath_in, 
            string aspxFile_in, 
			out string result_out
        ) {
            Parse(
                appPath_in, 
//appVirtualPath_in, 
//hostingVirtualPath_in, 
                aspxFile_in, 
                new Hashtable(0), 
				out result_out
            );
        }
        private static Hashtable serverlist_;
        public static void Parse(
            string appPath_in, 
//string appVirtualPath_in, 
//string hostingVirtualPath_in, 
            string aspxFile_in, 
            Hashtable parameters_in, 
			out string result_out
        ) {
string appVirtualPath_in = "/";
string hostingVirtualPath_in = "/";
            string _parameters = OGen.lib.presentationlayer.webforms.utils.ConcatenateURLParams(parameters_in);
            string _domainId = "ParserASPX_" +  DateTime.Now.ToString().GetHashCode().ToString("x");
            string _applicationName = "ParserASPX";
            #region Checking...
            if (
                (appPath_in == string.Empty) ||
                (appVirtualPath_in == string.Empty) ||
                (aspxFile_in == string.Empty)
            ) {
                throw new Exception("empty parameters supplied");
            }

            if (appPath_in[appPath_in.Length - 1] !=  System.IO.Path.DirectorySeparatorChar)
                appPath_in += System.IO.Path.DirectorySeparatorChar;
            #endregion

            #region _appdomainsetup = new AppDomainSetup();
            AppDomainSetup _appdomainsetup = new AppDomainSetup();
            _appdomainsetup.ApplicationName = _applicationName;
            //_appdomainsetup.ConfigurationFile = "web.config";
            //_appdomainsetup.ApplicationBase = Directory.GetCurrentDirectory();
            //_appdomainsetup.DynamicBase = Directory.GetCurrentDirectory();
            //_appdomainsetup.ShadowCopyFiles = "true";
            //_appdomainsetup.PrivateBinPath
            #endregion
            #region _appdomain = AppDomain.CreateDomain(..., _appdomainsetup);
            AppDomain _appdomain = AppDomain.CreateDomain(
                _domainId, 
                null, 
                _appdomainsetup
            );
            _appdomain.SetData(".appDomain",			"*");
            _appdomain.SetData(".domainId",				_domainId);
            //---
            _appdomain.SetData(".appPath",				appPath_in);
            _appdomain.SetData(".appVPath",				appVirtualPath_in);
            _appdomain.SetData(".hostingVirtualPath",	hostingVirtualPath_in);
            //---
            _appdomain.SetData(".hostingInstallDir",	HttpRuntime.AspInstallDirectory);
            //_appdomain.SetData(".relativeSearchpath", appPath_in);
            #endregion
            #region _server = (_aux_HttpRuntime)_appdomain.CreateInstance(...).Unwrap();;
            // keeping resource consumption low, it was taking up too
            // much memory hence Hashtable's serverlist...
            _aux_HttpRuntime _server;
            if (serverlist_.ContainsKey(appPath_in)) {
                _server = (_aux_HttpRuntime)serverlist_[appPath_in];
            } else {
                _server = (_aux_HttpRuntime)_appdomain.CreateInstance(
                    typeof(_aux_HttpRuntime).Module.Assembly.FullName, 
                    typeof(_aux_HttpRuntime).FullName
                    //, true, 
                    //BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, 
                    //null,null,null,null,null
                ).Unwrap();

                serverlist_.Add(
                    appPath_in, 
                    _server
                );
            }
            #endregion

            StringBuilder _stringbuilder = new StringBuilder();
            StringWriter _stringwriter = new StringWriter(_stringbuilder);

            #region _server.ProcessRequest(aspxFile_in, _parameters, _stringwriter);
            bool _errorInProcess = !_server.ProcessRequest(
                //appVirtualPath_in, 
                //appPath_in, 
                aspxFile_in, 
                _parameters, 
                (TextWriter)_stringwriter
            );
            _stringwriter.Close();

            if (_errorInProcess) {
                throw new Exception(
                    string.Format(
                        "\n---\n{0}\n{1}?{2}\n---\n{3}", 
                        appPath_in, 
                        aspxFile_in, 
                        _parameters, 
                        _stringbuilder.ToString()
                    )
                );
            }
            #endregion

			result_out = _stringbuilder.ToString();
        }
    }
}
