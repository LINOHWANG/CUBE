USE [dbSSShop]
GO
IF NOT EXISTS ( SELECT 1 FROM [sysConfig] WHERE [configname] = 'LABEL_PRINTER_NAME')
BEGIN
	INSERT [dbo].[sysConfig] ([configname], [configvalue], [configdesc], [IsActive]) VALUES (N'LABEL_PRINTER_NAME', N'LeftHans2 LH-560', 'LabelPrinter LeftHans2 LH-560' , 1)
END