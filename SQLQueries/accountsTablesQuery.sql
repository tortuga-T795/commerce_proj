USE DepartmentOfCommerceDB;
GO

DROP TABLE IF EXISTS Accounts
DROP TABLE IF EXISTS AccountTypes
GO

CREATE TABLE AccountTypes
(
    id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    typeName NVARCHAR(40) NOT NULL
);

CREATE TABLE Accounts
(
    token NVARCHAR(255) NOT NULL PRIMARY KEY,
    accountNickname NVARCHAR(100) NOT NULL,
    ownerName NVARCHAR(255) NOT NULL,
    ownerSurname NVARCHAR(255) NOT NULL,
    accType INT NOT NULL,
    FOREIGN KEY(accType) REFERENCES AccountTypes(id)
);
GO

INSERT INTO AccountTypes(typeName) VALUES (N'user')
INSERT INTO AccountTypes(typeName) VALUES (N'admin')

INSERT INTO Accounts(token, accountNickname, ownerName, ownerSurname, accType) VALUES
	(N'123hhh', N'pipidastr', N'pip', N'pypa', 1)
INSERT INTO Accounts(token, accountNickname, ownerName, ownerSurname, accType) VALUES
	(N'123hhg', N'pipi', N'pyp', N'pypi', 1)
GO

SELECT Accounts.accountNickname, AccountTypes.typeName FROM Accounts 
		JOIN AccountTypes ON Accounts.accType = AccountTypes.id
