CREATE TABLE [dbo].[Person] (
    [PersonId]  INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NULL,
    [LastName]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PersonId] ASC)
);

