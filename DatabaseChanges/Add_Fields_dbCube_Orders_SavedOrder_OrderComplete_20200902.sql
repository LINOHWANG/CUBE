USE [dbCube]
GO
ALTER TABLE Orders
ADD 
    IsDiscounted bit null
GO
USE [dbCube]
GO
ALTER TABLE SavedOrders
ADD 
    IsDiscounted bit null
GO
USE [db1Cube]
GO
ALTER TABLE OrderComplete
ADD 
    IsDiscounted bit null
GO