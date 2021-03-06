﻿<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-NewsHighlight.aspx.cs" 
	Inherits="OGen.NTier.Kick.PresentationLayer.WebLayer.NWS_NewsHighlight" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.Libraries.PresentationLayer.WebForms"
	Assembly="OGen.Libraries.PresentationLayer.WebForms-2.0" %>
<%@ Register 
	src="../App_Controls/wuc_txt_Dic.ascx" 
	tagname="wuc_Dic" 
	tagprefix="asol" %>
<asp:Content
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

	- Highlight
</asp:Content>
<asp:Content
	id="CNT_Head" runat="server"
	ContentPlaceHolderID="CPH_Head">

</asp:Content>
<asp:Content
	id="CNT_Body" runat="server"
	ContentPlaceHolderID="CPH_Body">

	<table border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td style="width: 50%"></td>
			<td>
				<table
					border="0" cellpadding="2" cellspacing="0" width="100%">
					<tr>
						<td colspan="2" align="center" class="label_title">
							Highlight
						</td>
					</tr>

					<tr><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Name:&nbsp;
						</td>
						<td>
							<asp:TextBox
								ID="TXT_Name" runat="server"
								CssClass="textbox_dim4" />
						</td>
					</tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Parent:&nbsp;
						</td>
						<td>
							<asol:KickListBox
								ID="DDL_Highlight_parent" runat="server" 

								CssClass="dropdownlist" 
								Rows="1" 
								SelectionMode="Single" />
						</td>
					</tr>
					<tr>
						<td></td>
						<td align="right">
							<input 
								type="button" 
								onclick="javascript:window.location='NWS-NewsHighlight-list.aspx';return false;" 
								value="Cancel"
								class="button" />
							<asp:Button
								ID="BTN_Save" runat="server"
								OnClick="BTN_Save_Click"
						
								CssClass="button"
								Text="Save" />
						</td>
					</tr>
				</table>
			</td>
			<td style="width: 50%"></td>
		</tr>
	</table>

</asp:Content>