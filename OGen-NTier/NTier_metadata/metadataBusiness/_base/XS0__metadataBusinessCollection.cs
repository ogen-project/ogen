<html>
    <head>
        <title>Object reference not set to an instance of an object.</title>
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

            <h2> <i>Object reference not set to an instance of an object.</i> </h2></span>

            <font face="Arial, Helvetica, Geneva, SunSans-Regular, sans-serif ">

            <b> Description: </b>An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.

            <br><br>

            <b> Exception Details: </b>System.NullReferenceException: Object reference not set to an instance of an object.<br><br>

            <b>Source Error:</b> <br><br>

            <table width=100% bgcolor="#ffffcc">
               <tr>
                  <td>
                      <code><pre>

Line 75: 
Line 76: 				for (int i = 0; i &lt; &lt;%=_aux_schema.Element.Name.ToLower()%&gt;collection_.Length; i++) {
<font color=red>Line 77: 					if (&lt;%=_aux_schema.Element.Name.ToLower()%&gt;collection_[i].&lt;%=_aux_rootmetadata.MetadataCollection[0].MetadataIndexCollection[_aux_schema.Element.Name].Index%&gt; == name_in) {
</font>Line 78: 						return &lt;%=_aux_schema.Element.Name.ToLower()%&gt;collection_[i];
Line 79: 					}</pre></code>

                  </td>
               </tr>
            </table>

            <br>

            <b> Source File: </b> x:\OGen.berlios.de\trunk\OGen-XSD\XSD_templates\XS-XS0__BaseClassCollection.cs.aspx<b> &nbsp;&nbsp; Line: </b> 77
            <br><br>

            <b>Stack Trace:</b> <br><br>

            <table width=100% bgcolor="#ffffcc">
               <tr>
                  <td>
                      <code><pre>

[NullReferenceException: Object reference not set to an instance of an object.]
   ASP.xs_xs0__baseclasscollection_cs_aspx.__Render__control1(HtmlTextWriter __w, Control parameterContainer) in x:\OGen.berlios.de\trunk\OGen-XSD\XSD_templates\XS-XS0__BaseClassCollection.cs.aspx:77
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
[NullReferenceException]: Object reference not set to an instance of an object.
   at ASP.xs_xs0__baseclasscollection_cs_aspx.__Render__control1(HtmlTextWriter __w, Control parameterContainer) in x:\OGen.berlios.de\trunk\OGen-XSD\XSD_templates\XS-XS0__BaseClassCollection.cs.aspx:line 77
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
   at ASP.xs_xs0__baseclasscollection_cs_aspx.ProcessRequest(HttpContext context) in c:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Temporary ASP.NET Files\root\f9485a64\49ec1bda\App_Web_hqud0ztx.9.cs:line 0
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)
-->