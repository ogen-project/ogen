<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="LOG-Log.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.LOG_Log"
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

	- Log
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

	<table
		border="0" cellpadding="2" cellspacing="0" width="100%">
		<tr>
			<td colspan="2" align="center" class="label_title">
				Log
			</td>
		</tr>

		<tr><td colspan="2">&nbsp;</td></tr>

		<tr>
			<td align="right" class="label_small nowrap">
				Log Type:&nbsp;
			</td>
			<td>
				<asol:KickListBox
					ID="ddl_Logtype" runat="server" 
					
					CssClass="dropdownlist"
					Rows="1" SelectionMode="Single" />
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				Error Type:&nbsp;
			</td>
			<td>
				<asol:KickListBox
					ID="ddl_Errortype" runat="server" 
					
					CssClass="dropdownlist"
					Rows="1" SelectionMode="Single" />
			</td>
		</tr>
		<%--<tr>
			<td class="label_nonBold" align="right">
				Coworker:
			</td>
			<td>
				<asol:KickListBox
					ID="ddl_Coworker" runat="server" 
					
					Rows="1" SelectionMode="Single"
					CssClass="dropdownlist" />
			</td>
		</tr>--%>
		<tr>
			<td align="right" class="label_small nowrap">
				Date Interval:&nbsp;
			</td>
			<td>
				<table border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td>
							&nbsp; 
						</td>
						<td class="label_small">
							begin:&nbsp;
						</td>
						<td>
							<%--&nbsp;<uc1:wuc_Calendar 
								ID="wuc_Date_begin" runat="server" 
								Title="begin date" />&nbsp;&nbsp;--%>
							&nbsp;<kick:htmlDatePicker 
								ID="txt_Date_begin" runat="server" 
								AutoUpdateAfterCallBack="true"
								class="date-pick"
								onclick="javascript:GetDate(this);" />&nbsp;&nbsp;
						</td>
						<td>
							&nbsp; 
						</td>
						<td class="label_small">
							end:&nbsp;
						</td>
						<td>
							<%--&nbsp;<uc1:wuc_Calendar 
								ID="wuc_Date_end" runat="server" 
								Title="end date" />&nbsp;&nbsp;--%>
							&nbsp;<kick:htmlDatePicker 
								ID="txt_Date_end" runat="server" 
								AutoUpdateAfterCallBack="true"
								class="date-pick"
								onclick="javascript:GetDate(this);" />&nbsp;&nbsp;
						</td>


						<td>
							&nbsp;&nbsp;
						</td>
						<td>
							<anthem:LinkButton
								ID="lbl_Date_lastDay" runat="server" 
								
								EnableCallBack="true"
								EnabledDuringCallBack="false"
								
								CssClass="label_small"
								CommandArgument="1"
								OnClick="lbt_Date_Click"
								Text="Last&nbsp;Day" />
						</td>
						<td>
							&nbsp;&nbsp;
						</td>
						<td>
							<anthem:LinkButton
								ID="lbl_Date_lastWeek" runat="server" 
								
								EnableCallBack="true"
								EnabledDuringCallBack="false"
								
								CssClass="label_small"
								CommandArgument="2"
								OnClick="lbt_Date_Click"
								Text="Last&nbsp;Week" />
						</td>
						<td>
							&nbsp;&nbsp;
						</td>
						<td>
							<anthem:LinkButton
								ID="lbl_Date_clear" runat="server" 
								
								EnableCallBack="true"
								EnabledDuringCallBack="false"
								
								CssClass="label_small"
								CommandArgument="0"
								OnClick="lbt_Date_Click"
								Text="Clear" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td align="right" class="label_small nowrap">
				State:&nbsp;
			</td>
			<td>
				<asp:CheckBox
					ID="cbx_Read" runat="server" 
					
					CssClass="checkboxlist"
					Text="Read" />
			</td>
		</tr>
		<tr>
			<td colspan="2" align="right">
				<anthem:Button
					ID="btn_Search" runat="server"
					
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					TextDuringCallBack="working..."

					CssClass="button"
					OnClick="btn_Search_Click"
					Text="&nbsp;&nbsp;Search&nbsp;&nbsp;" />
			</td>
		</tr>
	</table>
	<br />

	<anthem:Repeater
		ID="rep_Log" runat="server"
					
		AutoUpdateAfterCallBack="true">
		<HeaderTemplate>
			<table 
				border="0" align="center" cellpadding="2" cellspacing="1" width="100%"
				class="table_alternating">
				<tr>
					<td colspan="6" align="center" class="label_subtitle alternating_item">
						Search Results
					</td>
				</tr>
				<tr>
					<%--<td class="label_nonBold">
						ID
					</td>--%>
					<td class="label_small" style="white-space:normal;">
						Log<%-- Type--%>
					</td>
					<td class="label_small" style="white-space:normal;">
						Error<%-- Type--%>
					</td>
					<td class="label_small">
						User
					</td>
					<td class="label_small">
						Date
					</td>
					<td class="label_small">
						Message
					</td>
					<td>
					</td>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
				<tr>
					<%--<td class="label_nonBold" valign="top">
						<%# DataBinder.Eval(Container.DataItem, "IDLog")%>
					</td>--%>
					<td class="label_small wrap" valign="top">
						<%# DataBinder.Eval(Container.DataItem, "Logtype")%>
					</td>
					<td class="label_small wrap"valign="top">
						<%# DataBinder.Eval(Container.DataItem, "Errortype")%>
					</td>
					<td class="label_small wrap" valign="top">
						<a 
							runat="server"
							href='<%# "~/admin/CRD-User.aspx?IDUser=" + DataBinder.Eval(Container.DataItem, "IFUser")%>'>
							<%# DataBinder.Eval(Container.DataItem, "IFUser")%>
						</a>
					</td>
					<td class="label_small nowrap"valign="top">
						<%# DataBinder.Eval(Container.DataItem, "Date")%>
					</td>
					<td class="label_small wrap" valign="top">
						<%# DataBinder.Eval(Container.DataItem, "Message")%>
					</td>
					<td valign="top">
						<anthem:Button
							id="btn_MarkRead" runat="server"
										
							Visible='<%# DataBinder.Eval(Container.DataItem, "Visible")%>'

							EnableCallBack="true"
							EnabledDuringCallBack="false"
										
							CssClass="button"
							CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDLog")%>'
							OnClick="btn_MarkRead_Click"
							Text="del" />
					</td>
				</tr>
		</ItemTemplate>
		<FooterTemplate>
					</td>
				</tr>
			</table>
		</FooterTemplate>
	</anthem:Repeater>


</asp:Content>