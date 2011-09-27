<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-News-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.NWS_News_list" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="kick" 
	Namespace="OGen.NTier.Kick.presentationlayer.weblayer"
	Assembly="OGen.NTier.Kick.presentationlayer.weblayer-2.0" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.lib.presentationlayer.webforms"
	Assembly="OGen.lib.presentationlayer.webforms-2.0" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<asp:Content
	id="cnt_Title" runat="server" 
	ContentPlaceHolderID="cph_Title">

	- Article Search
</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

	<script src="../include/htmlDatePicker.js" type="text/javascript" language="JavaScript"></script>
	<link href="../include/htmlDatePicker.css" type="text/css" rel="stylesheet" />
	<script language="javascript" type="text/javascript">
		DisablePast = false;
		dateFormat = "d/m/Y";
		DisableNoDateButton = false;
	</script>

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">

	<table border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td style="width: 50%"></td>
			<td>
				<table
					border="0" cellpadding="2" cellspacing="0" width="100%">
					<tr>
						<td colspan="2" align="center" class="label_title">
							Article Search
						</td>
					</tr>

					<tr><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Text:&nbsp;
						</td>
						<td>
							<asp:TextBox
								ID="txt_Text" runat="server"
								CssClass="textbox_dim4" />
						</td>
					</tr>
					<tr>
						<td align="right" class="label_small nowrap">
							State:&nbsp;
						</td>
						<td>
							<asol:KickListBox
								id="ddl_Approved" runat="server"

								CssClass="dropdownlist" 
								Rows="1" 
								SelectionMode="Single" />
						</td>
					</tr>
					<tr>
						<td align="right" class="label_small nowrap">
							Schedule:&nbsp;
						</td>
						<td class="label_small nowrap">
							between:
							<kick:htmlDatePicker
								ID="txt_Begin_date" runat="server" 
								class="date-pick textbox_date"
								onclick="javascript:GetDate(this);" />

							and:
							<kick:htmlDatePicker
								ID="txt_End_date" runat="server" 
								class="date-pick textbox_date"
								onclick="javascript:GetDate(this);" />

						</td>
					</tr>
					<tr>
						<td align="right" valign="top" class="label_small nowrap">
							Tag:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="cbl_Tags" runat="server"

								CssClass="checkboxlist" 
								RepeatColumns="2" 
								RepeatDirection="Vertical" />
						</td>
					</tr>
					<tr>
						<td align="right" valign="top" class="label_small nowrap">
							Author:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="cbl_Author" runat="server"

								CssClass="checkboxlist" 
								RepeatColumns="2" 
								RepeatDirection="Vertical" />
						</td>
					</tr>
					<tr>
						<td align="right" valign="top" class="label_small nowrap">
							Source:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="cbl_Source" runat="server"

								CssClass="checkboxlist" 
								RepeatColumns="2" 
								RepeatDirection="Vertical" />
						</td>
					</tr>
					<tr>
						<td align="right" valign="top" class="label_small nowrap">
							Highlight:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="cbl_Highlight" runat="server" 

								CssClass="checkboxlist" 
								RepeatColumns="2" 
								RepeatDirection="Vertical" />
						</td>
					</tr>
					<tr>
						<td align="right" valign="top" class="label_small nowrap">
							Profile:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="cbl_Profile" runat="server"

								CssClass="checkboxlist" 
								RepeatColumns="2" 
								RepeatDirection="Vertical" />
						</td>
					</tr>
					<tr>
						<td></td>
						<td align="right">
							<asp:Button
								ID="btn_Search" runat="server"
								OnClick="btn_Search_Click"

								CssClass="button"
								Text="Pesquisar" />
						</td>
					</tr>
				</table>
			</td>
			<td style="width: 50%"></td>
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
					<td colspan="4" align="center" class="label_subtitle alternating_item">
						Search Results
					</td>
				</tr>

				<tr>
					<td class="label_small" valign="bottom">
						Title
					</td>
					<td class="label_small" valign="bottom">
						Created by
					</td>
					<td class="label_small" valign="bottom">
						State
					</td>
					<td class="label_small" valign="bottom">
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<td class="label_small wrap">
						<a 
							href='NWS-News.aspx?IDContent=<%# DataBinder.Eval(Container.DataItem, "IDContent") %>'
							class="label_small">
							<%# 
								(
									(DataBinder.Eval(Container.DataItem, "Title") == DBNull.Value)
									||					
									((string)DataBinder.Eval(Container.DataItem, "Title") == "")
								) ? "&lt;empty&gt;" : (string)DataBinder.Eval(Container.DataItem, "Title")
							%></a>
					</td>
					<td class="label_small nowrap">
						<a 
							href='<%# "CRD-User.aspx?IDUser=" + ((long)DataBinder.Eval(Container.DataItem, "IFUser__Publisher")).ToString() %>'>
							<%# DataBinder.Eval(Container.DataItem, "PublisherName") %></a>
						<br />
						<%# ((DateTime)DataBinder.Eval(Container.DataItem, "Publish_date")).ToString("dd-MMM-yyyy HH:mm") %>
					</td>
					<td class="label_small nowrap">
						<%# 
							(
								(
									(
										(long)DataBinder.Eval(Container.DataItem, "IFUser__Aproved")
									) > 0
								) 
									? string.Format(
										//por: {1}, <br />
										"<a href='CRD-User.aspx?IDUser={0}'>{1}</a>, <br />{2}", 				
										((long)DataBinder.Eval(Container.DataItem, "IFUser__Aproved")).ToString(), 				
										OGen.NTier.Kick.presentationlayer.weblayer.NWS_News_list.ContentstateEnum.approved.ToString(), 
										((DateTime)DataBinder.Eval(Container.DataItem, "Aproved_date")).ToString("dd-MMM-yyyy HH:mm")
									)				
									: OGen.NTier.Kick.presentationlayer.weblayer.NWS_News_list.ContentstateEnum.pending.ToString().Replace('_', ' ')
							) %>
					</td>
					<td class="label_small nowrap" align="center">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td align="left">
									<asp:Button
										ID="btn_Delete" runat="server"
										CssClass="button"

										CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDContent")%>'
										OnClick="btn_Delete_Click"

										Text="Delete" />
								</td>
								<td>&nbsp;</td>
								<td align="right">
									<asp:Button
										ID="btn_Approve" runat="server"
										CssClass="button"
										Visible='<%#
											(
												(
													(long)DataBinder.Eval(Container.DataItem, "IFUser__Aproved")
												) <= 0
											)
										%>'

										CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDContent")%>'
										OnClick="btn_Approve_Click"

										Text="Approve" />
								</td>
							</tr>
						</table>
<%--
						<%# DataBinder.Eval(Container.DataItem, "IFUser__Publisher")%>
						|
						<%# DataBinder.Eval(Container.DataItem, "Publish_date")%>
						|
						<%# DataBinder.Eval(Container.DataItem, "Aproved_date")%>
--%>
					</td>
				</tr>
		</ItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
	</asp:Repeater>
	<br />

	<table
		border="0" cellpadding="2" cellspacing="0" width="100%">
		<tr>
			<td align="right">
				<input 
					type="button" 
					onclick="javascript:window.location='NWS-News.aspx';return false;" 
					value="New"
					class="button" />
			</td>
		</tr>
	</table>

</asp:Content>