-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
USE Storage
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Emil Perez Barranco>
-- Create date: <April 6th, 2020>
-- Description:	<Trigger for the Billing Table's Insert>
-- =============================================
ALTER TRIGGER Billing_Update_Stock
   ON  Billing 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--ALTER TABLE Stock DISABLE TRIGGER Entries_Data_Stock
	ALTER TABLE Stock DISABLE TRIGGER Entries_Update_Stock
	SET NOCOUNT ON;
	DECLARE 
		@quan varchar(Max), 
		@prod varchar(Max), 
		@time varchar(Max)
	Select @quan = Quantity, @prod = ProductName, @time = SaleDate from inserted

    -- Insert statements for trigger here
	--ALTER TABLE Stock ENABLE TRIGGER Entries_Data_Stock
	ALTER TABLE Stock ENABLE TRIGGER Entries_Update_Stock
END
GO