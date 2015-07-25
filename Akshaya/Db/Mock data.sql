BEGIN TRAN
GO

INSERT INTO [dbo].[Products]
           ([Code]
           ,[Description]
           ,[BuyingPrice]
           ,[UnitPrice]
           ,[CurrentlyAvailable])
     VALUES
           ('P1'
           ,NULL
           ,21
           ,10
           ,10)
		   ,
		   
           ('P2'
           ,NULL
           ,15
           ,7
           ,10)
		   ,
           ('P3'
           ,NULL
           ,45
           ,20
           ,3)
GO


COMMIT;