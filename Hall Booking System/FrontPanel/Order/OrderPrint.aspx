<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel/FrontPanel.master" AutoEventWireup="true" CodeFile="OrderPrint.aspx.cs" Inherits="FrontPanel_Order_OrderPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Order</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/FrontPanel/Order/OrderList.aspx") %>'>Order List</a></li>
    <li class="breadcrumb-item active">Order Print</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-body m-sm-3 m-md-5">
                    <asp:Label ID="lblErrorMessage" runat="server" EnableViewState="false" CssClass="text-danger"></asp:Label>
                    <asp:Panel ID="panelPrint" runat="server">
                        <div class="mb-4 text-center">
                            <h2>Hall Booking System</h2>
                        </div>
                        <div class="mb-4">
                            Hello <strong>
                                <asp:Label ID="lblUsername1" runat="server"></asp:Label></strong>,<br>
                            This is the receipt for your order from <strong>Hall Booking System</strong>.
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="text-muted">Order No.</div>
                                <strong>
                                    <asp:Label ID="lblOrderID" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-6 text-md-right">
                                <div class="text-muted">Order Date</div>
                                <strong>
                                    <asp:Label ID="lblBookingDate" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <hr class="my-4">
                        <div class="row mb-4">
                            <div class="col-md-6">
                                <div class="text-muted">Customer</div>
                                <strong>
                                    <asp:Label ID="lblUsername2" runat="server"></asp:Label></strong>
                                <p>
                                    <asp:Label ID="lblPhoneNo" runat="server"></asp:Label><br />
                                    <a href="#">
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label></a>
                                </p>
                            </div>
                            <div class="col-md-6 text-md-right">
                                <div class="text-muted">Payment To</div>
                                <strong>
                                    <asp:Label ID="lblHallName1" runat="server"></asp:Label></strong>
                                <p>
                                    <asp:Label ID="lblArea" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblCity" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblPincode" runat="server"></asp:Label><br />
                                </p>
                            </div>
                        </div>

                        <table class="table table-sm">
                            <thead>
                                <tr>
                                    <th>Hall Name</th>
                                    <th>Start Date</th>
                                    <th>End Date</th>
                                    <th class="text-right">Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHallName2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblStartDate" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEndDate" runat="server"></asp:Label></td>
                                    <td class="text-right">
                                        <asp:Label ID="lblOrderAmount1" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                <tr>
                                    <th>&nbsp;</th>
                                    <th>&nbsp;</th>
                                    <th>Total </th>
                                    <th class="text-right">
                                        <asp:Label ID="lblOrderAmount2" runat="server"></asp:Label>&#x20B9;</th>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                    <div class="text-center">
                        <p class="text-sm">
                            <strong>Extra note:</strong>
                            This is system generated recpit. Original recipt take on Hall.
                        </p>
                        <a href="#" class="btn btn-primary" onclick="printClick()">Print this receipt</a>
                        <a href='<%=ResolveClientUrl("~/FrontPanel/Order/OrderList.aspx") %>' class="btn btn-danger">Back</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
    <script>
        function printClick() {
            var printPanel = document.getElementById("<%=panelPrint.ClientID %>").innerHTML;
            var originalPanel = document.body.innerHTML;
            document.body.innerHTML = printPanel;
            window.print();
            document.body.innerHTML = originalPanel;
        }
    </script>
</asp:Content>

