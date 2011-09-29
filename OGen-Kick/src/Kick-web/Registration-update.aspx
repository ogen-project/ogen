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
			<td align="left" style="width: 50%;">
				<anthem:LinkButton
					ID="lbt_RegistrationDataShow" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="lbt_RegistrationDataShow_Click"
					AutoUpdateAfterCallBack="true"

					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Update Registration</div></anthem:LinkButton>
			</td>
			<td align="right" style="width: 50%;">
				<anthem:LinkButton
					ID="lbt_RegistrationDataHide" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="lbt_RegistrationDataHide_Click"
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
					ID="tbl_RegistrationData" runat="server"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					Width="100%" BorderWidth="0" CellPadding="4" CellSpacing="0">
					<asp:TableRow>
						<asp:TableCell Width="35%" HorizontalAlign="Right" CssClass="label_small">
							Name:&nbsp;
						</asp:TableCell>
						<asp:TableCell Width="65%" HorizontalAlign="Left">
							<anthem:HiddenField
								ID="hfi_Name" runat="server" 
								AutoUpdateAfterCallBack="true" />
							<anthem:TextBox
								ID="txt_Name" runat="server" CssClass="textbox_dim25"
								AutoUpdateAfterCallBack="true" />

							&nbsp;<anthem:Label
								ID="lbl_Name" runat="server" 
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
								ID="hfi_Login" runat="server" 
								AutoUpdateAfterCallBack="true" />
							<anthem:TextBox
								ID="txt_Login" runat="server" CssClass="textbox_dim25"
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
											ID="btn_RegistrationDataCancel" runat="server"
											OnClick="btn_RegistrationDataCancel_Click"
											EnableCallBack="true"
											EnabledDuringCallBack="false"

											CssClass="button"
											Text="Cancel" />
									</td>
									<td>&nbsp;</td>
									<td>
										<anthem:Button
											ID="btn_RegistrationDataUpdate" runat="server"
											EnableCallBack="true"
											EnabledDuringCallBack="false"
											OnClick="btn_RegistrationDataUpdate_Click"

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
					ID="lbt_RegistrationEMailShow" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="lbt_RegistrationEMailShow_Click"
					AutoUpdateAfterCallBack="true"

					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Update EMail</div></anthem:LinkButton>
			</td>
			<td align="right" style="width: 50%;">
				<anthem:LinkButton
					ID="lbt_RegistrationEMailHide" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="lbt_RegistrationEMailHide_Click"
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
					ID="tbl_RegistrationEMail" runat="server"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					Width="100%" BorderWidth="0" CellPadding="4" CellSpacing="0">
					<asp:TableRow>
						<asp:TableCell Width="35%" HorizontalAlign="Right" CssClass="label_small">
							Email:&nbsp;
						</asp:TableCell>
						<asp:TableCell Width="65%" HorizontalAlign="Left">
							<anthem:HiddenField
								ID="hfi_EMail" runat="server" 
								AutoUpdateAfterCallBack="true" />
							<anthem:TextBox
								ID="txt_EMail" runat="server" CssClass="textbox_dim25"
								AutoUpdateAfterCallBack="true" />

							&nbsp;<anthem:Label
								ID="lbl_EMail" runat="server" 
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
											ID="btn_RegistrationEMailCancel" runat="server"
											OnClick="btn_RegistrationEMailCancel_Click"
											EnableCallBack="true"
											EnabledDuringCallBack="false"

											CssClass="button"
											Text="Cancel" />
									</td>
									<td>&nbsp;</td>
									<td>
										<anthem:Button
											ID="btn_RegistrationEMailUpdate" runat="server"
											EnableCallBack="true"
											EnabledDuringCallBack="false"
											OnClick="btn_RegistrationEMailUpdate_Click"

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
					ID="lbt_RegistrationPasswordShow" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="lbt_RegistrationPasswordShow_Click"
					AutoUpdateAfterCallBack="true"

					CssClass="label_small"
					style="width: 100%; height: 100%;">
					<div style="width: 100%; height: 100%;">Update Password</div></anthem:LinkButton>
			</td>
			<td align="right" style="width: 50%;">
				<anthem:LinkButton
					ID="lbt_RegistrationPasswordHide" runat="server"
					EnableCallBack="true"
					EnabledDuringCallBack="false"
					OnClick="lbt_RegistrationPasswordHide_Click"
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
					ID="tbl_RegistrationPassword" runat="server"
					AutoUpdateAfterCallBack="true"

					Visible="false"
					Width="100%" BorderWidth="0" CellPadding="4" CellSpacing="0">
					<asp:TableRow>
						<asp:TableCell Width="45%" HorizontalAlign="Right" CssClass="label_small">
							Password:&nbsp;
						</asp:TableCell>
						<asp:TableCell Width="55%" HorizontalAlign="Left">
							<anthem:TextBox
								ID="txt_Password" runat="server" 
								AutoUpdateAfterCallBack="true" 

								TextMode="Password"
								CssClass="textbox_dim15" />

							&nbsp;<anthem:Label
								ID="lbl_Password" runat="server"
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
								ID="txt_PasswordNew" runat="server" 
								AutoUpdateAfterCallBack="true" 

								TextMode="Password"
								CssClass="textbox_dim15" />

							&nbsp;&nbsp;
							<anthem:Label
								ID="lbl_PasswordNew" runat="server"
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
								ID="txt_PasswordConfirm" runat="server" 
								AutoUpdateAfterCallBack="true" 

								TextMode="Password"
								CssClass="textbox_dim15" />

							&nbsp;&nbsp;
							<anthem:Label
								ID="lbl_PasswordConfirm" runat="server"
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
											ID="btn_RegistrationPasswordCancel" runat="server"
											OnClick="btn_RegistrationPasswordCancel_Click"
											EnableCallBack="true"
											EnabledDuringCallBack="false"

											CssClass="button"
											Text="Cancel" />
									</td>
									<td>&nbsp;</td>
									<td>
										<anthem:Button
											ID="btn_RegistrationPasswordUpdate" runat="server"
											EnableCallBack="true"
											EnabledDuringCallBack="false"
											OnClick="btn_RegistrationPasswordUpdate_Click"

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