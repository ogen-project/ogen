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

	<table border="1" align="center" cellpadding="0" cellspacing="0">
		<tr>
			<td colspan="2">
				Search
			</td>
		</tr>
		<tr>
			<td>
				Login:
			</td>
			<td>
				<asp:TextBox
					ID="txt_Login" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				EMail:
			</td>
			<td>
				<asp:TextBox
					ID="txt_EMail" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				Name:
			</td>
			<td>
				<asp:TextBox
					ID="txt_Name" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				On Profile:
			</td>
			<td>
				<asol:KickListBox
					id="ddl_Profile__in" runat="server"

					Rows="1" 
					SelectionMode="Single" />
			</td>
		</tr>
		<tr>
			<td>
				Not on Profile:
			</td>
			<td>
				<asol:KickListBox
					id="ddl_Profile__out" runat="server"

					Rows="1" 
					SelectionMode="Single" />
			</td>
		</tr>
		<tr>
			<td colspan="2" align="right">
				<asp:Button
					ID="btn_Search" runat="server"
					OnClick="btn_Search_Click"

					Text="Search" />
			</td>
		</tr>
	</table>

	<asp:Repeater
		ID="rep_SearchResults" runat="server">
		<HeaderTemplate>
			<table border="1" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td colspan="3">
						User List
					</td>
				</tr>
				<tr>
					<td valign="bottom">
						Login
					</td>
					<td valign="bottom">
						EMail
					</td>
					<td valign="bottom">
						Name
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<td style="white-space:normal;">
						<a 
							href='<%# "CRD-User.aspx?IDUser=" + ((long)DataBinder.Eval(Container.DataItem, "IDUser")).ToString() %>'>
						<%# DataBinder.Eval(Container.DataItem, "Login") %></a>
					</td>
					<td style="white-space:normal;">
						<%# DataBinder.Eval(Container.DataItem, "EMail") %>
					</td>
					<td style="white-space:nowrap;">
						<%# DataBinder.Eval(Container.DataItem, "Name") %>
					</td>
				</tr>
		</ItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
	</asp:Repeater>


</asp:Content>