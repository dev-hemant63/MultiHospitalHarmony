let login = () => {
    if (!valiadteInputs()) {
        return false;
    }
    let obj = {
        EmailId:$('#txtEmail').val(),
        Password:$('#txtPassword').val(),
    }
    $.post('/account/login', obj).done((res) => {
        console.log('res ', res);
        alert(res.message);
        if (res.success == true) {
            window.location.href = res.data.redirectURL;
        }
    }).fail((xhr) => {
        console.log(xhr.responseText);
    });
}