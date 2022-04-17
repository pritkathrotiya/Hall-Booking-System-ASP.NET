<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel/FrontPanel.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="FrontPanel_Order_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link rel="stylesheet" href='<%=ResolveClientUrl("~/Content/FrontPanel/Assets/css/feather.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Order</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/FrontPanel/Hall/HallList.aspx") %>'>Hall</a></li>
    <li class="breadcrumb-item active">OrderList</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-6 col-lg-3 col-xl">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col mt-0">
                            <h5 class="card-title card-title-size">Total Orders</h5>
                        </div>
                        <div class="col-auto">
                            <div class="avatar">
                                <div class="avatar-title rounded-circle bg-primary-dark">
                                    <i class="feather-shopping-cart"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="display-5 mt-1 mb-3">
                        <asp:Label ID="lblTotalOrders" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 col-xl">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col mt-0">
                            <h5 class="card-title card-title-size">Total Amount Pay</h5>
                        </div>
                        <div class="col-auto">
                            <div class="avatar">
                                <div class="avatar-title rounded-circle bg-primary-dark">
                                    <i class="feather feather-dollar-sign"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="display-5 mt-1 mb-3">
                        <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 col-xl">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col mt-0">
                            <h5 class="card-title card-title-size">Completed Order</h5>
                        </div>
                        <div class="col-auto">
                            <div class="avatar">
                                <div class="avatar-title rounded-circle bg-primary-dark">
                                    <i class="feather feather-check-circle align-middle"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="display-5 mt-1 mb-3">
                        <asp:Label ID="lblCompletedOrder" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 col-xl">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col mt-0">
                            <h5 class="card-title card-title-size">Pending Order</h5>
                        </div>
                        <div class="col-auto">
                            <div class="avatar">
                                <div class="avatar-title rounded-circle bg-primary-dark">
                                    <i class="feather feather-pause-circle align-middle"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="display-5 mt-1 mb-3">
                        <asp:Label ID="lblPendingOrder" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">Order List</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvOrder_RowCommand" OnRowDataBound="gvOrder_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" ItemStyle-CssClass="text-nowrap" />
                            <asp:BoundField DataField="HallName" HeaderText="Hall Name" ItemStyle-CssClass="text-nowrap" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-CssClass="text-nowrap" />
                            <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-CssClass="text-nowrap" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" ItemStyle-Font-Bold="true" />
                            <asp:BoundField DataField="TotalDays" HeaderText="Total Days" />
                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="#18BA9B" />
                            <asp:TemplateField HeaderText="Print" HeaderStyle-Width="15" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnPrint" runat="server" CommandName="PrintRecord" CommandArgument='<%# "~/FrontPanel/Order/OrderPrint.aspx?OrderID="+ Eval("OrderID") %>'><i class="fa fa-print"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Oprations" HeaderStyle-Width="105" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger rounded-pill btn-sm button-custom"
                                        CommandName="DeleteRecord" CommandArgument='<%# Eval("OrderID") %>' />
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning rounded-pill text-dark btn-sm button-custom"
                                        CommandName="EditRecord" CommandArgument='<%# "~/FrontPanel/Order/OrderAddEdit.aspx?OrderID="+ Eval("OrderID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

