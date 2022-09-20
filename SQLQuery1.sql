/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Au_ID]
      ,[Author]
      ,[year_Born]
      ,[Description]
  FROM [OnlineLib].[dbo].[authors]