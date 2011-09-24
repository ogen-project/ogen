<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="NWS-News.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.NWS_News" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<%@ Register 
	TagPrefix="kick" 
	Namespace="OGen.NTier.Kick.presentationlayer.weblayer"
	Assembly="OGen.NTier.Kick.presentationlayer.weblayer-2.0" %>
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

	- Article
</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

	<link href="../include/tabber.css" rel="stylesheet" type="text/css" />
	<script src="../include/tabber.js" type="text/javascript"></script>
	<script type="text/javascript">
		/* Optional: Temporarily hide the "tabber" class so it does not "flash"
		on the page as plain HTML. After tabber runs, the class is changed
		to "tabberlive" and it will appear. */
		document.write('<style type="text/css">.tabber{display:none;}<\/style>');
	</script>

</asp:Content>
<asp:Content
	id="cnt_Body" runat="server"
	ContentPlaceHolderID="cph_Body">

	<table
		border="0" cellpadding="2" cellspacing="0" width="100%">
		<tr>
			<td colspan="2" align="center" class="label_title">
				Article
			</td>
		</tr>

		<tr>
			<td colspan="2">

				<div class="tabber">
					<div id="div_Article" class="tabbertab">
						<h2>Article</h2>
						<div>
							<table width="100%" border="0" cellpadding="2" cellspacing="1">
								<tr>
									<td width="0%" class="label_small" align="right" valign="top">
										Title:&nbsp;
									</td>
									<td width="100%">
										<asol:wuc_Dic
											ID="dic_Title" runat="server" 
											Text_CssClass="textbox_dim4"
											Label_CssClass="label_small"
											Rows="1" />
									</td>
								</tr>
								<tr>
									<td class="label_small" align="right" valign="top">
										Subtitle:&nbsp;
									</td>
									<td>
										<asol:wuc_Dic
											ID="dic_subtitle" runat="server" 
											Text_CssClass="textbox_dim4"
											Label_CssClass="label_small"
											Rows="1" />
									</td>
								</tr>
								<tr>
									<td class="label_small" align="right" valign="top">
										Article:&nbsp;
									</td>
									<td>
										<asol:wuc_Dic
											ID="dic_News" runat="server" 
											Text_CssClass="textbox_dim45"
											Label_CssClass="label_small"
											Rows="12" 
											isHorizontal_notVertial="false" />
									</td>
								</tr>
								<tr>
									<td class="label_small" align="right" valign="top">
										Summary:&nbsp;
									</td>
									<td>
										<asol:wuc_Dic
											ID="dic_summary" runat="server" 
											Text_CssClass="textbox_dim45"
											Label_CssClass="label_small"
											Rows="6" 
											isHorizontal_notVertial="false" />
									</td>
								</tr>
								<tr>
									<td height="70" colspan="2" align="right">
										<asp:Button
											ID="btn_News" runat="server"

											OnClick="btn_News_Click"
											CssClass="button"
											Text="Save" />
									</td>
								</tr>
							</table>
						</div>
					</div>
					<div id="div_Attachments" runat="server" class="tabbertab">
						<h2>Attachments</h2>
						<div>
							<anthem:Repeater
								ID="rep_Attachments" runat="server"
								AutoUpdateAfterCallBack="true">
								<ItemTemplate>
									<table width="100%" border="0" cellpadding="2" cellspacing="1">
										<tr>
											<td class="label_small" align="right" valign="top">
												Name:&nbsp;
											</td>
											<td>
												<asol:wuc_Dic
													ID="dic_Name" runat="server" 
													Text_CssClass="textbox_dim25"
													Label_CssClass="label_small"
													Rows="1" />
											</td>
											<td 
												rowspan="2" 
												align="center" 
												valign="middle"
												class="label_small">
												<a 
													id="a_Attachment" runat="server"

													href=""

													target="_blank"
													class="label_small">
														<span 
															runat="server"
															visible='<%# !(bool)DataBinder.Eval(Container.DataItem, "isImage") %>'>
															download
														</span>
														<img 
															id="img_Attachment" runat="server"

															src=""

															alt='<%# DataBinder.Eval(Container.DataItem, "FileName") %>'
															visible='<%# (bool)DataBinder.Eval(Container.DataItem, "isImage") %>'
															style="
																min-widthXXX: 120px;
																min-heightXXX: 120px;

																max-width: 132px; 
																max-height: 220px;
															" />
												</a>
											</td>
										</tr>
										<tr>
											<td class="label_small" align="right" valign="top">
												Description:&nbsp;
											</td>
											<td>
												<asol:wuc_Dic
													ID="dic_Description" runat="server" 
													Text_CssClass="textbox_dim3"
													Label_CssClass="label_small"
													Rows="4" 
													isHorizontal_notVertial="false" />
											</td>
										</tr>
										<tr>
											<td class="label_small" colspan="3" align="right">
												<%# DataBinder.Eval(Container.DataItem, "FileName") %>
											</td>
										</tr>
										<tr>
											<td colspan="3" align="right">
												<anthem:Button
													ID="btn_AttachmentDelete" runat="server"
													CssClass="button"
													Text="Delete"
															
													OnClick="btn_AttachmentDelete_Click" 
													CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDAttachment") %>' 
													EnableCallBack="true"
													EnabledDuringCallBack="false"/>
												<anthem:Button
													ID="btn_AttachmentSave" runat="server"
													CssClass="button"
													Text="Save"
															
													OnClick="btn_AttachmentSave_Click"
													CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDAttachment") %>' 
													EnableCallBack="true"
													EnabledDuringCallBack="false" />
											</td>
										</tr>
									</table>
									<hr />
									<br />
								</ItemTemplate>
							</anthem:Repeater>
							<table width="100%" border="0" cellpadding="2" cellspacing="1">
								<tr>
									<td align="right">
										<asp:FileUpload
											ID="fup_Attachment" runat="server" />
										<asp:Button
											ID="btn_AttachmentUpload" runat="server"
											OnClick="btn_AttachmentUpload_Click"
											CssClass="button"
											Text="Upload" />
									</td>
								</tr>
							</table>
						</div>
					</div>
					<div id="div_Tags" runat="server" class="tabbertab">
						<h2>Tags</h2>
						<div>
							<table width="100%" border="1" cellpadding="5" cellspacing="0">
								<tr>
									<td align="center">
										<asol:KickCheckBoxList
											id="cbl_Tags" runat="server"

											CssClass="cl_noticias_normal" 
											RepeatColumns="1" 
											RepeatDirection="Vertical"

											AutoUpdateAfterCallBack="true" />
									</td>
								</tr>
								<tr>
									<td height="70" align="right">
										<anthem:Button
											ID="btn_Tags" runat="server"

											CssClass="cl_noticias_normal"
											Text="Submeter"

											OnClick="btn_Tags_Click" 
											EnableCallBack="true" 
											EnabledDuringCallBack="false" />
									</td>
								</tr>
							</table>
						</div>
					</div>
					<div id="div_Authors" runat="server" class="tabbertab">
						<h2>Authors</h2>
						<div>
							<table width="100%" border="1" cellpadding="5" cellspacing="0">
								<tr>
									<td align="center">
										<asol:KickCheckBoxList
											id="cbl_Author" runat="server"

											CssClass="cl_noticias_normal" 
											RepeatColumns="1" 
											RepeatDirection="Vertical"

											AutoUpdateAfterCallBack="true" />
									</td>
								</tr>
								<tr>
									<td height="70" align="right">
										<anthem:Button
											ID="btn_Authors" runat="server"

											CssClass="cl_noticias_normal"
											Text="Submeter" 

											OnClick="btn_Authors_Click" 
											EnableCallBack="true" 
											EnabledDuringCallBack="false" />
									</td>
								</tr>
							</table>
						</div>
					</div>
					<div id="div_Sources" runat="server" class="tabbertab">
						<h2>Sources</h2>
						<div>
							<table width="100%" border="1" cellpadding="5" cellspacing="0">
								<tr>
									<td align="center">
										<asol:KickCheckBoxList
											id="cbl_Source" runat="server"

											CssClass="cl_noticias_normal" 
											RepeatColumns="1" 
											RepeatDirection="Vertical"

											AutoUpdateAfterCallBack="true" />
									</td>
								</tr>
								<tr>
									<td height="70" align="right">
										<anthem:Button
											ID="btn_Sources" runat="server"

											CssClass="cl_noticias_normal"
											Text="Submeter" 

											OnClick="btn_Sources_Click"
											EnableCallBack="true" 
											EnabledDuringCallBack="false" />
									</td>
								</tr>
							</table>
						</div>
					</div>
					<div id="div_Highlights" runat="server" class="tabbertab">
						<h2>Highlights</h2>
						<div>
