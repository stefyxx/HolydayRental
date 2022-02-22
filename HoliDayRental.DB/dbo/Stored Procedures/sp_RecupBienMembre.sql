-- =============================================
-- Author:		Cognitic 
-- Create date: 28/02/2015
-- Description:	Récupérer les biens d'un membre
-- =============================================
CREATE PROCEDURE [dbo].[sp_RecupBienMembre] 
	@idMembre int
AS
BEGIN
	select * from BienEchange
	where idMembre = @idMembre
END
