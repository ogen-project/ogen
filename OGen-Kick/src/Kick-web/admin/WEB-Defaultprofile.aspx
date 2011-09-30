<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="WEB_Defaultprofile.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.WEB_Defaultprofile" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
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

	- Default Profiles
</asp:Content>
<asp:Content
	id="cnt_Head" runat="server"
	ContentPlaceHolderID="cph_Head">

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
						<td colspan="2" align="center" class="label_title nowrap">
							Default Profiles
						</td>
					</tr>

					<tr><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Profiles:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="cbl_Profile" runat="server"
								AutoUpdateAfterCallBack="true"

								CssClass="checkboxlist nowrap" />
						</td>
					</tr>
					<tr>
						<td></td>
						<td align="right">
							<anthem:Button
								ID="btn_Save" runat="server"
								OnClick="btn_Save_Click"
								AutoUpdateAfterCallBack="true"
								EnableCallBack="true"

								CssClass="button"
								Text="  Save  " />
						</td>
					</tr>
				</table>
			</td>
			<td style="width: 50%"></td>
		</tr>
	</table>


</asp:Content>