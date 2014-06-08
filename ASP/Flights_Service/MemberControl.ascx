<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberControl.ascx.cs" Inherits="Flights_Service.MemberControl" %>
<table style="width:500px">
    <tr>
        <td>
            <asp:Label ID="MemberIDLabel" Text="ID: *" runat="server" AssociatedControlID="MemberID" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="MemberID" MaxLength="10" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="* Задължително поле" ControlToValidate="MemberID"
                Display="Dynamic" ForeColor="Red" runat="server" />
             <asp:CustomValidator 
                        ID="CustomValidator1" 
                        ControlToValidate="MemberID"
                        Display="Dynamic" 
                        ForeColor="Red" 
                        OnServerValidate="ValidateMemberID" 
                        runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="MemberNameLabel" Text="Име: *" runat="server" AssociatedControlID="MemberNameInput" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="MemberNameInput" />
            <asp:RequiredFieldValidator ID="MemberNameRFV" ErrorMessage="* Задължително поле" ControlToValidate="MemberNameInput"
                Display="Dynamic" ForeColor="Red" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="MemberPositionLabel" Text="Позиция: *" runat="server" AssociatedControlID="MemberPosition" />
        </td>
        <td>
           <asp:DropDownList ID="MemberPosition" runat="server">
           <asp:ListItem
                Enabled="True"
                Selected="True"
            />
           <asp:ListItem
                Enabled="True"
                Selected="False"
                Text="пилот"
                Value="пилот"
            />
            <asp:ListItem
                Enabled="True"
                Selected="False"
                Text="стюард"
                Value="стюард"
            />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="MemberPositionRFV" ErrorMessage="* Задължително поле" ControlToValidate="MemberPosition"
                Display="Dynamic" ForeColor="Red" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="MemberCountryLabel" Text="Държава: " runat="server" AssociatedControlID="MemberCountry" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="MemberCountry" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="MemberAgeLabel" Text="Години: " runat="server" AssociatedControlID="MemberAge" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="MemberAge" />
        </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="MemberYearsLabel" Text="Години стаж: " runat="server" AssociatedControlID="MemberYears" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="MemberYears"/>
        </td>
    </tr>
</table>
