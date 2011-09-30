<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="CRD-Profile-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.CRD_Profile_list" 
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

	- Profile Search
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
				Profile Search
			</td>
		</tr>
		<tr><td>&nbsp;</td></tr>
	</table>
	<anthem:Repeater
		ID="rep_Profiles" runat="server"
		AutoUpdateAfterCallBack="true">
		<HeaderTemplate>
			<table 
				border="0" align="center" cellpadding="2" cellspacing="1" width="100%"
				class="table_alternating">
				<tr>
					<td colspan="4" align="center" class="label_subtitle alternating_item">
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
							href='CRD-Profile.aspx?IDProfile=<%# DataBinder.Eval(Container.DataItem, "IDProfile") %>'
							class="label_small">
							<%# 
								(((string)DataBinder.Eval(Container.DataItem, "Name")).Trim() == "")
									? "&lt;empty&gt;"
									: (string)DataBinder.Eval(Container.DataItem, "Name")
							%></a>
					</td>
					<td class="label_small nowrap" align="center">
						<anthem:Button
							ID="btn_Delete" runat="server"
							CssClass="button"
							Text="Delete" 

							CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDProfile")%>'
							OnClick="btn_Delete_Click"
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
					onclick="javascript:window.location='CRD-Profile.aspx';return false;" 
					value="New"
					class="button" />
			</td>
		</tr>
	</table>

</asp:Content>