<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="CTGSPG.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <strong>Welcome to the ClarkTribeGames Strong Password Generator!</strong><br />
        <br />
        This is a simple site based on the <a href="https://xkcd.com/936/" target="_blank" rel="noopener noreferrer" class="auto-style1">xkcd Password Strength</a> methodology that generates a strong password for you to use.<br />
        <br />
        Uses <a href="https://github.com/dwyl/english-words" target="_blank" rel="noopener noreferrer" class="auto-style1">dwyl's English Words</a> as a source for the database of the words which is covered by <a href="https://unlicense.org/" target="_blank" rel="noopener noreferrer" class="auto-style1">The Unlicense</a>.<br />
        <br />
        This site is purposely lightweight and simple for speed and consistency.<br />
        <br />
        <asp:Table ID="AnswerTable" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:TextBox ID="GeneratedBox" runat="server" Width="600px" /></asp:TableCell><asp:TableCell runat="server"><asp:Button ID="CopyButton" runat="server" Text="Copy" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Label ID="StatusLabel" runat="server" Font-Bold="True"></asp:Label><br /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
       <br />
        <asp:Table ID="SymbolsTable" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:CheckBox ID="SymbolsCheck" runat="server" Text="Customize Symbol" AutoPostBack="true" />
</asp:TableCell><asp:TableCell runat="server"><asp:DropDownList ID="SymbolsDrop" runat="server" Enabled="False">
            <asp:ListItem Selected="True">#</asp:ListItem>
            
<asp:ListItem>-</asp:ListItem>
            
<asp:ListItem>!</asp:ListItem>
            
<asp:ListItem>$</asp:ListItem>
            
<asp:ListItem>%</asp:ListItem>
            
<asp:ListItem>+</asp:ListItem>
            
<asp:ListItem>&amp;</asp:ListItem>
            
<asp:ListItem>(</asp:ListItem>
            
<asp:ListItem>)</asp:ListItem>
            
<asp:ListItem>&lt;</asp:ListItem>
            
<asp:ListItem>&gt;</asp:ListItem>
            
<asp:ListItem>?</asp:ListItem>
            
<asp:ListItem>[</asp:ListItem>
            
<asp:ListItem>]</asp:ListItem>
            
<asp:ListItem>=</asp:ListItem>
            
<asp:ListItem>_</asp:ListItem>
            
<asp:ListItem>~</asp:ListItem>
        
</asp:DropDownList>
        
</asp:TableCell><asp:TableCell runat="server"><asp:CheckBox ID="MaxCheckBox" runat="server" Text="Custom Max Length"  AutoPostBack="true" /></asp:TableCell>
                <asp:TableCell runat="server"><asp:DropDownList ID="MaxLengthDrop" runat="server" Enabled="false"><asp:ListItem>16</asp:ListItem></asp:DropDownList></asp:TableCell></asp:TableRow></asp:Table><br />
        <asp:Button ID="GenButton" runat="server" Text="Generate" Width="100px" />
            &nbsp;<asp:Button ID="ClearButton" runat="server" Text="Clear" Width="100px" />
        <br /><div>
            <br />Disclaimer:&nbsp; ClarkTribeGames LLC is not responsible for any loss of data, access to any accounts or applications, or measurement of the actual strength of the password.&nbsp; Please be responsible!se be responsible!<br />
            <br />
            <asp:Button ID="DonateButton" runat="server" Text="Donate via PayPal" Width="150px" />
             <asp:Button ID="PatreonButton" runat="server" Text="Become a Patreon" Width="150px" />
            &nbsp;<asp:Button ID="FacebookButton" runat="server" Text="Facebook" Width="150px" />  <asp:Button ID="DiscordButton" runat="server" Text="Discord" Width="150px" />  <asp:Button ID="ContactButton" runat="server" Text="Contact Us" Width="150px" />
            </div>
    </form>
</body>
</html>
