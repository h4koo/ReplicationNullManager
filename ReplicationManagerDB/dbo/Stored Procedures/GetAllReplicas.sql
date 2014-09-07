-- =============================================
-- Author:		Juan Pablo Arias Mora
-- Create date: 9/4/2014
-- Description:	This Storage Procedure will check all the current configure Replicas on the DB, Using the View Replicas
-- =============================================
CREATE PROCEDURE [dbo].[GetAllReplicas] 
	-- Add the parameters for the stored procedure here
	@intResult int = 0 OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY
		SELECT * FROM [ReplicationManager].[dbo].[Replicas];
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
