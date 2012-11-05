<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="CRD-User-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.PresentationLayer.WebLayer.CRD_User_list" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.Libraries.PresentationLayer.WebForms"
	Assembly="OGen.Libraries.PresentationLayer.WebForms-2.0" %>
<asp:Content
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

	- User Search
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
								ID="TXT_LogOn" runat="server"
								CssClass="textbox_dim2" />
						</td>
					</tr>
					<tr>
						<td align="right" class="label_small nowrap">
							Email:&nbsp;
						</td>
						<td>
							<asp:TextBox
								ID="TXT_Email" runat="server"
								CssClass="textbox_dim4" />
						</td>
					</tr>
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
							On&nbsp;Profile:&nbsp;
						</td>
						<td>
							<asol:KickListBox
								id="DDL_Profile__in" runat="server"

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
								id="DDL_Profile__out" runat="server"

								CssClass="dropdownlist"
								Rows="1" 
								SelectionMode="Single" />
						</td>
					</tr>
					<tr>
						<td></td>
						<td align="right">
							<asp:Button
								ID="BTN_Search" runat="server"
								OnClick="BTN_Search_Click"
								CssClass="button"
								Text="Search" />
						</td>
					</tr>
				</table>
			</td>
			<td style="width: 50%"></td>
		</tr>
	</table>
	<br />

	<asp:Repeater
		ID="REP_SearchResults" runat="server">
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
						Email
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
							href='<%# "CRD-User.aspx?IDUser=" + ((long)DataBinder.Eval(Container.DataItem, "IDUser")).ToString(System.Globalization.CultureInfo.CurrentCulture) %>'>
						<%# DataBinder.Eval(Container.DataItem, "Login") %></a>
					</td>
					<td class="label_small wrap">
						<%# DataBinder.Eval(Container.DataItem, "Email") %>
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