<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assembly.aspx.cs" Inherits="ProjM.WebForms.Team.Assembly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="container">
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
        </div>
    </div>

    <div class="container">
        <div class="col-lg-6">
            <div class="col-lg-12">
                <div class="form-group">
                    <label class="col-lg-1 control-label">Search By</label>
                    <div class="col-lg-11">
                        <div class="form-group">
                            <div class="col-lg-5">
                                <asp:DropDownList ID="SearchByDdl" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">Name</asp:ListItem>
                                    <asp:ListItem Value="2">Speciality</asp:ListItem>
                                    <asp:ListItem Value="3">Rank</asp:ListItem>
                                    <asp:ListItem Value="4">Project Count</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-5">
                                <asp:TextBox ID="SearchKeyWord" runat="server" PlaceHolder="Key word" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:Button ID="SearchBtn" runat="server" OnClick="SearchBtn_Click" CssClass="btn btn-default" Text="Search" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="form-group">
                    <label class="col-lg-1 control-label">Order By</label>
                    <div class="col-lg-11">
                        <div class="form-group">
                            <div class="col-lg-5">
                                <asp:DropDownList ID="OrderByDdl" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">Name</asp:ListItem>
                                    <asp:ListItem Value="2">Speciality</asp:ListItem>
                                    <asp:ListItem Value="3">Rank</asp:ListItem>
                                    <asp:ListItem Value="4">Project Count</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-5">
                                <asp:DropDownList ID="DirectionDdl" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">Ascending</asp:ListItem>
                                    <asp:ListItem Value="2">Descending</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <asp:Button ID="SortBtn" runat="server" OnClick="SortBtn_Click" CssClass="btn btn-default" Text="Sort" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="col-lg-12">
            </div>
            <div class="col-lg-12">
                <h4>Team members:</h4>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="col-lg-6">
            <asp:GridView ID="AllDevsGv"
                DataKeysNames="Id"
                OnRowCommand="AllDevsGv_RowCommand"
                ItemType="ProjM.ViewModels.DevVM"
                AllowPaging="true"
                PageSize="6"
                AutoGenerateColumns="false"
                SelectMethod="AllDevsGv_GetData"
                runat="server"
                CssClass="table table-striped table-bordered table-condensedr table-hover">


                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Speciality" HeaderText="Speciality" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Rank" HeaderText="Rank" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="ProjectCount" HeaderText="Project Count" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="RankId" HeaderText="RankId" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />
                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />

                    <asp:ButtonField ButtonType="Button" Text="Details" CommandName="Details" ItemStyle-HorizontalAlign="center" />
                    <asp:ButtonField ButtonType="Button" Text="Add" CommandName="Add" ItemStyle-HorizontalAlign="center" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-lg-6">
            <asp:GridView ID="TeamDevsGv"
                runat="server"
                DataKeyNames="Id"
                AllowPaging="true"
                PageSize="6"
                OnRowCommand="TeamDevGv_RowCommand"
                SelectMethod="TeamDevsGv_GetData"
                ItemType="ProjM.ViewModels.DevVM"
                AutoGenerateColumns="false"
                CssClass="table table-striped table-bordered table-condensedr table-hover">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Speciality" HeaderText="Speciality" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Rank" HeaderText="Rank" ItemStyle-HorizontalAlign="center" />
                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-HorizontalAlign="center" />
                    <asp:ButtonField ButtonType="Button" Text="Details" CommandName="Details" ItemStyle-HorizontalAlign="center" />
                    <asp:ButtonField ButtonType="Button" Text="Remove" CommandName="Remove" ItemStyle-HorizontalAlign="center" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

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
</asp:Content>
