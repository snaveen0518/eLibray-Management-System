/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [MemID]
      ,[CatID]
      ,[CreateDate]
      ,[UserId]
      ,[Title]
      ,[FName]
      ,[MName]
      ,[LName]
      ,[Dob]
      ,[Profession]
      ,[Qualification]
      ,[Address]
      ,[City]
      ,[PostalCode]
      ,[Country]
      ,[Email]
      ,[TelephoneO]
      ,[TelephoneH]
      ,[MobileNo]
      ,[Photo]
  FROM [OnlineLib].[dbo].[m]