CREATE TABLE [dbo].[MembreBienEchange] (
    [idMembre]       INT  NOT NULL,
    [idBien]         INT  NOT NULL,
    [DateDebEchange] DATE NOT NULL,
    [DateFinEchange] DATE NOT NULL,
    [Assurance]      BIT  NULL,
    [Valide]         BIT  CONSTRAINT [DF_MembreBienEchange_Valide] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_MembreBienEchange] PRIMARY KEY CLUSTERED ([idMembre] ASC, [idBien] ASC, [DateDebEchange] ASC, [DateFinEchange] ASC),
    CONSTRAINT [FK_MembreBienEchange_BienEchange] FOREIGN KEY ([idBien]) REFERENCES [dbo].[BienEchange] ([idBien]),
    CONSTRAINT [FK_MembreBienEchange_membre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre])
);

