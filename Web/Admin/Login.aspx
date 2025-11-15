<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="BPDWeb.JobTrackerAdmin.Login" Title="BPD - Impressão de Dados" %>
<%@ Reference Page="~/Util/PaginaWeb.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BPD - Impressão de Dados</title>
    <link href="../padrao.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../funcoes.js"></script>
</head>
<body style="filter: progid:DXImageTransform.Microsoft.Gradient(endColorstr='#C0CFE2', startColorstr='#6186B3', gradientType='0');">
    <div id="desliga" class="desabilita"></div>
    <div id="new_pm_popup" class="fonte1" style="position: absolute; top: 160px; left: 250px; display: none; z-index:1000">
        &nbsp;<map name="Map_janela_div"><area shape="rect" coords="373,11,391,25" href="#" onclick="getElementById('new_pm_popup').style.display = 'none'; getElementById('desliga').style.display = 'none'; return false;"></map></div>
    
    <form id="form1" runat="server" > 
    
    <div align="center">
        <div class="content">
            <div style="text-align: center">
                    <table id="Table_01" width="760" border="0" cellpadding="0" cellspacing="0" style="height: 94px">
	<tr>
		<td colspan="3" style="height: 13px">
			<a href="#"
				onmouseover="window.status='BPD - Impressão de Dados';  return true;"
				onmouseout="window.status='';  return true;">
				<img src="../img/papel_timbrado_cabecalho_01.png" width="760" height="14" border="0" alt=""></a></td>
	</tr>
	<tr>
		<td rowspan="2">
			<a href="#"
				onmouseover="window.status='BPD - Impressão de Dados';  return true;"
				onmouseout="window.status='';  return true;">
				<img src="../img/papel_timbrado_cabecalho-02.png" width="316" height="93" border="0" alt=""></a></td>
		<td>
			<a href="http://www.bpd.com.br" target="_top"
				onmouseover="window.status='BPD - Impressão de Dados';  return true;"
				onmouseout="window.status='';  return true;">
				<img src="../img/papel_timbrado_cabecalho_03.png" width="132" height="47" border="0" alt=""></a></td>
		<td rowspan="2">
			<a href="#"
				onmouseover="window.status='BPD - Impressão de Dados';  return true;"
				onmouseout="window.status='';  return true;">
				<img src="../img/papel_timbrado_cabecalho-04.png" width="312" height="93" border="0" alt=""></a></td>
	</tr>
	<tr>
		<td>
			<a href="#"
				onmouseover="window.status='BPD - Impressão de Dados';  return true;"
				onmouseout="window.status='';  return true;">
				<img src="../img/papel_timbrado_cabecalho-05.png" width="132" height="46" border="0" alt=""></a></td>
	</tr>
	<tr>
	    <td colspan="3" style="height: 0px" valign="top">
            <br />
            <div align="right" class="toplink">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" ForeColor="White">Início</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="White" NavigateUrl="~/Empresa.aspx">A Empresa</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="White" NavigateUrl="~/Servicos.aspx">Serviços</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="White" NavigateUrl="~/Contato.aspx">Contato</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink5" runat="server" ForeColor="White" NavigateUrl="https://ssl3.porta80.com.br/bpd/Login.aspx">Área do Cliente</asp:HyperLink>&nbsp;
                &nbsp;</div>
            <br />
	    </td>
	   </tr>
      </table>
                    <div align="center">

    <table border="0" cellpadding="0" cellspacing="0" style="width: 659px;">
        <tr>
            <td style="width: 100px; height: 18px;" align="center" valign="bottom">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/up_login.gif" /></td>
        </tr>
        <tr>
            <td style="width: 640px; background-color: #023d75; vertical-align: middle; text-align: center;" align="center" valign="middle">
                <br />
                <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; height: 100px; background-color: #023d75;" class="tblFormlogin">
                    <tr>
                        <td style="height: 28px;" colspan="3" rowspan="" class="toplink">
                            Área Administrativa<br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 24px;" align="right">
                            E-Mail:&nbsp;
                        </td>
                        <td align="left" colspan="2" style="height: 24px">
                            <asp:TextBox ID="txtEmail" runat="server" ForeColor="Black" Width="97%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 14px;" align="right">
                            Senha:&nbsp;
                        </td>
                        <td align="left" colspan="2" style="height: 14px">
                            <asp:TextBox ID="txtSenha" runat="server" MaxLength="10" TextMode="Password" Width="65px" CssClass="TextBox" ForeColor="Black"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" Height="20px" ImageUrl="~/img/Forward.gif" Width="20px" /></td>
                    </tr>
                    <tr>
                        <td style="height: 22px;">
                        </td>
                        <td style="height: 22px;" colspan="2">
                            <br />
                            </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 100px" align="center" valign="top">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/img/down_final.gif" /></td>
        </tr>
    </table>

<br />
                        <div align="center" class="Rodape" style="width: 659px; height: 39px">
                            <hr class="Line" />
                            Copyright - 2009 BPD Impressão de Dados<br />
                            Rua Desembargador José Batalha, 90 - 2º Andar - Consolação - Vitória - ES - CEP:
                            29045-530 |
                            Telefone: (27) 3323-2880
                            <br />
                        </div>
                        
                    </div>
            </div>
            </div>
            
    </div>
    
    </form>
</body>
</html>

