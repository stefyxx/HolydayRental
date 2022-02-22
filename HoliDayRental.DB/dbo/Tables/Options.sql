CREATE TABLE [dbo].[Options] (
    [idOption] INT           IDENTITY (1, 1) NOT NULL,
    [Libelle]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED ([idOption] ASC)
);

