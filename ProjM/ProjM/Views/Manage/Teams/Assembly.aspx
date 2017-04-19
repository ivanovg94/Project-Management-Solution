<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assembly.aspx.cs" Inherits="ProjM.WebForms.Team.Assembly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="col-lg-6">
        <div class="panel panel-success">
            <div class="panel-heading">Project details</div>
            <div class="panel-body">
                <div class="pull-left">
                    <asp:Label CssClass="control-label" runat="server" Text="Name:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="Type:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="Category:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="Budget:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="Status:" Font-Bold="True"></asp:Label>
                </div>

                <div class="pull-right">
                    <asp:Label ID="ProjectNameLValue" CssClass="control-label" runat="server" Text="" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="ProjectTypeLValue" CssClass="control-label" runat="server" Text="" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="ProjectCategoryLValue" CssClass="control-label" runat="server" Text="" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="BudgetLValue" CssClass="control-label" runat="server" Text="" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="ProjectStatusValue" CssClass="control-label" runat="server" Text="" Font-Bold="True"></asp:Label>
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
                    <asp:Label CssClass="control-label" runat="server" Text="Total number of Developers needed:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="Front-end:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="Back-end:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="QA:" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" Text="Status:" Font-Bold="True"></asp:Label>

                </div>
                <div class="pull-right">
                    <asp:Label ID="CurrentTotalLValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    /
                    <asp:Label ID="TotalLValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="CurrentFrontEndLValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    /
                    <asp:Label ID="FrontEndLValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="CurrentBackEndLValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    /
                    <asp:Label ID="BackEndLValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="CurrentQALValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    /
                    <asp:Label ID="QALValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="TeamStatusValue" CssClass="control-label" runat="server" Text="x" Font-Bold="True"></asp:Label>

                </div>
            </div>
        </div>
        <asp:GridView ID="TeamDevsGv" runat="server" OnRowCommand="TeamDevGv_RowCommand" OnRowDataBound="TeamDevsGv_RowDataBound" CssClass="table table-striped table-bordered table-condensedr table-hover">
            <Columns>
                <asp:ButtonField ButtonType="Button" HeaderText="Remove" Text="Remove" CommandName="Remove" />
            </Columns>
        </asp:GridView>
        <div class="pull-right">
            <div id="resultBtns" class="btn-group btn-group-justified" runat="server" visible="false">
                <div class="col-lg-11">
                    <div class="col-lg-5">
                        <asp:Button ID="SuccessfulBtn" CssClass="btn btn-success" runat="server" Text="Mark Project as Successful" OnClick="SuccessfulBtn_Click" />
                    </div>
                    <div class="col-lg-4">
                        <asp:Button ID="FailedBtn" runat="server" CssClass="btn btn-danger" Text="Mark Project as Failed" OnClick="FailedBtn_Click" />
                    </div>
                </div>
            </div>
            <asp:Button ID="EndBtn" CssClass="btn btn-success" Visible="false" runat="server" Text="End Project" OnClick="EndBtn_Click" />
            <asp:Button ID="StartProjectBtn" runat="server" CssClass="btn btn-success" Text="Start Project" Visible="false" OnClick="StartProjectBtn_Click" />
            <asp:Button ID="AssemblyBtn" CssClass="btn btn-primary" runat="server" Text="Assembly Team" OnClick="AssemblyBtn_Click" />
        </div>
    </div>
</asp:Content>
