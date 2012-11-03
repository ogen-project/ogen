<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="DIC-Language-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.DIC_Language_list" 
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

	- Language Search
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
				Language Search
			</td>
		</tr>
		<tr><td>&nbsp;</td></tr>
	</table>
	<anthem:Repeater
		ID="REP_Languages" runat="server"
		AutoUpdateAfterCallBack="true">
		<HeaderTemplate>
			<table 
				border="0" align="center" cellpadding="2" cellspacing="1" width="100%"
				class="table_alternating">
				<tr>
					<td colspan="2" align="center" class="label_subtitle alternating_item">
						Search Results
					</td>
				</tr>

				<tr>
					<td class="label_small">
						Name
					</td>
					<td class="label_small">
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<td class="label_small nowrap" style="width: 100%;">
						<a 
							href='DIC-Language.aspx?IDLanguage=<%# DataBinder.Eval(Container.DataItem, "IDLanguage") %>'
							class="label_small">
							<%# 
								(((string)DataBinder.Eval(Container.DataItem, "Language")).Trim().Length == 0)
									? "&lt;empty&gt;"
									: (string)DataBinder.Eval(Container.DataItem, "Language")
							%></a>
					</td>
					<td class="label_small nowrap" align="center">
						<anthem:Button
							ID="BTN_Delete" runat="server"
							CssClass="button"
							Text="Delete" 

							CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDLanguage")%>'
							OnClick="BTN_Delete_Click"
							EnableCallBack="true"
							EnabledDuringCallBack="false" />
					</td>
				</tr>
		</ItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
	</anthem:Repeater>
	<br />

	<table
		border="0" cellpadding="2" cellspacing="0" width="100%">
		<tr>
			<td align="right">
				<input 
					type="button" 
					onclick="javascript:window.location='DIC-Language.aspx';return false;" 
					value="New"
					class="button" />
			</td>
		</tr>
	</table>

</asp:Content>