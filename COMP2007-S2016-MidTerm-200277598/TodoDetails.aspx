﻿<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200277598.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Todo Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="TodoNameTextBox">Todo Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" id="TodoNameTextBox" placeholder="Todo Name" required="true" MaxLength="50"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TodoNotesTextBox">Todo Notes</label>
                    <asp:TextBox runat="server" CssClass="form-control" id="TodoNotesTextBox" placeholder="Todo Notes" required="true" MaxLength="50"></asp:TextBox>
                </div>

                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning btn-lg" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary btn-lg" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>