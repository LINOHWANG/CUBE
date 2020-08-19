/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *  FROM [dbCube].[dbo].[Orders]
SELECT *  FROM [dbCube].[dbo].[RfidTags]
SELECT *  FROM [db1Cube].[dbo].[OrderComplete] order by id desc
SELECT *  FROM [db1Cube].[dbo].[TranCollection] order by id desc
/*Update [dbCube].[dbo].[RfidTags] Set IsUsed=0, InvoiceNo=0*/
use db1Cube
go
select * from OrderComplete where CompleteDate >= '2020-07-13' and CompleteDate <= '2020-07-13' and CompleteTime >= '00:00:00' and CompleteTime <= '23:59:59' 

/*update OrderComplete set CompleteDate = '2020-07-13' where CompleteDate = '7/13/2020'
update [TranCollection] set CreateDate = '2020-07-13' where CreateDate = '7/13/2020'*/