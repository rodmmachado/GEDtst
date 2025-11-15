<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArInfo.aspx.cs" Inherits="BPDWeb.JobTracker.Job.ArInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>JOB Info</title>
    <link href="../padrao.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div id="areaImprimivel" align="center">
        <table border="0" cellpadding="4" cellspacing="0" style="width: 500px" class="tblForm">
            <tr>
                <td>
                    <asp:Literal ID="ltrIdRegistro" runat="server" Visible="False"></asp:Literal><br />
                    <span style="font-size: 10pt"><strong>
                    INFORMAÇÕES DO AR </strong></span>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <table align="center" border="1" bordercolor="#49669e" cellpadding="2" cellspacing="0"
                            style="font-size: 10pt; color: mediumblue; font-family: Arial; background-color: lightgrey">
                        <tr>
                            <td style="text-align: right">
                                Nº Localizador do Objeto :</td>
                            <td>
                                <asp:Label ID="lblNumeroLocalizador" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Nome :</td>
                            <td>
                                <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Processado em :</td>
                            <td>
                                <asp:Label ID="lblDataProcessamento" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Retorno em :</td>
                            <td>
                                <asp:Label ID="lblDataRetorno" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Postado em :</td>
                            <td>
                                <asp:Label ID="lblDataPostagem" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Nº do Contrato :</td>
                            <td>
                                <asp:Label ID="lblNumeroContrato" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                CPF / CNPJ :</td>
                            <td>
                                <asp:Label ID="lblCpfCnpj" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td align=left>
                    <span style="font-size: 9pt">
                    AR DIGITALIZADO:</span></td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:Image ID="imgArquivoDigitalizado" runat="server" Width="800px" />
                    </div>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                    &nbsp;
                &nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/img/voltar2.gif"
                            NavigateUrl="javascript:history.back(1)" Width="59px"></asp:HyperLink>&nbsp;
                        <asp:Image ID="Image11" runat="server" ImageUrl="~/img/Sep.gif" />
                        <asp:ImageButton ID="btnImprimir" runat="server" ImageUrl="~/img/imprimir_86x20.gif"
                            OnClick="btnImprimir_Click" />
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Sep.gif" />
                        <asp:ImageButton ID="btnSair" runat="server" ImageUrl="~/img/sair_52x20.gif" OnClick="btnSair_Click" />
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="left">
                <span style="font-size: 10pt">.............................................................<br />
                            <strong><span style="color: navy">BPD - GED</span></strong>
                            <br />
                        </span><a href="mailto:suporte@bpd.com.br"><span style="font-size: 10pt; font-family: Arial;
                            text-decoration: underline">suporte@bpd.com.br</span></a><span style="font-size: 10pt;
                                font-family: Arial"> </span>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
