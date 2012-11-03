<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Registration.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.Registration" 

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

	<table border="0" cellpadding="4" cellspacing="0" width="100%" class="table_thin">
		<tr class="alternating_item">
			<td colspan="2" class="label_small">
				Join
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Name:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="TXT_Name" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="LBL_Name" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Email:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="TXT_Email" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="LBL_Email" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Confirm Email:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="TXT_Email_Confirmation" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="LBL_Email_Confirmation" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Username:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="TXT_LogOn" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim1" />
				<anthem:Label
					ID="LBL_LogOn" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<anthem:Button
					ID="BTN_Registration" runat="server"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="BTN_Registration_Click"

					CssClass="button"
					Text="Submit" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<ul>
					<anthem:Label
						ID="LBL_Error" runat="server" 
						AutoUpdateAfterCallBack="true" />
				</ul>
			</td>
		</tr>
	</table>
	<br />

	<table border="0" cellpadding="4" cellspacing="0" width="100%" class="table_thin">
		<tr class="alternating_item">
			<td colspan="2" class="label_small">
				Lost your Password? Let us mail you with instructions to recover your account
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Email:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="TXT_LostPassword_Email" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="LBL_LostPassword_Email" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Confirm Email:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="TXT_LostPassword_Email_Confirmation" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="LBL_LostPassword_Email_Confirmation" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<anthem:Button
					ID="BTN_LostPassword" runat="server"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="BTN_LostPassword_Click"

					CssClass="button"
					Text="Submit" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<ul>
					<anthem:Label
						ID="LBL_LostPassword_Error" runat="server" 
						AutoUpdateAfterCallBack="true" />
				</ul>
			</td>
		</tr>
	</table>
</asp:Content>