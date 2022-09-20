/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [UserID]
      ,[UserName]
      ,[UserPassword]
      ,[UserType]
      ,[IsEnable]
  FROM [OnlineLib].[dbo].[user_master]