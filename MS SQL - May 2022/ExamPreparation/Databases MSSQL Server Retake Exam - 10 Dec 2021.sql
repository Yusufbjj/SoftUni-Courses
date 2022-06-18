CREATE DATABASE Airport

CREATE TABLE Passengers(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[FullName] VARCHAR(100) NOT NULL,
[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE Pilots(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[FirstName] VARCHAR(30) NOT NULL,
[LastName] VARCHAR(30) NOT NULL,
[Age] TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL,
[Rating] FLOAT CHECK(Rating BETWEEN 0 AND 10)
)

CREATE TABLE AircraftTypes
(
    Id INT PRIMARY KEY IDENTITY,
    TypeName VARCHAR(30)NOT NULL UNIQUE 
)

CREATE TABLE Aircraft
(
    Id INT PRIMARY KEY IDENTITY,
    Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30 ) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id) 
)

CREATE TABLE PilotsAircraft
(
    AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id)  ,
    PilotId INT NOT NULL FOREIGN KEY REFERENCES Pilots(Id) ,
	PRIMARY KEY (AircraftId,PilotId)
)

CREATE TABLE Airports
(
    Id INT PRIMARY KEY IDENTITY,
    AirportName VARCHAR(70)NOT NULL UNIQUE ,
	Country VARCHAR(100)NOT NULL UNIQUE 
)

CREATE TABLE FlightDestinations(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[AirportId] INT REFERENCES [Airports](Id) NOT NULL,
[Start] DATETIME NOT NULL,
[AircraftId] INT REFERENCES [Aircraft](Id) NOT NULL,
[PassengerId] INT REFERENCES [Passengers](Id) NOT NULL,
[TicketPrice] DECIMAL(18,2) NOT NULL DEFAULT 15
)

--02. Insert

INSERT INTO  Passengers(FullName,Email)
		SELECT	
		CONCAT([p].FirstName,' ',[p].LastName),
		CONCAT([p].FirstName,[p].LastName,'@gmail.com')
		FROM Pilots
		AS [p]
		WHERE Id >=5 AND Id <=15

--03. Update

SELECT *
FROM Aircraft

UPDATE Aircraft
SET Condition = 'A'
WHERE ((Condition = 'C' OR Condition = 'B') 
		AND (FlightHours IS NULL OR FlightHours<=100)
		AND [Year] >=2013)
		

--04. Delete

DELETE Passengers
WHERE LEN(FullName)<=10


--05. Aircraft

SELECT Manufacturer,Model,FlightHours,Condition
FROM Aircraft
ORDER BY FlightHours DESC

--06. Pilots and Aircraft

SELECT [p].FirstName,[p].LastName,Manufacturer,Model,FlightHours
 FROM Pilots AS p
JOIN PilotsAircraft AS [pi] ON [pi].PilotId=[p].Id
JOIN Aircraft AS [a] ON [a].Id=[pi].AircraftId
WHERE FlightHours IS NOT NULL AND FlightHours <=304
ORDER BY FlightHours DESC,FirstName

--07. Top 20 Flight Destinations

SELECT TOP 20 
		[fd].Id as DestinationId,
		[fd].[Start] as [Start],
		[p].FullName AS FullName,
		[a].AirportName AS AirportName,
		[fd].TicketPrice AS TicketPrice
FROM FlightDestinations as [fd]
JOIN Passengers as [p] ON [p].Id=[fd].PassengerId
JOIN Airports AS [a] ON [a].Id=[fd].AirportId
WHERE FORMAT([Start],'dd') %2 = 0 
ORDER BY TicketPrice DESC,AirportName ASC

--08. Number of Flights for Each Aircraft

SELECT  [A].Id as AircraftId,
		[A].[Manufacturer],
		[A].FlightHours,
		COUNT([fd].AircraftId) AS FlightDestinationsCount,
		ROUND(AVG([fd].TicketPrice),2) AS AvgPrice
FROM FlightDestinations AS [fd]
JOIN Aircraft AS [A] ON [A].[Id]=[fd].AircraftId
GROUP BY [A].Id,[A].[Manufacturer],[A].FlightHours
HAVING COUNT([fd].AircraftId)>1
ORDER BY FlightDestinationsCount DESC,AircraftId

--09. Regular Passengers

SELECT [p].FullName,
		COUNT([p].Id) as CountOfAircraft,
		SUM([fd].TicketPrice) as TotalPayed
FROM Passengers AS [p]
JOIN FlightDestinations
AS[fd]
ON [p].Id=[fd].PassengerId
GROUP BY [p].FullName
HAVING COUNT([p].Id)>1 AND SUBSTRING([p].FullName,2,1)='a'
ORDER BY [p].FullName

--10. Full Info for Flight Destinations

select 
	a.AirportName,
	concat(format(fd.Start,'yyyy-MM-dd HH:mm:ss'),'.000') as DayTime,
	fd.TicketPrice,
	p.FullName,
	ac.Manufacturer,
	ac.Model
from FlightDestinations fd, Airports a, Passengers p, Aircraft ac
where fd.AirportId=a.Id
and fd.PassengerId=p.Id
and fd.AircraftId=ac.Id
and format(fd.Start,'HH:mm:ss')>='06:00:00'
and format(fd.Start,'HH:mm:ss')<='20:59:59'
and fd.TicketPrice>2500
order by ac.Model

-- task 11

go

create function udf_FlightDestinationsByEmail(@email varchar(50)) 
returns int  
as 

begin
	 DECLARE @result int
		set @result = (select count(*) from FlightDestinations where PassengerId in (select id from Passengers where Email=@email))
	 return @result 
end


-- task 12
go

create procedure usp_SearchByAirportName @airportName varchar(70)
as 
begin
select 
	a.AirportName, 
	p.FullName, 
	case 
		when fd.TicketPrice<=400 then'Low' 
		when  fd.TicketPrice>400 and fd.TicketPrice<=1500 then 'Medium'
		when  fd.TicketPrice>1500  then 'High'
	end as LevelOfTickerPrice, 
	ac.Manufacturer, 
	ac.Condition, 
	at.TypeName 
from Airports a,FlightDestinations fd, Passengers p,Aircraft ac,AircraftTypes at
where a.AirportName=@airportName
and a.Id=fd.AirportId
and fd.PassengerId=p.Id
and fd.AircraftId=ac.Id
and ac.TypeId=at.Id
order by ac.Manufacturer, p.FullName
end 


EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'
