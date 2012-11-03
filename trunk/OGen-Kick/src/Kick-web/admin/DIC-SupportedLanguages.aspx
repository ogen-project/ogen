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
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

	- Supported Languages
</asp:Content>
<asp:Content
	id="CNT_Head" runat="server"
	ContentPlaceHolderID="CPH_Head">

</asp:Content>
<asp:Content
	id="CNT_Body" runat="server"
	ContentPlaceHolderID="CPH_Body">

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
					ID="CBL_Languages" runat="server"

					CssClass="checkboxlist nowrap"
					AutoUpdateAfterCallBack="true"
					EnableCallBack="false"
					RepeatColumns="1" />
			</td>
		</tr>
		<tr>
			<td class="label_small" align="center">
				<anthem:Button
					ID="BTN_Save" runat="server"
					CssClass="button"
					Text="Save" 

					OnClick="BTN_Save_Click"
					EnableCallBack="true"
					EnabledDuringCallBack="false" />
			</td>
		</tr>
	</table>

</asp:Content>