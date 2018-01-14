<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ProjM.WebForms.ProjectForms.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="well col-lg-6 col-lg-offset-3">
            <fieldset>
                <legend>Project Details</legend>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="ProjectName" class="col-lg-2 control-label">Name</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="ProjectNameTb" Enabled="false" placeholder="Project Name" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="PrjTypeDdl" class="col-lg-2 control-label">Type</label>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="PrjTypeDdl" Enabled="false" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="PrjCategoryDdl" class="col-lg-2 control-label">Category</label>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="PrjCategoryDdl" Enabled="false" CssClass="form-control details-page-ddl" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="DescTextArea" class="col-lg-2 control-label">Description</label>
                        <div class="col-lg-10">
                            <textarea id="DescTextArea" runat="server" disabled="true" cols="20" class="form-control details-page-ddl" rows="3"></textarea>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label class="col-lg-2 control-label">Status</label>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="StatusDdl" Enabled="false" runat="server" CssClass="form-control details-page-ddl"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="BudgetTb" class="col-lg-2 control-label">Budget</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="BudgetTb" Enabled="false" placeholder="0.00$" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group" id="ParticipantsDiv" visible="false" runat="server">
                        <label for="ParticipantsTb" class="col-lg-2 control-label">Participants</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="ParticipantsTb" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="StartDateTb" class="col-lg-2 control-label">Start Date</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="StartDateTb" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="date" class="col-lg-2 control-label">Deadline</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="date" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <asp:Button ID="CancelBtn" CssClass="btn btn-default pull-right" runat="server" Text="Cancel" />
                        <asp:Button ID="EditBtn" CssClass="btn btn-default pull-right" runat="server" Text="Edit" />
                        <asp:Button ID="TeamBtn" CssClass="btn btn-primary pull-left" runat="server" Text="Team" OnClick="TeamBtn_Click" />
                        <asp:Button ID="BackBtn" Visible="false" CssClass="btn btn-primary pull-left" runat="server" Text="Back" OnClick="BackBtn_Click" Style="height: 47px" />

                    </div>
                </div>
            </fieldset>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(".datePicker").eq(0).datepicker({
                dateFormat: 'dd.mm.yy'
            });
        });
    </script>
</asp:Content>
