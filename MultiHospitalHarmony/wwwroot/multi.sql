USE [db_New]
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetInvoiceList]    Script Date: 03-05-2024 11:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[Proc_GetInvoiceList]
@WID int,
@HospitalId int,
@loginId int,
@StatusId int =0
AS
BEGIN
	select t2.Name + ' [ '+t2.MobileNo + ' ]' CustomerInfo,t1.* from Invoices t1 
	inner join Customer t2 on t1.CustomerId = t2.Id
	where t1.WID = @WID and t1.HospitalId = @HospitalId and t1.PharmacyId = @loginId AND (t1.[Status] = @StatusId OR @StatusId = 0)
	order by t1.Id desc
END





-- Proc_GetPurchaseReportMonthWise 1,3,48,0
CREATE PROC Proc_GetPurchaseReportMonthWise
@WID int,
@HospitalId int,
@loginId int,
@Year int = 0
AS
BEGIN
	CREATE table #temp
	(
		MonthId int,
		Discount numeric(18,2),
		TotalAmount numeric(18,2),
		PaidAmount numeric(18,2),
		BalanceAmount numeric(18,2)
	)

	INSERT INTO #temp(MonthId,Discount,TotalAmount,PaidAmount,BalanceAmount)
	SELECT ID,0.00,0.00,0.00,0.00 FROM MonthlyData

	select MONTH(t1.PurchaseDate) MonthId,SUM(t1.Discount) Discount,SUM(t1.TotalAmount) TotalAmount,SUM(t1.PaidAmount) PaidAmount,SUM(t1.BalanceAmount) BalanceAmount INTO #tempData from MedicinePurchase t1
	inner join Supplier t2 ON t1.SupplierId = t2.Id
	where t1.WID = @WID AND t1.HospitalId = @HospitalId And t1.PharmacyId = @loginId
	group by MONTH(t1.PurchaseDate)


	UPDATE t
	SET t.Discount = td.Discount,t.TotalAmount = td.TotalAmount,t.PaidAmount = td.PaidAmount,t.BalanceAmount = td.BalanceAmount
	FROM #temp t
	INNER JOIN #tempData td ON t.MonthId = td.MonthId

	SELECT t1.*,t2.[MonthName] FROM #temp t1 
	inner join MonthlyData t2 ON t1.MonthId = t2.ID
END



-- Create the table
CREATE TABLE MonthlyData (
    ID INT PRIMARY KEY,
    MonthName NVARCHAR(50)
);

-- Insert data for 12 months
INSERT INTO MonthlyData (ID, MonthName) VALUES 
(1, 'January'),
(2, 'February'),
(3, 'March'),
(4, 'April'),
(5, 'May'),
(6, 'June'),
(7, 'July'),
(8, 'August'),
(9, 'September'),
(10, 'October'),
(11, 'November'),
(12, 'December');











-- Proc_GetSaleReportMonthWise 1,3,48,0
CREATE PROC Proc_GetSaleReportMonthWise
@WID int,
@HospitalId int,
@loginId int,
@Year int = 0
AS
BEGIN
	CREATE table #temp
	(
		MonthId int,
		SubTotalAmount numeric(18,2),
		GST numeric(18,2),
		Discount numeric(18,2),
		TotalAmount numeric(18,2),
		PaidAmount numeric(18,2),
		BalanceAmount numeric(18,2)
	)

	INSERT INTO #temp(MonthId,SubTotalAmount,GST,Discount,TotalAmount,PaidAmount,BalanceAmount)
	SELECT ID,0.00,0.00,0.00,0.00,0.00,0.00 FROM MonthlyData

	select MONTH(t1.InvoiceDate) MonthId,SUM(t1.SubTotalAmount) SubTotalAmount,SUM(t1.GST) GST,SUM(t1.Discount) Discount,SUM(t1.TotalPrice) TotalAmount,SUM(t1.PaidAmount) PaidAmount,SUM(t1.BalanceAmount) BalanceAmount INTO #tempData from Invoices t1
	where t1.WID = @WID AND t1.HospitalId = @HospitalId And t1.PharmacyId = @loginId
	group by MONTH(t1.InvoiceDate)


	UPDATE t
	SET t.Discount = td.Discount,t.TotalAmount = td.TotalAmount,t.PaidAmount = td.PaidAmount,t.BalanceAmount = td.BalanceAmount,t.SubTotalAmount = td.SubTotalAmount,t.GST = td.GST
	FROM #temp t
	INNER JOIN #tempData td ON t.MonthId = td.MonthId

	SELECT t1.*,t2.[MonthName] FROM #temp t1 
	inner join MonthlyData t2 ON t1.MonthId = t2.ID
END