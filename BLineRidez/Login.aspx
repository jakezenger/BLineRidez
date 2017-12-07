<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BLineRidez.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Login</h1>
    </div>
    <div class="row">
        <div class="col-md-4" align="right">
            <p>
                Username: 
                <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Password: 
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
            </p>
        </div>
    </div>
</asp:Content>
