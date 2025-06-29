IF NOT EXISTS (
    SELECT * FROM sysobjects WHERE name='Employees' AND xtype='U'
)
BEGIN
    CREATE TABLE Employees (
        EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
        FirstName VARCHAR(50),
        LastName VARCHAR(50),
        DepartmentID INT,
        Salary DECIMAL(10,2),
        JoinDate DATE
    );
END;
GO

IF OBJECT_ID('sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertEmployee;
GO

IF OBJECT_ID('sp_GetEmpByDepart', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmpByDepart;
GO

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM Employees
        WHERE FirstName = @FirstName AND LastName = @LastName
              AND DepartmentID = @DepartmentID AND JoinDate = @JoinDate
    )
    BEGIN
        INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
        VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
    END
END;
GO

CREATE PROCEDURE sp_GetEmpByDepart
    @DepartmentID INT
AS
BEGIN
    SELECT 
        EmployeeID,
        FirstName, 
        LastName, 
        DepartmentID, 
        Salary, 
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

DELETE FROM Employees
WHERE FirstName IN ('Usha', 'Priya', 'Rahul', 'Neha', 'Suresh', 'Anjali');
GO

EXEC sp_InsertEmployee 
    @FirstName = 'Usha',
    @LastName = 'Chinnu',
    @DepartmentID = 2,
    @Salary = 48000.00,
    @JoinDate = '2025-06-28';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'Priya',
    @LastName = 'Verma',
    @DepartmentID = 2,
    @Salary = 52000.00,
    @JoinDate = '2025-06-29';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'Rahul',
    @LastName = 'Singh',
    @DepartmentID = 3,
    @Salary = 60000.00,
    @JoinDate = '2025-06-27';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'Neha',
    @LastName = 'Patel',
    @DepartmentID = 3,
    @Salary = 55000.00,
    @JoinDate = '2025-06-26';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'Suresh',
    @LastName = 'Kumar',
    @DepartmentID = 4,
    @Salary = 47000.00,
    @JoinDate = '2025-06-25';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'Anjali',
    @LastName = 'Mehra',
    @DepartmentID = 2,
    @Salary = 51000.00,
    @JoinDate = '2025-06-30';
GO

EXEC sp_GetEmpByDepart 
    @DepartmentID = 2;
GO

EXEC sp_GetEmpByDepart 
    @DepartmentID = 3;
GO

EXEC sp_GetEmpByDepart 
    @DepartmentID = 4;
GO
TRUNCATE TABLE Employees;
GO

