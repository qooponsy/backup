
--DB全体
EXEC sp_spaceused

--テーブル単体
EXEC sp_spaceused '[dbo].[T_Trade]'
EXEC sp_spaceused '[dbo].[T_Cash]'
EXEC sp_spaceused '[dbo].[M_Product]'
EXEC sp_spaceused '[dbo].[T_CustHist]'
EXEC sp_spaceused '[dbo].[T_RateHistExerc]'
EXEC sp_spaceused '[dbo].[T_ProductTradeSum]'
EXEC sp_spaceused '[dbo].[T_ProductTradeSumCur]'

--name				テーブル名
--rows				レコード数
--reserved			テーブル用にリザーブされている容量
--data				データが使っているディスク容量
--index_size		インデックスが使っているディスク容量
--unused			リザーブされているが使われていない容量

