<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="AdminPanel_User_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link rel="stylesheet" href='<%=ResolveClientUrl("~/Content/AdminPanel/Assets/css/feather.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Order List</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item active">Order List</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-4 col-xl">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col mt-0">
                            <h5 class="card-title card-title-size">Total Order</h5>
                        </div>
                        <div class="col-auto">
                            <div class="avatar">
                                <div class="avatar-title rounded-circle bg-primary-dark">
                                    <i class="feather feather-shopping-cart align-middle"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="display-5 mt-1 mb-3">
                        <asp:Label ID="lblTotalOrder" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-xl">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col mt-0">
                            <h5 class="card-title card-title-size">Order Per User</h5>
                        </div>
                        <div class="col-auto">
                            <div class="avatar">
                                <div class="avatar-title rounded-circle bg-primary-dark">
                                    <i class="feather-user-check"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="display-5 mt-1 mb-3">
                        <asp:Label ID="lblOrderPerUser" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-xl">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col mt-0">
                            <h5 class="card-title card-title-size">Order Per Hall</h5>
                        </div>
                        <div class="col-auto">
                            <div class="avatar">
                                <div class="avatar-title rounded-circle bg-primary-dark">
                                    <i class="feather feather-layers"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="display-5 mt-1 mb-3">
                        <asp:Label ID="lblOrderPerHall" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="col-md-4">
                        <h5 class="card-title mb-0">Order List</h5>
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowCommand="gvOrder_RowCommand" OnRowDataBound="gvOrder_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" />
                                    <asp:BoundField DataField="HallName" HeaderText="Hall Name" ItemStyle-CssClass="text-nowrap" />
                                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-CssClass="text-nowrap" />
                                    <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-CssClass="text-nowrap" />
                                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" ItemStyle-Font-Bold="true" />
                                    <asp:BoundField DataField="Username" HeaderText="User Name" />
                                    <asp:BoundField DataField="Email" HeaderText="User Email" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="#18BA9B" />
                                    <asp:TemplateField HeaderText="Print" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnPrint" runat="server" CommandName="PrintRecord" CommandArgument='<%# Eval("OrderID") %>'><i class="fa fa-print"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>
