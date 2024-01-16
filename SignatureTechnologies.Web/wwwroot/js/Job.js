var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable1').DataTable({
        "ajax": {
            "url": "/Admin/JobInformation/GetAll"
        },
        "columns": [
            { "data":"title","width":"50%"},
            { "data":"department","width":"50%"},
            { "data":"startDate","width":"50%"},
            { "data": "workLocation", "width": "50%" },
            { "data":"employeeDetail.fullName","width":"50%"},
            
            {
                "data": "id",
                "render": function (data) {
                    return `
                     <div class="w-50 btn-group" role="group">
                    <a href="/Admin/JobInformation/Upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a> |
                    <a onClick=Delete('/Admin/JobInformation/Delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash"></i>Delete</a>
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