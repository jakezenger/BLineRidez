<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerPayment.aspx.cs" Inherits="BLineRidez.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Payment</h1>
    </div>
    <div>
        <asp:TextBox ID="RequestDetailsTextBox" runat="server" BorderStyle="None" Height="140px" ReadOnly="True" TextMode="MultiLine" Width="375px" Wrap="False"></asp:TextBox>
    </div>
    <div align="right" style="width: 304px; margin-left: 5px">        
        <h3>Card Information</h3>
        <p>
            First Name: 
            <asp:TextBox ID="BillingFirstNameTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Last Name: 
            <asp:TextBox ID="BillingLastNameTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Card Number: 
            <asp:TextBox ID="BillingCardNumTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Security Code: 
            <asp:TextBox ID="BillingSecCodeTextBox" runat="server"></asp:TextBox>
        </p>
        <br>
        <h5>Billing Address</h5>
        <p>
            Line 1: 
            <asp:TextBox ID="BillingLine1TextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Line 2: 
            <asp:TextBox ID="BillingLine2TextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            City: 
            <asp:TextBox ID="BillingCityTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            State: 
            <asp:TextBox ID="BillingStateTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Zip Code: 
            <asp:TextBox ID="BillingZipTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </p>
    </div>
</asp:Content>
