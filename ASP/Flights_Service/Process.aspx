<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Flights.Master" CodeBehind="Process.aspx.cs" Inherits="Flights_Service.Process" %>

<asp:Content runat="server" ContentPlaceHolderID="head">

    <title>Обработка на XML файлове</title>
    <style type="text/css">
        .success
        {
            color: Blue;
        }
        .fail
        {
            color: Red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="body">
    <div>
        <asp:LinkButton ID="LinkButton1" Text="Назад" runat="server" PostBackUrl="~/Default.aspx" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="up1">
            <ContentTemplate>
                <asp:Panel ID="PanelResults" runat="server">
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="up2">
            <ContentTemplate>
             <asp:Label ID="TruncateLabel" runat="server"></asp:Label>
             <br />
            <asp:Button ID="Button1" Text="Изпразни БД" runat="server" OnClick="TruncateDB" />
     </ContentTemplate>
     </asp:UpdatePanel> 
    </div>
</asp:Content>