USE [dbCube]
GO
ALTER TABLE ProductType
ADD 
	IsBatchDonation bit NULL,
	IsBatchDiscount bit NULL
GO