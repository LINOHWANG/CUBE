USE [db1Cube]
GO
ALTER TABLE OrderComplete
ADD 
	ParentId  numeric(10,0) NULL,
    OrderCategoryId  int NULL
GO