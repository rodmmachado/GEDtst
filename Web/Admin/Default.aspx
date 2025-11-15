<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BPDWeb.JobTrackerAdmin.Default" Title="Untitled Page" %>
<%@ Reference Page="~/Util/PaginaWeb.aspx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Job Tracker - Área Administrativa</title>
    <link href="../padrao.css" type="text/css" rel="stylesheet"/>
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
                                                    <img src="../img/papel_timbrado_cabecalho_01.png" width="760" height="14" border="0"
                                                        alt=""></a></td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">
                                                <a href="#" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../img/papel_timbrado_cabecalho-02.png" width="316" height="93" border="0"
                                                        alt=""></a></td>
                                            <td>
                                                <a href="http://www.bpd.com.br" target="_top" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../img/papel_timbrado_cabecalho_03.png" width="132" height="47" border="0"
                                                        alt=""></a></td>
                                            <td rowspan="2">
                                                <a href="#" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../img/papel_timbrado_cabecalho-04.png" width="312" height="93" border="0"
                                                        alt=""></a></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="#" onmouseover="window.status='BPD - Impressão de Dados';  return true;"
                                                    onmouseout="window.status='';  return true;">
                                                    <img src="../img/papel_timbrado_cabecalho-05.png" width="132" height="46" border="0"
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
                                    <asp:Literal ID="ltrIdUsuario" runat="server" Visible="False"></asp:Literal>
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
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td colspan="2">
                <br />
                Bem vindo a Área do Cliente da BPD<br />
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
            </td>
            <td style="width: 50%">
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
            </td>
            <td style="width: 50%">
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <table border="0" cellpadding="3" cellspacing="0" style="width: 90%; height: 100%">
                    <tr>
                        <td align="left">
                            Usuário:
                            <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 50%">
                <table cellpadding="3" cellspacing="0" width="90%">
                    <tr>
                        <td align="center" class="SubTitulo" colspan="4">
                            ACESSO RÁPIDO</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            &nbsp;</td>
                        <td style="width: 35%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 15%">
                            &nbsp;</td>
                        <td style="width: 35%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%; height: 23px">
                            <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="../imagens/abrir.gif" /></td>
                        <td align="left" style="width: 35%; height: 23px">
                            <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/JobTracker/Job/EnviarJob.aspx">Enviar um Job</asp:LinkButton></td>
                        <td align="right" style="width: 15%; height: 23px">
                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="../imagens/abrir.gif" /></td>
                        <td align="left" style="width: 35%; height: 23px">
                            <asp:LinkButton ID="LinkButton10" runat="server">Manual</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="../imagens/abrir.gif" /></td>
                        <td align="left" style="width: 35%">
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="~/JobTracker/Job/AcompanhamentoJob.aspx">Acompanhar Job(s) enviados</asp:LinkButton></td>
                        <td align="right" style="width: 15%">
                            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="../imagens/abrir.gif" /></td>
                        <td align="left" style="width: 35%">
                            <asp:LinkButton ID="LinkButton12" runat="server">Dúvidas e Sugestões</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="../imagens/abrir.gif" /></td>
                        <td align="left" style="width: 35%">
                            <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="~/JobTracker/Aprovacao/JobAguardandoAprovacao.aspx">Aprovar Job(s) enviados</asp:LinkButton></td>
                        <td align="right" style="width: 15%">
                        </td>
                        <td align="left" style="width: 35%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%">
                        </td>
                        <td style="width: 35%">
                        </td>
                        <td style="width: 15%">
                        </td>
                        <td style="width: 35%">
                        </td>
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
 



