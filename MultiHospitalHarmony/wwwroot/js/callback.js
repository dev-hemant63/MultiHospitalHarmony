window.addEventListener("storage", () => {
    $('.btn-close').click();
    $('input').val('');
    let obj = window.localStorage.getItem("obj");
    console.log('Result ',obj);
    if (obj.status == 'S') {
        Swal.fire({
            title: "Transaction Success",
            text: obj.remark,
            icon: "Success"
        });
    }
    else {
        Swal.fire({
            title: "Transaction Failed!",
            text: obj.remark,
            icon: "error"
        });
    }
});