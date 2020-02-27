IF NOT EXISTS ( SELECT * FROM master.dbo.syslogins WHERE loginname = N'@LoginName@' )
   EXEC sp_addlogin N'@LoginName@', N'@LoginPassword@', N'@DatabaseName@'

GO

USE [@DatabaseName@]
if '@LoginName@' <> 'sa'
BEGIN
   IF NOT EXISTS (SELECT * FROM sysusers WHERE name = N'@LoginName@' AND uid < 16382 )
   BEGIN
      EXEC sp_grantdbaccess N'@LoginName@', N'@LoginName@'
   END
   
   EXEC sp_addrolemember N'db_owner', N'@LoginName@'
END

GO
