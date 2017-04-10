<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="ProjM.WebForms.ProjectForms.All" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <div class="col-lg-10 col-lg-offset-1">
            <asp:GridView ID="ProjectsGridView" OnRowCommand="Grid_RowCommand" runat="server" Width="529px" CssClass="table table-striped table-bordered table-condensedr table-hover">
                <Columns>
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
