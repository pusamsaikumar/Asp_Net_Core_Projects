//Moved from _FindShopperResults partial view 
$(document).ready(function () {
    //////debugger;
    var table = $('#content-table1').DataTable({
        "sDom": 'T<"clear">lfrtip',
        "oTableTools": {
            "sSwfPath": "https://cdn.datatables.net/tabletools/2.2.2/swf/copy_csv_xls_pdf.swf",
            "aButtons": [
                {
                    "sExtends": "copy",
                    "mColumns": [1, 2, 3, 4, 5]
                },
                {
                    "sExtends": "csv",
                    "mColumns": [1, 2, 3, 4, 5]
                },
                {
                    "sExtends": "pdf",
                    "mColumns": [1, 2, 3, 4, 5]
                },
                {
                    "sExtends": "print",
                    "mColumns": [1, 2, 3, 4, 5]
                },
                {
                    "sExtends": "xls",
                    "mColumns": [1, 2, 3, 4, 5]
                },
            ],
        },
        "bSort": false
    });
});

//Find Shopper sortable logic
$(".sortable").click(function () {
    var o = $(this).hasClass('asc') ? 'desc' : 'asc';
    $('.sortable').removeClass('asc').removeClass('desc');
    $(this).addClass(o);

    var colIndex = $(this).prevAll().length;
    var tbod = $(this).closest("table").find("tbody");
    var rows = tbod.find("tr");

    rows.sort(function (a, b) {
        var A = $(a).find("td").eq(colIndex).text();
        var B = $(b).find("td").eq(colIndex).text();

        if (!isNaN(A)) A = Number(A);
        if (!isNaN(B)) B = Number(B);

        return o == 'asc' ? A > B : B > A;
    });

    $.each(rows, function (index, ele) {
        tbod.append(ele);
    });
});

//End of code Changes - Support portal