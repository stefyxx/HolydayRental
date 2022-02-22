CREATE TABLE [dbo].[OptionsBien] (
    [idOption] INT           NOT NULL,
    [idBien]   INT           NOT NULL,
    [Valeur]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OptionsBien] PRIMARY KEY CLUSTERED ([idOption] ASC, [idBien] ASC),
    CONSTRAINT [FK_OptionsBien_BienEchange] FOREIGN KEY ([idBien]) REFERENCES [dbo].[BienEchange] ([idBien]),
    CONSTRAINT [FK_OptionsBien_Options] FOREIGN KEY ([idOption]) REFERENCES [dbo].[Options] ([idOption])
);

