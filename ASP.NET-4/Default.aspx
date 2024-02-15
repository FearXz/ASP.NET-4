<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET_4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <asp:DropDownList ID="dropDownAutoList" runat="server">
            <asp:ListItem Value="null">Seleziona un'auto</asp:ListItem>
        </asp:DropDownList>

    </main>

</asp:Content>
