<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PesquisarUsuario.aspx.cs"    Inherits="BPDWeb.JobTrackerAdmin.Seguranca.PesquisarUsuario" %>
<%@ Reference Page="~/Util/PaginaWeb.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BPD Impressão de Dados - Job Tracker[Pesquisar Usuários]</title>
    <link href="../../padrao.css" type="text/css" rel="stylesheet">
</head>

<body bottommargin="0" topmargin="0" leftmargin="0" rightmargin="0" style="filter: progid:DXImageTransform.Microsoft.Gradient(endColorstr='#C0CFE2', startColorstr='#6186B3', gradientType='0');">
    
    <form id="form1" runat="server">
    <div align="center">
            <table border="0" class="tblForm" cellpadding="0" cellspacing="0" style="width: 760px; height: 98%;">
                <tr>
                    <td style="text-align: center;" valign="top">
                        <table width="100%" cellspacing="1">
                            <tr>
                                <td style="text-align: center;">
                                <table id="Table_01" width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 94px">
                                        <tr>
                                            <td colspan="3" style="height: 13px">
                                                <a href="#" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../../img/papel_timbrado_cabecalho_01.png" width="760" height="14" border="0"
                                                        alt=""></a></td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">
                                                <a href="#" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../../img/papel_timbrado_cabecalho-02.png" width="316" height="93" border="0"
                                                        alt=""></a></td>
                                            <td>
                                                <a href="http://www.bpd.com.br" target="_top" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../../img/papel_timbrado_cabecalho_03.png" width="132" height="47" border="0"
                                                        alt=""></a></td>
                                            <td rowspan="2">
                                                <a href="#" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../../img/papel_timbrado_cabecalho-04.png" width="312" height="93" border="0"
                                                        alt=""></a></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="#" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../../img/papel_timbrado_cabecalho-05.png" width="132" height="46" border="0"
                                                        alt=""></a></td>
                                        </tr>
                                        <tr>
                                            <td class="TituloAreaCliente" colspan="3" style="height: 0px; text-align: left">
                                                &nbsp;Área Administrativa</td>
                                        </tr>
                                    </table></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; background-color: #6666ff;" class="lnkMenu">
                                    &nbsp;
                                    &nbsp;<asp:LinkButton ID="lkbInicio" runat="server" OnClick="lkbInicio_Click" ForeColor="White">Início</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbUsuario" runat="server" OnClick="lkbUsuario_Click" ForeColor="White">Usuários</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbAprovarJob" runat="server" OnClick="lkbAprovarJob_Click" ForeColor="White">Aprovação</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbAcompanhamento" runat="server" OnClick="lkbAcompanhamento_Click"
                                        ForeColor="White">Acompanhamento</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbSair" runat="server" OnClick="lkbSair_Click" ForeColor="#FFFF80">Sair</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td valign="top" align="center">

<table border="0" class="tblForm" cellpadding="0" cellspacing="0" style="width: 760px;
                height: 98%;">
                <tr>
                    <td style="text-align: center;" valign="top">
                        <table width="100%" cellspacing="1">
                         
                            <tr>
                                <td align="left" class="SubTitulo">
                                    &nbsp;JobTracker&nbsp; &gt; &nbsp;&nbsp;Pesquisar Usuários&nbsp;
                                    <hr />
                                    &nbsp;<asp:ImageButton ID="btnNovo" runat="server" OnClick="btnNovo_Click" ImageUrl="~/img/Novo.gif" ToolTip="Novo..." /></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                
                                <table border="0" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 40%; text-align: right">
                                </td>
                            <td style="width: 60%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40%; text-align: right">
                                Cliente :</td>
                            <td style="width: 60%" align="left">
                                &nbsp;<asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;
                                <asp:ImageButton ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" 
                                    ImageUrl="~/img/pesquisar.gif" ToolTip="Pesquisar" style="width: 20px" />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40%; text-align: right">
                                </td>
                            <td style="width: 60%" align="left">
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        </table>
                                
                                
                                   </td>
                            </tr>
                            <tr>
                                <td style="width: 100%" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:DataGrid ID="dgrUsuarios" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderStyle="None" BorderWidth="1px" CellPadding="0" CssClass="textosimples"
                                        GridLines="Horizontal" OnSelectedIndexChanged="dgrUsuarios_SelectedIndexChanged"
                                        Width="100%" OnItemDataBound="dgrUsuarios_ItemDataBound">
                                        <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                                        <SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C" Font-Italic="False"
                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left">
                                        </SelectedItemStyle>
                                        <AlternatingItemStyle ForeColor="Black" CssClass="GridSistemaItemAlternado" Font-Bold="False"
                                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
                                            HorizontalAlign="Left"></AlternatingItemStyle>
                                        <ItemStyle ForeColor="Black" CssClass="GridItemSistema" Font-Bold="False" Font-Italic="False"
                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left">
                                        </ItemStyle>
                                        <HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" CssClass="GridSistemaCabecalho"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundColumn DataField="id_usuario" HeaderText="id_usuario" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="nome" HeaderText="Nome">
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="email" HeaderText="E-Mail">
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Cliente(s)">
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:TemplateColumn>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgAbrir" runat="server" CommandName="Select" 
                                                        ImageUrl="../../img/abrir.gif" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" Mode="NumericPages" />
                                        <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:DataGrid>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 19px; text-align: right">
                                    &nbsp;<asp:Label ID="lblResultado" runat="server" ForeColor="Red" Text="Label"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

</td>
                            </tr>
                            <tr>
                                <td style="text-align: center" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" valign="top">
                                    JobTracker v2.0 - Copyright BPD</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
 


