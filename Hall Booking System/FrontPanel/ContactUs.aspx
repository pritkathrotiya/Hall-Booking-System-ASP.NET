<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanel/FrontPanel.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="FrontPanel_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/FrontPanel/Assets/css/custom.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Contact Us</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/FrontPanel/Hall/HallList.aspx") %>'>Hall</a></li>
    <li class="breadcrumb-item active">ContactUs</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title mb-0">Contact Us</h5>
                </div>
                <div class="cardd-body">
                    <div class="col-md-8 offset-md-2 mb-5">
                        <h1 class="mb-4 contact-heading">Have any queries? We’re always here to help!</h1>
                        <h1 class="font-italic">
                            <p>Write us at <a href="mailto:p2rtechnology@gmail.com">p2rtechnology@gmail.com</a></p>
                        </h1>
                    </div>
                    <div class="text-center mb-4">
                        <h1 class="mb-4 contact-heading">Follow Us On</h1>
                        <h1>
                            <a href="#" class="text-dark ml-1 mr-1"><i class="fab fa-facebook"></i></a>
                            <a href="#" class="text-dark ml-1 mr-1"><i class="fab fa-instagram"></i></a>
                            <a href="#" class="text-dark ml-1 mr-1"><i class="fab fa-twitter"></i></a>
                            <a href="#" class="text-dark ml-1 mr-1"><i class="fab fa-github"></i></a>
                        </h1>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>

