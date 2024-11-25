CREATE DATABASE dssDB 

CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Users (
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

CREATE TABLE UserDetails (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    DateOfBirth DATE,
    ProfilePicture NVARCHAR(255),
    Bio NVARCHAR(500),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    Description NVARCHAR(500)
);

CREATE TABLE Permissions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PermissionName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RolePermissions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id),
    FOREIGN KEY (PermissionId) REFERENCES Permissions(Id),
    UNIQUE (RoleId, PermissionId) -- Ensure unique role-permission pairs
);
