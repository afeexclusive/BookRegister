var dataTable;

$(document).ready(function () {
    loadDataTable();
   
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url":"/api/book",
            "type":"GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "author", "width": "25%" },
            { "data": "isbn", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-danger">
                                <a href="/BookLists/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>Edit</a>
                                &nbsp;
                                <a onclick=Delete('/api/book?id='+${data}) class='btn btn-danger text-white' style='cursor:pointer; width:70px;'>Delete</a>
                            </div>`
                },"width":"25%"
            }
        ],
        "language": {
            "emptyTable":"No data found"
        },
        "width":"100%"
    })
}

function Delete(url) {
    $(document).ready(function () {
        swal({
            title: "Are you sure?",
            text: "Once delete, you will not be able to recover",
            icon: "warning",
            buttons: true,
            dangerMode: true
        }).then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "DELETE",
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            dataTable.ajax.reload();
                        }
                        else {
                            toastr.error(data.message);
                        }
                    }
                });
            }
        });
    });
}