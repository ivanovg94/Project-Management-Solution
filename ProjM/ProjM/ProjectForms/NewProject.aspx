<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="ProjM.ProjectForms.NewProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="well col-lg-6">
            <fieldset>
                <legend>New Project</legend>
                <div class="form-group">
                    <label for="ProjectName" class="col-lg-2 control-label">Name</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectNameTb" placeholder="Project Name" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="DescTextArea" class="col-lg-2 control-label">Description</label>
                    <div class="col-lg-10">
                        <textarea id="DescTextArea" cols="20" rows="3"></textarea>
                    </div>
                </div>

                <div class="form-group">
                    <label for="Deadline" class="col-lg-2 control-label">Deadline</label>
                    <asp:Calendar ID="DeadLineCalendar" runat="server"></asp:Calendar>
                </div>
                 <label for="BudgetTb" class="col-lg-2 control-label">Budget</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="BudgetTb" placeholder="0.00$" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <button type="reset" class="btn btn-default">Cancel</button>
                        <button type="submit" class="btn btn-primary">Submit</button>
                    </div>
                </div>
            </fieldset>

        </div>
    </div>

</asp:Content>
