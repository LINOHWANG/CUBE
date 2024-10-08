USE [dbCube]
GO

/****** Object:  Table [dbo].[Promotion]    Script Date: 09/02/2020 16:22:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Promotion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PromoName] [nvarchar](50) NULL,
	[PromoType] [int] NULL,
	[PromoValue] [float] NULL,
	[PromoQTY] [int] NULL,
	[PromoStartDttm] [datetime] NULL,
	[PromoEndDttm] [datetime] NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


