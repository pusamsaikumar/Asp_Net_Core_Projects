$(document).ready(function () {
    getCustomerList();
});

//$("#dataTableId").DataTable({
//    "language": {
//        "lengthMenu": "Display _MENU_ records per page",
//        "zeroRecords": "Nothing found - sorry",
//        "info": "Showing page _PAGE_ of _PAGES_",
//        "infoEmpty": "No records available",
//        "infoFiltered": "(filtered from _MAX_ total records)"
//    }
//})
function getCustomerList() {
    $.ajax(
        {
            url: '/Search/GetCustomerList',
            type: "Get",
            dataType: "json",
            success: onSuccess
        }

        )
}
function onSuccess(response) {
   
    $("#dataTableId").DataTable({
        bProcessing: true,
        bLengthChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        pageLength:5,
        bfilter: true,
        bSort: true,
        bPaginate: true,
        "language": {
            "lengthMenu": "Display _MENU_ records per page",
            "zeroRecords": "Sorry! No Data available",
            "info": "Showing page _PAGE_ of _PAGES_ records",
            "infoEmpty": "No records available .....",
            "infoFiltered": "(filtered from _MAX_ total records)"
        },

        data: response,
        columns: [
            {
                data: "Id", name:"Id",autowidth:true,
                render: function (data,type,row,meta) {
                    return row.id
                }
            },
            {
                data: "FirstName", name: "FirstName", autowidth: true,
            render: function (data, type, row, meta) {
                return row.firstName
            }
            },
            {
                data: "LastName", name: "LastName", autowidth: true,
                 render: function (data, type, row, meta) {
                  return row.lastName
                   }
            },
            {
                data: " Job", name: "Job", autowidth: true,
                render: function (data, type, row, meta) {
                    return row.job
                }
            },
            {
                data: "Amount", name: "Amount", autowidth: true,
                render: function (data, type, row, meta) {
                    return row.amount
                }
            },
            {
                data: "Tdate", name: "Tdate", autowidth: true,
               
                render: function (data, type, row, meta) {
                    let date = row.tdate.split("T")[0];
                    let yyyy = date.split("-")[0];
                    let mm = date.split("-")[1];
                    let dd = date.split("-")[2];
                    var dt = dd + "/" + mm + "/" + yyyy;
                   //return row.tdate.toString('dd-MM-yyyy');
                    // return date;
                    return dt;
                    
                }
            },
            {
                render: function (data, type, row, meta) {
                    return`<div class="btn btn-group-sm g-1"><a href=${row.id} class="btn btn-info">View</><a href=${row.id} class="btn btn-danger">Delete</a><a href=${row.id} class="btn btn-secondary">Edit</a></div>`
                }
            }
            //{
            //    render: function (data, type, row, meta) {
            //        return '<a href="#" class="btn btn-danger">Delete</a>'
            //    }
            //},
            //{
            //    render: function (data, type, row, meta) {
            //        return '<a href="#" class="btn btn-secondary">Edit</a>'
            //    }
            //}
        ],
        columnDefs: [
            {
                targets: [0],
               // visible: false,
                searchable: false,
               
            }
        ]
      




    });
}
