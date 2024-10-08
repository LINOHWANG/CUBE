/****** Script for SelectTopNRows command from SSMS  ******/
SELECT Distinct Substring(Convert(varchar,CreateDate,12),1,7),Sum(TotalPaid)
  FROM [db1SSShop].[dbo].[TranCollection]
  group by Substring(Convert(varchar,CreateDate,12),1,7)
  order by Substring(Convert(varchar,CreateDate,12),1,7)