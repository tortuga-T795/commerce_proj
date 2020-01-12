USE DepartmentOfCommerceDB;
GO

DROP TABLE IF EXISTS TypesLists;
DROP TABLE IF EXISTS Recipients;
DROP TABLE IF EXISTS ProductSuppliers;
DROP TABLE IF EXISTS ProductionTypes;
DROP TABLE IF EXISTS Addresses;
DROP TABLE IF EXISTS Buildings;
DROP TABLE IF EXISTS Streets;
DROP TABLE IF EXISTS Cities;
DROP TABLE IF EXISTS Countries;
DROP TABLE IF EXISTS LegalEntityTypes;

CREATE TABLE LegalEntityTypes
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	legal_entity_form NVARCHAR(20) NOT NULL,
);

CREATE TABLE Countries
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	countries_name NVARCHAR(60) NOT NULL,
);

CREATE TABLE Cities 
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	cities_name NVARCHAR(255) NOT NULL,
	countryId INT NOT NULL,
	FOREIGN KEY (countryId) REFERENCES Countries(id)
);

CREATE TABLE Streets 
(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	street_name NVARCHAR(255) NOT NULL,
	citiesId INT NOT NULL,
	FOREIGN KEY (CitiesId) REFERENCES Cities(id)
);

CREATE TABLE Buildings 
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	building_number NVARCHAR(20) NOT NULL,
	streetId INT NOT NULL,
	FOREIGN KEY (streetId) REFERENCES Streets(id)
);

CREATE TABLE Addresses 
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	countryId INT NOT NULL,
	cityId INT NOT NULL,
	streetId INT NOT NULL,
	buildingId INT NOT NULL,
	FOREIGN KEY (countryId) REFERENCES Countries(id),
	FOREIGN KEY (cityId) REFERENCES Cities(id),
	FOREIGN KEY (streetId) REFERENCES Streets(id),
	FOREIGN KEY (buildingId) REFERENCES Buildings(id)
);

CREATE TABLE ProductionTypes 
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	type_of_product NVARCHAR(255) NOT NULL
);

CREATE TABLE ProductSuppliers
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	supplierName  NVARCHAR(255) NOT NULL,
	legalAddressId INT NOT NULL,
	uniquePayerNumber NVARCHAR(255) NOT NULL,
	legalEntityTypeId INT NOT NULL,
	phoneNumber INT NOT NULL,
	FOREIGN KEY (legalEntityTypeId) REFERENCES LegalEntityTypes(id),
	FOREIGN KEY (legalAddressId) REFERENCES Addresses(id)
);

CREATE TABLE Recipients
(
	id INT IDENTITY PRIMARY KEY,
	recipientName  NVARCHAR(255) NOT NULL,
	legalAddressId INT NOT NULL,
	uniquePayerNumber NVARCHAR(255) NOT NULL,
	legalEntityTypeId INT NOT NULL,
	phoneNumber INT NOT NULL,
	FOREIGN KEY (legalEntityTypeId) REFERENCES LegalEntityTypes(id),
	FOREIGN KEY (legalAddressId) REFERENCES Addresses(id)
);

CREATE TABLE TypesLists 
(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	productTypeId  INT NOT NULL,
	supplierId  INT NOT NULL,
	FOREIGN KEY (productTypeId) REFERENCES ProductionTypes(id),
	FOREIGN KEY (supplierId) REFERENCES ProductSuppliers(id)
);
