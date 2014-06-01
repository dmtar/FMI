<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Input.aspx.cs" Inherits="Flights_Service.Input" MasterPageFile="~/Flights.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server" >
<asp:LinkButton ID="LinkButton1" Text="Назад" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="false" />
<div runat="server" id="DivForm">
        <fieldset>
        <legend>Полет</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="FlightIDLabel" runat="server" AssociatedControlID="IDInput">ID на полета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="IDInput" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="IDInput"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                    <asp:CustomValidator 
                        ID="CustomValidatorFlightID" 
                        ControlToValidate="IDInput"
                        Display="Dynamic" 
                        ForeColor="Red" 
                        OnServerValidate="ValidateFlightID" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="FlightDateLabel" runat="server" AssociatedControlID="DateInput">Дата на полета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="DateInput" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="DateInput"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                    <asp:CustomValidator 
                        runat="server"
                        ID="valDateRange" 
                        ControlToValidate="DateInput"
                        onservervalidate="valDateRange_ServerValidate" 
                        ForeColor="Red" 
                        ErrorMessage="Въведете коректна дата" />
                </td>
            </tr>
        </table>
        </fieldset>
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
        <asp:Button ID="BtnSubmit" Text="Запиши полета" runat="server" OnClick="BtnSubmit_Click" />
        <p>Изпращането на формата ще създаде XML файл и ще вмъкне информацията в БД.</p>
    </div>
</asp:Content>