/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CategoryID]
      ,[CategoryType]
      ,[NoOfBooks]
      ,[NoOfDays]
      ,[LateFine]
      ,[DepositAmount]
      ,[CardRenewFees]
  FROM [OnlineLib].[dbo].[category]