<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DriverRideRequest.aspx.cs" Inherits="BLineRidez.DriverRideRequestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Ride Requests</h1>
    </div>
    <asp:Table ID="RideRequestTable" runat="server" GridLines="Both"></asp:Table>
    <div align="right">
        <p>
            Request ID: 
            <asp:TextBox ID="RequestIdTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Estimated time until pickup (minutes): 
            <asp:TextBox ID="EtaTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </p>
    </div>
</asp:Content>
