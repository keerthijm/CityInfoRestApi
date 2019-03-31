CREATE TABLE City
(
[Id] UNIQUEIDENTIFIER DEFAULT NEWID(),
[Name] VARCHAR(250) DEFAULT NULL,
[State] VARCHAR(250) DEFAULT NULL,
[Country] VARCHAR(250) DEFAULT NULL,
[TouristRating] [tinyint] NULL,
[DateEstablished] [datetime] NULL,
[EstimatedPopulation] [bigint] NULL,
PRIMARY KEY (ID)
)