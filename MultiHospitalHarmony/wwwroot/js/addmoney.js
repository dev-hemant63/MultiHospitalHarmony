var initiatePaymentConfirm = () => {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to continue!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Next"
    }).then((result) => {
        if (result.isConfirmed) {
            openAddMoney();
        }
    });
}

var openAddMoney = () => {
    $('#txtAmount').attr('txtAmount',true);
    $('#btnaddmoney').click();
}
$('#btnAdd').click(function () {
    if (!valiadteInputs()) {
        return false;
    }
    initiatePayment();
});
var initiatePayment = () => {
    $.post('/addmoney/InitiateTxn', {
        amount: $('#txtAmount').val()
    }).done((res) => {
        if (res.success) {
            window.open(
                res.data.url,
                "_blank",
                "width=800,height=600,top=100,left=100,resizable=yes"
            );
        }
        else {
            Swal.fire({
                title: "Failed!",
                text: res.message,
                icon: "error"
            });
        }
    }).fail((xhr) => {
        console.log(xhr.responseText);
        Swal.fire({
            title: "Failed!",
            text: "Server Error",
            icon: "error"
        });
    });
}
