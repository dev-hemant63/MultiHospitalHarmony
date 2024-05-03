-- Proc_GetPharmacyDashboardData 1,3,48
Alter proc Proc_GetPharmacyDashboardData
@WID int,
@HospitalId int,
@loginId int
AS
BEGIN
	DECLARE @TotalCustomer int,@TotalMedicine int,@OutOfStock int,@ExpiredMedicine int,@SaleInfo nvarchar(max),@TotalSales numeric(18,2),
			@TotalPurchase numeric(18,2),@CashReceived numeric(18,2),@BankReceive numeric(18,2)

	SELECT @TotalCustomer = COUNT(*) FROM Customer WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId
	SELECT @TotalMedicine = COUNT(*) FROM Medicines WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId
	SELECT @OutOfStock = COUNT(*) FROM MedicineInventory WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId AND TotalQty = 0
	SELECT @ExpiredMedicine = COUNT(*) FROM MedicineInventory WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId AND CONVERT(date,ExpiryDate,103) < CONVERT(date,GETDATE(),103)

	SELECT @TotalSales = SUM(PaidAmount) FROM Invoices WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId
	SELECT @TotalPurchase = SUM(PaidAmount) FROM MedicinePurchase WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId
	SELECT @CashReceived = SUM(PaidAmount) FROM MedicinePurchasePaymentDetails WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId And PaymentModeId = 1 AND PurchaseId = 0
	SELECT @BankReceive = SUM(PaidAmount) FROM MedicinePurchasePaymentDetails WHERE WID = @WID AND HospitalId = @HospitalId AND PharmacyId = @loginId And PaymentModeId <> 1 AND PurchaseId = 0

	SELECT c.Name + ' ['+c.MobileNo + ' ]' CustomerInfo,i.InvoiceNo,i.TotalPrice,i.PaidAmount,i.BalanceAmount,i.EntryAt Into #tempSaleInfo FROM Invoices i 
	inner join Customer c on i.CustomerId = c.Id

	SET @SaleInfo = (select * from #tempSaleInfo for json auto)

	SELECT ISNULL(@TotalCustomer,0) TotalCustomer,ISNULL(@TotalMedicine,0) TotalMedicine,ISNULL(@OutOfStock,0) OutOfStock,ISNULL(@ExpiredMedicine,0) ExpiredMedicine,ISNULL(@TotalSales,0) TotalSales,ISNULL(@TotalPurchase,0)
	 TotalPurchase,ISNULL(@CashReceived,0) CashReceived,ISNULL(@BankReceive,0) BankReceive,@SaleInfo SaleInfo
END