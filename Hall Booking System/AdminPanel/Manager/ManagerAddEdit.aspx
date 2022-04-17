<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="ManagerAddEdit.aspx.cs" Inherits="AdminPanel_Manager_ManagerAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Manager</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Manager/ManagerList.aspx") %>'>Manager</a></li>
    <li class="breadcrumb-item active">
        <asp:Label ID="lblNavigationHeader" runat="server"></asp:Label></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">
                                <asp:Label ID="lblPageHeader" runat="server"></asp:Label></h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Manager Name<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtManagerName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvManagerName" runat="server"
                                ErrorMessage="Enter Manager Name"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtManagerName" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Email<span class="text-danger">*</span></label>
                        <div class="col-md-4">
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
                        <label class="col-md-2 col-form-label">Phone No<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhoneNo" runat="server"
                                ErrorMessage="Enter Phone No"
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
                        <div class="col-md-4">
                            <label class="custom-control custom-radio">
                                <input type="radio" name="custom-radio" runat="server" class="custom-control-input" checked="true" id="rbMale" />
                                <span class="custom-control-label">Male</span>
                            </label>
                            <label class="custom-control custom-radio">
                                <input type="radio" name="custom-radio" runat="server" class="custom-control-input" id="rbFemale" />
                                <span class="custom-control-label">Female</span>
                            </label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Salary<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSalary" runat="server"
                                ErrorMessage="Enter Salary"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtSalary" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-2 offset-md-2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-primary mr-1" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                        </div>
                        <div class="col-md-8 col-form-label">
                            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" EnableViewState="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

