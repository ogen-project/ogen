<%@ Page 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Default.aspx.cs" 
	Inherits="OGen.NTier.Kick.presentationlayer.weblayer.Default" 
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

			<anthem:Repeater
				ID="rep_News" runat="server"
				AutoUpdateAfterCallBack="true">
				<ItemTemplate>
					<anthem:Repeater
						ID="rep_News_Tags" runat="server"
						AutoUpdateAfterCallBack="true">
						<HeaderTemplate>
							<table width="100%" height="15" border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td width="5" class="subtitulo_preto">&nbsp;&nbsp;</td>
						</HeaderTemplate>
						<ItemTemplate>
									<td bgcolor="#E6F0D5" class="titulo_branco">
										<span class="subtitulo_preto">
											<%# DataBinder.Eval(Container.DataItem, "Name") %></span>
									</td>
									<td bgcolor="#E6F0D5" class="subtitulo_preto">&nbsp;&nbsp;&nbsp;</td>
									<td><img src="imagens/1x1.png" /></td>
						</ItemTemplate>
						<FooterTemplate>
									<td width="100%" bgcolor="#E6F0D5"></td>
								</tr>
							</table>
						</FooterTemplate>
					</anthem:Repeater>
					<table width="100%" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td width="5" height="10"></td>
							<td width="389" height="10"></td>
							<td width="5"></td>
						</tr>
						<tr>
							<td width="5"></td>
							<td width="389">
								<a 
									href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>'
									class="texto_home2 titulos_noticias"><strong><%# DataBinder.Eval(Container.DataItem, "Title") %></strong></a>
							</td>
							<td width="5"></td>
						</tr>

						<tr>
							<td width="5" height="10"></td>
							<td width="389" height="10"></td>
							<td width="5"></td>
						</tr>
						<tr id="tr_ImageNews" runat="server">
							<td></td>
							<td height="105" valign="top">
								<anthem:Image
									ID="img_News" runat="server"
									AutoUpdateAfterCallBack="true"
									style="max-height: 100px; max-width: 400px;" />
							</td>
							<td></td>
						</tr>

						<tr>
							<td width="5"></td>
							<td width="389">
								<a 
									href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>' 
									class="texto_11"><%# DataBinder.Eval(Container.DataItem, "summary") %></a>
							</td>
							<td width="5"></td>
						</tr>
						<tr valign="bottom">
							<td height="20"></td>
							<td height="20">



								<table width="389" border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td align="left" valign="middle" style="width: 338px;">

											<anthem:Repeater
												ID="rep_News_Sources" runat="server"
												AutoUpdateAfterCallBack="true">
												<HeaderTemplate>
													<em class="fonte">(Fonte 
												</HeaderTemplate>
												<ItemTemplate><%# 
													(Container.ItemIndex == 0) ? "" : ", " %>
													<span class="fonte">
														<%# DataBinder.Eval(Container.DataItem, "Name") %></span></ItemTemplate>
												<FooterTemplate>
													)</em>
												</FooterTemplate>
											</anthem:Repeater>

										</td>
										<td style="width: 1px;" align="center" valign="middle" bgcolor="#93bb1a"> </td>
										<td style="width: 50px;" align="right" valign="middle">
											<a 
												href='<%# "News.aspx?IDNews=" + ((long)DataBinder.Eval(Container.DataItem, "IDContent")).ToString() %>' 
												class="vermais">VER MAIS</a>
										</td>
									</tr>
								</table>





							</td>
							<td height="20"></td>
						</tr>
						<tr>
							<td colspan="3">&nbsp;</td>
						</tr>
					</table>
				</ItemTemplate>
			</anthem:Repeater>

</asp:Content>