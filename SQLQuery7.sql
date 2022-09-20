/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [LibCardID]
      ,[MemID]
      ,[CreateDate]
      ,[UserID]
      ,[ValidFrom]
      ,[ValidUpto]
      ,[IsActive]
  FROM [OnlineLib].[dbo].[library_card]