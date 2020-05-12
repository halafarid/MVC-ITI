function handleDelete(id) {
    let result = confirm("Are you sure to delete this employee?");
    if (result) {
        $.ajax({
            url: "/Employees/Delete/" + id,
            type: "POST",
            success: function (response) {
                if (response) {
                    let res = "#" + id;
                    res.remove();
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    }
};

function OnSuccess(employee) {
    $("#form0")[0].reset();
    $("#employee-modal").modal("hide");
}