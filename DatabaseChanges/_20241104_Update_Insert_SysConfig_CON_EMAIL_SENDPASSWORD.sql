USE [dbSSShop]
GO

IF NOT EXISTS ( SELECT 1 FROM [sysConfig] WHERE [configname] = 'CON_EMAIL_SENDPASSWORD')
	BEGIN
		INSERT [dbo].[sysConfig] ([configname], [configvalue], [configdesc], [IsActive]) VALUES (N'CON_EMAIL_SENDPASSWORD', N'aoY0/gp3J3femlXpVoeoAw==', N'Send email account password' , 1)
	END
ELSE
	BEGIN
		UPDATE [dbo].[sysConfig] SET [configvalue] = 'aoY0/gp3J3femlXpVoeoAw==' WHERE  [configname] = 'CON_EMAIL_SENDPASSWORD'
	END
