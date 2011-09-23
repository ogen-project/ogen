<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="CRD-User.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.CRD_User" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.lib.presentationlayer.webforms"
	Assembly="OGen.lib.presentationlayer.webforms-2.0" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<asp:Content
	id="cnt_Title" runat="server" 
	ContentPlaceHolderID="cph_Title">

	- User
</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">

	<table
		border="0" cellpadding="2" cellspacing="0" width="100%">
		<tr>
			<td colspan="2" align="center" class="label_title">
				<b>User</b>
			</td>
		</tr>

		<tr><td colspan="2">&nbsp;</td></tr>

		<tr>
			<td align="right" class="label_small nowrap">
				Login:&nbsp;
			</td>
			<td>
				<asp:TextBox
					ID="txt_Login" runat="server"
					CssClass="textbox_dim2" 
					Enabled="false" ReadOnly="true" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				EMail:&nbsp;
			</td>
			<td>
				<asp:TextBox
					ID="txt_EMail" runat="server"
					CssClass="textbox_dim4" 
					Enabled="false" ReadOnly="true" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				Name:&nbsp;
			</td>
			<td>
				<asp:TextBox
					ID="txt_Name" runat="server"
					CssClass="textbox_dim4" 
					Enabled="false" ReadOnly="true" />
			</td>
		</tr>
		<tr>
			<td align="right" valign="top" class="label_small nowrap">
				Profiles:&nbsp;
			</td>
			<td>
				<asol:KickCheckBoxList
					ID="cbl_Profiles" runat="server"

					CssClass="checkboxlist"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="false" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td align="right">
				<anthem:Button
					ID="btn_Profile" runat="server"
					OnClick="btn_Profile_Click"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="true"
					CssClass="button"
					Text="Submit" />
			</td>
		</tr>
	</table>


</asp:Content>