<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="News-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.FE_News_list"

	MasterPageFile="~/App_Controls/Site.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<asp:Content
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

</asp:Content>
<asp:Content
	id="CNT_Head" runat="server"
	ContentPlaceHolderID="CPH_Head">

</asp:Content>
<asp:Content
	id="CNT_Body" runat="server"
	ContentPlaceHolderID="CPH_Body">

	<table 
		id="TBL_News" runat="server" visible="false"
		width="100%" border="0" cellpadding="1" cellspacing="0" class="table_thin">
		<tr>
			<td valign="top" 

style="height: 100%; width: 0%;">

				<anthem:HiddenField
					ID="HFI_Source" runat="server" 
					AutoUpdateAfterCallBack="true" />
				<anthem:HiddenField
					ID="HFI_IDTag" runat="server" 
					AutoUpdateAfterCallBack="true" />
				<anthem:Repeater
					ID="REP_Tags" runat="server"
					AutoUpdateAfterCallBack="true">
					<HeaderTemplate>
						<table 
							width="100%" 
							border="0" 
							cellpadding="4" 
							cellspacing="0"
							class="table_thin"
style="height: 100%;">
							<tr>
								<td>
									-&nbsp;<anthem:LinkButton
										ID="lbt_Tag__news" runat="server"
										EnableCallBack="true"
										EnabledDuringCallBack="false"
										OnClick="Tag_Click"
										CommandArgument=""

										CssClass="label_small nowrap">ALL&nbsp;NEWS</anthem:LinkButton>&nbsp;-
								</td>
							</tr>
					</HeaderTemplate>
					<ItemTemplate>
							<tr>
								<td>
									<anthem:LinkButton
										ID="lbt_Tag" runat="server"
										EnableCallBack="true"
										EnabledDuringCallBack="false"
										OnClick="Tag_Click"
										CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDTag") %>'
										CssClass='<%# "label_small nowrap " + (((long)DataBinder.Eval(Container.DataItem, "IDTag") == IDTag) ? "label_bold" : "") %>'>
										<%# DataBinder.Eval(Container.DataItem, "Name") %></anthem:LinkButton>
								</td>
							</tr>
					</ItemTemplate>
					<FooterTemplate>
						</table>
					</FooterTemplate>
				</anthem:Repeater>
			</td>
			<td valign="top" style="width: 100%;">

				<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
					<tr>
						<td align="right">
							<a 
								id="A_Page_1" runat="server"
								class="label_small" />

							<asp:Label
								ID="LBL_PageSeparator_left" runat="server" 
								CssClass="label_small" />

							<asp:Label
								ID="LBL_PageSeparator_2" runat="server" /><a 
								id="A_Page_2" runat="server"
								class="label_small" />
							<asp:Label
								ID="LBL_PageSeparator_3" runat="server" /><a 
								id="A_Page_3" runat="server"
								class="label_small label_bold" />
							<asp:Label
								ID="LBL_PageSeparator_4" runat="server" /><a 
								id="A_Page_4" runat="server"
								class="label_small" />

							<asp:Label
								ID="LBL_PageSeparator_right" runat="server" 
								CssClass="label_small" />

							<asp:Label
								ID="LBL_PageSeparator_5" runat="server"/><a 
								id="A_Page_5" runat="server"
								class="label_small" />
						</td>
					</tr>
				</table>
				<br />

				<anthem:Repeater
					ID="REP_News" runat="server"
					AutoUpdateAfterCallBack="true">
					<ItemTemplate><%# 
						(Container.ItemIndex == 0) ? "" : "<br />"%>
						<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
							<tr class="alternating_item">
								<td colspan="2">
									<a 
										href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString(System.Globalization.CultureInfo.CurrentCulture) %>'
										style="width: 100%; height: 100%;">
										<div style="width: 100%; height: 100%;"><%# DataBinder.Eval(Container.DataItem, "Title") %></div></a>
								</td>
							</tr>

							<tr>
								<td valign="top" colspan="2">
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
										<tr>
											<td valign="top">
												<anthem:Image
													ID="IMG_News" runat="server"
													AutoUpdateAfterCallBack="true"
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

							<tr>
								<td align="left" class="label_small nowrap">

									<anthem:Repeater
										ID="REP_News_Sources" runat="server"
										Visible="false"
										AutoUpdateAfterCallBack="true">
										<HeaderTemplate>(source: </HeaderTemplate>
										<ItemTemplate><%# 
											(Container.ItemIndex == 0) ? "" : ", " %>
											<anthem:LinkButton
												ID="lbt_NewsSource" runat="server"
												EnableCallBack="true"
												EnabledDuringCallBack="false"
												OnClick="Source_Click"
												CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDSource") %>'

												CssClass="label_small"><%# DataBinder.Eval(Container.DataItem, "Name") %></anthem:LinkButton></ItemTemplate>
										<FooterTemplate>)</FooterTemplate>
									</anthem:Repeater>

								</td>
								<td align="right" class="label_small nowrap">
									<anthem:Repeater
										ID="REP_News_Tags" runat="server"
										AutoUpdateAfterCallBack="true">
										<ItemTemplate>
											&nbsp;#<anthem:LinkButton
												ID="lbt_NewsTag" runat="server"
												EnableCallBack="true"
												EnabledDuringCallBack="false"
												OnClick="Tag_Click"
												CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDTag") %>'

												CssClass="label_small"><%# DataBinder.Eval(Container.DataItem, "Name") %></anthem:LinkButton>
										</ItemTemplate>
									</anthem:Repeater>
								</td>
							</tr>
						</table>
					</ItemTemplate>
				</anthem:Repeater>
			</td>
		</tr>
	</table>

</asp:Content>