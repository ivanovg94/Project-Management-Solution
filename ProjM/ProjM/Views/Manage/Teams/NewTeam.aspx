<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewTeam.aspx.cs" Inherits="ProjM.Views.Teams.NewTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="well col-lg-8 col-lg-offset-2">
            <fieldset>
                <legend>New Team</legend>
                <div class="form-group">
                    <label class="col-lg-4 control-label">Team Name</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TeamNameTb" placeholder="Team Name" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-lg-4 control-label">Required Front-end developers</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="FrontEndTb" CssClass="form-control" placeholder="Number of Developers needed" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-lg-4 control-label">Required Back-end developers</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="BackEndTb" CssClass="form-control" placeholder="Number of Developers needed" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-lg-4 control-label">Required QA specialists</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="QATb" CssClass="form-control" placeholder="Number of QA specialists needed" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-lg-4 col-lg-offset-8">
                        <asp:Button ID="CancelBtn" CssClass="btn btn-default" runat="server" Text="Cancel" OnClick="CancelBtn_Click" />
                        <asp:Button ID="ContinueBtn" CssClass="btn btn-primary" runat="server" Text="Continue" OnClick="ContinueBtn_Click" />
                    </div>
                </div>

            </fieldset>

        </div>
    </div>



</asp:Content>
