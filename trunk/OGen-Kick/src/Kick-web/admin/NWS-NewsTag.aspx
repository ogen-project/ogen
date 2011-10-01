﻿<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-NewsTag.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.NWS_NewsTag" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.lib.presentationlayer.webforms"
	Assembly="OGen.lib.presentationlayer.webforms-2.0" %>
<%@ Register 
	src="../App_Controls/wuc_txt_Dic.ascx" 
	tagname="wuc_Dic" 
	tagprefix="asol" %>
<asp:Content
	id="cnt_Title" runat="server" 
	ContentPlaceHolderID="cph_Title">

	- Tag
</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">

	<table border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td style="width: 50%"></td>
			<td>
				<table
					border="0" cellpadding="2" cellspacing="0" width="100%">
					<tr>
						<td colspan="2" align="center" class="label_title">
							Tag
						</td>
					</tr>

					<tr><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td align="right" valign="top" class="label_small nowrap">
							Name:&nbsp;
						</td>
						<td>
							<asol:wuc_Dic
								ID="dic_Name" runat="server"
								Text_CssClass="textbox_dim4"
								Label_CssClass="label_small"
								Rows="1" />
						</td>
					</tr>
					<tr>
						<td align="right" class="label_small nowrap">
							Parent:&nbsp;
						</td>
						<td>
							<asol:KickListBox
								ID="ddl_Tag_parent" runat="server" 

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
								onclick="javascript:window.location='NWS-NewsTag-list.aspx';return false;" 
								value="Cancel"
								class="button" />
							<asp:Button
								ID="btn_Save" runat="server"
								OnClick="btn_Save_Click"

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