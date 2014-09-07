EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_accessadmin', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_securityadmin', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_ddladmin', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_backupoperator', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_denydatareader', @membername = N'ReplicationManager_su';


GO
EXECUTE sp_addrolemember @rolename = N'db_denydatawriter', @membername = N'ReplicationManager_su';

