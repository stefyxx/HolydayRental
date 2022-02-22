CREATE TABLE [dbo].[Pays] (
    [idPays]  INT           IDENTITY (1, 1) NOT NULL,
    [Libelle] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED ([idPays] ASC)
);

