let login = () => {
    if (!valiadteInputs()) {
        return false;
    }
    let obj = {
        UserName: $('#txtUserName').val(),
        Password:$('#txtPassword').val(),
    }
    $.post('/account/login', obj).done((res) => {
        if (res.success == true) {
            window.location.href = res.data.redirectURL;
        }
        else {
            Swal.fire({
                title: "Failed!!",
                text: res.message,
                icon: "error"
            });
        }
    }).fail((xhr) => {
        console.log(xhr.responseText);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}