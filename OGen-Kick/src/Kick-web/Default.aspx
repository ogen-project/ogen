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
					<td colspan="2" class="alternating_item">
						<a 
							href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>'
							style="width: 100%; height: 100%;"
							class="">
							<div style="width: 100%; height: 100%;"><%# DataBinder.Eval(Container.DataItem, "Title") %></div></a>
					</td>
				</tr>

				<tr>
					<td valign="top" colspan="2">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
									<anthem:Image
										ID="img_News" runat="server"
										AutoUpdateAfterCallBack="true"
										Visible="false"
										style="
											vertical-align: top;
											max-height: 100px; max-width: 400px;
											margin: 3px;
										" />
								</td>
								<td valign="top" style="
									width: 100%;
								">
									<%# DataBinder.Eval(Container.DataItem, "summary") %>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr 
					id="tr_Details" runat="server" 
					visible="false">

					<td align="left" class="label_small nowrap">
						<anthem:Repeater
							ID="rep_News_Sources" runat="server"
							Visible="false"
							AutoUpdateAfterCallBack="true">
							<HeaderTemplate>(source: </HeaderTemplate>
							<ItemTemplate><%# 
								(Container.ItemIndex == 0) ? "" : ", " %>
								<%# DataBinder.Eval(Container.DataItem, "Name") %></ItemTemplate>
							<FooterTemplate>)</FooterTemplate>
						</anthem:Repeater>
					</td>
					<td align="right" class="label_small nowrap">
						<anthem:Repeater
							ID="rep_News_Tags" runat="server"
							Visible="false"
							AutoUpdateAfterCallBack="true">
							<ItemTemplate>
								&nbsp;#<%# DataBinder.Eval(Container.DataItem, "Name") %>
							</ItemTemplate>
						</anthem:Repeater>
					</td>
				</tr>
			</table>
			<br />
		</ItemTemplate>
	</anthem:Repeater>

</asp:Content>