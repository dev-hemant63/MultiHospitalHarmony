var addRow = () => {
    if ($('#ddlSupplier').val() == '' || $('#ddlSupplier').val() == '0') {
        Swal.fire({
            title: "Failed!!",
            text: "Please select supplier!",
            icon: "error"
        });
        return false;
    }
    let rowCount = $('#addpurchase tr.item').length;
    rowCount = rowCount + 1;
    let _html = `<tr data-rowid="1" class="item">
                                        <td>
                                            <select class="form-control form-control-sm" onchange="handelMedicine('${rowCount}')" id="ddlMedicine_${rowCount}">
                                                <option value="0">:: SELECT Medicine ::</option>
                                            </select>
                                        </td>
                                        <td>
                                            <input type="text" class="form-control form-control-sm" id="txtBatch_${rowCount}" />
                                        </td>
                                        <td>
                                            <input type="date" class="form-control form-control-sm" id="txtExpiry_${rowCount}" />
                                        </td>
                                        <td>
                                            <select class="form-control" id="ddlBox_${rowCount}">
                                                <option value="0">:: SELECT BOX ::</option>
                                            </select>
                                        </td>
                                        <td>
                                            <input type="number" class="form-control form-control-sm" oninput="handlePrice('${rowCount}')" id="txtBoxQty_${rowCount}" />
                                        </td>
                                        <td>
                                            <input type="number" class="form-control form-control-sm" id="txtTotalQty_${rowCount}" />
                                        </td>
                                        <td>
                                            <input type="number" class="form-control form-control-sm" oninput="handlePrice('${rowCount}')" id="txtSupplierPrice_${rowCount}" />
                                        </td>
                                        <td>
                                            <input type="number" class="form-control form-control-sm" id="txtMRP_${rowCount}" />
                                        </td>
                                        <td>
                                            <input type="number" class="form-control form-control-sm" id="txtTotalPrice_${rowCount}" />
                                        </td>
                                        <td>
                                            <button class="btn btn-danger light btn-sm delete"><i class="fa fa-trash"></i></button>
                                        </td>
                                    </tr>`;
    $("#addpurchase tr.item:last").after(_html);
    bindMedicine(rowCount);
}
$(document).on('click', '.delete', function () {
    let rowCount = $('#addpurchase tr.item').length;
    if (rowCount > 1) {
        $(this).closest('tr').remove();
    } else {
        $('input').val('');
        $('select').val('0');
    }
});
var bindSupliers = () => {
    $.post('/Medicine/GetSupliers').done((response) => {
        if (response.success) {
            let _option = response.data.map((v, i) => {
                return `<option value='${v.id}'>${v.name}</option>`;
            });
            $('#ddlSupplier').empty().append('<option value="0">:: Select ::</option>').append(_option);
            bindPaymentModes();
        }
    }).fail((xhr) => {
        console.log(xhr);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}
var bindPaymentModes = () => {
    $.post('/Purchase/GetPaymentModes').done((response) => {
        if (response.success) {
            let _option = response.data.map((v, i) => {
                return `<option value='${v.id}'>${v.name}</option>`;
            });
            $('#ddlPaymentType').empty().append('<option value="0">:: Select ::</option>').append(_option);
            $('#ddlPaymnetMethod').empty().append('<option value="0">:: Select ::</option>').append(_option);
        }
    }).fail((xhr) => {
        console.log(xhr);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}
var bindMedicine = (id) => {
    let SupplierId = $('#ddlSupplier').val();
    $.post('/Purchase/GetMedicineList', { SupplierId: SupplierId }).done((result) => {
        console.log('GetMedicineList', result);
        if (result.success) {
            let _option = result.data.map((v, i) => {
                return `<option value="${v.id}" data-box="${v.boxSize}" data-supplierprice="${v.supplierPrice}">${v.name}</option>`;
            });
            $('#ddlMedicine_' + id).empty().append('<option value="0">:: Select ::</option>').append(_option);
            bindBoxPattern(id);
        }
    }).fail(() => {
        console.log(xhr);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}
var bindBoxPattern = (id) => {
    $.post('/Medicine/GetLeafSetting').done((result) => {
        if (result.success) {
            let _option = result.data.map((v, i) => {
                return `<option value="${v.id}" data-totalnumber="${v.totalNumber}">${v.leafType} (${v.totalNumber})</option>`;
            });
            $('#ddlBox_' + id).empty().append('<option value="0">:: Select ::</option>').append(_option);
        }
    }).fail(() => {
        console.log(xhr);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}
var handelMedicine = (id) => {
    let boxPattern = $('#ddlMedicine_' + id + ' option:selected').data('box');
    let supplierprice = $('#ddlMedicine_' + id + ' option:selected').data('supplierprice');
    $('#ddlBox_' + id).val(boxPattern);
    $('#txtSupplierPrice_' + id).val(supplierprice);
}
var handlePrice = (id) => {
    let subtotal = 0;
    let boxQty = $('#txtBoxQty_' + id).val();
    let totalNumber = $('#ddlBox_' + id + ' option:selected').data('totalnumber');
    $('#txtTotalQty_' + id).val((parseFloat(boxQty) * parseFloat(totalNumber)));
    let supplierprice = $('#txtSupplierPrice_' + id).val();
    let totalPrice = (parseFloat(supplierprice) * parseFloat(boxQty));
    $('#txtTotalPrice_' + id).val(totalPrice);
    $('#addpurchase tr.item').each(function (i, v) {
        subtotal += parseFloat($(v).find('td:eq(8) input').val());
    });
    $('#txtsubtotal').val(subtotal);
    let discount = $('#txtDiscount').val();
    let grandTotal = (parseFloat(subtotal) - parseFloat(discount));
    $('#txtGrandTotal').val(grandTotal);

    let paidAmount = $('#paidAmount').val();
    $('#txtBalanceAmount').val((parseFloat(grandTotal)  - parseFloat(paidAmount)));
}
var saveData = () => {

    var MedicinePurchaseDetails = [];
    let obj = {
        SupplierId: $('#ddlSupplier').val(),
        InvoiceNo: $('#txtInvoiceNo').val(),
        PaymentTypeId: $('#ddlPaymentType').val(),
        PurchaseDate: $('#txtdate').val(),
        Details: $('#txtDetails').val(),
        Remark: $('#txtRemark').val(),
        TotalAmount: $('#txtGrandTotal').val(),
        PaidAmount: $('#paidAmount').val(),
        SubTotalAmount: $('#txtsubtotal').val(),
        Discount: $('#txtDiscount').val(),
        BalanceAmount: $('#txtBalanceAmount').val(),
        MedicinePurchaseDetails:[]
    }
    $('#addpurchase tr.item').each(function (i, v) {
        let obj = {
            MedicineId: $(v).find('td:eq(0) select').val(),
            BatchCode: $(v).find('td:eq(1) input').val(),
            ExpiryDate: $(v).find('td:eq(2) input').val(),
            BoxPattern: $(v).find('td:eq(3) select').val(),
            StockQty: $(v).find('td:eq(4) input').val(),
            BoxQty: $(v).find('td:eq(4) input').val(),
            TotalQuantity: $(v).find('td:eq(5) input').val(),
            SupplierPrice: $(v).find('td:eq(6) input').val(),
            MRP: $(v).find('td:eq(7) input').val(),
            TotalPurchasePrice: $(v).find('td:eq(8) input').val(),
        }
        MedicinePurchaseDetails.push(obj);
    });
    obj.MedicinePurchaseDetails = MedicinePurchaseDetails;
    $.post('/Purchase/SaveMedicinePurchase', obj).done((res) => {
        Swal.fire({
            title: res.success == true ? "Success" : "Failed",
            text: res.message,
            icon: res.success == true ? "success" : "error"
        });
        if (res.success == true) {
            $('input').val('');
            $('select').val('');
        }
    }).fail((xhr) => {
        console.log(xhr);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}
var loadData = () => {
    $.post('/Purchase/GetMedicinePurchase').done((result) => {
        if (result.success) {
            console.log('result', result);
            let _html = result.data.map((v, i) => {

                let status = '';
                let option = '';
                if (v.status == 1) {
                    status = '<span class="badge badge-sm badge-success">Order Completed</span>';
                }
                if (v.status == 2) {
                    status = '<span class="badge badge-sm badge-danger">Order Canceled</span>';
                }
                if (v.status == 3) {
                    status = '<span class="badge badge-sm badge-danger">Order Returned</span>';
                }
                if (v.status == 4) {
                    option = `<a class="dropdown-item" href="javascript:void(0)" data-bs-toggle="modal" data-bs-target="#exampleModalCenter" onclick="paymentModel('${v.balanceAmount}','${v.id}')">Pay</a>`;
                    status = '<span class="badge badge-sm badge-info">Partially Paid</span>';
                }

                return `
                <tr>
                <td>${i + 1}</td>
                <td>
                <div class="btn-group mb-1">
                            <button class="btn btn-outline-dark btn-sm dropdown-toggle" type="button" data-bs-toggle="dropdown">
                            </button>
                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="/Purchase/ViewPurchaseDetails?Id=${v.id}">View</a>
                                ${option}
                            </div>
                        </div>
                </td>
                <td>${v.supplier}</td>
                <td>${v.invoiceNo}</td>
                <td>${status}</td>
                <td>${v.subTotalAmount}</td>
                <td>${v.discount}</td>
                <td>${v.totalAmount}</td>
                <td>${v.paidAmount}</td>
                <td>${v.balanceAmount}</td>
                <td>${v.purchaseDate}</td>
                <td>${v.details}</td>
                <td>${v.remark}</td>
                <td>${v.entryAt}</td>
                </tr>
                `;
            });
            $('#datagrid tbody').empty().append(_html);
        }
    }).fail((xhr) => {
        console.log(xhr);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}
var paymentModel = (amount,id) => {
    $('#dueamount').val(amount);
    $('#hdnId').val(id);
    bindPaymentModes();
}
var payDueAmount = () => {
    let obj = {
        Id: $('#hdnId').val(),
        DueAmount: $('#dueamount').val(),
        PaidAmount: $('#paidamount').val(),
        Remark: $('#remark').val(),
        PaymentMode: $('#ddlPaymnetMethod').val(),
    }
    $.post('/Purchase/PayPurchaseDueAmount',obj).done((res) => {
        Swal.fire({
            title: res.success == true ? "Success" : "Failed",
            text: res.message,
            icon: res.success == true ? "success" : "error"
        });
        if (res.success == true) {
            $('input').val('');
            $('select').val('0');
            $('.btn-close').click();
            loadData();
        }
    }).fail((xhr) => {
        console.log(xhr);
        Swal.fire({
            title: "Failed!!",
            text: "Server Error!",
            icon: "error"
        });
    });
}