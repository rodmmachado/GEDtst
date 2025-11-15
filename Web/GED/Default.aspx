<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BPDWeb.JobTracker.Default" %>

<%@ Reference Page="~/Util/PaginaWeb.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BPD - Job Tracker</title>
    <link href="../padrao.css" type="text/css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            width: 20%;
            height: 19px;
        }
        .style2
        {
            height: 19px;
        }
    </style>
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
                                <table id="Table_01" width="760" border="0" cellpadding="0" cellspacing="0" style="background-color:White;" >
	<tr>
   <td><img src="../img/spacer.gif" width="262" height="1" border="0" alt=""></td>
   <td><img src="../img/spacer.gif" width="273" height="1" border="0" alt=""></td>
   <td><img src="../img/spacer.gif" width="225" height="1" border="0" alt=""></td>
   <td><img src="../img/spacer.gif" width="1" height="1" border="0" alt=""></td>
  </tr>

  <tr>
   <td colspan="3"><img name="Untitled1_r1_c1" src="../img/Untitled-1_r1_c1.gif" width="760" height="22" border="0" alt=""></td>
   <td><img src="../img/spacer.gif" width="1" height="22" border="0" alt=""></td>
  </tr>
  <tr>
   <td><img name="Untitled1_r2_c1" src="../img/Untitled-1_r2_c1.gif" width="262" height="55" border="0" alt=""></td>
   <td><img name="Untitled1_r2_c2" src="../img/Untitled-1_r2_c2.gif" width="273" height="55" border="0" alt=""></td>
   <td><img name="Untitled1_r2_c3" src="../img/Untitled-1_r2_c3.gif" width="225" height="55" border="0" alt=""></td>
   <td><img src="../img/spacer.gif" width="1" height="55" border="0" alt=""></td>
  </tr>
  <tr>
   <td colspan="3"><img name="Untitled1_r3_c1" src="../img/Untitled-1_r3_c1.gif" width="760" height="28" border="0" alt=""></td>
   <td><img src="../img/spacer.gif" width="1" height="28" border="0" alt=""></td>
  </tr>
	<tr>
	    <td colspan="3" style="height: 0px" valign="top">
            &nbsp;<br />            
	    </td>
	   </tr>
      </table></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; background-color: #808080;" class="lnkMenu">
                                    &nbsp;<asp:LinkButton ID="lkbInicio" runat="server" OnClick="lkbInicio_Click" ForeColor="White">Início</asp:LinkButton>
                                    &nbsp;|&nbsp;<asp:LinkButton ID="lkbUsuario" runat="server" OnClick="lkbUsuario_Click" ForeColor="White">Meu 
                                    Perfil</asp:LinkButton>
                                    &nbsp;|
                                    <asp:LinkButton ID="lkbRelatorioAr" runat="server" OnClick="lkbAcompanhamento_Click"
                                        ForeColor="White">Relatório de AR´s</asp:LinkButton>
                                    &nbsp;|
                                    <asp:LinkButton ID="lkbRelatorioPendencias" runat="server" 
                                        ForeColor="White" onclick="lkbRelatorioPendencias_Click">Relatório de Pendências</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbSair" runat="server" OnClick="lkbSair_Click" ForeColor="#FFFF80">Sair</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td valign="top" align="center">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                Bem vindo a Área de GED<br />
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
                                            <td style="width: 50%" valign="top">
                                    <table border="0" cellpadding="3" cellspacing="0" style="width: 90%; height: 100%">
                                        <tr>
                                            <td align="center" class="SubTitulo" colspan="2" valign="top">
                                                INFORMAÇÕES DE ACESSO</td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 20%" valign="top">
                                            </td>
                                            <td align="left" valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" class="style1">
                                                Usuário:
                                                </td>
                                            <td align="left" valign="top" class="style2">
                                                <asp:Label ID="lblUsuario" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" style="width: 20%">
                                                &nbsp;</td>
                                            <td align="left" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="left" style="width: 20%">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 20%">
                                                </td>
                                            <td>
                                                </td>
                                        </tr>
                                    </table>
                                            </td>
                                            <td style="width: 50%" valign="top">
                                    <table cellpadding="3" cellspacing="0" width="90%">
                                        <tr>
                                            <td colspan="4" align="center" class="SubTitulo">
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
                                            <td align="right" style="width: 15%; height: 23px;">
                                                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="../img/abrir.gif" /></td>
                                            <td style="width: 35%; height: 23px;" align="left">
                                                <asp:LinkButton ID="LinkButton7" runat="server" 
                                                    PostBackUrl="~/GED/Usuario/EditarUsuario.aspx">Editar meu Perfil</asp:LinkButton></td>
                                            <td align="right" style="width: 15%; height: 23px;">
                                                </td>
                                            <td style="width: 35%; height: 23px;" align="left">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 15%">
                                                <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="../img/abrir.gif" /></td>
                                            <td align="left" colspan="3">
                                                <asp:LinkButton ID="LinkButton9" runat="server" 
                                                    PostBackUrl="~/GED/LocalizarRegistros.aspx">Relatório de AR´s</asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 15%">
                                                &nbsp;</td>
                                            <td style="width: 35%" align="left">
                                                &nbsp;</td>
                                            <td align="right" style="width: 15%">
                                                </td>
                                            <td style="width: 35%" align="left">
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
                                    <br />
                                    <br />
                                    <br />
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
