﻿<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="ServerVariables.aspx.cs" 
	Inherits="OGen.NTier.Kick.PresentationLayer.WebLayer.ServerVariables" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head runat="server">
		<title></title>
	</head>
	<body>
		<form id="MainForm" runat="server">
			<div style="font-family: Courier New; font-size: small">
				<asp:Literal
					ID="LIT_Dump" runat="server" />
			</div>
		</form>
	</body>
</html>