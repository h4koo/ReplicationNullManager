CREATE PROCEDURE [dbo].[GetReplicaLogsUnsynchronized]
	@intResult int = 0 OUTPUT
AS
BEGIN

BEGIN TRY

	SELECT
		[idReplicaLog],
		[ReplicaTable],
		[ReplicaDatetime],
		[ReplicaTransaction],
		[IsSynchronized]
	FROM [dbo].[ReplicaLog]
	WHERE 
		[IsSynchronized] = 0

END TRY
BEGIN CATCH

	SELECT @intResult = ERROR_MESSAGE() 
	
END CATCH

END
