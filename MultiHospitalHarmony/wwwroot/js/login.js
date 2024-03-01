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
            alert(res.message);
        }
    }).fail((xhr) => {
        console.log(xhr.responseText);
    });
}