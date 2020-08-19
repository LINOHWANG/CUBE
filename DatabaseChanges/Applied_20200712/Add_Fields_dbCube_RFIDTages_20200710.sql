USE [dbCube]
GO
ALTER TABLE RFIDTags
ADD 
	DiscountRate float NULL,
	DateTimeDiscount datetime NULL,
	IsDonation bit NULL,
	DateTimeDonation datetime NULL
GO