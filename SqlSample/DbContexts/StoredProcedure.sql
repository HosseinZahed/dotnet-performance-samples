USE [SqlSampleDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetPersons]            
        AS
        BEGIN
            SET NOCOUNT ON;
            SELECT * FROM Persons INNER JOIN Phones ON Persons.Id = Phones.PersonId
        END
GO