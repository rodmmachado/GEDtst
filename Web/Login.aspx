<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="BPDWeb.JobTracker.Login" %>
<%@ Reference Page="~/Util/PaginaWeb.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BPD - Impressão de Dados</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="padrao.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="funcoes.js"></script>
    <style type="text/css">
        
        
.bordaBox {background: ttransparent; width:470px;}
.bordaBox .b1, .bordaBox .b2, .bordaBox .b3, .bordaBox .b4, .bordaBox .b1b, .bordaBox .b2b, .bordaBox .b3b, .bordaBox .b4b {display:block; overflow:hidden; font-size:1px;}
.bordaBox .b1, .bordaBox .b2, .bordaBox .b3, .bordaBox .b1b, .bordaBox .b2b, .bordaBox .b3b {height:1px;}
.bordaBox .b2, .bordaBox .b3, .bordaBox .b4 {background:white; border-left:1px solid white; border-right:1px solid white;}
.bordaBox .b1 {margin:0 5px; background: white;}
.bordaBox .b2 {margin:0 3px; border-width:0 2px;}
.bordaBox .b3 {margin:0 2px;}
.bordaBox .b4 {height:2px; margin:0 1px;}
.bordaBox .conteudo {padding:5px;display:block; background:white; border-left:1px solid white; border-right:1px solid white;}

        .style2
        {
            height: 58px;
        }
        .style3
        {
            width: 20%;
            height: 22px;
        }
        .style4
        {
            height: 22px;
        }
        .style5
        {
            height: 577px;
        }
    </style>
</head>
<body  bgcolor=""  style="filter: progid:DXImageTransform.Microsoft.Gradient(endColorstr='#C0CFE2', startColorstr='#6186B3', gradientType='0');">

    <form id="form1" runat="server" > 
    
 
                    
            <table width="100%" border="0" class="textosimples" height="100%" >
            <tr >
                <td width="100%" align="center" class="style5">
                <div class="bordaBox">

                <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b><div class="conteudo">
                    <table class="tblFormlogin" width="450" height="351" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0">
                        
                        <tr>
                            <td align="top" valign="top" >
                                <table class="TextoSimples" border="0" style="height:100%" width="100%" background="./img/quadradologo.png"  align="center">
                                    <tr>
                                        <td colspan="2" align="left" style="text-align: center">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="text-align: center">
                                            
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="text-align: center">
                                            
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="text-align: center">
                                            
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="text-align: center" class="style2">
                                            <font style="text-align: center"><strong><span style="color: #333366">BPD - GED 
                                            <br />
                                            Para acessar, entre com os dados abaixo e clique em ENTRAR.&nbsp;</span></strong><br />
                                                <hr />
                                            </font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;" class="style3">
                                            <asp:Label ID="lbllogin" runat="server" ForeColor="#3366CC">E-mail:</asp:Label>
                                        </td>
                                        <td class="style4" style="text-align:left;">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="Form" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; " class="style3">
                                            <asp:Label ID="lblSenha" runat="server" ForeColor="#3366CC">Senha:</asp:Label>
                                        </td>
                                        <td class="style4" style="text-align:left;">
                                            <asp:TextBox ID="txtSenha" runat="server" CssClass="Form" TextMode="Password"></asp:TextBox>
                                            &nbsp;&nbsp;<asp:Button ID="ImageButton1" runat="server" Text="Entrar"  CssClass="botao" 
                                                 Height="19px" onclick="ImageButton1_Click1"/>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; " class="style3">
                                            &nbsp;</td>
                                        <td class="style4" style="text-align: left;" >
                            <asp:HyperLink ID="hplEsqueciSenha" runat="server" NavigateUrl="~/EnviarSenha.aspx">Esqueceu sua senha? Clique aqui.</asp:HyperLink>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center;">
                                            <asp:Label ID="lblMenssagem" runat="server" ForeColor="Red" Visible="False">Usuário ou Senha inválida</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </div>
                    <b class="b4"></b><b class="b3"></b><b class="b2"></b><b class="b1">g</b>
                    </div>
                </td>                
            </tr>
            
        
        </table>
                    

    
    </form>
</body>
</html>