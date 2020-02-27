IF NOT EXISTS ( SELECT * FROM master.dbo.syslogins where loginname = N'@MachineName@\ASPNET' )
BEGIN
	EXEC sp_grantlogin N'@MachineName@\ASPNET'
	EXEC sp_defaultdb N'@MachineName@\ASPNET', N'@DatabaseName@'
END

GO

USE [@DatabaseName@]

IF NOT EXISTS ( SELECT * FROM dbo.sysusers WHERE name = N'ASPNET' AND uid < 16382 )
BEGIN
  EXEC sp_grantdbaccess N'@MachineName@\ASPNET', N'ASPNET'
END

GO

USE [@DatabaseName@]
  
EXEC sp_addrolemember N'db_owner', N'ASPNET'

GO
