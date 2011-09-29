<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Registration-confirmEMail.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.Registration_confirmEMail" 

	MasterPageFile="~/App_Controls/Site.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<asp:Content
	id="cnt_Title" runat="server" 
	ContentPlaceHolderID="cph_Title">

</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">


	<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
		<tr class="alternating_item">
			<td class="label_small">
				Updating EMail...
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label 
					ID="lbl_Error" runat="server" />
			</td>
		</tr>
	</table>

</asp:Content>