<%@ Control 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="wuc_txt_Dic.ascx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.wuc_txt_Dic" %>

<asp:Repeater
	ID="rep_Field" runat="server">
	<HeaderTemplate>
		<table 
			border="0" cellpadding="2" cellspacing="0">
	</HeaderTemplate>
	<ItemTemplate>
			<tr>
				<td>
					<asp:TextBox
						ID="txt_Field" runat="server" />
				</td>
<asp:Literal ID="lit_Horizontal" runat="server" Visible="true">
				<td>&nbsp;</td>
				<td valign="middle">
</asp:Literal>
<asp:Literal ID="lit_Vertial" runat="server" Visible="false">
			</tr>
			<tr>
				<td align="right">
</asp:Literal>
					<asp:HiddenField
						ID="hfi_IDLanguage" runat="server"
						Value='<%# DataBinder.Eval(Container.DataItem, "IDLanguage")%>' />

					<asp:Label
						ID="lbl_Language" runat="server">
						(<%# DataBinder.Eval(Container.DataItem, "Language")%>)
					</asp:Label>
				</td>
			</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>