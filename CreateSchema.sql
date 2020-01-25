USE [master]
GO

ALTER DATABASE [myTestDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE [myTestDB]
GO
--EXEC sp_detach_db [myTestDB], 'true';
CREATE DATABASE [myTestDB]
GO

USE [myTestDB]
GO

DROP TABLE Country
GO
CREATE TABLE Country
(
CountryId VARCHAR(5) PRIMARY KEY,
CountryName VARCHAR(20) NOT NULL
)
GO

DROP TABLE Cities
GO
CREATE TABLE Cities
(
CityId VARCHAR(5) PRIMARY KEY,
CountryId VARCHAR(5) FOREIGN KEY REFERENCES Country(CountryId),
CityName VARCHAR(20) NOT NULL
)
GO

INSERT INTO Country VALUES ('C1', 'India')
INSERT INTO Country VALUES ('C2', 'China')
INSERT INTO Country VALUES ('C3', 'USA')

INSERT INTO Cities VALUES ('P1','C1','New Delhi')
INSERT INTO Cities VALUES ('P2','C1','Mumbai')
INSERT INTO Cities VALUES ('P3','C1','Chennai')
INSERT INTO Cities VALUES ('P4','C1','Hyderabad')
INSERT INTO Cities VALUES ('P5','C1','Bengaluru')
INSERT INTO Cities VALUES ('P6','C2','Beijing')
INSERT INTO Cities VALUES ('P7','C2','Shanghai')
INSERT INTO Cities VALUES ('P8','C2','Hong Kong')
INSERT INTO Cities VALUES ('P9','C2','Macau')
INSERT INTO Cities VALUES ('P10','C3','New York')
INSERT INTO Cities VALUES ('P11','C3','Chicago')
INSERT INTO Cities VALUES ('P12','C3','Las Vegas')
