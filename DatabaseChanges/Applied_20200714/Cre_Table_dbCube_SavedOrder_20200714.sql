USE [dbCube]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 07/14/2020 13:50:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SavedOrders](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[TranType] [nvarchar](2) NULL,
	[ProductId] [nvarchar](20) NULL,
	[ProductName] [nvarchar](75) NULL,
	[SecondName] [nvarchar](75) NULL,
	[ProductTypeId] [int] NULL,
	[InUnitPrice] [float] NULL,
	[OutUnitPrice] [float] NULL,
	[IsTax1] [bit] NULL,
	[IsTax2] [bit] NULL,
	[IsTax3] [bit] NULL,
	[UnitCategoryId] [smallint] NULL,
	[Deposit] [float] NULL,
	[RecyclingFee] [float] NULL,
	[ChillCharge] [float] NULL,
	[IsPointException] [bit] NULL,
	[IsManualPrice] [bit] NULL,
	[IsTaxInverseCalculation] [bit] NULL,
	[Tare] [float] NULL,
	[Quantity] [float] NULL,
	[Amount] [float] NULL,
	[Tax1Rate] [float] NULL,
	[Tax2Rate] [float] NULL,
	[Tax3Rate] [float] NULL,
	[Tax1] [float] NULL,
	[Tax2] [float] NULL,
	[Tax3] [float] NULL,
	[InvoiceNo] [int] NULL,
	[IsPaidComplete] [bit] NULL,
	[CompleteDate] [nvarchar](10) NULL,
	[CompleteTime] [nvarchar](8) NULL,
	[CreateDate] [nvarchar](10) NULL,
	[CreateTime] [nvarchar](8) NULL,
	[CreateUserId] [int] NULL,
	[CreateUserName] [nvarchar](20) NULL,
	[CreateStation] [nvarchar](10) NULL,
	[LastModDate] [nvarchar](10) NULL,
	[LastModTime] [nvarchar](8) NULL,
	[LastModUserId] [int] NULL,
	[LastModUserName] [nvarchar](20) NULL,
	[LastModStation] [nvarchar](10) NULL,
	[RFTagID] [int] NULL,
	[ParentId] [numeric](10, 0) NULL,
	[OrderCategoryId] [int] NULL,
 CONSTRAINT [PK_SavedOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


