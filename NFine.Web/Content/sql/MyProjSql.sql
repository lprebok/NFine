
/****** Object:  StoredProcedure [dbo].[MY_Base_GetWeekOfDay]    Script Date: 2019-01-08 17:58:44 ******/
DROP PROCEDURE [dbo].[MY_Base_GetWeekOfDay]
GO

/****** Object:  StoredProcedure [dbo].[MY_Base_GetWeekOfDay]    Script Date: 2019-01-08 17:58:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		来朋
-- Create date: 2019年1月8日
-- Description:	获取日期是第几周
-- =============================================
CREATE PROCEDURE [dbo].[MY_Base_GetWeekOfDay]
@StarDate DATETIME,
@EndDate DATETIME
AS
BEGIN
	SET NOCOUNT ON;

SET DATEFIRST 1;

SELECT DATEPART(WEEK,@StarDate) AS FResult

END

GO

/****** Object:  StoredProcedure [dbo].[MY_ProjProg_GetLastBill]    Script Date: 2019-01-08 19:03:46 ******/
DROP PROCEDURE [dbo].[MY_ProjProg_GetLastBill]
GO

/****** Object:  StoredProcedure [dbo].[MY_ProjProg_GetLastBill]    Script Date: 2019-01-08 19:03:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		来朋
-- Create date: 2019年1月8日
-- Description:	获取指定人员上条单据信息
-- =============================================
CREATE PROCEDURE [dbo].[MY_ProjProg_GetLastBill]
@StarDate DATETIME,
@EndDate DATETIME,
@FCode VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @BillNO VARCHAR(100)
	SET @BillNO=''
SELECT @BillNO=mppm.FBillNO
FROM dbo.MY_ProjProgressMain AS mppm
WHERE NOT EXISTS(SELECT 1 FROM dbo.MY_ProjProgressMain AS mppm2 WHERE mppm2.FStarDate>mppm.FStarDate
      AND mppm2.FCode=mppm.FCode AND mppm2.FCancelFlag=0 AND mppm2.FStarDate<@StarDate)
AND mppm.FCode=@FCode AND mppm.FCancelFlag=0 
AND mppm.FStarDate<@StarDate

SELECT ISNULL(@BillNO,'') AS FResult

END

GO

