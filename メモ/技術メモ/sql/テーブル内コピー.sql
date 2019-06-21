
--BEGIN TRAN

INSERT INTO [Penguin8].[dbo].[T_TradeNew_bk20150910]
           ([InsTime]
           ,[TradeSeq]
           ,[TradeSubSeq]
           ,[TradeStatus])
SELECT
--			top 1
			[InsTime]
           ,[TradeSeq]
           ,[TradeSubSeq]
           ,[TradeStatus]
From [Penguin8].[dbo].[T_TradeNew] with (nolock)

--ROLLBACK

--4742087
--4742087
--select count(*) from T_TradeNew with (nolock)
--select count(*) from T_TradeNew_bk20150910 with (nolock)


