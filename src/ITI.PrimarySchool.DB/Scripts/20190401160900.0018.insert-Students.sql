-- Insert rows into table 'iti.tClass'
INSERT INTO iti.tClass
    ( -- columns to insert data into
    [Name], [Level],TeacherId
    )
VALUES
    ( -- first row: values for the columns in the list above
        'ClassName1', 'CM2', 0
),
    ( -- second row: values for the columns in the list above
        'ClassName2', 'CM2', 0
)
-- add more rows here
GO

-- Insert rows into table 'iti.tStudent'
INSERT INTO iti.tStudent
    ( -- columns to insert data into
    FirstName, LastName, BirthDate, ClassId
    )
VALUES
    ( -- first row: values for the columns in the list above
        'StudentFN1', 'StudentLN1', '20001010', 1
),
    (
        'StudentFN2', 'StudentLN2', '20001010', 1
),
    (
        'StudentFN3', 'StudentLN3', '20001010', 1
),
    (
        'StudentFN4', 'StudentLN4', '20001010', 1
),
    (
        'StudentFN5', 'StudentLN5', '20001010', 1
),
    (
        'StudentFN6', 'StudentLN6', '20001010', 2
),
    (
        'StudentFN7', 'StudentLN7', '20001010', 2
)
,
    (
        'StudentFN8', 'StudentLN8', '20001010', 2
)
,
    (
        'StudentFN9', 'StudentLN9', '20001010', 2
)
,
    (
        'StudentFN10', 'StudentLN10', '20001010', 2
)
-- add more rows here
GO

-- Insert rows into table 'iti.tTeacher'
INSERT INTO iti.tTeacher
    ( -- columns to insert data into
    FirstName, LastName, [Availability]
    )
VALUES
    ( -- first row: values for the columns in the list above
        'TeacherFN1', 'TeacherLN1', 1
),
    (
        'TeacherFN2', 'TeacherLN2', 1
),
    (
        'TeacherFN3', 'TeacherLN3', 1
)
GO