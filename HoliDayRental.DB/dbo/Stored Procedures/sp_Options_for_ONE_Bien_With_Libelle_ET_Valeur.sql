-- =============================================
-- Author:		Stefania
-- Create date: 02/03/2022
-- Description:	Recuperare tutte le opzioni, comprese di label associate a UN bene 
-- =============================================
CREATE PROCEDURE [dbo].[sp_Options_for_ONE_Bien_With_Libelle_ET_Valeur]

	@bene int
AS
BEGIN
	SELECT OptionsBien.idBien, OptionsBien.idOption, Options.Libelle, OptionsBien.Valeur
	FROM     BienEchange INNER JOIN
                  OptionsBien ON BienEchange.idBien = OptionsBien.idBien INNER JOIN
                  Options ON OptionsBien.idOption = Options.idOption
	WHERE OptionsBien.idBien = @bene
END
GO
