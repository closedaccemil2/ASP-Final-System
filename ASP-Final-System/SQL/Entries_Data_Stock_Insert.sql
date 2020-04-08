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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Emil Perez Barranco>
-- Create date: <April 6th, 2020>
-- Description:	<Trigger for the Stock Table's Insert>
-- =============================================
ALTER TRIGGER Entries_Data_Stock
   ON  Stock 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
		@prod varchar(Max), 
		@time varchar(Max), 
		@prov varchar(Max)
	Select @prod = Product, @time = TimeStamp, @prov = Provider from inserted
    -- Insert statements for trigger here

	Insert Into Entries (Product ,Provider, TimeStamp)
	Values (@prod, @prov, @time)
END
GO
