<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Registration-update.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.Registration_update" 

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

	<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
		<tr class="alternating_item">
			<td align="left" style="width: 50%;">
				<anthem:LinkButton
					ID="LBT_RegistrationDataShow" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="LBT_RegistrationDataShow_Click"
					AutoUpdateAfterCallBack="true"

					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Update Registration</div></anthem:LinkButton>
			</td>
			<td align="right" style="width: 50%;">
				<anthem:LinkButton
					ID="LBT_RegistrationDataHide" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="LBT_RegistrationDataHide_Click"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Cancel</div></anthem:LinkButton>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<anthem:Table
					ID="TBL_RegistrationData" runat="server"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					Width="100%" BorderWidth="0" CellPadding="4" CellSpacing="0">
					<asp:TableRow>
						<asp:TableCell Width="35%" HorizontalAlign="Right" CssClass="label_small">
							Name:&nbsp;
						</asp:TableCell>
						<asp:TableCell Width="65%" HorizontalAlign="Left">
							<anthem:HiddenField
								ID="HFI_Name" runat="server" 
								AutoUpdateAfterCallBack="true" />
							<anthem:TextBox
								ID="TXT_Name" runat="server" CssClass="textbox_dim25"
								AutoUpdateAfterCallBack="true" />

							&nbsp;<anthem:Label
								ID="LBL_Name" runat="server" 
								AutoUpdateAfterCallBack="true"

								CssClass="label_error" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow Visible="false">
						<asp:TableCell HorizontalAlign="right" CssClass="label_small">
							Username:&nbsp;
						</asp:TableCell>
						<asp:TableCell>
							<anthem:HiddenField
								ID="HFI_LogOn" runat="server" 
								AutoUpdateAfterCallBack="true" />
							<anthem:TextBox
								ID="TXT_LogOn" runat="server" CssClass="textbox_dim25"
								AutoUpdateAfterCallBack="true" 

								Enabled="false"
								ReadOnly="true" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell></asp:TableCell>
						<asp:TableCell 
							HorizontalAlign="Left">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td>
										<anthem:Button
											ID="BTN_RegistrationDataCancel" runat="server"
											OnClick="BTN_RegistrationDataCancel_Click"
											EnableCallBack="true"
											EnabledDuringCallBack="false"

											CssClass="button"
											Text="Cancel" />
									</td>
									<td>&nbsp;</td>
									<td>
										<anthem:Button
											ID="BTN_RegistrationDataUpdate" runat="server"
											EnableCallBack="true"
											EnabledDuringCallBack="false"
											OnClick="BTN_RegistrationDataUpdate_Click"

											CssClass="button"
											Text="Save" />
									</td>
								</tr>
							</table>
						</asp:TableCell>
					</asp:TableRow>
				</anthem:Table>
			</td>
		</tr>
	</table>
	<br />


	<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
		<tr class="alternating_item">
			<td align="left" style="width: 50%;">
				<anthem:LinkButton
					ID="LBT_RegistrationEmailShow" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="LBT_RegistrationEmailShow_Click"
					AutoUpdateAfterCallBack="true"

					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Update Email</div></anthem:LinkButton>
			</td>
			<td align="right" style="width: 50%;">
				<anthem:LinkButton
					ID="LBT_RegistrationEmailHide" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="LBT_RegistrationEmailHide_Click"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Cancel</div></anthem:LinkButton>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<anthem:Table
					ID="TBL_RegistrationEmail" runat="server"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					Width="100%" BorderWidth="0" CellPadding="4" CellSpacing="0">
					<asp:TableRow>
						<asp:TableCell Width="35%" HorizontalAlign="Right" CssClass="label_small">
							Email:&nbsp;
						</asp:TableCell>
						<asp:TableCell Width="65%" HorizontalAlign="Left">
							<anthem:HiddenField
								ID="HFI_Email" runat="server" 
								AutoUpdateAfterCallBack="true" />
							<anthem:TextBox
								ID="TXT_Email" runat="server" CssClass="textbox_dim25"
								AutoUpdateAfterCallBack="true" />

							&nbsp;<anthem:Label
								ID="LBL_Email" runat="server" 
								AutoUpdateAfterCallBack="true"

								CssClass="label_error" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell></asp:TableCell>
						<asp:TableCell 
							HorizontalAlign="Left">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td>
										<anthem:Button
											ID="BTN_RegistrationEmailCancel" runat="server"
											OnClick="BTN_RegistrationEmailCancel_Click"
											EnableCallBack="true"
											EnabledDuringCallBack="false"

											CssClass="button"
											Text="Cancel" />
									</td>
									<td>&nbsp;</td>
									<td>
										<anthem:Button
											ID="BTN_RegistrationEmailUpdate" runat="server"
											EnableCallBack="true"
											EnabledDuringCallBack="false"
											OnClick="BTN_RegistrationEmailUpdate_Click"

											CssClass="button"
											Text="Save" />
									</td>
								</tr>
							</table>
						</asp:TableCell>
					</asp:TableRow>
				</anthem:Table>
			</td>
		</tr>
	</table>
	<br />


	<table width="100%" border="0" cellpadding="4" cellspacing="0" class="table_thin">
		<tr class="alternating_item">
			<td align="left" style="width: 50%;">
				<anthem:LinkButton
					ID="LBT_RegistrationPasswordShow" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="LBT_RegistrationPasswordShow_Click"
					AutoUpdateAfterCallBack="true"

					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Update Password</div></anthem:LinkButton>
			</td>
			<td align="right" style="width: 50%;">
				<anthem:LinkButton
					ID="LBT_RegistrationPasswordHide" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="LBT_RegistrationPasswordHide_Click"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Cancel</div></anthem:LinkButton>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<anthem:Table
					ID="TBL_RegistrationPassword" runat="server"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					Width="100%" BorderWidth="0" CellPadding="4" CellSpacing="0">
					<asp:TableRow>
						<asp:TableCell Width="45%" HorizontalAlign="Right" CssClass="label_small">
							Password:&nbsp;
						</asp:TableCell>
						<asp:TableCell Width="55%" HorizontalAlign="Left">
							<anthem:TextBox
								ID="TXT_Password" runat="server" 
								AutoUpdateAfterCallBack="true" 

								TextMode="Password"
								CssClass="textbox_dim15" />

							&nbsp;<anthem:Label
								ID="LBL_Password" runat="server"
								AutoUpdateAfterCallBack="true"

								CssClass="label_error" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Right" CssClass="label_small">
							New Password:&nbsp;
						</asp:TableCell>
						<asp:TableCell HorizontalAlign="Left">
							<anthem:TextBox
								ID="TXT_PasswordNew" runat="server" 
								AutoUpdateAfterCallBack="true" 

								TextMode="Password"
								CssClass="textbox_dim15" />

							&nbsp;&nbsp;
							<anthem:Label
								ID="LBL_PasswordNew" runat="server"
								AutoUpdateAfterCallBack="true"

								CssClass="label_error" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Right" CssClass="label_small">
							Re-type New Password:&nbsp;
						</asp:TableCell>
						<asp:TableCell HorizontalAlign="Left">
							<anthem:TextBox
								ID="TXT_PasswordConfirm" runat="server" 
								AutoUpdateAfterCallBack="true" 

								TextMode="Password"
								CssClass="textbox_dim15" />

							&nbsp;&nbsp;
							<anthem:Label
								ID="LBL_PasswordConfirm" runat="server"
								AutoUpdateAfterCallBack="true"

								CssClass="label_error" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell></asp:TableCell>
						<asp:TableCell 
							HorizontalAlign="Left">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td>
										<anthem:Button
											ID="BTN_RegistrationPasswordCancel" runat="server"
											OnClick="BTN_RegistrationPasswordCancel_Click"
											EnableCallBack="true"
											EnabledDuringCallBack="false"

											CssClass="button"
											Text="Cancel" />
									</td>
									<td>&nbsp;</td>
									<td>
										<anthem:Button
											ID="BTN_RegistrationPasswordUpdate" runat="server"
											EnableCallBack="true"
											EnabledDuringCallBack="false"
											OnClick="BTN_RegistrationPasswordUpdate_Click"

											CssClass="button"
											Text="Save" />
									</td>
								</tr>
							</table>
						</asp:TableCell>
					</asp:TableRow>
				</anthem:Table>
			</td>
		</tr>
	</table>

</asp:Content>