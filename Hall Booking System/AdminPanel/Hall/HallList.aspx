<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel/AdminPanel.master" AutoEventWireup="true" CodeFile="HallList.aspx.cs" Inherits="AdminPanel_Hall_HallList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <h1 class="header-title">Area</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNavigation" runat="Server">
    <li class="breadcrumb-item"><a href='<%=ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>'>Dashboard</a></li>
    <li class="breadcrumb-item active">Hall List</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-4">
                            <h5 class="card-title mb-0">Hall List</h5>
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnAddHall" runat="server" Text="Add Hall" CssClass="btn btn-info mb-2 float-right" OnClick="btnAddHall_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvHall" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowCommand="gvHall_RowCommand" OnRowDataBound="gvHall_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="HallName" HeaderText="Hall Name" />
                                    <asp:BoundField DataField="HallAddress" HeaderText="Address" />
                                    <asp:BoundField DataField="AreaName" HeaderText="Area" />
                                    <asp:BoundField DataField="CityName" HeaderText="City" />
                                    <asp:BoundField DataField="HallPeopleCapacity" HeaderText="People Capacity" />
                                    <asp:BoundField DataField="HallVechileCapacity" HeaderText="Vechile Capacity" />
                                    <asp:BoundField DataField="HallPrice" HeaderText="Price" />
                                    <asp:BoundField DataField="ManagerName" HeaderText="Manager Name" />
                                    <asp:TemplateField HeaderText="Oprations" HeaderStyle-Width="105">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger rounded-pill btn-sm button-custom"
                                                CommandName="DeleteRecord" CommandArgument='<%# Eval("HallID") %>' />
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning rounded-pill btn-sm text-dark button-custom"
                                                CommandName="EditRecord" CommandArgument='<%# "~/AdminPanel/Hall/HallAddEdit.aspx?HallID="+ Eval("HallID") %>' />
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

