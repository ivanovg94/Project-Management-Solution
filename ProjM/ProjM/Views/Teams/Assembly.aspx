<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assembly.aspx.cs" Inherits="ProjM.WebForms.Team.Assembly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="col-lg-6">
        <div class="panel panel-success">

            <div class="panel-heading">Project details</div>
            <div class="panel-body">

                <div class="pull-left">
                    <div class="col=lg-3">
                        <div class="col=lg-3">
                            <asp:Label ID="ProjectNamelL" CssClass="control-label" runat="server" Text="Name:" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="ProjectTypeL" CssClass="control-label" runat="server" Text="Type:" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="ProjectCategoryL" CssClass="control-label" runat="server" Text="Category:" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="BudgetL" CssClass="control-label" runat="server" Text="Budget:" Font-Bold="True"></asp:Label>
                        </div>

                    </div>
                </div>

                <div class="pull-right">
                    <div class="col=lg-3">
                        <asp:Label ID="ProjectNameLValue" CssClass="control-label" runat="server" Text="1" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="ProjectTypeLValue" CssClass="control-label" runat="server" Text="2" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="ProjectCategoryLValue" CssClass="control-label" runat="server" Text="3" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="BudgetLValue" CssClass="control-label" runat="server" Text="4" Font-Bold="True"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <asp:GridView ID="AllDevsGv" OnRowCommand="AllDevsGv_RowCommand" OnRowDataBound="AllDevsGv_RowDataBound" runat="server" CssClass="table table-striped table-bordered table-condensedr table-hover">
            <Columns>
                <asp:ButtonField ButtonType="Button" HeaderText="Add" Text="Add" CommandName="Add" />
            </Columns>
        </asp:GridView>


    </div>
    <div class="col-lg-6">
        <div class="panel panel-default">
            <div class="panel-heading">Team details</div>
            <div class="panel-body">

                <div class="pull-left">
                    <div class="col=lg-3">
                        <div class="col=lg-3">
                            <asp:Label ID="TotalL" CssClass="control-label" runat="server" Text="Total number of Developers needed:" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="FrontEndL" CssClass="control-label" runat="server" Text="Front-end:" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="BackEndL" CssClass="control-label" runat="server" Text="Back-end:" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="QAL" CssClass="control-label" runat="server" Text="QA:" Font-Bold="True"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="pull-right">
                    <div class="col=lg-3">
                        <asp:Label ID="CurrentTotalLValue" CssClass="control-label" runat="server" Text="0" Font-Bold="True"></asp:Label>
                        <asp:Label ID="slash1" CssClass="control-label" runat="server" Text="/" Font-Bold="True"></asp:Label>
                        <asp:Label ID="TotalLValue" CssClass="control-label" runat="server" Text="1" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="CurrentFrontEndLValue" CssClass="control-label" runat="server" Text="0" Font-Bold="True"></asp:Label>
                        <asp:Label ID="slash2" CssClass="control-label" runat="server" Text="/" Font-Bold="True"></asp:Label>
                        <asp:Label ID="FrontEndLValue" CssClass="control-label" runat="server" Text="2" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="CurrentBackEndLValue" CssClass="control-label" runat="server" Text="0" Font-Bold="True"></asp:Label>
                        <asp:Label ID="slash3" CssClass="control-label" runat="server" Text="/" Font-Bold="True"></asp:Label>
                        <asp:Label ID="BackEndLValue" CssClass="control-label" runat="server" Text="3" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="CurrentQALValue" CssClass="control-label" runat="server" Text="0" Font-Bold="True"></asp:Label>
                        <asp:Label ID="slash4" CssClass="control-label" runat="server" Text="/" Font-Bold="True"></asp:Label>
                        <asp:Label ID="QALValue" CssClass="control-label" runat="server" Text="4" Font-Bold="True"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <asp:GridView ID="TeamDevsGv" runat="server" OnRowCommand="TeamDevGv_RowCommand" OnRowDataBound="TeamDevsGv_RowDataBound" CssClass="table table-striped table-bordered table-condensedr table-hover">
            <Columns>
                <asp:ButtonField ButtonType="Button" HeaderText="Remove" Text="Remove" CommandName="Remove" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:Label ID="CurrentProjectId" runat="server" Hidden="false;" Text="Label"></asp:Label>


</asp:Content>
