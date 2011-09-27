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
					<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
						<tr>
							<td colspan="4" class="alternating_item">
								<a 
									href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>'
									class="">
									<%# DataBinder.Eval(Container.DataItem, "Title") %></a>
							</td>
						</tr>

						<tr>
							<td valign="top">
								<anthem:Image
									ID="img_News" runat="server"
									AutoUpdateAfterCallBack="true"
									Visible="false"
									style="
										max-height: 100px; max-width: 400px;
										margin: 3px;
									" />
							</td>
							<td colspan="3" valign="top">
								<a 
									href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>' 
									class="texto_11"><%# DataBinder.Eval(Container.DataItem, "summary") %></a>
							</td>
						</tr>
						<tr>
							<td style="height: 0px;"></td>
							<td style="height: 0px; width: 50%;"></td>
							<td style="height: 0px; width: 50%;"></td>
							<td style="height: 0px;"></td>
						</tr>
						<tr>
							<td colspan="2" align="left" class="label_small nowrap">
								<anthem:Repeater
									ID="rep_News_Sources" runat="server"
									Visible="false"
									AutoUpdateAfterCallBack="true">
									<HeaderTemplate>(source: </HeaderTemplate>
									<ItemTemplate><%# 
										(Container.ItemIndex == 0) ? "" : ", " %>
										<span>
											<%# DataBinder.Eval(Container.DataItem, "Name") %></span></ItemTemplate>
									<FooterTemplate>)</FooterTemplate>
								</anthem:Repeater>
							</td>
							<td colspan="2" align="right" class="label_small nowrap">
								<anthem:Repeater
									ID="rep_News_Tags" runat="server"
									AutoUpdateAfterCallBack="true">
									<HeaderTemplate>
									</HeaderTemplate>
									<ItemTemplate>
										&nbsp;#<%# DataBinder.Eval(Container.DataItem, "Name") %>
									</ItemTemplate>
									<FooterTemplate>
									</FooterTemplate>
								</anthem:Repeater>
							</td>
						</tr>
					</table>
					<br />
				</ItemTemplate>
			</anthem:Repeater>

</asp:Content>