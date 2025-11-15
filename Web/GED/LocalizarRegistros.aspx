<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LocalizarRegistros.aspx.cs" Inherits="BPDWeb.JobTracker.Job.LocalizarRegistros" %>

<%@ Reference Page="~/Util/PaginaWeb.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acompanhamento</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../padrao.css" type="text/css" rel="stylesheet">
    <script src="../funcoes.js"></script>
    <style type="text/css">
        .style1
        {
            width: 40%;
            height: 26px;
        }
        .style2
        {
            width: 60%;
            height: 26px;
        }
        .style3
        {
            width: 40%;
            height: 24px;
        }
        .style4
        {
            width: 60%;
            height: 24px;
        }
    </style>
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
      </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; background-color: #808080;" class="lnkMenu">
                                    <asp:Literal ID="ltrIdEntidade" runat="server" Visible="False"></asp:Literal>
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
                                    &nbsp;BPD GED&nbsp; &gt; &nbsp;Localizador de Registro(s)&nbsp;
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
                                Data de Postagem :</td>
                            <td style="width: 60%" align="left">
                                <asp:TextBox ID="txtDataInicial" runat="server"  
                               CssClass="Form" MaxLength="10"

                                    onChange="formataMascara('##/##/###@', this);" onkeypress="return filtraCaracteres(event);"

                                    
                                    onkeyup="if(isTeclaRelevante(getTeclaPressionada(event))){formataMascara('##/##/###@', this)}" Width="86px"
 
                                
                                
                                ></asp:TextBox>
                            &nbsp;à
                                <asp:TextBox ID="txtDataFinal" runat="server" 
                                CssClass="Form" MaxLength="10"

                                    onChange="formataMascara('##/##/###@', this);" onkeypress="return filtraCaracteres(event);"

                                    
                                    onkeyup="if(isTeclaRelevante(getTeclaPressionada(event))){formataMascara('##/##/###@', this)}" Width="86px"

                                
                                
                                ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="style3">
                                Nome :</td>
                            <td align="left" class="style4">
                                <asp:TextBox ID="txtNome" runat="server" CssClass="Form"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="style1">
                                CPF ou CNPJ :</td>
                            <td align="left" class="style2">
                                <asp:TextBox ID="txtCpfCnpj" runat="server" CssClass="Form"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40%; text-align: right">
                                Nº de Contrato :</td>
                            <td style="width: 60%" align="left">
                                <asp:TextBox ID="txtNumeroContrato" runat="server" CssClass="Form"></asp:TextBox>
&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 40%; text-align: right">
                                Situação :</td>
                            <td style="width: 60%" align="left">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Form">
                                    <asp:ListItem Value="0">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Postados</asp:ListItem>
                                    <asp:ListItem Value="3">Positivo</asp:ListItem>
                                    <asp:ListItem Value="4">Negativo</asp:ListItem>
                                    <asp:ListItem Value="5">PI</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;
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
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:DataGrid ID="dgrRegistros" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderStyle="None" BorderWidth="1px" CellPadding="0" CssClass="TextoSimples"
                                        GridLines="Horizontal" OnSelectedIndexChanged="dgrAtividade_SelectedIndexChanged"
                                        Width="100%" OnItemDataBound="dgrRegistros_ItemDataBound" 
                                        OnDeleteCommand="dgrProtocolo_DeleteCommand">
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
                                            <asp:BoundColumn DataField="id_registro" HeaderText="id_registro" 
                                                Visible="False">
                                            </asp:BoundColumn>
                                            <asp:HyperLinkColumn ItemStyle-Width="100px" DataNavigateUrlField="numero_localizador"
                                                DataNavigateUrlFormatString="http://websro.correios.com.br/sro_bin/txect01$.QueryList?P_LINGUA=001&amp;P_TIPO=001&amp;P_COD_UNI={0}" 
                                                DataTextField="numero_localizador" HeaderText="Nº Localizador" Target="_blank" >
<ItemStyle Width="100px"></ItemStyle>
                                            </asp:HyperLinkColumn>
                                            <asp:BoundColumn DataField="nome" HeaderText="Nome">
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left"  />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="data_postagem" HeaderText="Data Postagem" 
                                                DataFormatString="{0: dd/MM/yyyy}">
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" />
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="numero_contrato" HeaderText="Nº Contrato">
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" Width="100px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="cpf_cnpj" HeaderText="CPF/CNPJ">
                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Left" Width="120px"  />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="status" HeaderText="Situação">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="arquivo_espelho" HeaderText="arquivo_espelho" 
                                                Visible="False"></asp:BoundColumn>
                                            <asp:TemplateColumn HeaderText="Espelho">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgCancelar" runat="server" CommandName="Delete" 
                                                        ImageUrl="../img/abrir.gif" />
                                                </ItemTemplate>
                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Center" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="AR">
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgAbrir" runat="server" CommandName="Select" 
                                                        ImageUrl="../img/novo.gif" />
                                                </ItemTemplate>
                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="motivo_devolucao" HeaderText="motivo_devolucao" 
                                                Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="numero_pi" HeaderText="numero_pi" Visible="False">
                                            </asp:BoundColumn>
                                            
                                        </Columns>
                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" Mode="NumericPages" />
                                        <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:DataGrid>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 19px; text-align: right">
                                    &nbsp;<asp:Label ID="lblResultado" runat="server" ForeColor="Red" Text="Label"></asp:Label><br/>
                                    <asp:LinkButton ID="lkbExportarCsv" runat="server" 
                                        onclick="lkbExportarCsv_Click" Enabled="False" Visible="False">Exportar CSV</asp:LinkButton>
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
