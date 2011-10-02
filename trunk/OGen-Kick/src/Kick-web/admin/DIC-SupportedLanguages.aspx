<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="DIC-SupportedLanguages.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.DIC_SupportedLanguages" 
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

	- Supported Languages
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
			<td align="center" class="label_title">
				Supported Languages
			</td>
		</tr>
		<tr><td>&nbsp;</td></tr>
	</table>
	<table 
		border="0" align="center" cellpadding="2" cellspacing="1" width="100%">
		<tr>
			<td align="center" class="label_subtitle alternating_item">
				Languages
			</td>
		</tr>
		<tr>
			<td align="center" class="label_small">
				<asol:KickCheckBoxList
					ID="cbl_Languages" runat="server"

					CssClass="checkboxlist nowrap"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="false"
					RepeatColumns="1" />
			</td>
		</tr>
		<tr>
			<td class="label_small" align="center">
				<anthem:Button
					ID="btn_Save" runat="server"
					CssClass="button"
					Text="Save" 

					OnClick="btn_Save_Click"
					EnableCallBack="true"
					EnabledDuringCallBack="false" />
			</td>
		</tr>
	</table>

</asp:Content>