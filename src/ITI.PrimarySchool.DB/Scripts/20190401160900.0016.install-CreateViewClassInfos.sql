-- Create the VIEW in the specified schema
CREATE VIEW iti.vClassInfo
AS
    -- Select rows from a Table or View 'tStudent' in schema 'iti'
    SELECT
        c.ClassId,
        c.Name,
        c.[Level],
        s.StudentId,
        SFirstname = s.FirstName ,
        SLastname = s.LastName ,
        t.TeacherId ,
        TFirstname = CASE WHEN t.TeacherId = 0 THEN N'' ELSE t.FirstName END,
        TLastname = CASE WHEN t.TeacherId = 0 THEN N'' ELSE t.LastName END
    FROM iti.tClass c LEFT OUTER JOIN iti.tStudent s
        ON s.ClassId = c.ClassId
        LEFT OUTER JOIN iti.tTeacher t
        ON c.TeacherId = t.TeacherId
    WHERE  c.ClassId <> 0

GO