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
                        <asp:Label ID="Label1" CssClass="control-label"  runat="server" Text="Name:" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label2" CssClass="control-label" runat="server" Text="Type:" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" CssClass="control-label" runat="server" Text="Category:" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label8" CssClass="control-label" runat="server" Text="Budget:" Font-Bold="True"></asp:Label>
                    </div>

                    </div>
                </div>

                <div class="pull-right">
                    <div class="col=lg-3">
                        <asp:Label ID="Label4" CssClass="control-label"  runat="server" Text="1" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label5" CssClass="control-label" runat="server" Text="2" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" CssClass="control-label" runat="server" Text="3" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label7" CssClass="control-label" runat="server" Text="4" Font-Bold="True"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <asp:GridView ID="AllDevsGv" runat="server"></asp:GridView>


    </div>
    <div class="col-lg-6">
        <div class="panel panel-default">
            <div class="panel-heading">Required number of Developers</div>
            <div class="panel-body">

      <div class="pull-left">
                    <div class="col=lg-3">
                      <div class="col=lg-3">
                        <asp:Label ID="Label9" CssClass="control-label"  runat="server" Text="Total:" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label10" CssClass="control-label" runat="server" Text="Front-end:" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label11" CssClass="control-label" runat="server" Text="Back-end:" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label12" CssClass="control-label" runat="server" Text="QA:" Font-Bold="True"></asp:Label>
                    </div>
                    </div>
                </div>
                <div class="pull-right">
                    <div class="col=lg-3">
                        <asp:Label ID="Label13" CssClass="control-label"  runat="server" Text="1" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label14" CssClass="control-label" runat="server" Text="2" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label15" CssClass="control-label" runat="server" Text="3" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="Label16" CssClass="control-label" runat="server" Text="4" Font-Bold="True"></asp:Label>
                    </div>
                </div>



            </div>
        </div>
        <asp:GridView ID="TeamDevsGv" runat="server"></asp:GridView>
    </div>



</asp:Content>
