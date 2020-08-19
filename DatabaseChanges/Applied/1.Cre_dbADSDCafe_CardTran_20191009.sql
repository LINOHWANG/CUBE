USE [dbADSDCafe]
GO

/****** Object:  Table [dbo].[CardTran]    Script Date: 10/09/2019 15:35:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CardTran](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[TransactionStatus] [nvarchar](2) NULL,
	[MultiTranFlag] [nvarchar](1) NULL,
	[TransactionType] [nvarchar](2) NULL,
	[TransactionDate] [nvarchar](6) NULL,
	[TransactionTime] [nvarchar](6) NULL,
	[TransactionAmount] [nvarchar](20) NULL,
	[TipAmount] [nvarchar](20) NULL,
	[CashBackAmount] [nvarchar](20) NULL,
	[SurchargeAmount] [nvarchar](20) NULL,
	[TaxAmount] [nvarchar](20) NULL,
	[TotalAmount] [nvarchar](20) NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[PurchaseOrderNo] [nvarchar](50) NULL,
	[ReferenceNo] [nvarchar](50) NULL,
	[TransactionSequenceNo] [nvarchar](50) NULL,
	[TicketNo] [nvarchar](50) NULL,
	[VoucherNo] [nvarchar](50) NULL,
	[ClerkId] [nvarchar](50) NULL,
	[GiftCardReferenceNo] [nvarchar](50) NULL,
	[OriginalTransactionType] [nvarchar](2) NULL,
	[CustomerCardType] [nvarchar](2) NULL,
	[CustomerAccountNumber] [nvarchar](50) NULL,
	[CustomerCardEntryMode] [nvarchar](1) NULL,
	[CardNotPresent] [nvarchar](1) NULL,
	[AuthorizationNo] [nvarchar](50) NULL,
	[HostResponseCode] [nvarchar](50) NULL,
	[HostResponseText] [nvarchar](50) NULL,
	[HostResponseISOCode] [nvarchar](2) NULL,
	[AmountDue] [nvarchar](20) NULL,
	[CardBalance] [nvarchar](20) NULL,
	[HostTransactionRefNbr] [nvarchar](50) NULL,
	[TerminalId] [nvarchar](50) NULL,
	[DemoMode] [nvarchar](1) NULL,
	[TransactionData] [nvarchar](max) NULL,
	[CreateInvoiceNo] [int] NULL,
	[CreateDate] [nvarchar](10) NULL,
	[CreateTime] [nvarchar](8) NULL,
	[CreateUserId] [int] NULL,
	[CreateUserName] [nvarchar](20) NULL,
	[CreateStation] [nvarchar](10) NULL,
 CONSTRAINT [PK_CardTran] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


