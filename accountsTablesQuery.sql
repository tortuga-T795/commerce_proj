CREATE TABLE Accounts
(
    token NVARCHAR(255) NOT NULL PRIMARY KEY,
    accountNickname NVARCHAR(100) NOT NULL,
    ownerName NVARCHAR(255) NOT NULL,
    ownerSurname NVARCHAR(255) NOT NULL
);