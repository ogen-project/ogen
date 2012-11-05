<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Registration-confirmEmail.aspx.cs" 
	Inherits="OGen.NTier.Kick.PresentationLayer.WebLayer.Registration_confirmEmail" 

	MasterPageFile="~/App_Controls/Site.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<asp:Content
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

</asp:Content>
<asp:Content
	id="CNT_Head" runat="server"
	ContentPlaceHolderID="CPH_Head">

</asp:Content>
<asp:Content
	id="CNT_Body" runat="server"
	ContentPlaceHolderID="CPH_Body">


	<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
		<tr class="alternating_item">
			<td class="label_small">
				Updating Email...
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label 
					ID="LBL_Error" runat="server" />
			</td>
		</tr>
	</table>

</asp:Content>