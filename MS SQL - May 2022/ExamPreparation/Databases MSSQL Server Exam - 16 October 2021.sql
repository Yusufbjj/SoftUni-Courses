CREATE DATABASE [CigarShop]

--Task 01. DDL

CREATE TABLE Sizes (
Id INT PRIMARY KEY IDENTITY,
[Length] INT NOT NULL CHECK ([Length]>=10 AND [Length]<=25),
RingRange DECIMAL(18,2) NOT NULL CHECK (RingRange>=1.5 AND RingRange <=7.5)
)

CREATE TABLE Tastes (
Id INT PRIMARY KEY IDENTITY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL,
)

CREATE TABLE Brands (
Id INT PRIMARY KEY IDENTITY,
BrandName VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR(max),
)

CREATE TABLE Cigars (
Id INT PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id),
TastId INT NOT NULL FOREIGN KEY REFERENCES Tastes(Id),
SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
PriceForSingleCigar MONEY NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL ,
ZIP VARCHAR(20) NOT NULL ,
)

CREATE TABLE Clients (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL ,
AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id) ,
)

CREATE TABLE ClientsCigars (
ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id),
CigarId INT NOT NULL FOREIGN KEY REFERENCES Cigars(Id),
PRIMARY KEY (ClientId,CigarId)
)

--Task 02. Insert

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,Country,Streat,ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--Task 03. Update

UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar * 1.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--Task 04. Delete

DELETE FROM Clients
WHERE AddressId IN (
SELECT Id
FROM Addresses
WHERE SUBSTRING(Country,1,1) = 'C'
)

DELETE 
FROM Addresses
WHERE SUBSTRING(Country,1,1) = 'C'

--Task 05. Cigars by Price

SELECT
	CigarName,
	PriceForSingleCigar,
	ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar ASC, CigarName DESC

--Task 06. Cigars by Taste

SELECT
	c.Id,
	CigarName,
	PriceForSingleCigar,
	TasteType,
	TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId=t.Id
WHERE TasteType IN ('Woody','Earthy')
ORDER BY PriceForSingleCigar DESC

--Task 07. Clients without Cigars

SELECT 
	Id,
	CONCAT(FirstName,' ',LastName) AS ClientName,
	Email
FROM Clients
WHERE NOT EXISTS (SELECT ClientId FROM ClientsCigars WHERE ClientId=Id)
ORDER BY ClientName ASC

--Task 08. First 5 Cigars

SELECT TOP 5
	CigarName,
	PriceForSingleCigar,
	ImageURL
FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE
s.[Length]>=12 
AND (CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50)
AND s.RingRange >2.55
ORDER BY c.CigarName ASC,c.PriceForSingleCigar DESC

--Task 09. Clients with ZIP Codes

SELECT
	CONCAT(c.FirstName,' ',c.LastName) AS FullName,
	a.Country,
	a.ZIP,
CONCAT('$',
	(SELECT MAX(PriceForSingleCigar)
	FROM Cigars AS cg 
	JOIN ClientsCigars AS cc ON cg.Id=cc.CigarId AND cc.ClientId = c.Id)) AS CigarPrice
FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
WHERE ISNUMERIC(a.ZIP) = 1
ORDER BY FullName ASC

--Task 10. Cigars by Size

SELECT
	LastName,
	AVG(s.[Length]) AS CiagrLength,
	CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients AS c
JOIN ClientsCigars AS cc on cc.ClientId = c.Id
JOIN Cigars AS cg ON cc.CigarId = cg.Id
JOIN Sizes AS s ON cg.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC

--Task 11. Client with Cigars

GO

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT AS
BEGIN
	DECLARE @cigarCount INT;
	SET @cigarCount = 
		(SELECT
			COUNT(*)
		FROM ClientsCigars
		WHERE ClientId IN (SELECT Id FROM Clients WHERE FirstName = @name));
	RETURN @cigarCount;
END

--Task 12. Search for Cigar with Specific Taste

GO

CREATE PROCEDURE usp_SearchByTaste @taste VARCHAR(20)
AS
BEGIN
SELECT
	CigarName,
	CONCAT('$',c.PriceForSingleCigar) AS Price,
	TasteType,
	BrandName,
	CONCAT(s.[Length], ' ','cm') AS CigarLength,
	CONCAT(s.RingRange,' ','cm') AS CigarRingRange
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId=t.Id
JOIN Sizes AS s ON s.Id = c.SizeId
JOIN Brands AS b ON b.Id = c.BrandId
WHERE t.TasteType = @taste
ORDER BY CigarLength ASC, CigarRingRange DESC
END

EXEC usp_SearchByTaste 'Woody'





