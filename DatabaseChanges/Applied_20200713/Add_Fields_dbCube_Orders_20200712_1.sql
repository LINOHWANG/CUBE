USE [dbCube]
GO
ALTER TABLE Orders
ADD 
	ParentId  numeric(10,0) NULL,
    OrderCategoryId  int NULL
GO