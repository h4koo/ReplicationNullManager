-- =============================================
-- Author:		Juan Pablo Arias Mora
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE DeleteReplica 
	-- Add the parameters for the stored procedure here
	@intIdReplica int,
	@intResult int = 0 OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
		DELETE FROM [dbo].[Replica] WHERE [Replica].[idReplica] = @intIdReplica;
		SELECT @intResult = 0 ;
	END TRY
	BEGIN CATCH
		
		SELECT @intResult = ERROR_MESSAGE() 
			--   ERROR_NUMBER() AS ErrorNumber,
			--   ERROR_SEVERITY() AS ErrorSeverity,
			--   ERROR_STATE() AS ErrorState,
			--   ERROR_PROCEDURE() AS ErrorProcedure,
			--   ERROR_LINE() AS ErrorLine,
			--   ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END
