﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ProjM.WebForms.ProjectForms.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container">
        <div class="well col-lg-8 col-lg-offset-2">
           <%-- <fieldset>
                <legend>Project Details</legend>
                <div class="form-group">
                    <label for="ProjectName" class="col-lg-2 control-label">Name</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectNameTb" placeholder="Project Name" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="PrjTypeDdl" class="col-lg-2 control-label">Selects</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="PrjTypeDdl" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label for="PrjCategoryDdl" class="col-lg-2 control-label">Selects</label>
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
                    <asp:Calendar ID="DeadLineCalendar" runat="server"></asp:Calendar>
                </div>
                <label for="BudgetTb" class="col-lg-2 control-label">Budget</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="BudgetTb" placeholder="0.00$" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <asp:Button ID="CancelBtn" CssClass="btn btn-default" runat="server" Text="Cancel" />
                        <asp:Button ID="EditBtn" CssClass="btn btn-primary" runat="server" Text="Edit" OnClick="CreateBtn_Click" />
                    </div>
                </div>
            </fieldset>--%>

        </div>
    </div>

</asp:Content>