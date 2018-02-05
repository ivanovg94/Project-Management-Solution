<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ProjM.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="container">
        <div class="well col-lg-6">
            <fieldset>
                <legend>Personal Data</legend>

                <%--  <dt>External Logins:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />
                    </dd>--%>
                <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="http://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                --%>
                <%--
                    <dt>Phone Number:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                --%>

                <%--  <dt>Two-Factor Authentication:</dt>
                    <dd>
                        <p>
                            none
                        </p>--%>
                <% //if (TwoFactorEnabled)
// { %>
                <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                --%>
                <% //}
// else
// { %>
                <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                --%>
                <% //} %>
                <%--</dd>--%>


                <div class="form-group">
                    <asp:Label ID="LabelName" runat="server" CssClass="col-lg-2 control-label" Text="Name"></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="UserNameTb" runat="server" placeholder="User Name" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelPhoneNum" runat="server" CssClass="col-lg-2 control-label" Enabled="true" Text="Phone Number"></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="PhoneNumberTb" runat="server" CssClass="form-control" placeholder="Phone Number" Text="" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="ExperienceLable" runat="server" CssClass="col-lg-2 control-label" Text="Certificates, Internships, Working experience"></asp:Label>
                    <div class="col-lg-10">
                        <textarea id="ExperienceTextArea" class="form-control" runat="server" placeholder="Description" disabled="true" cols="50" rows="6"></textarea>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Lab" runat="server" CssClass="col-lg-2 control-label" Enabled="true" Text=""></asp:Label>

                    <div class="col-lg-8 col-lg-offset-6">
                        <asp:HyperLink CssClass="btn btn-default " NavigateUrl="/Account/ManagePassword" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink CssClass="btn btn-default" NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                        <asp:Button ID="SaveDataButton" CssClass="btn btn-default " runat="server" Text="Edit profile" OnClick="SaveDataButton_Click" />
                    </div>
                </div>


            </fieldset>
        </div>

        <div class="well col-lg-6">
            <fieldset>
                <legend>Professional Information</legend>

                <div class="form-group">
                    <asp:Label ID="LabelRank" CssClass="col-lg-2 control-label" runat="server" Text="Rank"></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="RankTb" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelRankPoints" CssClass="col-lg-2 control-label" runat="server" Text="Rank points"></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="RankPointsTb" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="DevSpec" CssClass="col-lg-2 control-label" runat="server" Text="Speciality"></asp:Label>
                    <div class="col-lg-10">
                        <asp:Label ID="DevSpecLabel" Visible="false" CssClass="col-lg-6 control-label" runat="server" Text="None"></asp:Label>
                        <asp:DropDownList ID="DevSpecDdl" Visible="true" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="StatusLabelTag" CssClass="col-lg-2 control-label" runat="server" Text="Status "></asp:Label>
                    <div class="col-lg-10">

                        <asp:Label ID="StatusLabel" runat="server" CssClass="col-lg-2 control-label" Text="" ForeColor=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="LastProjectInfo" CssClass="col-lg-2 control-label" runat="server" Text="Previous project  "></asp:Label>
                    <div class="col-lg-10">

                        <asp:Label ID="LastProjectInfoValue" runat="server" CssClass="col-lg-10 control-label" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="LanguagesLabel" CssClass="col-lg-12 control-label" runat="server" Text="Languages"></asp:Label>
                    <div class="col-lg-10 col-lg-offset-2">
                        <asp:CheckBoxList ID="LanguagesCbl" CssClass="control-checkbox " RepeatDirection="Vertical" Enabled="false" RepeatColumns="3" RepeatLayout="Table" runat="server"></asp:CheckBoxList>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
