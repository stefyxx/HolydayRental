CREATE TABLE [dbo].[AvisMembreBien] (
    [idAvis]   INT      IDENTITY (1, 1) NOT NULL,
    [note]     INT      NOT NULL,
    [message]  NTEXT    NOT NULL,
    [idMembre] INT      NOT NULL,
    [idBien]   INT      NOT NULL,
    [DateAvis] DATETIME NOT NULL,
    [Approuve] BIT      CONSTRAINT [DF_AvisMembreBien_Approuve] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AvisMembreBien] PRIMARY KEY CLUSTERED ([idAvis] ASC),
    CONSTRAINT [FK_AvisMembreBien_BienEchange] FOREIGN KEY ([idBien]) REFERENCES [dbo].[BienEchange] ([idBien]),
    CONSTRAINT [FK_AvisMembreBien_membre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre])
);

