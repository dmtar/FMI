<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Input.aspx.cs" Inherits="Flights_Service.Input" MasterPageFile="~/Flights.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server" >
<asp:LinkButton ID="LinkButton1" Text="Назад" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="false" />
<div runat="server" id="DivForm">
        <table>
            <colgroup>
                <col width="208px" />
                <col />
            </colgroup>
            <tr>
                <td>
                    <asp:Label ID="FlighID" runat="server" AssociatedControlID="FlightID">ID на полета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="FlightID" />
                </td>
            </tr>
        </table>
        <fieldset>
            <legend>Авиолиния</legend>
            <table>
            </table>
        </fieldset>
        <fieldset>
            <legend>Самолет</legend>
            <table>
                
            </table>
        </fieldset>
        <fieldset>
            <legend>Летище</legend>
        </fieldset>
        <fieldset>
            <legend>Пилот/Стюард</legend>
        </fieldset>
        <div style="text-align: right">
        </div>
        <p>
            Изпращането на формата ще създаде XML файл и ще вмъкне информацията в БД.</p>
    </div>
</div>
</asp:Content>