-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE Storage
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Emil Pérez Barranco>
-- Create date: <April 5th, 2020>
-- Description:	<Stored Procedure for Final Project System>
-- =============================================
ALTER PROCEDURE CreateBill
	@ClientName varchar(Max),
	@ProductName varchar(Max),
	@Quantity int,
	@TotalPrice varchar(Max),
	@SaleDate DateTime
AS
BEGIN
	INSERT INTO Billing
	Values(@ClientName, @ProductName, @Quantity, @TotalPrice, @SaleDate)
	Update Stock
	Set Quantity -= @Quantity
	Where Product = @ProductName
END;

