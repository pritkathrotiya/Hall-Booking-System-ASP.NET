<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">City</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item active">City List</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">City List</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnAddCity" runat="server" Text="Add City" CssClass="btn btn-info mb-3 float-right" OnClick="btnAddCity_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowCommand="gvCity_RowCommand" OnRowDataBound="gvCity_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="CityName" HeaderText="City Name" />
                                    <asp:BoundField DataField="CityCode" HeaderText="City Code" />
                                    <asp:TemplateField HeaderText="Oprations" HeaderStyle-Width="105">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger rounded-pill btn-sm button-custom"
                                                CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>' />
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning rounded-pill text-dark btn-sm button-custom"
                                                CommandName="EditRecord" CommandArgument='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID="+ Eval("CityID") %>' />
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

