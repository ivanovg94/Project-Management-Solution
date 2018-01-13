<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="ProjM.WebForms.ProjectForms.All" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>All Projects</h3>
    <div class="container">
        <div class="col-lg-12">
            <div class="form-group">
                <label class="col-lg-2 col-lg-offset-1 control-label">Search By</label>
                <div class="col-lg-9">
                    <div class="form-group">
                        <div class="col-lg-3">
                            <asp:DropDownList ID="SearchByDdl" runat="server" CssClass="form-control">
                                <asp:ListItem Value="1">Name</asp:ListItem>
                                <asp:ListItem Value="2">Start Date</asp:ListItem>
                                <asp:ListItem Value="3">DeadLine</asp:ListItem>
                                <asp:ListItem Value="4">Budget</asp:ListItem>
                                <asp:ListItem Value="5">Status</asp:ListItem>
                                <asp:ListItem Value="6">Team</asp:ListItem>
                                <asp:ListItem Value="7">TeamStatus</asp:ListItem>
                                <asp:ListItem Value="8">Category</asp:ListItem>
                                <asp:ListItem Value="9">Type</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox ID="SearchKeyWord" runat="server" PlaceHolder="Key word" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3 col-lg-offset-1">
                            <asp:Button ID="SearchBtn" runat="server" CssClass="btn btn-success" OnClick="SearchBtn_Click" Text="Search" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12">
            <div class="form-group">
                <label class="col-lg-2 col-lg-offset-1 control-label">Order By</label>
                <div class="col-lg-9">
                    <div class="form-group">
                        <div class="col-lg-3">
                            <asp:DropDownList ID="OrderByDdl" runat="server" CssClass="form-control">
                                <asp:ListItem Value="1">Name</asp:ListItem>
                                <asp:ListItem Value="2">Start Date</asp:ListItem>
                                <asp:ListItem Value="3">DeadLine</asp:ListItem>
                                <asp:ListItem Value="4">Budget</asp:ListItem>
                                <asp:ListItem Value="5">Status</asp:ListItem>
                                <asp:ListItem Value="6">Team</asp:ListItem>
                                <asp:ListItem Value="7">TeamStatus</asp:ListItem>
                                <asp:ListItem Value="8">Category</asp:ListItem>
                                <asp:ListItem Value="9">Type</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="DirectionDdl" CssClass="form-control" runat="server">
                                <asp:ListItem Value="1">Ascending</asp:ListItem>
                                <asp:ListItem Value="2">Descending</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-4 col-lg-offset-1">
                            <asp:Button ID="SortBtn" CssClass="btn btn-success" runat="server" OnClick="SortBtn_Click" Text="Sort" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="col-lg-10 col-lg-offset-1">
            <asp:GridView ID="ProjectsGridView"
                DataKeyNames="Id"
                OnRowCommand="Grid_RowCommand"
                ItemType="ProjM.ViewModels.ProjectVM"
                runat="server"
                AllowPaging="true"
                PageSize="6"
                SelectMethod="ProjectsGridView_GetData"
                CssClass="table table-striped table-bordered table-condensedr table-hover"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />
                    <asp:BoundField DataField="StatusId" HeaderText="StatusId" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />
                    <asp:BoundField DataField="TeamStatusId" HeaderText="TeamStatusId" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="StartDateFormated" HeaderText="Start Date" ItemStyle-HorizontalAlign="center"  />
                    <asp:BoundField DataField="DeadLine" HeaderText="DeadLine" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Budget" HeaderText="Budget" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Team" HeaderText="Team" ItemStyle-HorizontalAlign="center"  />
                    <asp:BoundField DataField="TeamStatus" HeaderText="TeamStatus" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Category" HeaderText="Category" ItemStyle-HorizontalAlign="center"  />
                    <asp:BoundField DataField="Type" HeaderText="Type" ItemStyle-HorizontalAlign="center" />
                    <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="center" >
                        <ItemTemplate>
                            <asp:Button ID="btnDetails" css="btn btn-default" runat="server" Text="Details" CommandName="Details"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
