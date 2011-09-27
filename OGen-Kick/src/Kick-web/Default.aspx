<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Default.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.Default" 
	MasterPageFile="~/App_Controls/Site.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<asp:Content
	id="cnt_Title" runat="server" 
	ContentPlaceHolderID="cph_Title">

</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">

			<anthem:Repeater
				ID="rep_News" runat="server"
				AutoUpdateAfterCallBack="true">
				<ItemTemplate>
					<anthem:Repeater
						ID="rep_News_Tags" runat="server"
						AutoUpdateAfterCallBack="true">
						<HeaderTemplate>
							<table width="100%" border="1" cellpadding="0" cellspacing="0">
								<tr>
									<td>&nbsp;&nbsp;</td>
						</HeaderTemplate>
						<ItemTemplate>
									<td>
										<%# DataBinder.Eval(Container.DataItem, "Name") %>&nbsp;&nbsp;&nbsp;
									</td>
						</ItemTemplate>
						<FooterTemplate>
									<td width="100%"></td>
								</tr>
							</table>
						</FooterTemplate>
					</anthem:Repeater>
					<table width="100%" border="1" cellpadding="0" cellspacing="0">
						<tr>
							<td></td>
							<td>
								<a 
									href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>'>
									<strong><%# DataBinder.Eval(Container.DataItem, "Title") %></strong></a>
							</td>
							<td></td>
						</tr>

						<tr id="tr_ImageNews" runat="server" visible="false">
							<td></td>
							<td valign="top">
								<anthem:Image
									ID="img_News" runat="server"
									AutoUpdateAfterCallBack="true"
									Visible="false"
									style="max-height: 100px; max-width: 400px;" />
							</td>
							<td></td>
						</tr>

						<tr>
							<td></td>
							<td>
								<a 
									href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>' 
									class="texto_11"><%# DataBinder.Eval(Container.DataItem, "summary") %></a>
							</td>
							<td></td>
						</tr>
						<tr valign="bottom">
							<td></td>
							<td>



								<table border="1" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td align="left">
											<anthem:Repeater
												ID="rep_News_Sources" runat="server"
												Visible="false"
												AutoUpdateAfterCallBack="true">
												<HeaderTemplate>
													<em>(Fonte 
												</HeaderTemplate>
												<ItemTemplate><%# 
													(Container.ItemIndex == 0) ? "" : ", " %>
													<span>
														<%# DataBinder.Eval(Container.DataItem, "Name") %></span></ItemTemplate>
												<FooterTemplate>)</em>
												</FooterTemplate>
											</anthem:Repeater>
										</td>
										<td align="right">
											<a 
												href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>'>VER MAIS</a>
										</td>
									</tr>
								</table>





							</td>
							<td></td>
						</tr>
						<tr>
							<td colspan="3">&nbsp;</td>
						</tr>
					</table>
				</ItemTemplate>
			</anthem:Repeater>

</asp:Content>