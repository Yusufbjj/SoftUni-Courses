CREATE DATABASE Zoo

CREATE TABLE Owners
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
    Id INT PRIMARY KEY IDENTITY,
    AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
    Id INT PRIMARY KEY IDENTITY,
    AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
    CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
	AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
	PRIMARY KEY(CageId,AnimalId)
)

CREATE TABLE VolunteersDepartments
(
    Id INT PRIMARY KEY IDENTITY,
    DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

DROP TABLE Owners
DROP TABLE AnimalTypes
DROP TABLE Cages
DROP TABLE Animals
DROP TABLE AnimalsCages
DROP TABLE VolunteersDepartments
DROP TABLE Volunteers

--02. Insert


INSERT INTO Volunteers ([Name],PhoneNumber,[Address],AnimalId,DepartmentId)
	VALUES
('Anita Kostova',0896365412,'Sofia, 5 Rosa str.',15,1),
('Dimitur Stoev',0877564223,null,42,4),
('Kalina Evtimova',0896321112,'Silistra, 21 Breza str.',9,7),
('Stoyan Tomov',0898564100,'Montana, 1 Bor str.',18,8),
('Boryana Mileva',0888112233,null,31,5)


INSERT INTO Animals ([Name],BirthDate,OwnerId,AnimalTypeId)
	VALUES
('Giraffe','2018-09-21',21,1),
('Harpy Eagle','2015-04-17',15,3),
('Hamadryas Baboon','2017-11-02',null,1),
('Tuatara','2021-06-30',2,4)

--03. Update

select * from Animals
where OwnerId is null

SELECT * FROM Owners
WHERE [Name] = 'Kaloqn Stoqnov'

UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

--04. Delete

SELECT * FROM VolunteersDepartments
SELECT * FROM Volunteers where DepartmentId =2 

DELETE Volunteers
WHERE DepartmentId = 2

DELETE VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

--05. Volunteers

SELECT [Name],
		PhoneNumber,
		[Address],
		AnimalId,
		DepartmentId
FROM Volunteers
ORDER BY [Name],AnimalId,DepartmentId

--06. Animals data

SELECT * FROM Animals
SELECT * FROM AnimalTypes

SELECT A.[Name],
		AT.AnimalType,
	FORMAT(A.BirthDate,'dd.MM.yyyy') AS BirthDate
FROM Animals AS A
JOIN AnimalTypes AS AT ON AT.Id = A.AnimalTypeId
ORDER BY A.[Name]

--07. Owners and Their Animals

select * from Animals
select * from Owners


SELECT TOP 5 o.[Name] as Owner,
	COUNT(a.OwnerId) as CountOfAnimals
FROM Owners as o
join Animals as a ON A.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC,o.[Name]

--08. Owners, Animals and Cages

select * from Animals
select * from Owners
select * from AnimalsCages
select * from Cages
select * from AnimalTypes

SELECT CONCAT(O.[Name],'-',A.[Name]) AS OwnersAnimals,
		O.PhoneNumber,
		AC.CageId
FROM Owners AS O
JOIN Animals AS A ON O.Id=A.OwnerId
JOIN AnimalsCages AS AC ON AC.AnimalId=A.Id
WHERE A.AnimalTypeId = 1
ORDER BY O.[Name] ASC,A.[Name] DESC

--09. Volunteers in Sofia
SELECT [Name],
		PhoneNumber,
		REPLACE(SUBSTRING([Address],8, 50),', ','' ) AS [Address]
FROM Volunteers 
WHERE (DepartmentId=2 AND [Address] LIKE('%Sofia%'))
ORDER by [Name]

--10. Animals for Adoption

select * from Animals
select * from AnimalTypes

SELECT A.[Name],
		SUBSTRING(FORMAT(A.BirthDate,'yyyy.MM.DD'),1,4) AS BirthYear,
		AT.AnimalType
FROM Animals AS A
JOIN AnimalTypes AS AT ON AT.Id=A.AnimalTypeId
WHERE A.OwnerId IS NULL 
AND (AT.AnimalType!='Birds' AND A.BirthDate>'01/01/2018')
ORDER BY A.Name

--11. All Volunteers in a Department
SELECT COUNT(*)
FROM Volunteers
WHERE DepartmentId =(
SELECT Id FROM VolunteersDepartments 
WHERE DepartmentName = 'Education program assistant')

GO

CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT AS
BEGIN

	DECLARE @countVolunteers INT = (
					SELECT COUNT(*)
						FROM Volunteers
						WHERE DepartmentId =(
						SELECT Id FROM VolunteersDepartments 
						WHERE DepartmentName = @VolunteersDepartment))

	 RETURN @countVolunteers;
END

GO

-- 12. Animals with Owner or Not

select * from Owners

GO

CREATE PROCEDURE usp_AnimalsWithOwnersOrNot @AnimalName VARCHAR(30)
AS
BEGIN
	DECLARE @OwnersId INT = ( SELECT Animals.OwnerId 
					FROM Animals
					WHERE Animals.[Name] = @AnimalName
					
					) 

	DECLARE @OwnersName VARCHAR(50) = (SELECT [Name] 
										from Owners
										where Id=@OwnersId)
			if @OwnersId is not null (
				SELECT	@AnimalName AS [Name],
						@OwnersName as OwnersName
						
			)else(
				SELECT	@AnimalName AS [Name],
						'For adoption' as OwnersName
			)	
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'