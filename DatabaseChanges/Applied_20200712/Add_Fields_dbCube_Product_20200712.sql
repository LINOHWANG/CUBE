USE [dbCube]
GO
ALTER TABLE Product
ADD 
	Deposit  float NULL,
    RecyclingFee  float NULL,
    ChillCharge  float NULL
GO