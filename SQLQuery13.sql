/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ReceiptId]
      ,[MemID]
      ,[ReceiptType]
      ,[Amount]
      ,[PaymentType]
      ,[ChequeNo]
      ,[BankName]
      ,[ChequeDate]
      ,[ReceiptDate]
      ,[UserID]
  FROM [OnlineLib].[dbo].[receipt_master]