<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Registration-changePassword.aspx.cs" 
	Inherits="OGen.NTier.Kick.PresentationLayer.WebLayer.Registration_changePassword" 

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
					ID="TXT_PasswordNew" runat="server" 
					AutoUpdateAfterCallBack="true" 

					TextMode="Password"
					CssClass="textbox_dim15" />

				&nbsp;&nbsp;
				<anthem:Label
					ID="LBL_PasswordNew" runat="server"
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
					ID="TXT_PasswordConfirm" runat="server" 
					AutoUpdateAfterCallBack="true" 

					TextMode="Password"
					CssClass="textbox_dim15" />

				&nbsp;&nbsp;
				<anthem:Label
					ID="LBL_PasswordConfirm" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td align="left">
				<anthem:Button
					ID="BTN_RegistrationPasswordUpdate" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="LBT_RegistrationPasswordUpdate_Click"

					CssClass="button"
					Text="Save" />
			</td>
		</tr>
	</table>

</asp:Content>