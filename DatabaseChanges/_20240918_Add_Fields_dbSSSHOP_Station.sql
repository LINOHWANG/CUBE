USE [dbSSShop]
GO
ALTER TABLE [dbSSShop].[dbo].[Station]
ADD 
	[IsPaymentree] [bit] NULL,
	[Client_Id] [nvarchar](10) NULL,
	[Location] [nvarchar](6) NULL,
	[Register] [nvarchar](6) NULL
GO
