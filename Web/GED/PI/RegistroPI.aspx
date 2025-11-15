<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroPI.aspx.cs" Inherits="BPDWeb.JobTracker.Job.RegistroPI" %>

<%@ Reference Page="~/Util/PaginaWeb.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de PI</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../padrao.css" type="text/css" rel="stylesheet">
    <script src="../../funcoes.js"></script>
    </head>
<body bottommargin="0" topmargin="0" leftmargin="0" rightmargin="0" style="filter: progid:DXImageTransform.Microsoft.Gradient(endColorstr='#C0CFE2', startColorstr='#6186B3', gradientType='0');">
    <form id="form1" runat="server">
        <div align="center" style=" height: 100%">
            <table border="0" class="tblForm" cellpadding="0" cellspacing="0" style="width: 760px;
                height: 98%;">
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
                                    <asp:Literal ID="ltrIdRegistro" runat="server" Visible="False"></asp:Literal>
                                    <asp:Literal ID="ltrIdUsuario" runat="server" Visible="False"></asp:Literal>
                                    <asp:LinkButton ID="lkbInicio" runat="server" OnClick="lkbInicio_Click" ForeColor="White">Início</asp:LinkButton>
                                    &nbsp;|&nbsp;<asp:LinkButton ID="lkbUsuario" runat="server" OnClick="lkbUsuario_Click" ForeColor="White">Meu 
                                    Perfil</asp:LinkButton>
                                    &nbsp;|
                                    <asp:LinkButton ID="lkbRelatorioAr" runat="server" OnClick="lkbAcompanhamento_Click"
                                        ForeColor="White">Relatório de AR´s</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbRelatorioPendencias" runat="server" 
                                        ForeColor="White" onclick="lkbRelatorioPendencias_Click">Relatório de Pendências</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lkbSair" runat="server" OnClick="lkbSair_Click" ForeColor="#FFFF80">Sair</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="SubTitulo">
                                    &nbsp;BPD GED&nbsp; &gt; &nbsp;Registro de PI&nbsp;
                                    <hr />
                                </td>
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
                                Nº Localizador :</td>
                            <td style="width: 60%" align="left">
                                <asp:TextBox ID="txtNumeroLocalizador" runat="server" CssClass="Form" 
                                    Height="20px" Width="136px"></asp:TextBox>
&nbsp;
                            <asp:ImageButton ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" ImageUrl="~/img/pesquisar.gif" ToolTip="Pesquisar" />
                                                </td>
                        </tr>
                        <tr>
                            <td style="width: 40%; text-align: right">
                                &nbsp;</td>
                            <td style="width: 60%" align="left">
                                &nbsp;</td>
                        </tr>
                        </table>
                                    
                                    
                                    </td>
                            </tr>
                            
                            
                            <tr>
                                <td style="width: 100%" valign="top">
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td style="width: 100%" valign="top">
                    <table align="center" border="1" bordercolor="#49669e" cellpadding="2" cellspacing="0"
                            style="font-size: 10pt; color: mediumblue; font-family: Arial; background-color: lightgrey">
                        <tr>
                            <td style="text-align: right">
                                Nº Localizador :</td>
                            <td style="text-align: left">
                                <asp:Label ID="lblNumeroLocalizador" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Nome :</td>
                            <td style="text-align: left">
                                <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Processado em :</td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDataProcessamento" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Postado em :</td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDataPostagem" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Status :</td>
                            <td style="text-align: left">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nº de PI</td>
                            <td>
                                <asp:TextBox ID="txtNumeroPI" runat="server" CssClass="Form" Enabled="False"></asp:TextBox>
&nbsp;<asp:Button ID="btnRegistrarPI" runat="server" CssClass="Form" Text="Registrar" Enabled="False" 
                                    onclick="btnRegistrarPI_Click" />
                            </td>
                        </tr>
                    </table>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td style="width: 100%" valign="top">
                                    &nbsp;</td>
                            </tr>
                            
                            
                            <tr>
                                <td style="width: 100%" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 19px; text-align: right">
                                    &nbsp;<asp:Label ID="lblResultado" runat="server" ForeColor="Red" Text="Label"></asp:Label><br/>
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
