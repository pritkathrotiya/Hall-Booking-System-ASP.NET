<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel/FrontPanel.master" AutoEventWireup="true" CodeFile="OrderAddEdit.aspx.cs" Inherits="FrontPanel_Order_OrderAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Order</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/FrontPanel/Hall/HallList.aspx") %>'>Hall</a></li>
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/FrontPanel/Order/OrderList.aspx") %>'>Order</a></li>
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
                        <label class="col-md-2 col-form-label">Booking Start Date<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStartDate" runat="server"
                                ErrorMessage="Select Start Date"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtStartDate" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">Booking End Date<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server"
                                ErrorMessage="Select End Date"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtEndDate" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-3 offset-md-2">
                            <asp:Button ID="btnCheckAvailable" runat="server" Text="Check Available Status" ValidationGroup="Save" CssClass="btn btn-primary" OnClick="btnCheckAvailable_Click" />
                        </div>
                    </div>
                    <asp:Panel ID="panelMessage" runat="server" Visible="false">
                        <div class="form-group row">
                            <div class="col-md-12 offset-md-2">
                                <asp:Label ID="lblCheckMessage" runat="server" CssClass="text-danger"></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelAvailable" runat="server" Visible="false">
                        <div class="form-group row">
                            <label class="col-md-2 col-form-label">Hall Name<span class="text-danger"></span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtHallName" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 col-form-label">Address<span class="text-danger"></span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtAddress" runat="server" ReadOnly="true" TextMode="MultiLine" Height="80" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 col-form-label">Total Days Booking<span class="text-danger"></span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTotalDays" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 col-form-label">Total Amount To Pay<span class="text-danger"></span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="mx-auto">
                                <asp:Button ID="btnBookAndPayNow" runat="server" Text="Book & Pay Now" CssClass="btn btn-danger btn-rounded" OnClick="btnBookAndPayNow_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-info btn-rounded" OnClick="btnBack_Click" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

