<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Input.aspx.cs" Inherits="Flights_Service.Input" MasterPageFile="~/Flights.Master" %>
<%@ Register TagPrefix="custom" TagName="AirportControl" Src="~/AirportControl.ascx" %>
<%@ Register TagPrefix="custom" TagName="MemberControl" Src="~/MemberControl.ascx" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server" >
<asp:LinkButton ID="LinkButton1" Text="Назад" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="false" />
    <div runat="server" id="DivSuccess" visible="false">
        <p style="color: Blue">
            Операцията завърши успешно!
        </p>
    </div>
<div runat="server" id="DivForm">
        <fieldset>
        <legend>Полет</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="FlightIDLabel" runat="server" AssociatedControlID="FlightID">ID на полета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="FlightID" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="FlightID"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                    <asp:CustomValidator 
                        ID="CustomValidatorFlightID" 
                        ControlToValidate="FlightID"
                        Display="Dynamic" 
                        ForeColor="Red" 
                        OnServerValidate="ValidateFlightID" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="FlightDateLabel" runat="server" AssociatedControlID="Date">Дата на полета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Date" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="Date"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="FlightNumberLabel" runat="server" AssociatedControlID="FlightNumber">Номер на полета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="FlightNumber" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="FlightNumber"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="DepTimeLabel" runat="server" AssociatedControlID="DepTime">Час на излитане: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="DepTime" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator4" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="DepTime"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ArrvTimeLabel" runat="server" AssociatedControlID="ArrvTime">Час на кацане: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="ArrvTime" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator5" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="ArrvTime"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="StatusLabel" runat="server" AssociatedControlID="Status">Статус: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Status" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="GroundOpLabel" runat="server" AssociatedControlID="GroundOp">Наземен оператор: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="GroundOp" />
                </td>
            </tr>
        </table>
        </fieldset>
        <fieldset>
            <legend>Авиолиния</legend>
            <table>
            <tr>
                <td>
                    <asp:Label ID="AirlineIDLabel" runat="server" AssociatedControlID="AirlineID">ID на авиолинията: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="AirlineID" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator8" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="AirlineID"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                    <asp:CustomValidator 
                        ID="AirlineIDCV" 
                        ControlToValidate="AirlineID"
                        Display="Dynamic" 
                        ForeColor="Red" 
                        OnServerValidate="ValidateAirlineID" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="AirlineNameLabel" runat="server" AssociatedControlID="AirlineName">Име на авиолинията: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="AirlineName" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator9" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="AirlineName"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="AirlineCountryLabel" runat="server" AssociatedControlID="AirlineCountry">Държава: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="AirlineCountry" />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="AirlinePhoneLabel" runat="server" AssociatedControlID="AirlinePhone">Телефон: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="AirlinePhone" />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="AirlineWebsiteLabel" runat="server" AssociatedControlID="AirlineWebsite">Уебсайт: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="AirlineWebsite" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="OnlineCheckINLabel" runat="server" AssociatedControlID="OnlineCheckIN">Онлайн чек-ин</asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="OnlineCheckIN" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="HotelBookingLabel" runat="server" AssociatedControlID="HotelBooking">Резервация на хотел</asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="HotelBooking" runat="server" />
                </td>
            </tr> 
            <tr>
                <td>
                    <asp:Label ID="CarRentalLabel" runat="server" AssociatedControlID="CarRental">Наем на автомобил</asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="CarRental" runat="server" />
                </td>
            </tr> 
            </table>
        </fieldset>
        <fieldset>
            <legend>Самолет</legend>
            <table>
            <tr>
                <td>
                    <asp:Label ID="AircraftIDLabel" runat="server" AssociatedControlID="AircraftID">ID на самолета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="AircraftID" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator13" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="AircraftID"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                    <asp:CustomValidator 
                        ID="CustomValidator1" 
                        ControlToValidate="AircraftID"
                        Display="Dynamic" 
                        ForeColor="Red" 
                        OnServerValidate="ValidateAircraftID" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="DescriptionLabel" runat="server" AssociatedControlID="Description">Описание: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Description" rows="5" TextMode="multiline" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="FirstDateLabel" runat="server" AssociatedControlID="FirstDate">Първи полет: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="FirstDate" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LengthLabel" runat="server" AssociatedControlID="Length">Дължина на самолета:</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Length" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="HeightLabel" runat="server" AssociatedControlID="Height">Височина на самолета:</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Height" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="WingspanLabel" runat="server" AssociatedControlID="Wingspan">Размах на крилата:</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Wingspan" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="DiameterLabel" runat="server" AssociatedControlID="Diameter">Диаметър на корпуса:</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Diameter" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="SpeedLabel" runat="server" AssociatedControlID="Speed">Скорост:</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Speed" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ManufacturerLabel" runat="server" AssociatedControlID="Manufacturer">Производител: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Manufacturer" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="TypeLabel" runat="server" AssociatedControlID="Type">Тип на самолета: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Type" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator17" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="Type"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="CpacityLabel" runat="server" AssociatedControlID="Capacity">Капацитет: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Capacity" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator18" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="Capacity"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                    <asp:CustomValidator 
                        ID="CustomValidator7" 
                        ControlToValidate="Capacity"
                        onservervalidate="ValidateCapacity" 
                        ForeColor="Red" 
                        ErrorMessage="Невалидни данни"
                        runat="server" />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="EnginesLabel" runat="server" AssociatedControlID="Engines">Брой двигатели: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Engines" />
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator19" 
                        ErrorMessage="* Задължително поле" 
                        ControlToValidate="Engines"
                        ForeColor="Red" 
                        Display="Dynamic" 
                        runat="server" />
                    <asp:CustomValidator 
                        ID="CustomValidator8" 
                        ControlToValidate="Engines"
                        onservervalidate="ValidateEngines" 
                        ForeColor="Red" 
                        ErrorMessage="Невалидни данни"
                        runat="server" />
                </td>
            </tr>
            </table>
        </fieldset>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <fieldset>
            <legend>Летище</legend>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="width: 230px">
                <ContentTemplate>
                    <asp:PlaceHolder runat="server" ID="AirportPlaceHolder"></asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddAirport" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnAddAirport" runat="server" Text="Добави летище" OnClick="btnAddAirport_Click"
                CausesValidation="false" />
        </fieldset>
        <fieldset>
            <legend>Пилот/Стюард</legend>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="width: 230px">
                <ContentTemplate>
                    <asp:PlaceHolder runat="server" ID="MemberPlaceHolder"></asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddMember" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnAddMember" runat="server" Text="Добави още екипаж" OnClick="btnAddMember_Click"
                CausesValidation="false" />
        </fieldset>
        <div style="text-align: right">
        </div>
        <asp:Button ID="BtnSubmit" Text="Запиши полета" runat="server" OnClick="BtnSubmit_Click" />
        <p>Изпращането на формата ще създаде XML файл и ще вмъкне информацията в БД.</p>
    </div>
</asp:Content>