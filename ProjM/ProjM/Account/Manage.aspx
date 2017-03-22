<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ProjM.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="form-horizontal">
                <h4>Manage personal information: </h4>
                <hr />
                <dl class="dl-horizontal">


                    <dt>Password:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>External Logins:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />
                    </dd>
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

                    <dt>Two-Factor Authentication:</dt>
                    <dd>
                        <p>
                            none
                        </p>
                        <% if (TwoFactorEnabled)
                            { %>
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                            else
                            { %>
                        <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>

                    <dt>
                        <asp:Label ID="LabelName" runat="server" Text="Name:"></asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="UserNameTb" runat="server" Text="" Enabled="false"></asp:TextBox>
                    </dd>

                    <dt>
                        <asp:Label ID="LabelPhoneNum" runat="server"  Enabled="true" Text="Phone Number:"></asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="PhoneNumberTb" runat="server" Text="" Enabled="false"></asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="ExperienceLable" runat="server"  Text="Certificates, Internships or Working experience"></asp:Label>
                    </dt>
                    <dd>
                        <textarea id="ExperienceTextArea" runat="server"  Disabled="true" cols="40" rows="4"></textarea>
                    </dd>

                    <asp:Button ID="SaveDataButton" runat="server" Text="Edit profile" OnClick="SaveDataButton_Click" />
                </dl>
            </div>

        </div>
        <div class="col-md-6">
            <div class="form-horizontal">
                <h4>Developer information: </h4>
                <hr />
                <dl class="dl-horizontal">
                      <dt>
                        <asp:Label ID="DevType" runat="server" Text="Type:"></asp:Label>
                    </dt>
                    <dd>
                        <asp:DropDownList ID="DevTypeDdl" Enabled="false" runat="server"></asp:DropDownList>
                    </dd>
                    <dt>
                        <asp:Label ID="LanguagesLabel" runat="server" Text="Languages"></asp:Label>
                    </dt>
                    <dd>
                        <asp:CheckBoxList ID="LanguagesCbl" RepeatDirection="Vertical" RepeatColumns="2" RepeatLayout="Table" runat="server"></asp:CheckBoxList>
                    </dd>

                    <dt>
                        <asp:Label ID="LabelRank" runat="server" Text="Rank:" ></asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="RankTb" runat="server" Enabled="false"></asp:TextBox>
                    </dd>
                        <dt>
                        <asp:Label ID="LabelRankPoints" runat="server" Text="Rank points:" ></asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="RankPointsTb" runat="server" Enabled="false"></asp:TextBox>
                    </dd>
                        <dt>
                        <asp:Label ID="Label1" runat="server" Text="Status: " ></asp:Label>
                    </dt>
                    <dd>
                        <asp:Label ID="StatusLabel" runat="server" Text="Free" ForeColor="Green"></asp:Label>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
