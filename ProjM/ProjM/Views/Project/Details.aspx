<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ProjM.WebForms.ProjectForms.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="well col-lg-6 col-lg-offset-3">
            <fieldset>
                <legend>Project Details</legend>
                <div class="form-group">
                    <label for="ProjectName" class="col-lg-2 control-label">Name</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectNameTb" Enabled="false" placeholder="Project Name" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="PrjTypeDdl" class="col-lg-2 control-label">Type</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="PrjTypeDdl" Enabled="false" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label for="PrjCategoryDdl" class="col-lg-2 control-label">Category</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="PrjCategoryDdl" Enabled="false" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label for="DescTextArea" class="col-lg-2 control-label">Description</label>
                    <div class="col-lg-10">
                        <textarea id="DescTextArea" runat="server" disabled="true" cols="20" class="form-control" rows="3"></textarea>
                    </div>
                </div>


                <div class="form-group">
                    <label class="col-lg-2 control-label">Status</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="StatusDdl" Enabled="false" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>


                <div class="form-group">
                    <label for="Deadline" class="col-lg-2 control-label">Deadline</label>
                    <asp:Calendar ID="DeadLineCalendar" Enabled="false" runat="server"></asp:Calendar>
                </div>
                <label for="BudgetTb" class="col-lg-2 control-label">Budget</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="BudgetTb" Enabled="false" placeholder="0.00$" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <asp:Button ID="CancelBtn" CssClass="btn btn-default pull-right" runat="server" Text="Cancel" />
                        <asp:Button ID="EditBtn" CssClass="btn btn-default pull-right" runat="server" Text="Edit" />
                        <asp:Button ID="TeamBtn" CssClass="btn btn-primary pull-left" runat="server" Text="Team" OnClick="TeamBtn_Click" style="height: 47px" />

                    </div>
                </div>

                <asp:Label ID="CurrentProjectIdLabel" runat="server" Text="Label"></asp:Label>
            </fieldset>

        </div>
    </div>

</asp:Content>
