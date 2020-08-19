USE [dbADSDCafe]
GO

/****** Object:  Table [dbo].[mfWorkstation]    Script Date: 10/10/2019 09:59:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Station](
	[ComputerName] [nvarchar](64) NULL,
	[Station] [nvarchar](16) NULL,
	[StationName] [nvarchar](64) NULL,
	[Created_Dttm] [date] NULL,
	[Modified_Dttm] [date] NULL,	
	[IP_Addr] [nvarchar](255) NULL,
	[StationNo] [int] NULL,
	[IPS_Port] [int] NULL,
	[POLE_COM_Port] [int] NULL,	
	[POLE_COM_Settings] [nvarchar](64) NULL,	
	[CAS_COM_Port] [int] NULL,
	[CAS_COM_Settings] [nvarchar](64) NULL,
	[CAS_Init_Char] [nvarchar](10) NULL,
	[CAS_Req_Char] [nvarchar](10) NULL,
	[Enabled] [int] NULL	
) ON [PRIMARY]

GO