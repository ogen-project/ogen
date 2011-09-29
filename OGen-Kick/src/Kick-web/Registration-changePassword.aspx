<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Registration-changePassword.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.Registration_changePassword" 

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
			<td colspan="2" class="label_small">
				Join
			</td>
		</tr>

		<tr>
			<td style="width: 45%;" align="right" class="label_small">
				New Password:&nbsp;
			</td>
			<td style="width: 55%;" align="left">
				<anthem:TextBox
					ID="txt_PasswordNew" runat="server" 
					AutoUpdateAfterCallBack="true" 

					TextMode="Password"
					CssClass="textbox_dim15" />

				&nbsp;&nbsp;
				<anthem:Label
					ID="lbl_PasswordNew" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Re-type New Password:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="txt_PasswordConfirm" runat="server" 
					AutoUpdateAfterCallBack="true" 

					TextMode="Password"
					CssClass="textbox_dim15" />

				&nbsp;&nbsp;
				<anthem:Label
					ID="lbl_PasswordConfirm" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td align="left">
				<anthem:Button
					ID="btn_RegistrationPasswordUpdate" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="lbt_RegistrationPasswordUpdate_Click"

					CssClass="button"
					Text="Save" />
			</td>
		</tr>
	</table>

</asp:Content>