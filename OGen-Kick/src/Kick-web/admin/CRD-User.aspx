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

	<table border="0" align="center" cellpadding="0" cellspacing="0">
		<tr>
			<td colspan="2" align="center">
				<b>User</b>
			</td>
		</tr>
		<tr>
			<td>
				Login:
			</td>
			<td>
				<asp:TextBox
					ID="txt_Login" runat="server"
					Enabled="false" ReadOnly="true" />
			</td>
		</tr>
		<tr>
			<td>
				EMail:
			</td>
			<td>
				<asp:TextBox
					ID="txt_EMail" runat="server"
					Enabled="false" ReadOnly="true" />
			</td>
		</tr>
		<tr>
			<td>
				Nome:
			</td>
			<td>
				<asp:TextBox
					ID="txt_Name" runat="server"
					Enabled="false" ReadOnly="true" />
			</td>
		</tr>
		<tr>
			<td valign="top">
				Profiles:
			</td>
			<td>
				<asol:KickCheckBoxList
					ID="cbl_Profiles" runat="server"

					AutoUpdateAfterCallBack="true"
					EnableCallBack="false" />
			</td>
		</tr>
		<tr>
			<td colspan="2" align="right">
				<anthem:Button
					ID="btn_Profile" runat="server"
					OnClick="btn_Profile_Click"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="true"

					Text="Submit" />
			</td>
		</tr>
	</table>


</asp:Content>