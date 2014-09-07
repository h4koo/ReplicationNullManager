-- =============================================
-- Author:		Juan Pablo Arias Mora
-- Create date: 9/4/2014
-- Description:	Get All Supported Engines
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSupportedEngines] 
	-- Add the parameters for the stored procedure here
	@intResult int = 0 OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY
		SELECT @intResult = 0;
		SELECT * FROM [ReplicationManager].[dbo].[Engine];
	END TRY
	BEGIN CATCH
		
		SELECT @intResult = ERROR_NUMBER() 
			--   ERROR_NUMBER() AS ErrorNumber,
			--   ERROR_SEVERITY() AS ErrorSeverity,
			--   ERROR_STATE() AS ErrorState,
			--   ERROR_PROCEDURE() AS ErrorProcedure,
			--   ERROR_LINE() AS ErrorLine,
			--   ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END
