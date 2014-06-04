<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AirportControl.ascx.cs" Inherits="Flights_Service.AirportControl" %>
<table style="width:500px">
    <tr>
        <td>
            <asp:Label ID="CodeLabel" Text="Код на летището: *" runat="server" AssociatedControlID="CodeInput" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="CodeInput" MaxLength="10" />
            <asp:RequiredFieldValidator ID="CodeRFV" ErrorMessage="* Задължително поле" ControlToValidate="CodeInput"
                Display="Dynamic" ForeColor="Red" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AirportPhoneLabel" Text="Заглавие: *" runat="server" AssociatedControlID="AirportPhoneInput" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportPhoneInput" MaxLength="100" />
            <asp:RequiredFieldValidator ID="AirportPhoneRFV" ErrorMessage="* Задължително поле" ControlToValidate="AirportPhoneInput"
                Display="Dynamic" ForeColor="Red" runat="server" />
        </td>
    </tr>
</table>