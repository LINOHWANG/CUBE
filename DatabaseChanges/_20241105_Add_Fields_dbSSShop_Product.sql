USE [dbSSShop]
GO
ALTER TABLE Product
ADD 
    IsSalesButton bit NULL
GO

Update Product Set IsSalesButton = 1;