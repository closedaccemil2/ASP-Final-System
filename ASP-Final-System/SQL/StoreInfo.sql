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
-- Create date: <April 6th, 2020>
-- Description:	<Stored Procedure for Final Project System>
-- =============================================
ALTER PROCEDURE StoreInfo
	@Desc varchar(Max),
	@Date DateTime
AS
BEGIN
		Insert Into [Audit] (Description, LogDate) 
		Values (@Desc, @Date)
END;

