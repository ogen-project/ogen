<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-NewsSource-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.NWS_NewsSource_list" 
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

	- Source Search
</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">

	<table width="700" border="1" align="center" cellpadding="5" cellspacing="0">
		<tr>
			<td width="700" bgcolor="#DDDDDD" colspan="2" class="heads_maior">
				Source Search
			</td>
		</tr>
	</table>
	<anthem:Repeater
		ID="rep_Sources" runat="server"
		AutoUpdateAfterCallBack="true">
		<HeaderTemplate>
			<table width="700" border="1" align="center" cellpadding="5" cellspacing="0">
				<tr>
					<td class="titulos">
						Name
					</td>
					<td class="titulos" style="white-space:nowrap;">
						Approved by
					</td>
					<td class="titulos" style="white-space:nowrap;">
						in
					</td>
					<td class="titulos">
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<td class="cl_noticias_normal" style="width: 100%;">
						<a 
							href='NWS-NewsSource.aspx?IDSource=<%# DataBinder.Eval(Container.DataItem, "IDSource") %>'
							class="cl_noticias_normal">
							<%# 
								(((string)DataBinder.Eval(Container.DataItem, "Name")).Trim() == "")
									? "&lt;empty&gt;"
									: (string)DataBinder.Eval(Container.DataItem, "Name")
							%></a>
					</td>
					<td class="cl_noticias_normal" style="white-space:nowrap;">
						<%# DataBinder.Eval(Container.DataItem, "ManagerName") %>
					</td>
					<td class="cl_noticias_normal" style="white-space:nowrap;">
						<%#
							(
								(
									(long)DataBinder.Eval(Container.DataItem, "IFUser__Approved")
								) <= 0
							) ? "" : ((DateTime)DataBinder.Eval(Container.DataItem, "Approved_date")).ToString("dd-MMM-yyyy HH:mm")
						%>
					</td>
					<td class="cl_noticias_normal" align="center" style="white-space:nowrap;">
						<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr>
							<td align="left">
								<anthem:Button
									ID="btn_Delete" runat="server"
									CssClass="cl_noticias_normal"
									Text="Delete" 

									CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDSource")%>'
									OnClick="btn_Delete_Click"
									EnableCallBack="true"
									EnabledDuringCallBack="false" />
							</td>
							<td>&nbsp;</td>
							<td align="right">
								<anthem:Button
									ID="btn_Approve" runat="server"
									CssClass="cl_noticias_normal"
									Visible='<%#
										(
											(
												(long)DataBinder.Eval(Container.DataItem, "IFUser__Approved")
											) <= 0
										)
									%>'
									Text="Approve"

									CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDSource")%>'
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
	<table width="700" border="1" align="center" cellpadding="5" cellspacing="0">
		<tr height="70">
			<td align="right">
				<input 
					type="button" 
					onclick="javascript:window.location='NWS-NewsSource.aspx';return false;" 
					value="Create"
					class="cl_noticias_normal" />
			</td>
		</tr>
	</table>

</asp:Content>