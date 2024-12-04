CREATE DATABASE dssDB

CREATE TABLE Roles
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(255),
    RoleId INT,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

CREATE TABLE UserDetails
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    DateOfBirth DATE,
    ProfilePicture NVARCHAR(255),
    Bio NVARCHAR(500),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- CREATE TABLE Products (
--     Id INT PRIMARY KEY IDENTITY(1,1),
--     Name NVARCHAR(100) NOT NULL,
--     Price DECIMAL(18, 2) NOT NULL,
--     StockQuantity INT NOT NULL,
--     Description NVARCHAR(500)
-- );

CREATE TABLE Permissions
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    PermissionName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RolePermissions
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id),
    FOREIGN KEY (PermissionId) REFERENCES Permissions(Id),
    UNIQUE (RoleId, PermissionId)
    -- Ensure unique role-permission pairs
);

CREATE TABLE Clients
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(20) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- CREATE TABLE Orders (
--     Id INT PRIMARY KEY IDENTITY(1,1),
--     ClientId INT NOT NULL,
--     OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
--     TotalAmount DECIMAL(10, 2),
--     Status NVARCHAR(50),
--     FOREIGN KEY (ClientId) REFERENCES Clients(Id)
-- );

CREATE TABLE Products
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    Description NVARCHAR(500)
);

CREATE TABLE Ingredients
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Unit INT NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    ExpiryDate DATETIME NOT NULL
);

CREATE TABLE Payment
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClientId INT NOT NULL,
    OrderId INT NULL,
    Amount FLOAT NOT NULL,
    TaxAmount FLOAT NOT NULL,
    PaymentMethod NVARCHAR(255) NOT NULL,
    Currency NVARCHAR(10) NOT NULL,
    DiscountApplied FLOAT NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    CONSTRAINT FK_Payment_Client FOREIGN KEY (ClientId) REFERENCES Client(Id),
);


-- CREATE TABLE OrderItems (
--     Id INT PRIMARY KEY IDENTITY(1,1),
--     OrderId INT NOT NULL,
--     ProductId INT NOT NULL,
--     Quantity INT NOT NULL,
--     Price DECIMAL(10, 2) NOT NULL,
--     FOREIGN KEY (OrderId) REFERENCES Orders(Id),
--     FOREIGN KEY (ProductId) REFERENCES Products(Id)
-- );

-- CREATE TABLE Reservations (
--     Id INT PRIMARY KEY IDENTITY(1,1),
--     ClientId INT NOT NULL,
--     ReservationDate DATETIME NOT NULL,
--     NumberOfGuests INT NOT NULL,
--     SpecialRequests NVARCHAR(500),
--     Status NVARCHAR(50) DEFAULT 'Pending',
--     CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
--     FOREIGN KEY (ClientId) REFERENCES Clients(Id)
-- );
