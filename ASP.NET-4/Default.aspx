<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET_4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <asp:DropDownList ID="dropDownAutoList" runat="server">
            <asp:ListItem Value="null">Seleziona un'auto</asp:ListItem>
        </asp:DropDownList>

         <asp:Button ID="GetDetailCar" class="btn btn-primary " runat="server" Text="Dettagli"  OnClick="GetDetailCar_Click" />
        <div id="divDettaglio"  runat="server">
            <p id="selectedModel" class="fs-2 mb-0" runat="server"></p>
            <p id="selectedBasePrice" runat="server"></p>
             <p id="selectedTotalPrice" runat="server"></p>
            <span>Garanzia: </span>
            <asp:DropDownList ID="garanzia" runat="server">
                <asp:ListItem Value="2">2 anni</asp:ListItem>
                <asp:ListItem Value="3">3 anni</asp:ListItem>
                <asp:ListItem Value="4">4 anni</asp:ListItem>
             <asp:ListItem Value="5">5 anni</asp:ListItem>
         </asp:DropDownList>

             <div class="d-flex flex-column">

                 <div>
                     <span>CerchionInLega </span>
                     <asp:CheckBox ID="CerchionInLega" runat="server" />
                 </div>
                 <div>
                     <span>VerniceCromata </span>
                     <asp:CheckBox ID="VerniceCromata" runat="server" />
                 </div>

                 <div>
                     <span>Climatizzatore </span>
                     <asp:CheckBox ID="climatizzatore" runat="server" />
                 </div>
                 <div>
                     <span>DoppioAirbag </span>
                     <asp:CheckBox ID="DoppioAirbag" runat="server" />
                 </div>
                 <div>
                     <span>ABS</span>
                     <asp:CheckBox ID="ABS" runat="server" />
                 </div>
                 <div>
                     <img src="" id="selectedImg" cssClass="" runat="server"  />
                 </div>
                 
                 
             </div>
         </div>

    </main>

</asp:Content>
