/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CardHisID]
      ,[LibCardID]
      ,[MemID]
      ,[ValidFrom]
      ,[ValidUpto]
      ,[IsActive]
      ,[UserID]
      ,[UpdateDate]
  FROM [OnlineLib].[dbo].[library_card_history]