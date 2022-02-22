CREATE TABLE [dbo].[BienEchange] (
    [idBien]               INT            IDENTITY (1, 1) NOT NULL,
    [titre]                NVARCHAR (50)  NOT NULL,
    [DescCourte]           NVARCHAR (150) NOT NULL,
    [DescLong]             NTEXT          NOT NULL,
    [NombrePerson]         INT            NOT NULL,
    [Pays]                 INT            CONSTRAINT [DF_BienEchange_Pays] DEFAULT ((1)) NOT NULL,
    [Ville]                NVARCHAR (50)  NOT NULL,
    [Rue]                  NVARCHAR (50)  NOT NULL,
    [Numero]               NVARCHAR (5)   NOT NULL,
    [CodePostal]           NVARCHAR (50)  NOT NULL,
    [Photo]                NVARCHAR (50)  NOT NULL,
    [AssuranceObligatoire] BIT            CONSTRAINT [DF_BienEchange_AssuranceObligatoire] DEFAULT ((0)) NOT NULL,
    [isEnabled]            BIT            CONSTRAINT [DF_BienEchange_isEnabled] DEFAULT ((0)) NOT NULL,
    [DisabledDate]         DATE           NULL,
    [Latitude]             NVARCHAR (50)  NOT NULL,
    [Longitude]            NVARCHAR (50)  NOT NULL,
    [idMembre]             INT            NOT NULL,
    [DateCreation]         DATE           CONSTRAINT [DF_BienEchange_DateCreation] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_BienEchange] PRIMARY KEY CLUSTERED ([idBien] ASC),
    CONSTRAINT [FK_BienEchange_membre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]),
    CONSTRAINT [FK_BienEchange_Pays] FOREIGN KEY ([Pays]) REFERENCES [dbo].[Pays] ([idPays])
);

