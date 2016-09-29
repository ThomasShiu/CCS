SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[SP_SYS_INSERTSYSRIGHT]
as
--將設置好的模組分配到角色組
    insert into CS_SYSRIGHT(Id,ModuleId,RoleId,Rightflag)
        select distinct b.Id+a.Id,a.Id,b.Id,0 from CS_SYSMODULE a,CS_SYSROLE b
        where a.Id+b.Id not in(select ModuleId+RoleId from CS_SYSRIGHT)

