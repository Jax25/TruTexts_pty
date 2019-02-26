--------------------------------Admin
Create Table Administrator
(
AdministratorId int primary key identity (1,1), 
AdminUsername varchar(100) not null,
AdminPassword varchar(100) not null,
AdminFirstName varchar(100) not null,
AdminLastName varchar(100) not null 
);
Go


Insert into dbo.Administrator values('Jax',N'password','John','Van Niekerk');
GO

----------------------------------Books
Create Table Books
(
BookStockId int primary key identity (1,1),--fix
BooksTitle varchar(300) not null,
BooksAuthor varchar (50) not null,
BooksYearPublished char (4) not null,
SupplierId int not null,
FOREIGN KEY (SupplierId) REFERENCES dbo.Suppliers(SupplierId)
);
GO

update dbo.Books
SET SupplierId = '4'
WHERE BookStockId = 5; 
Go

ALTER TABLE dbo.Books Add SupplierId int,
foreign key(SupplierId) REFERENCES dbo.suppliers(SupplierId);
Go

alter table books add constraint fk_books_authorid
    foreign key (AUthorId) references Authors(ID);

select BooksTitle,BooksAuthor,BooksYearPublished from dbo.Books
GO

Insert into dbo.Books values ('Harry Potter and the Philosophers Stone','J. K. Rowling','2001');
Insert into dbo.Books values('The Way of Shadows','Brent Weeks','2008');
Insert into dbo.Books values('Angels and Demons','Dan Brown','2009');
Insert into dbo.Books values('The Black Prism','Brent Weeks','2010');
Insert into dbo.Books values('The Eye of the World','James Oliver Rigney','1984');
GO

Drop table dbo.Books
Go

-------------------------------Customers


Create Table Customer
(
CustomerId int primary key identity(1,1),
CustFirstname varchar(50) not null,
CustLastname varchar(100) not null,
CustphysicalAddress varchar(100) not null,
CustCity varchar(100) not null,
CustCellnumber nvarchar(10) not null
);
go

Insert into dbo.Customer values('Jason','Todd','299 Brokhurst Road Kenwyn','Cape Town','082348769');
Insert into dbo.Customer values('Charis','Hall','26 Olive Road Wynberg','Cape Town','0856722358');
Insert into dbo.Customer values('Chad','Rogers','205 Morpeth Road Plumstead','Cape Town','0827878562');
Insert into dbo.Customer values('Ian','Poppers','12 Main Road Fishhoek','Cape Town','0217832567');
Insert into dbo.Customer values('Rob','Base','45 Holderness Road Stellenbosch','Cape Town','0742323745');
GO

ALTER TABLE dbo.Customer DROP CustCellnumber;
Go

Drop table dbo.Customer
Go

Insert into dbo.Customer values
('smith',N'password', 'smith','Debeer','Claremont close to CTU.','Cape Town',N'0818033999')
go

-----------------------------Supplier
Drop table Supplier
GO

Create Table Suppliers
(
SupplierId int primary key identity(1,1),
SuppliersName varchar (200) not null
)
GO

Insert into dbo.Suppliers values('Fast Book Deliveries')
Insert into dbo.Suppliers values('Readers books')
Insert into dbo.Suppliers values('Golden oldies')
Insert into dbo.Suppliers values('Fiction forever')
Insert into dbo.Suppliers values('Book Warehouse')
GO

select Supplier from dbo.Supplier
GO



------------------------------------Employee
Create Table Employees
(
EmployeeId int primary key identity (1,1), 
EmpUsername varchar(100) not null,
EmpPassword varchar(100) not null,
EmpFirstName varchar(100) not null,
EmpLastName varchar(100) not null 
);
Go

Insert into dbo.Employees values('rock',N'password','Rock','Mba');
GO




-------------------------other

select AdminUsername,AdminPassword,AdminFirstName,AdminLastName from dbo.Administrator
select EmpUsername,Emppassword,EmpFirstName,EmpLastName from dbo.Employees
select CustUsername,CustPassword,CustFirstname,CustLastname,CustPhsicalAddress,CustCity,CustCellnumber from dbo.Customer
select * from dbo.Customer

delete from dbo.Customer
where CustFirstname='22';
go

--refrence tables using index?????????????

------------------------Orders

Create Table Orders
(
OrdersId int Not null, 
CustomerId int not null,
EmployeeId int not null,
PRIMARY KEY (OrdersId),
FOREIGN KEY (CustomerId) REFERENCES dbo.Customer(CustomerId),
FOREIGN KEY (EmployeeId) REFERENCES dbo.Employees(EmployeeId)
);
Go

Insert into dbo.Orders values('9233','3','1');
Insert into dbo.Orders values('9234','1','1');
Insert into dbo.Orders values('9235','2','1');
Insert into dbo.Orders values('9236','5','3');
Insert into dbo.Orders values('9237','4','2');
GO

-----------------Order Details

Create Table OrderDetails
(
OrderDetailsId int primary key identity (1,1), 
OrdersID int not null,
BookID int not null,
Quantity int not null,
FOREIGN KEY (OrdersId) REFERENCES dbo.Orders(OrdersId),
FOREIGN KEY (BookID) REFERENCES dbo.Books(BookStockId)
);


Insert into dbo.OrderDetails values('9233','1','4');
Insert into dbo.OrderDetails values('9233','2','6');
Insert into dbo.OrderDetails values('9233','5','10');
Insert into dbo.OrderDetails values('9234','4','30');
Insert into dbo.OrderDetails values('9235','2','1');
Insert into dbo.OrderDetails values('9236','1','8');
Insert into dbo.OrderDetails values('9237','3','1');
GO


----------------------------------Views

--Example

--CREATE VIEW [Current Most Sold Books ] AS
--SELECT BookStockId, BooksTitle
--FROM dbo.Books
--WHERE OrderDetails != null and BookID; 

--with
--Topcustomers
--AS
--(select top(5)
--dbo.c

DELETE FROM dbo.Supplier
WHERE SupplierId IN 
  ( SELECT q.SupplierId
    FROM dbo.supplier q
      INNER JOIN tableB u on (u.qlabel = q.entityrole AND u.fieldnum = q.fieldnum) 
    WHERE (LENGTH(q.memotext) NOT IN (8,9,10) OR q.memotext NOT LIKE '%/%/%')
      AND (u.FldFormat = 'Date'));
