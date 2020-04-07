Use Storage;

-- Stock Table Create -- 

Create Table Stock (
	Id int Not Null Identity(1,1),
	Quantity int Not Null,
	Product varchar(Max) Not Null,
	Provider varchar(Max) Not Null,
	TimeStamp varchar(Max) Not Null,
	Primary Key (Id)
);

-- Dummy Data for Stock --

Insert Into Stock
Values ('10', 'Sierra X7',  'Barbosa Inc.', Current_Timestamp)
Insert Into Stock
Values ('20', 'Lanzallamas #13',  'Barbosa Inc.', Current_Timestamp)
Insert Into Stock
Values ('30', 'Herbalife',  'Xperia Inc.', Current_Timestamp)
Insert Into Stock
Values ('40', 'Samsung S9',  'Riflet Inc.', Current_Timestamp)
Insert Into Stock
Values ('50', 'Spotify Box',  'Xperia Inc.', Current_Timestamp)
Insert Into Stock
Values ('60', 'Roblox Kit',  'Mimosa Inc.', Current_Timestamp)
Insert Into Stock
Values ('70', 'Producto #13',  'Mimosa Inc.', Current_Timestamp)
Insert Into Stock
Values ('80', 'Rama de Jardín',  'Riflet Inc.', Current_Timestamp)

-- Dummy Data for Products -- 

Insert Into Products
Values ('Sierra X7', 10)
Insert Into Products
Values ('Lanzallamas #13', 20)
Insert Into Products
Values ('Herbalife',  30)
Insert Into Products
Values ('Samsung S9',  40)
Insert Into Products
Values ('Spotify Box',  50)
Insert Into Products
Values ('Roblox Kit',  60)
Insert Into Products
Values ('Producto #13',  70)
Insert Into Products
Values ('Rama de Jardín',  80)

-- Entries Table Create -- 
Create Table Entries (
	Id int Not Null Identity(1,1),
	Transaction_Desc varchar(Max),
	TimeStamp varchar(Max),
	Primary Key (Id)
);

DROP TABLE Entries

Declare @ProductName varchar(Max), @ProviderName varchar(Max)
Set @ProductName = 'Text#1'
Set @ProviderName = 'Text#2'

Insert Into Entries (Transaction_Desc, TimeStamp)
Values('Se ha agregado el producto ' + @ProductName + ' del proveedor ' + @ProviderName + '.', Current_TimeStamp)
Insert Into Entries
Values('Se ha agregado una cantidad de 50 del producto Product#7.', Current_Timestamp)

-- Billing Table Create -- 

Create Table Billing (
	Id int Not Null Identity(1,1),
	ClientName varchar(Max) Not Null,
	ProductName varchar(Max) Not Null,
	Quantity int Not Null,
	TotalPrice varchar(Max) Not Null,
	SaleDate DateTime,
	Primary Key (Id)
); 

-- Testing Billing Table (Procedures & Triggers Resulsts Check)  -- 

Insert Into Billing 
Values ('John Doe', 'Product#5',  '35', '6,195.00', Current_Timestamp)
Select * From Billing

-- Stored Procedure Test (Successful) --

Exec dbo.StockCheck 15, '#2 Googles', 'Oculus Inc.', '2020-04-05'
Select * From Stock
Select * From Entries

-- Testing Data for Billing Section --

Insert Into Clients
Values ('RNC55', 'TestReg', '888-986-5254', 'notprem@client.com', 'Regular')
Insert Into Clients
Values ('RNC56', 'TestPrem', '888-542-1478', 'prem@client.com', 'Premium')

-- Audit Log Table Creation & Testing --

Create Table Audit (
	Id int Not Null Identity(1,1),
	Description varchar(Max) Not Null,
	LogDate DateTime,
	Primary Key (Id)
); 

Insert Into Audit
Values ('Se ha creado el producto: Sierra X7 (#2).', Current_TimeStamp)
Select * From Audit

Exec dbo.StoreInfo 'Se ha creado el producto: Sierra X7 (#2).', '2020-04-06'

-- Emptying Tables to Reuse -- 

Truncate Table Products
Truncate Table Providers
Truncate Table Clients
Truncate Table Audit
Truncate Table Stock
Truncate Table Entries
Truncate Table Billing

Exec dbo.StoreInfo 'Audit', 'Goes to Audit', '2020-04-06'
Exec dbo.StoreInfo 'Entries', 'Goes to Entries', '2020-04-06'
Select * From Audit

-- Trigger/Procedure Result Tests -- 

Exec dbo.CreateBill 'Jamie Doe', 'Herbalife',  1, '1777.4', '2020-04-06'
Select * From Billing
Select * From Stock