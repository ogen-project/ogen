<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-NewsProfile.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.NWS_NewsProfile" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.lib.presentationlayer.webforms"
	Assembly="OGen.lib.presentationlayer.webforms-2.0" %>
<%@ Register 
	src="../App_Controls/wuc_txt_Dic.ascx" 
	tagname="wuc_Dic" 
	tagprefix="asol" %>
<asp:Content
	id="cnt_Title" runat="server" 
	ContentPlaceHolderID="cph_Title">

	- Profile
</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">

	<table width="700" border="1" align="center" cellpadding="5" cellspacing="0">
		<tr>
			<td width="700" bgcolor="#DDDDDD">
				<span class="heads_maior">Profile</span>
			</td>
		</tr>
	</table>
	<table width="700" border="1" align="center" cellpadding="5" cellspacing="0">
		<tr>
			<td width="200" class="titulos">
				Name
			</td>
			<td width="500">
				<asp:TextBox
					ID="txt_Name" runat="server"
					CssClass="textbox_dim4" />
			</td>
		</tr>
		<tr style="border-color: #CCCCCC;">
			<td 
				colspan="2"
				height="70"
				align="right" 
				valign="middle" 
				class="texto_home"
				style="border-color:#CCCCCC;">
				<span class="titulos">
					<input 
						type="button" 
						onclick="javascript:window.location='NWS-NewsProfile-list.aspx';return false;" 
						value="Cancel"
						class="cl_noticias_normal" />
					<asp:Button
						ID="btn_Save" runat="server"
						OnClick="btn_Save_Click"
						
						CssClass="cl_noticias_normal"
						Text="Save" />
				</span>
			</td>
		</tr>
	</table>

</asp:Content>