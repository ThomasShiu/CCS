

/****** Object:  StoredProcedure [dbo].[P_Sys_GetRightOperate]    Script Date: 12/01/2013 12:25:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:        <Author,,Name>
-- Create date: <Create Date,,>
-- Description:    <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Sys_GetRightOperate]
@userId varchar(50),@url varchar(200)
AS
--取模組的當前使用者操作許可權
select distinct KeyCode,IsValid from CS_SYSRIGHTOPERATE where RightId in(
select a.id from CS_SYSRIGHT a, CS_SYSMODULE b where RoleId in(
    select SysRoleId from CS_SYSROLESYSUSER where SysUserId =@userId)
    and a.ModuleId = b.Id
    and b.Url =@url)
    and IsValid=1


GO
