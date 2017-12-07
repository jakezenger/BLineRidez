<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DriverPickup.aspx.cs" Inherits="BLineRidez.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Request Fullfillment</h1>
    </div>
    <div id="pickupButtonDiv">
        <asp:Button ID="PickupButton" runat="server" Text="Pickup" OnClick="PickupButton_Click" />
    </div>
    <br />
    <br />
    <div id="dropoffButtonDiv">
        <p>
            &nbsp;<asp:Label ID="RideFareLabel" runat="server" Text="Ride Fare: " Visible="False"></asp:Label>
            <asp:TextBox ID="RideFareTextBox" runat="server" Visible="False"></asp:TextBox>
        </p>
        <asp:Button ID="DropoffButton" runat="server" Text="Dropoff" Visible="False" OnClick="DropoffButton_Click" />
    </div>
</asp:Content>
