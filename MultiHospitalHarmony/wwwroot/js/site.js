let valiadteInputs = () => {
    let isValid = false;
    $('input:required, select:required').removeClass("is-invalid");
    $('input:required, select:required').addClass("is-valid");
    let inputs = $('input:required, select:required');
    let filteredInputs = inputs.filter(function () {
        let value = $(this).val();
        return value === "";
    });
    if (filteredInputs.length > 0) {
        filteredInputs.each(function () {
            isValid = false;
            var input = $(this);
            if (input[0].required) {
                if (input[0].value != '') {
                    input.removeClass("is-invalid");
                    input.addClass("is-valid");
                }
                else {
                    input.addClass("is-invalid");
                }
            }
        });
    }
    else {
        isValid = true;
    }
    return isValid;
}
let getAreaByPincode = () => {
    $.post('/GetDetailsByPincode', { pincode: $('#txtZipCode').val() }).done((res) => {
        if (res.success) {
            $('#ddlcity').val(res.data.cityId);
            $('#ddlState').val(res.data.stateId);
        }        
    }).fail((xhr) => {
        console.log(xhr.responseText);
        alert('Server Error!');
    });
}
