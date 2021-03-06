﻿<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="DIC-Language.aspx.cs" 
	Inherits="OGen.NTier.Kick.PresentationLayer.WebLayer.DIC_Language" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.Libraries.PresentationLayer.WebForms"
	Assembly="OGen.Libraries.PresentationLayer.WebForms-2.0" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<%@ Register 
	src="../App_Controls/wuc_txt_Dic.ascx" 
	tagname="wuc_Dic" 
	tagprefix="asol" %>
<asp:Content
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

	- Language
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
							Language
						</td>
					</tr>

					<tr><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Language Name in:&nbsp;
						</td>
						<td>
							<table 
								border="0" cellpadding="2" cellspacing="0"
								id="TBL_NewLanguage" runat="server" visible="false">
								<tr>
									<td>
										<asp:TextBox
											ID="TXT_Name" runat="server"
											CssClass="textbox_dim15" />
									</td>
									<td>&nbsp;</td>
									<td class="label_small nowrap">
										(new language)
									</td>
								</tr>
							</table>

							<asol:wuc_Dic
								ID="DIC_LanguageNameIn" runat="server"
								Text_CssClass="textbox_dim15"
								Label_CssClass="label_small"
								Rows="1" />
						</td>
					</tr>

					<tr id="TR_New1" runat="server" visible="false"><td colspan="2">&nbsp;</td></tr>
					<tr id="TR_New2" runat="server" visible="false">
						<td align="right" class="label_small nowrap">
							existing Language Names&nbsp;<br />
							in new language:&nbsp;
						</td>
						<td>
							<asol:wuc_Dic
								ID="DIC_LanguagesInNewLanguage" runat="server"
								Text_CssClass="textbox_dim15"
								Label_CssClass="label_small"
								Rows="1" />
						</td>
					</tr>
					<tr id="TR_New3" runat="server" visible="false"><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td></td>
						<td align="right">
							<input 
								type="button" 
								onclick="javascript:window.location='DIC-Language-list.aspx';return false;" 
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