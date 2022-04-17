<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">City</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/City/CityList.aspx") %>'>City</a></li>
    <li class="breadcrumb-item active"><asp:Label ID="lblNavigationHeader" runat="server"></asp:Label></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0"><asp:Label ID="lblPageHeader" runat="server"></asp:Label></h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">City Name<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfCityName" runat="server"
                                ErrorMessage="Enter City Name"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtCityName" ValidationGroup="Save" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-2 col-form-label">City Code<span class="text-danger">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCityCode" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCityCode" runat="server"
                                ErrorMessage="Enter City Code"
                                CssClass="text-danger" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtCityCode" ValidationGroup="Save" />
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

