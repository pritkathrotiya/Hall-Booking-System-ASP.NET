<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel/FrontPanel.master" AutoEventWireup="true" CodeFile="HallList.aspx.cs" Inherits="FrontPanel_Hall_HallList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Hall</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item active">Hall</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-4">
                            <h5 class="card-title mb-2">Hall List</h5>
                        </div>
                        <div class="col-md-3 offset-md-5 text-right display">
                            <label class="lable-left">Sort By</label>
                            <asp:DropDownList ID="ddlSort" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                                <asp:ListItem Value="name" Selected="True">Name</asp:ListItem>
                                <asp:ListItem Value="price">Price</asp:ListItem>
                                <asp:ListItem Value="people">People Capacity</asp:ListItem>
                                <asp:ListItem Value="vechile">Vechile Capacity</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="true" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <asp:Repeater ID="rpHallList" runat="server" OnItemCommand="rpHallList_ItemCommand">
                            <ItemTemplate>
                                <div class="col-md-12">
                                    <div class="card shadow card-radius">
                                        <div class="row no-gutters">
                                            <div class="col-md-4 p-3">
                                                <asp:Image ID="imgHallPhoto" runat="server" Height="220" AlternateText="Hall Photo" ImageUrl='<%# Eval("Photo1") %>' CssClass="card-img-top" />
                                            </div>
                                            <div class="col-md-8">
                                                <div class="card-body p-3">
                                                    <h3 class="card-title">
                                                        <asp:Label ID="lblHallName" runat="server" Text='<%# Eval("HallName") %>'></asp:Label></h3>
                                                    <p class="card-text mb-2 font-weight-normal">
                                                        <i class="fas fa-map-marker-alt"></i>
                                                        <asp:Label ID="lblHallAddress" runat="server" Text='<%# Eval("HallAddress") %>'></asp:Label>
                                                    </p>
                                                    <p class="card-text mb-2">
                                                        <i class="fas fa-users"></i>
                                                        <asp:Label ID="lblPepopleCapacity" runat="server" Text='<%# Eval("HallPeopleCapacity") %>'></asp:Label>
                                                    </p>
                                                    <p class="card-text mb-2">
                                                        <i class="fas fa-car"></i>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("HallVechileCapacity") %>'></asp:Label>
                                                    </p>
                                                    <p class="card-text mb-2">
                                                        <i class="fas fa-rupee-sign"></i>
                                                        <asp:Label ID="sad" runat="server" Text='<%# Eval("HallPrice")+" per day" %>'></asp:Label>
                                                    </p>
                                                    <p class="card-text">
                                                        <asp:Button ID="btnMoreInfo" runat="server" Text="More Info" CssClass="btn btn-info rounded-pill mr-1" CommandName="MoreInfo" CommandArgument='<%# "~/FrontPanel/Hall/HallDetails.aspx?HallID="+ Eval("HallID") %>' />
                                                        <asp:Button ID="btnBooking" runat="server" Text="Book Now" CssClass="btn btn-primary rounded-pill" CommandName="BookHall" CommandArgument='<%# "~/FrontPanel/Order/OrderAddEdit.aspx?HallID="+ Eval("HallID") %>' />
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

