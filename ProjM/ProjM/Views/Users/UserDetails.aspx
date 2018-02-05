<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="ProjM.Views.Manage.Users.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="well col-lg-6 col-lg-offset-3">
            <fieldset>
                <legend>User Details</legend>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="UserNameL" class="col-lg-3 control-label">Name</label>
                        <div class="col-lg-9 ">
                            <asp:Label ID="UserNameL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="EmailL" class="col-lg-3 control-label">Email</label>
                        <div class="col-lg-9">
                            <asp:Label ID="EmailL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="PhoneL" class="col-lg-3 control-label">Phone</label>
                        <div class="col-lg-9">
                            <asp:Label ID="PhoneL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="ExperienceL" class="col-lg-3 control-label">Certificates, Internships, Experience</label>
                        <div class="col-lg-9">
                            <asp:Label ID="ExperienceL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="SpecialityL" class="col-lg-3 control-label">Speciality</label>
                        <div class="col-lg-9">
                            <asp:Label ID="SpecialityL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="RankL" class="col-lg-3 control-label">Rank</label>
                        <div class="col-lg-9">
                            <asp:Label ID="RankL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group" runat="server">
                        <label for="RankPointsL" class="col-lg-3 control-label">Rank Points</label>
                        <div class="col-lg-9">
                            <asp:Label ID="RankPointsL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="ProjectCountL" class="col-lg-3 control-label">Past Project Count</label>
                        <div class="col-lg-9">
                            <asp:Label ID="ProjectCountL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="LastProjectInfoValue" class="col-lg-3 control-label">Previous project:</label>
                        <div class="col-lg-9">
                            <asp:Label ID="LastProjectInfoValue" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="TeamL" class="col-lg-3 control-label">Team</label>
                        <div class="col-lg-9">
                            <asp:Label ID="TeamL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="ProgrammingLanguagesL" class="col-lg-3 control-label">Programming Languages</label>
                        <div class="col-lg-9">
                            <asp:Label ID="ProgrammingLanguagesL" CssClass="control-label pull-right" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12">
                    <asp:Button ID="BackBtn" CssClass="btn btn-primary pull-right" runat="server" Text="Back" OnClick="BackBtn_Click" />
                </div>

            </fieldset>
        </div>
    </div>

</asp:Content>
