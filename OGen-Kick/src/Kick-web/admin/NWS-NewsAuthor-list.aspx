<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-NewsAuthor.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.NWS_NewsAuthor_list" 
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

	- Author Search
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
				Author Search
			</td>
		</tr>
		<tr><td colspan="2">&nbsp;</td></tr>
	</table>
	<anthem:Repeater
		ID="rep_Authors" runat="server"
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
					<td class="label_small nowrap">
						Approved by
					</td>
					<td class="label_small nowrap">
						in
					</td>
					<td class="label_small">
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<td class="label_small nowrap" style="width: 100%;">
						<a 
							href='NWS-NewsAuthor.aspx?IDAuthor=<%# DataBinder.Eval(Container.DataItem, "IDAuthor") %>'
							class="label_small">
							<%# 
								(((string)DataBinder.Eval(Container.DataItem, "Name")).Trim() == "")
									? "&lt;empty&gt;"
									: (string)DataBinder.Eval(Container.DataItem, "Name")
							%></a>
					</td>
					<td class="label_small nowrap">
						<%# DataBinder.Eval(Container.DataItem, "ManagerName") %>
					</td>
					<td class="label_small nowrap">
						<%#
							(
								(
									(long)DataBinder.Eval(Container.DataItem, "IFUser__Approved")
								) <= 0
							) ? "" : ((DateTime)DataBinder.Eval(Container.DataItem, "Approved_date")).ToString("dd-MMM-yyyy HH:mm")
						%>
					</td>
					<td class="label_small nowrap" align="center">
						<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr>
							<td align="left">
								<anthem:Button
									ID="btn_Delete" runat="server"
									CssClass="button"
									Text="Delete" 

									CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDAuthor")%>'
									OnClick="btn_Delete_Click"
									EnableCallBack="true"
									EnabledDuringCallBack="false" />
							</td>
							<td>&nbsp;</td>
							<td align="right">
								<anthem:Button
									ID="btn_Approve" runat="server"
									CssClass="button"
									Visible='<%#
										(
											(
												(long)DataBinder.Eval(Container.DataItem, "IFUser__Approved")
											) <= 0
										)
									%>'
									Text="Approve"

									CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDAuthor")%>'
									OnClick="btn_Approve_Click"
									EnableCallBack="true"
									EnabledDuringCallBack="false" />
							</td>
						</tr></table>
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
					onclick="javascript:window.location='NWS-NewsAuthor.aspx';return false;" 
					value="New"
					class="button" />
			</td>
		</tr>
	</table>

</asp:Content>