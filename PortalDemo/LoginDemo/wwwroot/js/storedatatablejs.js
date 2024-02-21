$(document).ready(function () {


    $("#datatable-2").DataTable({
        bProcessing: true,
        bLengthChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        pageLength: 5,
        bfilter: true,
        bSort: true,

        /*bpaginate: true,*/
        "pagingType": "simple_numbers",
        "language": {
            "paginate": {
                "previous": '<i class="fa fa-angle-left" style="color: #FFF"></i>',
                "next": '<i class="fa fa-angle-right" style="color: #FFF"></i>'
            },
            "lengthMenu": " _MENU_ records per page",
            //"zeroRecords": "Sorry! No Data available",
            //"info": "Showing page _PAGE_ of _PAGES_ records",
            //"infoEmpty": "No records available .....",
            //"infoFiltered": "(filtered from _MAX_ total records)"
        },

        //"columnDefs": [

        //    {
        //        "targets": [6],
        //        "visible": true,
        //        "searchable": false,
        //        "sortable": false
        //    },

        //],

    });
});