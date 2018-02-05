<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="ProjM.ProjectForms.NewProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="well col-lg-8 col-lg-offset-2">
            <fieldset>
                <legend>New Project</legend>
                <div class="form-group">
                    <label for="ProjectName" class="col-lg-2 control-label">Name</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectNameTb" placeholder="Project Name" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="PrjTypeDdl" class="col-lg-2 control-label">Type</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="PrjTypeDdl" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label for="PrjCategoryDdl" class="col-lg-2 control-label">Category</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="PrjCategoryDdl" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label for="DescTextArea" class="col-lg-2 control-label">Description</label>
                    <div class="col-lg-10">
                        <textarea id="DescTextArea" runat="server" cols="20" class="form-control" rows="3"></textarea>
                    </div>
                </div>

                <div class="form-group">
                    <label for="Deadline" class="col-lg-2 control-label">Deadline</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="date" CssClass="datePicker form-control" runat="server"></asp:TextBox>
                      </div>
                </div>
                <label for="BudgetTb" class="col-lg-2 control-label">Budget</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="BudgetTb" placeholder="0.00$" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <div class="col-lg-5 col-lg-offset-7">
                        <asp:Button ID="CancelBtn" CssClass="btn btn-default" runat="server" Text="Cancel" OnClick="CancelBtn_Click" />
                        <asp:Button ID="CreateBtn" CssClass="btn btn-primary" runat="server" Text="Create" OnClick="CreateBtn_Click" />
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
