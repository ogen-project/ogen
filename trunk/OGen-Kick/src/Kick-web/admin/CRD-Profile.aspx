<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="CRD-Profile.aspx.cs" 
	Inherits="OGen.NTier.Kick.PresentationLayer.WebLayer.CRD_Profile" 
	MasterPageFile="~/App_Controls/Admin.Master" %>
<%@ Register 
	TagPrefix="asol" 
	Namespace="OGen.Libraries.PresentationLayer.WebForms"
	Assembly="OGen.Libraries.PresentationLayer.WebForms-2.0" %>
<%@ Register 
	TagPrefix="anthem" 
	Namespace="Anthem" 
	Assembly="Anthem" %>
<asp:Content
	id="CNT_Title" runat="server" 
	ContentPlaceHolderID="CPH_Title">

	- Profile
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
						<td colspan="2" align="center" class="label_title">
							Profile
						</td>
					</tr>

					<tr><td colspan="2">&nbsp;</td></tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Name:&nbsp;
						</td>
						<td>
							<asp:TextBox
								ID="TXT_Name" runat="server"
								CssClass="textbox_dim4" />
						</td>
					</tr>

					<tr>
						<td align="right" class="label_small nowrap">
							Parent Profiles:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="CBL_ParentProfiles" runat="server"

								CssClass="checkboxlist nowrap"
								AutoUpdateAfterCallBack="true"
								EnableCallBack="false"
								RepeatColumns="2" />
						</td>
					</tr>
					<tr>
						<td align="right" class="label_small nowrap">
							Permissions:&nbsp;
						</td>
						<td>
							<asol:KickCheckBoxList
								ID="CBL_Permissions" runat="server"

								CssClass="checkboxlist nowrap"
								AutoUpdateAfterCallBack="true"
								EnableCallBack="false"
								RepeatColumns="2" />
						</td>
					</tr>

					<tr>
						<td></td>
						<td align="right">
							<input 
								type="button" 
								onclick="javascript:window.location='CRD-Profile-list.aspx';return false;" 
								value="Cancel"
								class="button" />
							<asp:Button
								ID="BTN_Save" runat="server"
								OnClick="BTN_Save_Click"

								CssClass="button"
								Text="Save" />
						</td>
					</tr>
				</table>
			</td>
			<td style="width: 50%"></td>
		</tr>
	</table>

</asp:Content>