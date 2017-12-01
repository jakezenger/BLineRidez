<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BLineRidez.SignupForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class =" jumbotron">
        <h1>Create New Account</h1>
        <p>
            This is where accounts are created
        </p>
    </div>

    <div class="row">
        <div class="col-md-4" align="right">
            <h2>Customer Account</h2>
            <p>Username:
                <asp:TextBox ID="CustomerUsernameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Password:
                <asp:TextBox ID="CustomerPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>First Name:
                <asp:TextBox ID="CustomerFirstNameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Last Name:
                <asp:TextBox ID="CustomerLastNameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Email:
                <asp:TextBox ID="CustomerEmailTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Phone:
                <asp:TextBox ID="CustomerPhoneTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="CustomerSubmitButton" runat="server" Text="Submit" OnClick="CustomerSubmitButton_Click" />
            </p>
        </div>
        <div class="col-md-4" align="right">
            <h2>Driver Account</h2>
            <p>Username:
                <asp:TextBox ID="DriverUsernameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Password:
                <asp:TextBox ID="DriverPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>First Name:
                <asp:TextBox ID="DriverFirstNameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Last Name:
                <asp:TextBox ID="DriverLastNameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Email:
                <asp:TextBox ID="DriverEmailTextBox" runat="server"></asp:TextBox>
            </p>
            <p>Phone:
                <asp:TextBox ID="DriverPhoneTextBox" runat="server"></asp:TextBox>
            </p>
            <p>

                <h3>Car Details</h3>
            </p>
            <p>
                Make:
                 <asp:TextBox ID="CarMakeTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Model:
                 <asp:TextBox ID="CarModelTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Color: 
                 <asp:TextBox ID="CarColorTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Year:
                 <asp:TextBox ID="CarYearTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="DriverSubmitButton" runat="server" Text="Submit" OnClick="DriverSubmitButton_Click" />
            </p>
        </div>
    </div>

</asp:Content>
