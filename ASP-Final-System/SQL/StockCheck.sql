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
ALTER PROCEDURE StockCheck
	@Quantity int,
	@ProductName varchar(Max),
	@ProviderName varchar(Max),
	@TimeStamp DateTime
AS
BEGIN
   IF NOT EXISTS (SELECT * FROM Stock 
                   WHERE Product = @ProductName
                   AND Provider = @ProviderName)
   BEGIN
       INSERT INTO Stock 
       VALUES (@Quantity, @ProductName, @ProviderName, @TimeStamp)
   END
   ELSE 
   BEGIN
       UPDATE Stock
	   SET Quantity += @Quantity
	   WHERE Product = @ProductName
       AND Provider = @ProviderName;
   END
END;

