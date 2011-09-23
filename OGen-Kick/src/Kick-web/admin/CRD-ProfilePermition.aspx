<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="CRD-ProfilePermition.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.CRD_ProfilePermition" 
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

	- Profiles
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
				Profiles
			</td>
		</tr>

		<tr><td colspan="2">&nbsp;</td></tr>

		<tr>
			<td align="right" class="label_small nowrap">
				Profile:&nbsp;
			</td>
			<td>
				<asol:KickListBox
					ID="ddl_Profile" runat="server" 

					OnSelectedIndexChanged="ddl_Profile_SelectedIndexChanged"
					AutoCallBack="true"
					EnabledDuringCallBack="false"

					CssClass="dropdownlist"
					Rows="1" 
					SelectionMode="Single" />
			</td>
		</tr>
		<tr>
			<td align="right" valign="top" class="label_small nowrap">
				Permitions:&nbsp;
			</td>
			<td style="width: 200px;">
				<asol:KickCheckBoxList
					ID="cbl_Permitions" runat="server"

					CssClass="checkboxlist nowrap"
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
					Text="  Save  " />
			</td>
		</tr>
	</table>


</asp:Content>