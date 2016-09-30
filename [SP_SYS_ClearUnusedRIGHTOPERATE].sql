Create proc [dbo].[SP_SYS_ClearUnusedRIGHTOPERATE]
as
--清理許可權中的無用專案
delete from CS_SYSRIGHTOPERATE where Id not in(
    select a.RoleId+a.ModuleId+b.KeyCode from CS_SYSRIGHT a,CS_SYSMODULEOPERATE b
        where a.ModuleId = b.ModuleId
)
GO

