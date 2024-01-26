$(document).ready(function () {
   // alert("ok")
    GetAllData();
})

function GetAllData() {
    var rows_selected = [];
  var table =   $("#serverDataTable").DataTable({
        processing: true,
        serverSide: true,
        responsive:true,
        filter: true,
        lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        //pageSize:5,
        "language": {
            lengthMenu: "Display _MENU_ records per page",
            info: "showing page _PAGE_ of _PAGES_ page",
            infoEmpty: "No records available",
            zeroRecords: "Sorry! No data found",
           // infoFiltered: "(filtered from _MAX_ total records)"
        },
        ajax: {
            type: "Post",
            url: "/Search/GetCustomerLists",
            dataType: "json"
        },
      columnDefs: [
          {
              'targets': 0,
              orderable: false,
              sortable: false,
              'searchable': false,
              'checkboxes': {
                  'selectRow': true
              }
             
          },
          {
              orderable: false,
              sortable: true,
              'searchable': true,

              targets: 1,
          },
          {
              orderable: false,
              sortable: true,
              'searchable': true,

              targets: 2,
          },
          {
              orderable: false,
              sortable: true,
              'searchable': true,

              targets: 3,
          },
          {
              orderable: false,
              sortable: true,
              'searchable': true,

              targets: 4,
          },
          {
              orderable: false,
              sortable: true,
              'searchable': true,

              targets: 5,
          },
          {
              orderable: false,
              sortable: true,
              'searchable': true,


              targets: 6,
          }




      ],
    
        columns: [

          
           
       
            {
                "data": "id", "name": "Id", "autowidth": true,
              
                /*'className': 'dt-body-center',*/
                //render: function (data) {

                //    return '<input type="checkbox" id="check_" name="check_" value="' + data + '" />'
                //}
              render:  function(data, type, row, meta) {
                    return '<input type="checkbox" name="id[]" value="'
                        + $('<div/>').text(data).html() + '">';
                }
            },
            {
                "data": "id", "name": "Id", "autowidth": true,
                
            },

            {
                "data": "firstName", "name": "FirstName", "autowidth": true,  },
            { "data": "lastName", "name": "LastName", "autowidth": true },
            { "data": "job", "name": "Job", "autowidth": true },
            { "data": "amount", "name": "Amount", "autowidth": true },
            /*  { "data": "tdate", "name": "Tdate", "autowidth": true },*/
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
                sortable:false,
                render: function (data, type, row, meta) {
                    return `<div class="btn btn-group-sm g-1"><a href=${row.id} class="btn btn-info">View</><a href=${row.id} class="btn btn-danger">Delete</a><a href=${row.id} class="btn btn-secondary">Edit</a></div>`
                }
            }
      ],
     
      'select': {
          'style': 'multi'
      },
      order: [1, 'asc']   
  });


    //$('#check_all').on('click', function () {


    //    var rows = table.rows({ 'search': 'applied' }).nodes();
    //    $('input[type="checkbox"]', rows).prop('checked', this.checked);
    //});

    $('#check_all').change(function () {
        var cells = table.rows({ page: 'current' }).nodes();

        $(cells).find(':checkbox').prop('checked', $(this).is(':checked'));
        if ($(this).is(':checked')) {
            that.setState({ buttstate: false });
        }
        else {
            that.setState({ buttstate: true });
        }
    });


    $('#serverDataTable tbody').on('change', 'input[type="checkbox"]', function () {
        // If checkbox is not checked
        if (!this.checked) {
            var el = $('#check_all').get(0);
            // If "Select all" control is checked and has 'indeterminate' property
            if (el && el.checked && ('indeterminate' in el)) {
                // Set visual state of "Select all" control 
                // as 'indeterminate'
                el.indeterminate = true;
            }
        }
    });
    $("#formSubmit").on("submit", function (e) {
      //  alert("submit");
        var form = this;
       
        table.$('input[type="checkbox"]').each(function () {
         
            if ($.contains(document, this)) {
                if (this.checked) {
                    $(form).append(
                        $('<input/>')
                            .attr('type', 'hidden')
                            .attr('name', this.name)
                            .val(this.value)
                    )
                }
            }
        });
        $('#console').text($(form).serialize());
       // console.log("submit", $(form).serialize());
        e.preventDefault();
    });

   
    }

