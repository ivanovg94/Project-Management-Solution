<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjM._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>PMs</h1>
        <p class="lead">
           project management web-based solution - where project managers and developers meet!
            <a href="/About.aspx" class="btn btn-primary btn-default pull-right">Learn more &raquo;</a>
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h3>Getting started</h3>
            <p>
                Register and fill in details.
            </p>
            <p>
                <img src="Images/manageAcc.png" width="400" height="185" alt="not found" />
            </p>
        </div>
        <div class="col-md-4">
            <h3>Get selected</h3>
            <p>
                And participate in a full-scale project with your team members!
            </p>
            <p>
                <img src="Images/get selected.png" width="405" height="200" alt="not found" />

            </p>
        </div>
        <div class="col-md-4">
            <h3>Rank up the ladder </h3>
            <p>
                And be the top choice for the next big project.
            </p>
            <p>
                <img src="Images/Rank Up.png" width="370" height="220" alt="not found" />
            </p>
        </div>
    </div>

</asp:Content>
