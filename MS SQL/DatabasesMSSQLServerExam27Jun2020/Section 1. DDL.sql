--================	Section 1. DDL	========================== 

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending',
	ClientId INT REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE,
	CONSTRAINT chk_Status CHECK ([Status] IN ('Pending', 'In Progress', 'Finished'))
)


CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price MONEY NOT NULL,
	VendorId INT REFERENCES Vendors(VendorId),
	StockQty INT DEFAULT 0,
	CONSTRAINT chk_Price CHECK (Price > 0),
	CONSTRAINT chk_StockQty CHECK (StockQty >= 0)
)


CREATE TABLE OrderParts
(
	OrderId INT REFERENCES Orders(OrderId),
	PartId INT REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1,
	CONSTRAINT chk_Quantity CHECK (Quantity >= 0),
	CONSTRAINT PK_OrderParts PRIMARY KEY  (OrderId, PartId) 
)

CREATE TABLE PartsNeeded
(
	JobId INT REFERENCES Jobs(JobId),
	PartId INT REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1,
	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId),
	CONSTRAINT chk_QuantityPartsNeeded CHECK (Quantity >= 0),
)