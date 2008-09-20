<html>
    <head>
        <title>Could not find file 'X:\OGen.berlios.de\trunk\OGen-Doc-2\Doc_metadata\OGenXSD-metadatas\MD_Doc_templates.OGenXSD-metadata.xml'.</title>
        <style>
         body {font-family:"Verdana";font-weight:normal;font-size: .7em;color:black;} 
         p {font-family:"Verdana";font-weight:normal;color:black;margin-top: -5px}
         b {font-family:"Verdana";font-weight:bold;color:black;margin-top: -5px}
         H1 { font-family:"Verdana";font-weight:normal;font-size:18pt;color:red }
         H2 { font-family:"Verdana";font-weight:normal;font-size:14pt;color:maroon }
         pre {font-family:"Lucida Console";font-size: .9em}
         .marker {font-weight: bold; color: black;text-decoration: none;}
         .version {color: gray;}
         .error {margin-bottom: 10px;}
         .expandable { text-decoration:underline; font-weight:bold; color:navy; cursor:hand; }
        </style>
    </head>

    <body bgcolor="white">

            <span><H1>Server Error in '/' Application.<hr width=100% size=1 color=silver></H1>

            <h2> <i>Could not find file 'X:\OGen.berlios.de\trunk\OGen-Doc-2\Doc_metadata\OGenXSD-metadatas\MD_Doc_templates.OGenXSD-metadata.xml'.</i> </h2></span>

            <font face="Arial, Helvetica, Geneva, SunSans-Regular, sans-serif ">

            <b> Description: </b>An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.

            <br><br>

            <b> Exception Details: </b>System.IO.FileNotFoundException: Could not find file 'X:\OGen.berlios.de\trunk\OGen-Doc-2\Doc_metadata\OGenXSD-metadatas\MD_Doc_templates.OGenXSD-metadata.xml'.<br><br>

            <b>Source Error:</b> <br><br>

            <table width=100% bgcolor="#ffffcc">
               <tr>
                  <td>
                      <code><pre>

Line 63: 			string filePath_in
Line 64: 		) {
<font color=red>Line 65: 			FileStream _stream = new FileStream(
</font>Line 66: 				filePath_in,
Line 67: 				FileMode.Open,</pre></code>

                  </td>
               </tr>
            </table>

            <br>

            <b> Source File: </b> X:\OGen.berlios.de\trunk\OGen\OGen_generator\metadatas\Metadatas.cs<b> &nbsp;&nbsp; Line: </b> 65
            <br><br>

            <b>Stack Trace:</b> <br><br>

            <table width=100% bgcolor="#ffffcc">
               <tr>
                  <td>
                      <code><pre>

[FileNotFoundException: Could not find file 'X:\OGen.berlios.de\trunk\OGen-Doc-2\Doc_metadata\OGenXSD-metadatas\MD_Doc_templates.OGenXSD-metadata.xml'.]
   System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath) +328
   System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy) +1038
   System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share) +114
   OGen.lib.metadata.Metadatas.Load_fromFile(String filePath_in) in X:\OGen.berlios.de\trunk\OGen\OGen_generator\metadatas\Metadatas.cs:65
   OGen.XSD.lib.metadata.XS__RootMetadata..ctor(String metadataFilepath_in) in X:\OGen.berlios.de\trunk\OGen-XSD\XSD_metadata\_base\XS0__RootMetadata.cs:40
   OGen.XSD.lib.metadata.XS__RootMetadata.Load_fromFile(String metadataFilepath_in, Boolean useMetacache_in) in X:\OGen.berlios.de\trunk\OGen-XSD\XSD_metadata\_base\XS0__RootMetadata.cs:128
   ASP.xs_xs__baseclass_cs_aspx.__Render__control1(HtmlTextWriter __w, Control parameterContainer) in x:\OGen.berlios.de\trunk\OGen-XSD\XSD_templates\XS-XS__BaseClass.cs.aspx:24
   System.Web.UI.Control.RenderChildrenInternal(HtmlTextWriter writer, ICollection children) +98
   System.Web.UI.Control.RenderChildren(HtmlTextWriter writer) +21
   System.Web.UI.Page.Render(HtmlTextWriter writer) +27
   System.Web.UI.Control.RenderControlInternal(HtmlTextWriter writer, ControlAdapter adapter) +53
   System.Web.UI.Control.RenderControl(HtmlTextWriter writer, ControlAdapter adapter) +310
   System.Web.UI.Control.RenderControl(HtmlTextWriter writer) +24
   System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +7375
</pre></code>

                  </td>
               </tr>
            </table>

            <br>

            <hr width=100% size=1 color=silver>

            <b>Version Information:</b>&nbsp;Microsoft .NET Framework Version:2.0.50727.1433; ASP.NET Version:2.0.50727.1433

            </font>

    </body>
</html>
<!-- 
[FileNotFoundException]: Could not find file 'X:\OGen.berlios.de\trunk\OGen-Doc-2\Doc_metadata\OGenXSD-metadatas\MD_Doc_templates.OGenXSD-metadata.xml'.
   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy)
   at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share)
   at OGen.lib.metadata.Metadatas.Load_fromFile(String filePath_in) in X:\OGen.berlios.de\trunk\OGen\OGen_generator\metadatas\Metadatas.cs:line 65
   at OGen.XSD.lib.metadata.XS__RootMetadata..ctor(String metadataFilepath_in) in X:\OGen.berlios.de\trunk\OGen-XSD\XSD_metadata\_base\XS0__RootMetadata.cs:line 40
   at OGen.XSD.lib.metadata.XS__RootMetadata.Load_fromFile(String metadataFilepath_in, Boolean useMetacache_in) in X:\OGen.berlios.de\trunk\OGen-XSD\XSD_metadata\_base\XS0__RootMetadata.cs:line 128
   at ASP.xs_xs__baseclass_cs_aspx.__Render__control1(HtmlTextWriter __w, Control parameterContainer) in x:\OGen.berlios.de\trunk\OGen-XSD\XSD_templates\XS-XS__BaseClass.cs.aspx:line 24
   at System.Web.UI.Control.RenderChildrenInternal(HtmlTextWriter writer, ICollection children)
   at System.Web.UI.Control.RenderChildren(HtmlTextWriter writer)
   at System.Web.UI.Page.Render(HtmlTextWriter writer)
   at System.Web.UI.Control.RenderControlInternal(HtmlTextWriter writer, ControlAdapter adapter)
   at System.Web.UI.Control.RenderControl(HtmlTextWriter writer, ControlAdapter adapter)
   at System.Web.UI.Control.RenderControl(HtmlTextWriter writer)
   at System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
[HttpUnhandledException]: Exception of type 'System.Web.HttpUnhandledException' was thrown.
   at System.Web.UI.Page.HandleError(Exception e)
   at System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
   at System.Web.UI.Page.ProcessRequest(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
   at System.Web.UI.Page.ProcessRequest()
   at System.Web.UI.Page.ProcessRequestWithNoAssert(HttpContext context)
   at System.Web.UI.Page.ProcessRequest(HttpContext context)
   at ASP.xs_xs__baseclass_cs_aspx.ProcessRequest(HttpContext context) in c:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Temporary ASP.NET Files\root\dec3cfd5\de5e6cf8\App_Web_tqow-rmc.5.cs:line 0
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)
-->