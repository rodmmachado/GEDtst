<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditarUsuario.aspx.cs" Inherits="BPDWeb.JobTrackerAdmin.Seguranca.EditarUsuario" %>

<%@ Reference Page="~/Util/PaginaWeb.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BPD Impressão de Dados - Job Tracker [Editar Usuário]</title>
    <link href="../../padrao.css" type="text/css" rel="stylesheet">
</head>
<body bottommargin="0" topmargin="0" leftmargin="0" rightmargin="0" style="filter: progid:DXImageTransform.Microsoft.Gradient(endColorstr='#C0CFE2', startColorstr='#6186B3', gradientType='0');">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table border="0" class="tblForm" cellpadding="0" cellspacing="0" style="width: 760px;
                height: 98%;">
                <tr>
                    <td style="text-align: center;" valign="top">
                        <table width="100%" cellspacing="1">
                            <tr>
                                <td style="text-align: center;" colspan="2">
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
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; background-color: #6666ff;" class="lnkMenu" colspan="2">
                                    <asp:Literal ID="ltrIdUsuario" runat="server" Visible="False"></asp:Literal>
                                    <asp:LinkButton ID="lkbInicio" runat="server" OnClick="lkbInicio_Click" ForeColor="White">Início</asp:LinkButton>
                                    |&nbsp;
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
                                <td align="left" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="SubTitulo" colspan="2">
                                    &nbsp;JobTracker&nbsp; &gt; &nbsp;&nbsp;Cadastrar Usuário&nbsp;
                                    <hr />
                                    <asp:ImageButton ID="btnNovo" runat="server" ImageUrl="~/img/Novo.gif" OnClick="btnNovo_Click"
                                        ToolTip="Novo..." /></td>
                            </tr>
                            <tr>
                                <td class="lnkMenu" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                <table border="0" cellpadding="3" cellspacing="0" style="width: 100%">
                                        
                                        <tr>
                                            <td style="width: 20%; height: 24px;" align="right">
                                                Nome :</td>
                                            <td style="height: 24px;" align="left">
                                                &nbsp;
                                                <asp:TextBox ID="txtNome" runat="server" Width="278px" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%" align="right">
                                                Email :</td>
                                            <td align="left">
                                                &nbsp;
                                                <asp:TextBox ID="txtEmail" runat="server" Width="278px" MaxLength="150"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%" align="right">
                                                Senha :</td>
                                            <td align="left">
                                                &nbsp;
                                                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="105px" MaxLength="10"></asp:TextBox>
                                                <asp:LinkButton ID="lkbGerarSenha" runat="server" OnClick="lkbGerarSenha_Click">Gerar nova senha</asp:LinkButton><span style="color: Red"></span></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%">
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                                <asp:CheckBox ID="chkEnviarSenha" runat="server" Text="Enviar senha por e-mail ao salvar" /></td>
                                        </tr>
                                    <tr>
                                        <td style="width: 20%">
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                            <asp:LinkButton ID="lkbEnviarSenhaAgora" runat="server" OnClick="lkbEnviarSenhaAgora_Click">Enviar senha agora</asp:LinkButton></td>
                                    </tr>
                                    </table>
                                </td>
                                <td valign="top">
                                <table border="0" cellpadding="3" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                                Clientes :</td>
                                    </tr>
                                        
                                        
                                        <tr>
                                            <td  align="center" colspan="2">
                                                <asp:DataGrid ID="dgrClientes" runat="server" AutoGenerateColumns="False" BackColor="#FFFFC0"
                                                    Height="100%" OnDeleteCommand="dgrClientes_DeleteCommand" ShowHeader="False"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundColumn DataField="id_usuario_cliente" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="id_cliente" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="nome_fantasia"></asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="Delete" Text="Delete"></asp:ButtonColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                            
                                        </tr>                                        
                                        <tr>
                                            <td style="width: 20%; height: 24px;" align="right">
                                                <asp:DropDownList ID="ddlCliente" runat="server" Width="250px">
                                                </asp:DropDownList></td>
                                            <td style="height: 24px;" align="left">
                                                &nbsp;
                                                <asp:Button ID="btnAdicionar" runat="server" OnClick="btnAdicionar_Click" Text=">>" /></td>
                                        </tr>
                                        <tr>
                                        <td align="left" colspan="2" style="height: 19px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/img/left_16x16.gif" NavigateUrl="javascript:history.back(1)"
                                                    Width="59px"></asp:HyperLink><asp:Image ID="Image11" runat="server" ImageUrl="~/img/Sep.gif" /><asp:ImageButton
                                                        ID="btnSalvar" runat="server" ImageUrl="~/img/save_16x16.gif" OnClick="btnSalvar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
