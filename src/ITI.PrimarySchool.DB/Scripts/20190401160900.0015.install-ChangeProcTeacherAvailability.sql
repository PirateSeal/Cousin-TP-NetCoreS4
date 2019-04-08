USE [ITI.PrimarySchool]
GO

/****** Object:  StoredProcedure [iti].[sTeacherCreate]    Script Date: 02/04/2019 14:10:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER proc [iti].[sTeacherCreate]
(
    @FirstName nvarchar(32),
    @LastName  nvarchar(32),
	@TeacherId int out
)
as
begin
	set transaction isolation level serializable;
	begin tran;

	if exists(select * from iti.tTeacher t where t.FirstName = @FirstName and t.LastName = @LastName)
	begin
		rollback;
		return 1;
	end;

    insert into iti.tTeacher(FirstName, LastName, [Availability]) values(@FirstName, @LastName, 1);
	set @TeacherId = scope_identity();
	commit;
    return 0;
end;
GO
