<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="CRD-User-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.CRD_User_list" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.lib.presentationlayer.webforms"
	Assembly="OGen.lib.presentationlayer.webforms-2.0" %>
<asp:Content
	id="cnt_Title" runat="server" 
	ContentPlaceHolderID="cph_Title">

	- User Search
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
				User Search
			</td>
		</tr>

		<tr><td colspan="2">&nbsp;</td></tr>

		<tr>
			<td align="right" class="label_small nowrap">
				Login:&nbsp;
			</td>
			<td>
				<asp:TextBox
					ID="txt_Login" runat="server"
					CssClass="textbox_dim2" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				EMail:&nbsp;
			</td>
			<td>
				<asp:TextBox
					ID="txt_EMail" runat="server"
					CssClass="textbox_dim4" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				Name:&nbsp;
			</td>
			<td>
				<asp:TextBox
					ID="txt_Name" runat="server"
					CssClass="textbox_dim4" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				On&nbsp;Profile:&nbsp;
			</td>
			<td>
				<asol:KickListBox
					id="ddl_Profile__in" runat="server"

					CssClass="dropdownlist"
					Rows="1" 
					SelectionMode="Single" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				Not&nbsp;on&nbsp;Profile:&nbsp;
			</td>
			<td>
				<asol:KickListBox
					id="ddl_Profile__out" runat="server"

					CssClass="dropdownlist"
					Rows="1" 
					SelectionMode="Single" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td align="right">
				<asp:Button
					ID="btn_Search" runat="server"
					OnClick="btn_Search_Click"
					CssClass="button"
					Text="Search" />
			</td>
		</tr>
	</table>
	<br />

	<asp:Repeater
		ID="rep_SearchResults" runat="server">
		<HeaderTemplate>
			<table 
				border="0" align="center" cellpadding="2" cellspacing="1" width="100%"
				class="table_alternating">
				<tr>
					<td colspan="3" align="center" class="label_subtitle alternating_item">
						Search Results
					</td>
				</tr>
				<tr>
					<td valign="bottom" class="label_small">
						Login
					</td>
					<td valign="bottom" class="label_small">
						EMail
					</td>
					<td valign="bottom" class="label_small">
						Name
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<td class="label_small wrap">
						<a 
							href='<%# "CRD-User.aspx?IDUser=" + ((long)DataBinder.Eval(Container.DataItem, "IDUser")).ToString() %>'>
						<%# DataBinder.Eval(Container.DataItem, "Login") %></a>
					</td>
					<td class="label_small wrap">
						<%# DataBinder.Eval(Container.DataItem, "EMail") %>
					</td>
					<td class="label_small wrap">
						<%# DataBinder.Eval(Container.DataItem, "Name") %>
					</td>
				</tr>
		</ItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
	</asp:Repeater>


</asp:Content>