USE [dbADSDCafe]
GO

/****** Object:  Table [dbo].[CardReceipt]    Script Date: 10/09/2019 15:38:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CardReceipt](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ReceiptInformation] [nvarchar](2) NULL,
	[SeqNo] [nvarchar](1) NULL,
	[TransactionType] [nvarchar](2) NULL,
	[TransactionStatus] [nvarchar](2) NULL,
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
	[CustomerCardDescription] [nvarchar](20) NULL,
	[CustomerAccountNumber] [nvarchar](50) NULL,
	[CustomerLanguage] [nvarchar](1) NULL,
	[CustomerAccountType] [nvarchar](1) NULL,
	[CustomerCardEntryMode] [nvarchar](1) NULL,
	[EmvAid] [nvarchar](50) NULL,
	[EmvTvr] [nvarchar](10) NULL,
	[EmvTsi] [nvarchar](4) NULL,
	[EMVApplicationLabel] [nvarchar](50) NULL,
	[CVMResult] [nvarchar](1) NULL,
	[AuthorizationNo] [nvarchar](50) NULL,
	[HostResponseCode] [nvarchar](50) NULL,
	[HostResponseText] [nvarchar](50) NULL,
	[HostResponseISOCode] [nvarchar](2) NULL,
	[RetrievalReferenceNo] [nvarchar](50) NULL,
	[AmountDue] [nvarchar](20) NULL,
	[TraceNo] [nvarchar](50) NULL,
	[CardBalance] [nvarchar](20) NULL,
	[HostTransactionRefNbr] [nvarchar](50) NULL,
	[BatchNumber] [nvarchar](50) NULL,
	[TerminalId] [nvarchar](50) NULL,
	[DemoMode] [nvarchar](1) NULL,
	[MerchId] [nvarchar](50) NULL,
	[MerchCurrencyCode] [nvarchar](20) NULL,
	[ReceiptHeader1] [nvarchar](50) NULL,
	[ReceiptHeader2] [nvarchar](50) NULL,
	[ReceiptHeader3] [nvarchar](50) NULL,
	[ReceiptHeader4] [nvarchar](50) NULL,
	[ReceiptHeader5] [nvarchar](50) NULL,
	[ReceiptHeader6] [nvarchar](50) NULL,
	[ReceiptHeader7] [nvarchar](50) NULL,
	[ReceiptFooter1] [nvarchar](50) NULL,
	[ReceiptFooter2] [nvarchar](50) NULL,
	[ReceiptFooter3] [nvarchar](50) NULL,
	[ReceiptFooter4] [nvarchar](50) NULL,
	[ReceiptFooter5] [nvarchar](50) NULL,
	[ReceiptFooter6] [nvarchar](50) NULL,
	[ReceiptFooter7] [nvarchar](50) NULL,
	[EndorsementLine1] [nvarchar](50) NULL,
	[EndorsementLine2] [nvarchar](50) NULL,
	[EndorsementLine3] [nvarchar](50) NULL,
	[EndorsementLine4] [nvarchar](50) NULL,
	[EndorsementLine5] [nvarchar](50) NULL,
	[EndorsementLine6] [nvarchar](50) NULL,
	[EmvRespCode] [nvarchar](2) NULL,
	[TransactionData] [nvarchar](max) NULL,
	[CreateInvoiceNo] [int] NULL,
	[CreateDate] [nvarchar](10) NULL,
	[CreateTime] [nvarchar](8) NULL,
	[CreateUserId] [int] NULL,
	[CreateUserName] [nvarchar](20) NULL,
	[CreateStation] [nvarchar](10) NULL,
 CONSTRAINT [PK_CardReceipt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


