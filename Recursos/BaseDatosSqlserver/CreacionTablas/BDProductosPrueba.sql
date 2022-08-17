CREATE TABLE Products(
	IdProduct int not null IDENTITY(1,1) PRIMARY KEY, 
	ProductName varchar(250) not null, 
	Price decimal(10,4) not null,
	IdTradeMark int not null, 
	Model varchar(250) not null,
	DescriptionProduct varchar(250) not null,	
	Stock int not null,
	DischargeDate Date not null,
	FinishedDate Date,
	Active tinyint not null default 1,

);



CREATE TABLE TradeMarks (
    IdTradeMark int not null IDENTITY(1,1) PRIMARY KEY,
    NameTradeMark varchar(255) NOT NULL,
    Phone varchar(15) NOT NULL,
    Email varchar(50) NOT NULL,
	NameLegalRepresentative varchar (250) NOT NULL,
	LastNameLegalRepresentative varchar (250) NOT NULL,
	MotherLastNameLegalRepresentative varchar (250),
	DischargeDate Date not null,
	DownDate Date,
	Active tinyint not null default 1,
);


CREATE TABLE SalesMans(
	IdSalesMan int not null IDENTITY(1,1) PRIMARY KEY,
	NameSaleMan varchar(250) not null, 
	LastName varchar(250) not null, 
	MotherLastName varchar(250) not null,
	StoreSalesMan varchar(250) not null,
	Phone varchar(15) not null,
	Email varchar(50) not null, 
	DischargeDate Date not null,
	DownDate Date,
	Active tinyint not null default 1,
);

CREATE TABLE SalesCodes(
	SalesCode varchar(250) PRIMARY KEY not null, 
	JustificationCancelation varchar(250),
	DischargeDate Date not null,
	DownDate Date,
	TakeCode tinyint not null default 0,
	DateTakeCode date,
	Active tinyint not null default 1,
);

CREATE TABLE Buyers(
	IdBuyer int not null IDENTITY(1,1) PRIMARY KEY,
	NameBuyer varchar(250) not null,
	LastName varchar(250) not null, 
	MotherLastName varchar(250) not null,
	Recidence varchar(250),
	Phone varchar(15),
	Email varchar(250),
	CreditCard varchar(25) not null, 
	CVC smallint,
	DischargeDate Date not null,
	DownDate Date,
	Active tinyint not null default 1,
	);

CREATE TABLE StatusSales(
	IdStatus int not null IDENTITY(1,1) PRIMARY KEY,
	NameStatus varchar(50) not null,
	Active tinyint not null default 1, 
);

CREATE TABLE Sales(
	IdSale int not null IDENTITY(1,1) PRIMARY KEY,
	SalesCode varchar(250),
	IdProduct int not null,
	IdSalesMan int not null,
	IdBuyer int not null,
	IdStatus int not null,
	PurchaseDate date not null,
	DeadLineDate date not null
);



--Products.IdTradeMark con TradeMarks
--Se agrega llave foranea para saber que marca es el producto
ALTER TABLE Products ADD CONSTRAINT FK_ProductsTradeMarks FOREIGN  KEY (IdTradeMark) REFERENCES TradeMarks(IdTradeMark);

--Se agrega llave foranea para saber que codigo de venta tendra la venta
ALTER TABLE Sales ADD CONSTRAINT FK_SalesCode FOREIGN  KEY (SalesCode) REFERENCES SalesCodes(SalesCode);

--Se agrega llave foranea para saber saber que producto se va a comprar
ALTER TABLE Sales ADD CONSTRAINT FK_SalesProducts FOREIGN  KEY (IdProduct) REFERENCES Products(IdProduct);

--Se agrega llave fornea para saber quien es el vendedor del pedido
ALTER TABLE Sales ADD CONSTRAINT FK_SalesMan FOREIGN  KEY (IdSalesMan) REFERENCES SalesMans(IdSalesMan);

--Se agrega lllave para saber el status del pedido.
ALTER TABLE Sales ADD CONSTRAINT FK_SalesStatus FOREIGN  KEY (IdStatus) REFERENCES StatusSales(IdStatus);


--Se agrega lllave para saber el status del pedido.
ALTER TABLE Sales ADD CONSTRAINT FK_SalesBuyers FOREIGN  KEY (IdBuyer) REFERENCES Buyers(IdBuyer);