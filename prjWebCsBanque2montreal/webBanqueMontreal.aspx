<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webBanqueMontreal.aspx.cs" Inherits="prjWebCsBanque2montreal.webBanqueMontreal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="CSS/BanqueMontrealStyle.css" />
</head>
<body style="height: 247px">
    <form id="form1" runat="server">
        <div>
            <h1>BANQUE DE MONTREAL</h1>
            <hr />
            <marquee>Bienvenue à la Banque de Montréal, une institution financière 
                de confiance depuis des décennies, offrant des services bancaires 
                complets et personnalisés pour vous aider à réaliser vos objectifs 
                financiers.</marquee>
            <hr />
            <asp:Panel ID="panIdentificationClient" runat="server" GroupingText="Identification Client" Height="180px" Width="458px">
                <div>
                    <asp:Label ID="lblnumcompte" runat="server" Text="Numero de compte : " Enabled="False"></asp:Label>
                    <asp:TextBox ID="txtNumCompte" runat="server" CssClass="boite"></asp:TextBox>
                </div>
                <br />
                <div class="centrer">
                    <asp:Button ID="btnIdentification" runat="server" Text="Suivant" Width="179px" CssClass="MesBoutons" Height="36px" OnClick="btnIdentification_Click" />
                    <br />
                </div>
                <div class="centrer">
                    <asp:Label ID="lblInfoIdentification" runat="server" ></asp:Label>
                </div>
                <br />
            </asp:Panel>

            <asp:Panel ID="panVerification" runat="server" GroupingText="Verification Nip" Height="180px" Width="458px">
                <asp:Label ID="lblBienvenue" runat="server" Text=""></asp:Label><br />
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Entrez votre NIP : "></asp:Label>
                    <asp:TextBox ID="txtNip" runat="server" CssClass="boite"></asp:TextBox>
                </div>
                <br />
                <div class="centrer">
                    <asp:Button ID="btnVerificationNip" runat="server" Text="Suivant" Width="179px" CssClass="MesBoutons" Height="36px" OnClick="btnVerificationNip_Click" />
                    <br />
                </div>
                <div class="centrer">
                    <asp:Label ID="lblVerificationNip" runat="server" ></asp:Label>
                </div>
            </asp:Panel>

            <asp:Panel ID="panTransaction" runat="server" GroupingText="Choix Transaction" Height="180px" Width="458px">
    <table>
        <tr>
            <td>
                <br />
                <asp:RadioButtonList ID="radTransaction" runat="server">
                    <asp:ListItem Text="Deposer :" runat="server" Value="1" />
                    <asp:ListItem Text="Retirer  :" runat="server" Value="2" />
                    <asp:ListItem Text="Consulter :" runat="server" Selected="True" Value="3" />
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:TextBox ID="txtDeposer" runat="server" CssClass="boiteMontant"></asp:TextBox> $<br />
                <asp:TextBox ID="txtRetirer" runat="server" CssClass="boiteMontant"></asp:TextBox> $
            </td>
        </tr>
    </table>
                <br />
                <div class="centrer">
                    <asp:Button ID="btnTransaction" runat="server" Text="Suivant" Width="179px" CssClass="MesBoutons" Height="36px" OnClick="btnTransaction_Click" />
                    <br />
                </div>
                <div class="centrer">
                    <asp:Label ID="lblTransaction" runat="server" ></asp:Label>
                </div>
            </asp:Panel>

            <br /><br /><br />
            <asp:Panel ID="panInformationCompte" runat="server" GroupingText="Informations du compte" Height="180px" Width="458px">
                <asp:Label ID="lblInfoClt" runat="server" Text=""></asp:Label>
            </asp:Panel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnTerminer" runat="server" Text="Terminer" Width="179px" CssClass="MesBoutons" Height="36px" OnClick="btnTerminer_Click" />
            </div>
    </form>
       
</body>
</html>
