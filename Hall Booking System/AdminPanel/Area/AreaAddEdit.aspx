<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="AreaAddEdit.aspx.cs" Inherits="AdminPanel_Area_AreaAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">City</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Area/AreaList.aspx") %>'>Area</a></li>
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
                        <label class="col-md-2 col-form-label">Area Name<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAreaName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfAreaName" runat="server"
                                ErrorMessage="Enter Area Name"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtAreaName" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Address<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                                ErrorMessage="Enter Address"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtAddress" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Pincode<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPincode" runat="server"
                                ErrorMessage="Enter Pincode"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtPincode" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">City<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                                ErrorMessage="Select City"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="ddlCity" ValidationGroup="Save" InitialValue="-1" />
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

