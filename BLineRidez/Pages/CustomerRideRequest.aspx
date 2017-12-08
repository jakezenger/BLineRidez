<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRideRequest.aspx.cs" Inherits="BLineRidez.CustomerRideRequestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Request a Ride</h1>
    </div>
    <div align="center">
        <h3>Please enter your Pickup and Dropoff locations</h3>
    </div>
    <div class="row">
        <div class ="col-md-4" align="right">
            <h4>Pickup</h4>
            <p>
                Line 1: 
                <asp:TextBox ID="PickupLine1TextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Line 2: 
                <asp:TextBox ID="PickupLine2TextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                City: 
                <asp:TextBox ID="PickupCityTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                State: 
                <asp:TextBox ID="PickupStateTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Zip Code: 
                <asp:TextBox ID="PickupZipTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Pickup Time: 
                <asp:TextBox ID="PickupTimeTextBox" runat="server"></asp:TextBox>
            </p>
        </div>
        <div class ="col-md-4" align="right">
            <h4>Dropoff</h4>
            <p>
                Line 1: 
                <asp:TextBox ID="DropoffLine1TextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Line 2: 
                <asp:TextBox ID="DropoffLine2TextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                City: 
                <asp:TextBox ID="DropoffCityTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                State: 
                <asp:TextBox ID="DropoffStateTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                Zip Code: 
                <asp:TextBox ID="DropoffZipTextBox" runat="server"></asp:TextBox>
            </p>
            <p align="left">
                <asp:Button ID="AsapButton" runat="server" Text="ASAP" OnClick="AsapButton_Click" />
            </p>
        </div>
    </div>
    <div align="center">
        <p>
            <asp:Button ID="RequestRideButton" runat="server" Text="Request Ride" OnClick="RequestRideButton_Click" />
        </p>
        <p>
            <asp:Label runat="server" ID="RideRequestStatusLabel" BorderStyle="Solid" Height="25px" Width="280px" ValidateRequestMode="Enabled" />
            <asp:Timer ID="RideStatusTimer" runat="server" Enabled="False" Interval="2000" OnTick="RideStatusTimer_Tick">
            </asp:Timer>
        </p>
    </div>
</asp:Content>
