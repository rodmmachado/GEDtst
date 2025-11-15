<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditarUsuario.aspx.cs" Inherits="BPDWeb.JobTracker.Seguranca.EditarUsuario" %>

<%@ Reference Page="~/Util/PaginaWeb.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BPD - Job Tracker</title>
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
                                <table id="Table_01" width="760" border="0" cellpadding="0" cellspacing="0" style="background-color:White;" >
	<tr>
   <td><img src="../../img/spacer.gif" width="262" height="1" border="0" alt=""></td>
   <td><img src="../../img/spacer.gif" width="273" height="1" border="0" alt=""></td>
   <td><img src="../../img/spacer.gif" width="225" height="1" border="0" alt=""></td>
   <td><img src="../../img/spacer.gif" width="1" height="1" border="0" alt=""></td>
  </tr>

  <tr>
   <td colspan="3"><img name="Untitled1_r1_c1" src="../../img/Untitled-1_r1_c1.gif" width="760" height="22" border="0" alt=""></td>
   <td><img src="../../img/spacer.gif" width="1" height="22" border="0" alt=""></td>
  </tr>
  <tr>
   <td><img name="Untitled1_r2_c1" src="../../img/Untitled-1_r2_c1.gif" width="262" height="55" border="0" alt=""></td>
   <td><img name="Untitled1_r2_c2" src="../../img/Untitled-1_r2_c2.gif" width="273" height="55" border="0" alt=""></td>
   <td><img name="Untitled1_r2_c3" src="../../img/Untitled-1_r2_c3.gif" width="225" height="55" border="0" alt=""></td>
   <td><img src="../../img/spacer.gif" width="1" height="55" border="0" alt=""></td>
  </tr>
  <tr>
   <td colspan="3"><img name="Untitled1_r3_c1" src="../../img/Untitled-1_r3_c1.gif" width="760" height="28" border="0" alt=""></td>
   <td><img src="../../img/spacer.gif" width="1" height="28" border="0" alt=""></td>
  </tr>
	<tr>
	    <td colspan="3" style="height: 0px" valign="top">
            &nbsp;<br />            
	    </td>
	   </tr>
      </table>
                                
                                
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; background-color: #808080;" class="lnkMenu">
                                      <asp:Literal ID="ltrIdUsuario" runat="server" Visible="False"></asp:Literal>
                                    <asp:LinkButton ID="lkbInicio" runat="server" OnClick="lkbInicio_Click" ForeColor="White">Início</asp:LinkButton>
                                    |&nbsp;
                                    <asp:LinkButton ID="lkbUsuario" runat="server" OnClick="lkbUsuario_Click" ForeColor="White">Meu 
                                    Perfil</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbRelatorioAr" runat="server" OnClick="lkbAcompanhamento_Click"
                                        ForeColor="White">Relatório de AR´s</asp:LinkButton>
                                        
                                    |
                                    <asp:LinkButton ID="lkbRelatorioPendencias" runat="server" 
                                        ForeColor="White" onclick="lkbRelatorioPendencias_Click">Relatório de Pendências</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbSair" runat="server" OnClick="lkbSair_Click" ForeColor="#FFFF80">Sair</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="SubTitulo">
                                    BPD GED&nbsp; &gt; &nbsp;Alterar Meus Perfil
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td class="lnkMenu">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="center">
                                    <table border="0" cellpadding="3" cellspacing="0" style="width: 100%; height: 100%">
                                    <tr>
                                <td align="right" style="width: 40%">
                                    Cliente(s) :
                                </td>
                                <td align="left">
                                    &nbsp;
                                    <asp:Label ID="lblClientes" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 40%; height: 24px;" align="right">
                                    Nome :</td>
                                <td style="height: 24px;" align="left">
                                    &nbsp;
                                    <asp:TextBox ID="txtNome" runat="server" Width="278px" MaxLength="50" 
                                        CssClass="form"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 40%" align="right">
                                    Email :</td>
                                <td align="left">
                                    &nbsp;
                                    <asp:TextBox ID="txtEmail" runat="server" Width="278px" MaxLength="150" 
                                        CssClass="form"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 40%" align="right">
                                    Senha :</td>
                                <td align="left">
                                    &nbsp;
                                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="105px" 
                                        MaxLength="10" CssClass="form"></asp:TextBox>
                                    <span style="color: Red">(Até 10 caracteres)</span></td>
                            </tr>
                            <tr>
                                <td style="width: 40%">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40%">
                                </td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/img/left_16x16.gif"
                                        NavigateUrl="javascript:history.back(1)" Width="59px"></asp:HyperLink><asp:Image
                                            ID="Image11" runat="server" ImageUrl="~/img/Sep.gif" /><asp:ImageButton
                                                ID="btnSalvar" runat="server" ImageUrl="~/img/save_16x16.gif"
                                                OnClick="btnSalvar_Click" /></td>
                            </tr>
                                    </table>
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
