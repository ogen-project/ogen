<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="News.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.FE_News"

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


	<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
		<tr class="alternating_item">
			<td colspan="2">
				<asp:Label ID="lbl_Title" runat="server" />
			</td>
			<td colspan="2" align="right">
				<asp:Label ID="lbl_Publish_date" runat="server" /> 
			</td>
		</tr>
		<tr>
			<td 
				id="td_image1" runat="server"
				valign="top" style="border-width: 1px;">
				<asp:Image 
					ID="img_News" runat="server"
					style="max-height: 176px; max-width: 300px; background-color: Red;" />
				<br />
				<asp:Label
					ID="lbl_Image_Name" runat="server" />
				<asp:Label
					ID="lbl_Image_Description" runat="server" />
			</td>
			<td colspan="3" valign="top">
				<asp:Label 
					ID="lbl_Content" runat="server" />
			</td>
		</tr>
		<tr>
			<td style="height: 0px; width: 0px;"></td>
			<td style="height: 0px;"></td>
			<td style="height: 0px;"></td>
			<td style="height: 0px;"></td>
		</tr>
		<tr id="tr_Attachments1" runat="server">
			<td colspan="3"></td>
			<td valign="bottom" class="label_small" align="right">
				<asp:Repeater
					ID="rep_Attachments" runat="server">
					<HeaderTemplate>
						<table border="0" cellpadding="0" cellspacing="0">
					</HeaderTemplate>
					<ItemTemplate>
						<tr>
							<td>
								&bull;&nbsp;<a 
									runat="server"
									target="_blank"
									href='<%# 
										string.Format(
											"~/public-uploads/news/{0}/{1}-{2}/{3}", 
											DataBinder.Eval(Container.DataItem, "IFContent"), 
											DataBinder.Eval(Container.DataItem, "IDAttachment"), 
											DataBinder.Eval(Container.DataItem, "GUID"), 
											DataBinder.Eval(Container.DataItem, "FileName")
										)%>'><%# 
									DataBinder.Eval(Container.DataItem, "FileName")%></a>
							</td>
						</tr>
					</ItemTemplate>
					<FooterTemplate>
						</table>
					</FooterTemplate>
				</asp:Repeater>
			</td>
		</tr>
		<tr>
			<td colspan="2" class="nowrap label_small">
				<asp:Repeater
					ID="rep_Sources" runat="server">
					<HeaderTemplate>(source: </HeaderTemplate>
					<ItemTemplate><%# 
						(Container.ItemIndex == 0) ? "" : ", " %>
						<a 
							href="<%# string.Format(
								"News-list.aspx?IDSource={0}", 
								DataBinder.Eval(Container.DataItem, "IDSource")
							)%>"><%# DataBinder.Eval(Container.DataItem, "Name")%></a></ItemTemplate>
					<FooterTemplate>)</FooterTemplate>
				</asp:Repeater>
			</td>
			<td colspan="2" class="nowrap label_small" align="right">
				<asp:Repeater
					ID="rep_Tags" runat="server">
					<ItemTemplate>
						#<a 
							href="<%# string.Format(
								"News-list.aspx?IDTag={0}", 
								DataBinder.Eval(Container.DataItem, "IDTag")
							)%>"><%# DataBinder.Eval(Container.DataItem, "Name")%></a>&nbsp;&nbsp;
					</ItemTemplate>
				</asp:Repeater>
			</td>
		</tr>
	</table>

</asp:Content>