var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    //retrieves dtload and calls datatable on dtLoad
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/customer",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "customerName", "width": "20%" },
            { "data": "timeSpan", "width": "20%" },
            { "data": "timeStamp", "width": "30%" },
            {
                "data": "id",
                //render 2 buttons here
                "render": function (data) {
                    //return div w/ 2 buttons- edit & delete which are instantiated in CustomerController.cs
                    return `<div class="text-center">
                  
                    <a class='btn btn-danger text-white' style='cursor:pointer; width 70px;'
                        onClick=Delete('/api/Customer?id='+${data})>
                        Delete
                    </a>
                    &nbsp;
                    <a href="/CustomerList/UpdateInsert?id=${data}"
                    class='btn btn-success text-white' style='cursor:pointer; width 70px;'>
                        Edit
                    </a>
                   
                    </div>`;
                },
                "width": "40%"

            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//creates popup for confirmation of deletion
//also creates toaster message upon successful deletion
function Delete(url) {
    window.swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true, //adds cancel button
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    //if delete is successful then show message, otherwise
                    if (data.success) {
                        window.toastr.success(data.message);
                        dataTable.ajax.reload();

                    } else {
                        window.toastr.error(data.message);
                    }
                }
            });
        }
    });
}