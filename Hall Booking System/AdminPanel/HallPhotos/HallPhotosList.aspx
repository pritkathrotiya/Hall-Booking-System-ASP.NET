<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="HallPhotosList.aspx.cs" Inherits="AdminPanel_HallPhotos_HallPhotosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Hall</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item active">HallPhotosList</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">Hall List With Photos</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <asp:Repeater ID="rptHallPhotos" runat="server" OnItemCommand="rptHallPhotos_ItemCommand">
                            <ItemTemplate>
                                <div class="col-md-4">
                                    <div class="card shadow-custom card-radius">
                                        <asp:Image ID="imgHallPhoto" runat="server" AlternateText="Hall Photo" ImageUrl='<%# Eval("Photo1") %>' CssClass="card-img-top image-radius" />
                                        <div class="card-body pb-3">
                                            <h4 class="card-title">
                                                <asp:Label ID="lblHallName" runat="server" Text='<%# Eval("HallName") %>'></asp:Label>
                                            </h4>
                                            <p class="card-text">
                                                <i class="fas fa-map-marker-alt"></i>
                                                <asp:Label ID="lblHallAddress" runat="server" Text='<%# Eval("HallAddress") %>'></asp:Label>
                                            </p>
                                        </div>
                                        <div class="card-body pt-0">
                                            <asp:Button ID="btnMorePhotos" runat="server" Text="More Photos" CssClass="btn btn-info rounded-pill font-weight-bold" CommandName="MorePhotos" CommandArgument='<%# "~/AdminPanel/HallPhotos/HallPhotosAddEdit.aspx?HallPhotoID="+ Eval("HallPhotoID") %>' />
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

