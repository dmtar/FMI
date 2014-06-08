<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AirportControl.ascx.cs" Inherits="Flights_Service.AirportControl" %>
<table style="width:500px">
    <tr>
        <td>
            <asp:Label ID="AirportIDLabel" Text="ID на летището: *" runat="server" AssociatedControlID="AirportID" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportID" MaxLength="10" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="* Задължително поле" ControlToValidate="AirportID"
                Display="Dynamic" ForeColor="Red" runat="server" />
            <asp:CustomValidator 
                        ID="CustomValidator2" 
                        ControlToValidate="AirportID"
                        Display="Dynamic" 
                        ForeColor="Red" 
                        OnServerValidate="ValidateAirportInfoID" 
                        runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="CodeLabel" Text="Код на летището: *" runat="server" AssociatedControlID="AirportCode" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportCode" MaxLength="10" />
            <asp:RequiredFieldValidator ID="CodeRFV" ErrorMessage="* Задължително поле" ControlToValidate="AirportCode"
                Display="Dynamic" ForeColor="Red" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AirportPhoneLabel" Text="Телефон: " runat="server" AssociatedControlID="AirportPhoneInput" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportPhoneInput" MaxLength="100" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AirportPhoneTypeLabel" Text="Тип на телефона:" runat="server" AssociatedControlID="AirportPhoneType" />
        </td>
        <td>
           <asp:DropDownList ID="AirportPhoneType" runat="server">
           <asp:ListItem
                Enabled="True"
                Selected="True"
            />
           <asp:ListItem
                Enabled="True"
                Selected="False"
                Text="стационарен"
                Value="стационарен"
            />
            <asp:ListItem
                Enabled="True"
                Selected="False"
                Text="мобилен"
                Value="мобилен"
            />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="* Задължително поле" ControlToValidate="AirportPhoneType"
                Display="Dynamic" ForeColor="Red" runat="server" />
        </td>
    </tr>
            <tr>
                <td>
                    <asp:Label ID="PhoneFaxLabel" runat="server" AssociatedControlID="AirportPhoneFax">Факс:</asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="AirportPhoneFax" runat="server" />
                </td>
            </tr>
     <tr>
        <td>
            <asp:Label ID="CityLabe" Text="Град: " runat="server" AssociatedControlID="AirportCity" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportCity" MaxLength="100" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AirportStreetLabel" Text="Улица: " runat="server" AssociatedControlID="AirportStreet" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportStreet" MaxLength="100" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AirportPostalcodeLabel" Text="Пощ. код: " runat="server" AssociatedControlID="AirportPostalcode" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportPostalcode" MaxLength="100" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AirportWebsiteLabel" Text="Уебсайт: " runat="server" AssociatedControlID="AirportWebsiteInput" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="AirportWebsiteInput" MaxLength="100" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AirportDropDownLabel" Text="Изберете: *" runat="server" AssociatedControlID="AirportDropDown" />
        </td>
        <td>
           <asp:DropDownList ID="AirportDropDown" runat="server">
           <asp:ListItem
                Enabled="True"
                Selected="True"
            />
           <asp:ListItem
                Enabled="True"
                Selected="False"
                Text="кацане"
                Value="кацане"
            />
            <asp:ListItem
                Enabled="True"
                Selected="False"
                Text="излитане"
                Value="излитане"
            />
            <asp:ListItem
                Enabled="True"
                Selected="False"
                Text="прекачване"
                Value="прекачване"
            />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="AirportDropDownRFV" ErrorMessage="* Задължително поле" ControlToValidate="AirportDropDown"
                Display="Dynamic" ForeColor="Red" runat="server" />
        </td>
    </tr>
</table>