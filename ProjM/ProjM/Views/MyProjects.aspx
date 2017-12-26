<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProjects.aspx.cs" Inherits="ProjM.Views.MyProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:Panel ID="CurrentProjectPanel" Visible="false" runat="server">
            <div class="col-lg-6">
                <h4>Current Project</h4>
                <h3 Id="noProject" runat="server" visible="false">No projects.</h3>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="CurrentProjNameL" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <label class="col-lg-6 control-label">Type</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="TypeL" runat="server" Text="1"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">Category</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="CategoryL" runat="server" Text="1"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">Description</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="DescriptionL" runat="server" Text="1"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">Status</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="StatusL" runat="server" Text="1"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">Deadline</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="DeadLineL" runat="server" Text="1"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">Team</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="TeamL" runat="server" Text="">1</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-lg-6 control-label">Budget</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="BudgetL" runat="server" Text="1"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <h4>Team</h4>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="TeamNameL" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <label class="col-lg-6 control-label">Members count:</label>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">Front-end developers</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="FrontEndCount" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">Back-end developers</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="BackEndCount" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="col-lg-6 control-label">QA developers</label>
                            <div class="col-lg-6">
                                <div class="pull-right">
                                    <asp:Label ID="QACount" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-lg-12">
                <h4>Team members</h4>
                <div class="panel panel-default">
                    <div class="panel-body">

                        <asp:Repeater ID="membersRept" runat="server">
                            <ItemTemplate>
                                <%--     <td><%# Eval("title")%></td>--%>





                                <div class="col-lg-4">
                                    <div class="panel panel-info">
                                        <div class="panel-heading">
                                            <h3 class="panel-title"><%# Eval("Name")%></h3>
                                        </div>
                                        <div class="panel-body">


                                            <div class="row">
                                                <label class="col-lg-6 control-label">Email</label>
                                                <div class="col-lg-6">
                                                    <div class="pull-right">
                                                        <asp:Label ID="TypeL" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <label class="col-lg-6 control-label">Phone</label>
                                                <div class="col-lg-6">
                                                    <div class="pull-right">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <label class="col-lg-6 control-label">Specialization</label>
                                                <div class="col-lg-6">
                                                    <div class="pull-right">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Specialization") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                               <div class="row">
                                                   <label class="col-lg-6 control-label">Rank</label>
                                                   <div class="col-lg-6">
                                                       <div class="pull-right">
                                                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("Rank") %>'></asp:Label>
                                                       </div>
                                                   </div>
                                               </div>
                                        </div>
                                    </div>
                                </div>


                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>


        </asp:Panel>



        <asp:Panel ID="InvitePanel" runat="server" Visible="false">
            <div class="col-lg-6 col-lg-offset-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Project Invites</h3>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-10">
                            <asp:Label ID="NameL" CssClass="control-label" runat="server" Text="Project Name:"></asp:Label>
                            <asp:Label ID="ProjectNameL" CssClass="control-label" runat="server" Text="Label"></asp:Label>
                        </div>


                        <div class="col-lg-12">
                            <div class="pull-right">

                                <asp:Button ID="AcceptBtn" CssClass="btn btn-sm btn-success" runat="server" Text="Accept" OnClick="AcceptBtn_Click" />
                                <asp:Button ID="DetailsBtn" CssClass="btn btn-sm btn-default" runat="server" Text="Details" OnClick="DetailsBtn_Click" />
                                <asp:Button ID="DeclineBtn" CssClass="btn btn-sm btn-danger" runat="server" Text="Decline" OnClick="DeclineBtn_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </asp:Panel>
    </div>


</asp:Content>
