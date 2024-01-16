var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url":"/Admin/Employee/GetAll"
        },
        "columns": [
            { "data":"fullName","width":"50%"},
            { "data":"address","width":"50%"},
            { "data":"phoneNumber","width":"50%"},
            { "data": "idCard", "width": "50%" },
            { "data": "doBirth".toString("dd/mm/yyyy"), "width": "50%" },
            { "data":"maritalStatus","width":"50%"},
            { "data":"emailAddress","width":"50%"},
            
            {
                "data": "id",
                "render": function (data) {
                    return `
                     <div class="w-50 btn-group" role="group">
                    <a href="/Admin/Employee/Upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a> |
                    <a onClick=Delete('/Admin/Employee/Delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash"></i>Delete</a>
                    </div>
                            `
                },
                "width": "50%"
            },
        ],
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}