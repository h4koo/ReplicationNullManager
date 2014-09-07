-- =============================================
-- Author:		Juan Pablo Arias Mora
-- Create date: 
-- Description:	This Method Encapsulate the Replica Insertion
-- =============================================
CREATE PROCEDURE [dbo].[InsertReplica] 
	-- Add the parameters for the stored procedure here
	@intIdSourceEngine int, 
	@strSourceIPAddress nchar(16),
    @intSourcePort int,
	@strSourceUser nchar(20),
    @strSourcePassword nchar(20),       
    @strSourceDatabase nchar(20),
	@strSourceTable nchar(20),
	@intIdTerminalEngine int,
    @strTerminalIPAddress nchar(16),
    @intTerminalPort int,
    @strTerminalUser nchar(20),
    @strTerminalPassword nchar(20),
    @strTerminalDatabase nchar(20),
	@intResult int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
		SELECT @intResult = 0;
		--UPDATE
		INSERT INTO [dbo].[Replica]
           ([SourceEngine]
           ,[SourceIPAddress]
           ,[SourcePort]
           ,[SourceUser]
           ,[SourcePassword]
           ,[SourceDatabase]
           ,[SourceTable]
           ,[TerminalEngine]
           ,[TerminalIPAddress]
           ,[TerminalPort]
           ,[TerminalUser]
           ,[TerminalPassword]
           ,[TerminalDatabase])
		VALUES
           (@intIdSourceEngine,
            @strSourceIPAddress,
            @intSourcePort,
            @strSourceUser,
            @strSourcePassword,
            @strSourceDatabase,
            @strSourceTable,
            @intIdTerminalEngine,
            @strTerminalIPAddress,
            @intTerminalPort,
            @strTerminalUser,
            @strTerminalPassword,
            @strTerminalDatabase
		)
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
    -- Insert statements for procedure here
END
