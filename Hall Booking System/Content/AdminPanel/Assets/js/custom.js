/*Datatable JS*/
$(function () {
    $('#cphPageContent_gvCity').DataTable();
});

$(function () {
    $('#cphPageContent_gvArea').DataTable();
});

$(function () {
    $('#cphPageContent_gvManager').DataTable();
});

$(function () {
    $('#cphPageContent_gvHall').DataTable();
});

$(function () {
    $("#cphPageContent_gvOrder").DataTable({
        "order": [[0, "desc"]]
    });
});