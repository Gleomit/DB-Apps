use SoftUni

GO

CREATE PROCEDURE GetProjectsByEmployee
	@FirstName nvarchar(64), 
    @LastName nvarchar(64)
AS
	SELECT p.ProjectID, p.Name, p.Description, p.StartDate, p.EndDate FROM EmployeesProjects AS ep
	INNER JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID
	WHERE e.FirstName = @FirstName AND e.LastName = @LastName
GO