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

	<table border="0" cellpadding="4" cellspacing="0" width="100%" class="table_thin">
		<tr class="alternating_item">
			<td colspan="2">
				Join
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Name:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="txt_Name" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="lbl_Name" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				EMail:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="txt_EMail" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="lbl_EMail" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Confirm EMail:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="txt_EMail_Confirmation" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="lbl_EMail_Confirmation" runat="server" 
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
					ID="txt_Login" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim1" />
				<anthem:Label
					ID="lbl_Login" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<anthem:Button
					ID="btn_Registration" runat="server"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="btn_Registration_Click"

					CssClass="button"
					Text="Submit" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<ul>
					<anthem:Label
						ID="lbl_Error" runat="server" 
						AutoUpdateAfterCallBack="true" />
				</ul>
			</td>
		</tr>
	</table>
	<br />

	<table border="0" cellpadding="4" cellspacing="0" width="100%" class="table_thin">
		<tr class="alternating_item">
			<td colspan="2">
				Lost your Password? Let us mail you with instructions to recover your account
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				EMail:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="txt_LostPassword_EMail" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="lbl_LostPassword_EMail" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small">
				Confirm EMail:&nbsp;
			</td>
			<td align="left">
				<anthem:TextBox
					ID="txt_LostPassword_EMail_Confirmation" runat="server"
					AutoUpdateAfterCallBack="true"

					CssClass="textbox_dim25" />
				<anthem:Label
					ID="lbl_LostPassword_EMail_Confirmation" runat="server" 
					AutoUpdateAfterCallBack="true"

					CssClass="label_error" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<anthem:Button
					ID="btn_LostPassword" runat="server"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="btn_LostPassword_Click"

					CssClass="button"
					Text="Submit" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<ul>
					<anthem:Label
						ID="lbl_LostPassword_Error" runat="server" 
						AutoUpdateAfterCallBack="true" />
				</ul>
			</td>
		</tr>
	</table>
</asp:Content>