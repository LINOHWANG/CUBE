USE [db1SSShop]
GO

/****** Object:  Table [dbo].[InventoryLog]    Script Date: 2024-11-04 11:42:40 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryLog]') AND type in (N'U'))
DROP TABLE [dbo].[InventoryLog]
GO

/****** Object:  Table [dbo].[InventoryLog]    Script Date: 2024-11-04 11:42:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventoryLog](
	[Id] [int] NULL,
	[ProductId] [int] NULL,
	[ProductTypeId] [int] NULL,
	[LogTypeId] [int] NULL,
	[BeforeQTY] [float] NULL,
	[AfterQTY] [float] NULL,
	[CreateStation] [varchar](50) NULL,
	[CreatePassCode] [varchar](30) NULL,
	[DateTimeCreated] [datetime] NULL
) ON [PRIMARY]
GO


