<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="HallAddEdit.aspx.cs" Inherits="AdminPanel_Hall_HallAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">City</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Hall/HallList.aspx") %>'>Hall</a></li>
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
                        <label class="col-md-2 col-form-label">Hall Name<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtHallName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfHall" runat="server"
                                ErrorMessage="Enter Hall Name"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtHallName" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Address<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfAddress" runat="server"
                                ErrorMessage="Enter Address"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtAddress" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">City<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                                ErrorMessage="Select City"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="ddlCity" ValidationGroup="Save" InitialValue="-1" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Area<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvArea" runat="server"
                                ErrorMessage="Select Area"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="ddlArea" ValidationGroup="Save" InitialValue="-1" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">People Capacity<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPeopleCapacity" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfPeopleCapacity" runat="server"
                                ErrorMessage="Enter People Capacity"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtPeopleCapacity" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Hall Vechile Capacity<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtVechileCapacity" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvVechileCapacity" runat="server"
                                ErrorMessage="Enter Vechile Capacity"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtVechileCapacity" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Hall Price<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtHallPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvHallPrice" runat="server"
                                ErrorMessage="Enter Hall Price"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtHallPrice" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Manager<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlManager" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvManager" runat="server"
                                ErrorMessage="Select Manager"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="ddlManager" ValidationGroup="Save" InitialValue="-1" />
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

