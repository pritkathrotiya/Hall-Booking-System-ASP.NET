<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="AdminAddEdit.aspx.cs" Inherits="AdminPanel_Admin_AdminAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Admin</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Admin/AdminHome.aspx") %>'>AdminProfile</a></li>
    <li class="breadcrumb-item active">AdminProfileEdit</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-3">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title mb-0">Admin Settings</h5>
                </div>

                <div class="list-group list-group-flush" role="tablist">
                    <a class="list-group-item list-group-item-action active" data-toggle="list" href="#profileEdit" role="tab">Profile Edit</a>
                    <a class="list-group-item list-group-item-action" data-toggle="list" href="#password" role="tab">Password</a>
                </div>

            </div>
        </div>
        <div class="col-md-9">
            <div class="tab-content">
                <div class="tab-pane fade show active" id="profileEdit" role="tabpanel">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-4">
                                    <h5 class="card-title mb-0">Profile Edit</h5>
                                </div>
                                <div class="col-md-8">
                                    <asp:Label ID="lblErrorProfile" runat="server" CssClass="text-danger" EnableViewState="false" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <label class="col-md-2 col-form-label">Display Name<span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDisplayName" runat="server"
                                        ErrorMessage="Enter Display Name"
                                        CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                        ControlToValidate="txtDisplayName" ValidationGroup="Save" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 col-form-label">Email<span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                        ErrorMessage="Enter Email"
                                        CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                        ControlToValidate="txtEmail" ValidationGroup="Save" />
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                        ErrorMessage="Enter Proper Email"
                                        CssClass="text-danger" SetFocusOnError="True" Display="Dynamic"
                                        ControlToValidate="txtEmail" ValidationGroup="Save"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 col-form-label">PhoneNo<span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPhoneNo" runat="server"
                                        ErrorMessage="Enter PhoneNo"
                                        CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                        ControlToValidate="txtPhoneNo" ValidationGroup="Save" />
                                    <asp:RegularExpressionValidator ID="revPhoneNo" runat="server"
                                        ErrorMessage="Enter Proper Phone No"
                                        CssClass="text-danger" SetFocusOnError="True" Display="Dynamic"
                                        ControlToValidate="txtPhoneNo" ValidationGroup="Save"
                                        ValidationExpression="[0-9]{10}" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 col-form-label">Gender<span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <label class="custom-control custom-radio">
                                        <input type="radio" name="custom-radio" runat="server" class="custom-control-input" id="rbMale" />
                                        <span class="custom-control-label">Male</span>
                                    </label>
                                    <label class="custom-control custom-radio">
                                        <input type="radio" name="custom-radio" runat="server" class="custom-control-input" id="rbFemale" />
                                        <span class="custom-control-label">Female</span>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 col-form-label">BirthDate<span class="text-danger">*</span></label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server"
                                        ErrorMessage="Enter Birth Date"
                                        CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                        ControlToValidate="txtBirthDate" ValidationGroup="Save" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-4 offset-md-2">
                                    <asp:Button ID="btnSaveProfile" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-primary mr-1" OnClick="btnSaveProfile_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="password" role="tabpanel">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <fieldset>
                                <div class="card">
                                    <div class="card-header">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <h5 class="card-title mb-0">Password</h5>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:Label ID="lblErrorPassword" runat="server" CssClass="text-danger" EnableViewState="false" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label>Current Password<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control col-md-6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server"
                                                ErrorMessage="Enter Current Password"
                                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="txtCurrentPassword" ValidationGroup="Password" />
                                            <small><a href='<%=ResolveClientUrl("~/AdminPanel/Authorization/AdminResetPassword.aspx") %>'>Forgot your password?</a></small>
                                        </div>
                                        <div class="form-group">
                                            <label>New Password<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control col-md-6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server"
                                                ErrorMessage="Enter New Password"
                                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="txtNewPassword" ValidationGroup="Password" />
                                        </div>
                                        <div class="form-group">
                                            <label>Re-enter Password<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtReNewPassword" runat="server" CssClass="form-control col-md-6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvReNewPassword" runat="server"
                                                ErrorMessage="Enter Re-enter Password"
                                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                                ControlToValidate="txtReNewPassword" ValidationGroup="Password" />
                                            <asp:CompareValidator ID="cmpPassword" runat="server"
                                                ErrorMessage="Password doesn't match"
                                                SetFocusOnError="true" CssClass="text-danger" Display="Dynamic"
                                                ValidationGroup="Password" ControlToCompare="txtNewPassword" ControlToValidate="txtReNewPassword"></asp:CompareValidator>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-md-4">
                                                <asp:Button ID="btnSavePassword" runat="server" Text="Save" ValidationGroup="Password" CssClass="btn btn-primary mr-1" OnClick="btnSavePassword_Click" />
                                                <asp:Button ID="btnCancelPassword" runat="server" Text="Back" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                            </div>
                                            <div class="col-md-8">
                                                <asp:Label ID="lblChangePassword" runat="server" CssClass="text-success"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