<% #if DEBUG %>
<span class="label_error">
	NOTA: tens de considerar o intervalo de tempo em que a noticia vai estar associada ao destaque<br />
</span>
<% #endif %>
							<table width="100%" border="1" cellpadding="5" cellspacing="0">
								<tr>
									<td align="center">
										<asol:KickCheckBoxList
											id="cbl_Highlight" runat="server"

											CssClass="cl_noticias_normal" 
											RepeatColumns="1" 
											RepeatDirection="Vertical" 

											AutoUpdateAfterCallBack="true" />
									</td>
								</tr>
								<tr>
									<td height="70" colspan="2" align="right">
										<anthem:Button
											ID="btn_Highlights" runat="server"

											CssClass="cl_noticias_normal"
											Text="Submeter" 
											OnClick="btn_Highlights_Click" />
									</td>
								</tr>
							</table>
						</div>
					</div>
					<div id="div_Profiles" runat="server" class="tabbertab">
						<h2>Profiles</h2>
						<div>
							<table width="100%" border="1" cellpadding="5" cellspacing="0">
								<tr>
									<td align="center">
										<asol:KickCheckBoxList
											id="cbl_Profiles" runat="server"

											CssClass="cl_noticias_normal" 
											RepeatColumns="1" 
											RepeatDirection="Vertical" 

											AutoUpdateAfterCallBack="true" />
									</td>
								</tr>
								<tr>
									<td height="70" colspan="2" align="right">
										<anthem:Button
											ID="btn_Profiles" runat="server"

											CssClass="cl_noticias_normal"
											Text="Submeter" 

											OnClick="btn_Profiles_Click"
											EnableCallBack="true" 
											EnabledDuringCallBack="false" />
									</td>
								</tr>
							</table>
						</div>
					</div>
				</div>

			</td>
		</tr>
	</table>
	

<%--
				<PTExp:wuc_Calendar 
					ID="cal_YYY" runat="server" 
					isDate_notDateTime="true" />
				<br />
				<br />
				<br />
--%>
<%--
				<asol:SC_Calendar
					ID="cal_ZZZ" runat="server"
					isDate_notDateTime="true" />
				<br />
				<br />
				<br />
				<anthem:Repeater
					ID="rep_Test" runat="server"
					AutoUpdateAfterCallBack="true">
					<HeaderTemplate>
						<table border="1" cellpadding="2" cellspacing="2">
					</HeaderTemplate>
					<ItemTemplate>
							<tr>
								<td class="cl_noticias_normal">
									<asol:SC_Calendar
										ID="cal_XXX" runat="server"
										isDate_notDateTime="true" 
										SelectedValue='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "Begin_date")).Ticks %>' />
								</td>
								<td>
									<asol:SC_Calendar
										ID="cal_YYY" runat="server"
										isDate_notDateTime="true" 
										SelectedValue='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "End_date")).Ticks %>' />
								</td>
							</tr>
					</ItemTemplate>
					<FooterTemplate>
						</table>
					</FooterTemplate>
				</anthem:Repeater>
				<br />
				<br />
				<br />
--%>


</asp:Content>