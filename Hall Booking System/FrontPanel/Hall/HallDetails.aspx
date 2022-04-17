<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel/FrontPanel.master" AutoEventWireup="true" CodeFile="HallDetails.aspx.cs" Inherits="FrontPanel_Hall_HallDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Hall</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/FrontPanel/Hall/HallList.aspx") %>'>Hall</a></li>
    <li class="breadcrumb-item active">HallDetails</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">Hall Photos</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="offset-md-2 col-md-8">
                        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                                <div class="carousel-item active" id="photo1" runat="server">
                                    <asp:Image ID="imgPhoto1" runat="server" CssClass="img-fluid d-block w-100" />
                                </div>
                                <div class="carousel-item" id="photo2" runat="server">
                                    <asp:Image ID="imgPhoto2" runat="server" CssClass="img-fluid d-block w-100" />
                                </div>
                                <div class="carousel-item" id="photo3" runat="server">
                                    <asp:Image ID="imgPhoto3" runat="server" CssClass="img-fluid d-block w-100" />
                                </div>
                                <div class="carousel-item" id="photo4" runat="server">
                                    <asp:Image ID="imgPhoto4" runat="server" CssClass="img-fluid d-block w-100" />
                                </div>
                                <div class="carousel-item" id="photo5" runat="server">
                                    <asp:Image ID="imgPhoto5" runat="server" CssClass="img-fluid d-block w-100" />
                                </div>
                                <div class="carousel-item" id="photo6" runat="server">
                                    <asp:Image ID="imgPhoto6" runat="server" CssClass="img-fluid d-block w-100" />
                                </div>
                            </div>
                            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
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
                            <h5 class="card-title mb-0">Hall Details</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="Label1" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="col-md-12">
                        <table class="table table-bordered table-striped">
                            <tr>
                                <td class="font-weight-bold">Hall Name</td>
                                <td>
                                    <asp:Label ID="lblHallName" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Address</td>
                                <td>
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">City</td>
                                <td>
                                    <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Area</td>
                                <td>
                                    <asp:Label ID="lblArea" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Pincode</td>
                                <td>
                                    <asp:Label ID="lblPincode" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">People Capacity</td>
                                <td>
                                    <asp:Label ID="lblPeopleCapacity" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Vechile Capacity</td>
                                <td>
                                    <asp:Label ID="lblVechileCapacity" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Price</td>
                                <td>
                                    <asp:Label ID="lblPrice" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Manager Name</td>
                                <td>
                                    <asp:Label ID="lblManagerName" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Phone No</td>
                                <td>
                                    <asp:Label ID="lblPhoneNo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="font-weight-bold">Email</td>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnBookNow" runat="server" Text="Book Now" CssClass="btn btn-danger rounded-pill" OnClick="btnBookNow_Click" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-info rounded-pill" OnClick="btnBack_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
    <script>
        $('.carousel').carousel({
            interval: 2000
        })
    </script>
</asp:Content>

