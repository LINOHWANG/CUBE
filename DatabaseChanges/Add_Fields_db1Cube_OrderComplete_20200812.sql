USE [db1Cube]
GO
ALTER TABLE OrderComplete
ADD 
    IsVoid bit null,
    VoidDate nvarchar(10) null,
    VoidTime nvarchar(8) null
GO