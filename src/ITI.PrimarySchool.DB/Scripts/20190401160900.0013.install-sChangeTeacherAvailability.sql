-- Create the stored procedure in the specified schema
CREATE PROCEDURE iti.sChangeTeacherAvailability
    @teacherId /*parameter name*/ int
/*datatype_for_param1*/
-- add more stored procedure parameters here
AS
-- body of the stored procedure
-- Update rows in table 'iti.tTeacher'
UPDATE iti.tTeacher
    SET
        [Availability] = [Availability]^1
-- add more columns and values here
WHERE TeacherId = @teacherId	/* add search conditions here */
GO