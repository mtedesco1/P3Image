CREATE PROCEDURE [dbo].[GetDirectDemoById]
	@Id int = NULL
AS
	SELECT BT1.Value1 AS DirectDemoValue1,
		   BT1.Value2 AS DirectDemoValue2,
		   BT1.Value3 AS DirectDemoValue3,
		   BT2.Value1 AS DirectDemoValue4,
		   BT2.Value2 AS DirectDemoValue5,
		   BT2.Value3 AS DirectDemoValue6
	 FROM BadTable1 BT1 INNER JOIN BadTable2 BT2 ON BT1.Id = BT2.Id WHERE BT1.Id = @Id
RETURN 0
