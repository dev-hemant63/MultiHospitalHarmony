window.addEventListener("storage", () => {
    $('.btn-close').click();
    $('input').val('');
    let obj = JSON.parse(window.localStorage.getItem("obj"));
    if (obj.status == 'S') {
        Swal.fire({
            title: "Transaction Success",
            text: obj.remark,
            icon: "success"
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