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
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

	- Default Profiles
</asp:Content>
<asp:Content
	id="CNT_Head" runat="server"
	ContentPlaceHolderID="CPH_Head">

</asp:Content>
<asp:Content
	id="CNT_Body" runat="server"
	ContentPlaceHolderID="CPH_Body">

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
					<tr>
						<td colspan="2" align="left" class="label_small nowrap">
							uppon registration, new users will be associated with selected profiles below<br />
							you should pick profiles suitable for new registered users
						</td>
					</tr>

					<tr><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Profiles:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="CBL_Profile" runat="server"
								AutoUpdateAfterCallBack="true"

								CssClass="checkboxlist nowrap" />
						</td>
					</tr>
					<tr>
						<td></td>
						<td align="right">
							<anthem:Button
								ID="BTN_Save" runat="server"
								OnClick="BTN_Save_Click"
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