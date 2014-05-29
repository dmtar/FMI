<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Flights_Service.Default" MasterPageFile="~/Flights.Master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <title>ASP.NET Примерен проект</title>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    <div>
        <ol>
            <li>
                <asp:Button runat="server" ID="xmlT" Text="Прехвърли XML файловете в БД" PostBackUrl="Process.aspx" /></li>
            <li>
                <asp:HyperLink ID="InputData" NavigateUrl="Input.aspx" runat="server" Text="Въвеждане на данни" /></li>   
        </ol>
    </div>
</asp:Content>