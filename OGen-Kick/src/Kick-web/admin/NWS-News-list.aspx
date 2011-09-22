<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-News-list.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.NWS_News_list" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%--<%@ Register 
	src="../App_Controls/wuc_txt_Dic.ascx" 
	tagname="wuc_txt_Dic" tagprefix="PTExp" %>--%>
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

	- Search News
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

	<table border="1" align="center" cellpadding="0" cellspacing="0">
		<tr>
			<td colspan="2">
				Search
			</td>
		</tr>
		<tr>
			<td>
				Text:
			</td>
			<td>
				<%--
				<PTExp:wuc_txt_Dic
					ID="dic_Name" runat="server" 
					Text_CssClass="textbox_dim4"
					Label_CssClass="cl_noticias_normal"
					Rows="1" />
				--%>
				<asp:TextBox
					ID="txt_Text" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				State:
			</td>
			<td>
				<asol:KickListBox
					id="ddl_Approved" runat="server"

					CssClass="cl_noticias_normal" 
					Rows="1" 
					SelectionMode="Single" />
			</td>
		</tr>
<%--
		<tr>
			<td>
				Inserido por:
			</td>
			<td>
				...
			</td>
		</tr>
--%>
		<tr>
			<td class="titulos">
				Schedule:
			</td>
			<td class="cl_noticias_normal">
				between:
				<kick:htmlDatePicker
					ID="txt_Begin_date" runat="server" 
					class="date-pick"
					onclick="javascript:GetDate(this);" />

				and:
				<kick:htmlDatePicker
					ID="txt_End_date" runat="server" 
					class="date-pick"
					onclick="javascript:GetDate(this);" />

			</td>
		</tr>
		<tr>
			<td class="titulos" valign="top">
				Tag: 
			</td>
			<td>
				<span class="texto_home">
					<asol:KickCheckBoxList
						ID="cbl_Tags" runat="server"

						CssClass="cl_noticias_normal" 
						RepeatColumns="2" 
						RepeatDirection="Vertical" />
				</span>
			</td>
		</tr>
		<tr>
			<td class="titulos" valign="top">
				Author: 
			</td>
			<td>
				<span class="texto_home">
					<asol:KickCheckBoxList
						ID="cbl_Author" runat="server"

						CssClass="cl_noticias_normal" 
						RepeatColumns="2" 
						RepeatDirection="Vertical" />
				</span>
			</td>
		</tr>
		<tr>
			<td class="titulos" valign="top">
				Source: 
			</td>
			<td>
				<span class="texto_home">
					<asol:KickCheckBoxList
						ID="cbl_Source" runat="server"

						CssClass="cl_noticias_normal" 
						RepeatColumns="2" 
						RepeatDirection="Vertical" />
				</span>
			</td>
		</tr>
		<tr>
			<td class="titulos" valign="top">
				Highlight: 
			</td>
			<td>
				<span class="texto_home">
					<asol:KickCheckBoxList
						ID="cbl_Highlight" runat="server" 

						CssClass="cl_noticias_normal" 
						RepeatColumns="2" 
						RepeatDirection="Vertical" />
				</span>
			</td>
		</tr>
		<tr>
			<td class="titulos" valign="top">
				Profile: 
			</td>
			<td>
				<span class="texto_home">
					<asol:KickCheckBoxList
						ID="cbl_Profile" runat="server"

						CssClass="cl_noticias_normal" 
						RepeatColumns="2" 
						RepeatDirection="Vertical" />
				</span>
			</td>
		</tr>
		<tr>
			<td height="70" colspan="2" align="right">
				<asp:Button
					ID="btn_Search" runat="server"
					OnClick="btn_Search_Click"

					CssClass="cl_noticias_normal"
					Text="Pesquisar" />
			</td>
		</tr>
	</table>

	<asp:Repeater
		ID="rep_SearchResults" runat="server">
		<HeaderTemplate>
			<table width="700" border="1" align="center" cellpadding="5" cellspacing="0">
				<tr>
					<td width="700" bgcolor="#DDDDDD" colspan="2" class="heads_maior">
						News
					</td>
				</tr>
			</table>
			<table width="700" border="1" align="center" cellpadding="5" cellspacing="0">
				<tr>
					<td class="titulos" valign="bottom">
						Title
					</td>
					<td class="titulos">
						Inserido por
					</td>
					<td class="titulos" valign="bottom">
						State
					</td>
					<td class="titulos" valign="bottom">
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<td class="cl_noticias_normal" style="white-space:normal;">
						<a 
							href='NWS-News.aspx?IDContent=<%# DataBinder.Eval(Container.DataItem, "IDContent") %>'
							class="cl_noticias_normal">
							<%# 
								(
									(DataBinder.Eval(Container.DataItem, "Title") == DBNull.Value)
									||					
									((string)DataBinder.Eval(Container.DataItem, "Title") == "")
								) ? "&lt;empty&gt;" : (string)DataBinder.Eval(Container.DataItem, "Title")
							%></a>
					</td>
					<td class="cl_noticias_normal" style="white-space:nowrap;">
						<a 
							href='<%# "CRD-User.aspx?IDUser=" + ((long)DataBinder.Eval(Container.DataItem, "IFUser__Publisher")).ToString() %>'>
							<%# DataBinder.Eval(Container.DataItem, "PublisherName") %></a>
						<br />
						<%# ((DateTime)DataBinder.Eval(Container.DataItem, "Publish_date")).ToString("dd-MMM-yyyy HH:mm") %>
					</td>
					<td class="cl_noticias_normal" style="white-space:nowrap;">
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
					<td class="cl_noticias_normal" align="center" style="white-space:nowrap;">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td align="left">
									<asp:Button
										ID="btn_Delete" runat="server"
										CssClass="cl_noticias_normal"

										CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDContent")%>'
										OnClick="btn_Delete_Click"

										Text="Remover" />
								</td>
								<td>&nbsp;</td>
								<td align="right">
									<asp:Button
										ID="btn_Approve" runat="server"
										CssClass="cl_noticias_normal"
										Visible='<%#
											(
												(
													(long)DataBinder.Eval(Container.DataItem, "IFUser__Aproved")
												) <= 0
											)
										%>'

										CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDContent")%>'
										OnClick="btn_Approve_Click"

										Text="Aprovar" />
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
</asp:Content>