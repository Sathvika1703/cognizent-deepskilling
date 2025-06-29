IF OBJECT_ID('Employees', 'U') IS NOT NULL
    DROP TABLE Employees;
GO

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DepartmentID INT
);
GO

INSERT INTO Employees (FirstName, LastName, DepartmentID) VALUES
('Usha', 'Chinnu', 1),
('Ram', 'Johnson', 1),
('Charlie', 'Williams', 2),
('David', 'Brown', 2),
('Eva', 'Davis', 1);
GO

IF OBJECT_ID('GetEmployeeCountByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE GetEmployeeCountByDepartment;
GO

CREATE PROCEDURE GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees 
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
BEGIN 
     SELECT FirstName, LastName, DepartmentID FROM Employees
     WHERE DepartmentID = @DepartmentID;
End;
GO

EXEC GetEmployeeCountByDepartment @DepartmentID = 1;
