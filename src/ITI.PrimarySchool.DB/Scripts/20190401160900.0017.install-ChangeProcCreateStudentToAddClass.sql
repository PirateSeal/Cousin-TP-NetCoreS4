/****** Object:  StoredProcedure [iti].[sStudentCreate]    Script Date: 03/04/2019 09:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [iti].[sStudentCreate]
    (
    @FirstName   NVARCHAR(64),
    @LastName    NVARCHAR(64),
    @BirthDate   DATETIME2,
    @GitHubLogin NVARCHAR(64),
    @StudentId   INT out,
    @ClassId INT
)
AS
BEGIN
    SET TRANSACTION isolation level serializable;
    BEGIN TRAN;

    IF EXISTS(SELECT *
    FROM iti.tStudent s
    WHERE s.FirstName = @FirstName AND s.LastName = @LastName)
	BEGIN
        ROLLBACK;
        RETURN 1;
    END;

    IF @GitHubLogin <> N'' AND EXISTS(SELECT *
        FROM iti.tGitHubStudent s
        WHERE s.GitHubLogin = @GitHubLogin)
	BEGIN
        ROLLBACK;
        RETURN 2;
    END;

    INSERT INTO iti.tStudent
        (FirstName, LastName, BirthDate, ClassId)
    VALUES(@FirstName, @LastName, @BirthDate, @ClassId);
    SET @StudentId = scope_identity();
    IF @GitHubLogin <> N'' INSERT INTO iti.tGitHubStudent
        (StudentId, GitHubLogin)
    VALUES(@StudentId, @GitHubLogin);

    COMMIT;
    RETURN 0;
END;