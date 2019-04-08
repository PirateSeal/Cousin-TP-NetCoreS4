-- Add a new column '[Availability]' to table 'tTeacher' in schema 'iti'
ALTER TABLE iti.tTeacher
    ADD [Availability] /*new_column_name*/ BIT /*new_column_datatype*/ NULL /*new_column_nullability*/
GO

-- Update rows in table 'iti.tTeacher'
UPDATE iti.tTeacher
SET
    [Availability] = 1
GO

/****** Object:  View [iti].[vTeacher]    Script Date: 01/04/2019 16:21:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER view [iti].[vTeacher]
as
    select
        TeacherId = t.TeacherId,
        FirstName = t.FirstName,
        LastName = t.LastName,
        [Availability] = t.[Availability]
    from iti.tTeacher t
    where t.TeacherId <> 0;
GO

-- Alter column 'iti.tTeacher' to NOT NULL in schema 'iti'
ALTER TABLE iti.tTeacher
    ALTER COLUMN [Availability] /*column_name*/ BIT /*column_datatype*/ NOT NULL /*column_nullability*/
GO