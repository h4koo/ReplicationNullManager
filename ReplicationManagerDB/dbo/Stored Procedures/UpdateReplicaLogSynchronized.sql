CREATE PROCEDURE [dbo].[UpdateReplicaLogSynchronized]
	@intIdReplicaLog AS INT,
	@intResult int = 0 OUTPUT
AS
BEGIN
	

BEGIN TRY

	UPDATE [dbo].[ReplicaLog]
	SET
		[IsSynchronized] = 1
	WHERE
		[idReplicaLog] = @intIdReplicaLog

END TRY
BEGIN CATCH

		SELECT @intResult = ERROR_MESSAGE() 

END CATCH


END
