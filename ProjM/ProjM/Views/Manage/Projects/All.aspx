<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="ProjM.WebForms.ProjectForms.All" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <div class="col-lg-10 col-lg-offset-1">
            <asp:GridView ID="ProjectsGridView"
                DataKeyNames="Id"
                OnRowCommand="Grid_RowCommand"
                ItemType="ProjM.ViewModels.ProjectVM"
                runat="server"
                AllowPaging="true"
                PageSize="4"
                SelectMethod="ProjectsGridView_GetData"
                CssClass="table table-striped table-bordered table-condensedr table-hover"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId"/>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                    <asp:BoundField DataField="DeadLine" HeaderText="DeadLine" />
                    <asp:BoundField DataField="Budget" HeaderText="Budget" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Team" HeaderText="Team" />
                    <asp:BoundField DataField="TeamStatus" HeaderText="TeamStatus" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Type" HeaderText="Type" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnDetails" runat="server" Text="Details" CommandName="Details"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
