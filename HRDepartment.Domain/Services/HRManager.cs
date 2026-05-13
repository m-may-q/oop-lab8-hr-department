using HRDepartment.Domain.Models;

namespace HRDepartment.Domain.Services;

/// <summary>
/// Represents HR manager service.
/// </summary>
public class HRManager
{
    /// <summary>
    /// Gets employees list.
    /// </summary>
    public List<Employee> Employees { get; }

    /// <summary>
    /// Gets departments list.
    /// </summary>
    public List<Department> Departments { get; }

    /// <summary>
    /// Gets positions list.
    /// </summary>
    public List<Position> Positions { get; }

    public HRManager()
    {
        Employees = new List<Employee>();
        Departments = new List<Department>();
        Positions = new List<Position>();
    }

    /// <summary>
    /// Adds employee.
    /// </summary>
    public void AddEmployee(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        Employees.Add(employee);
    }

    /// <summary>
    /// Removes employee.
    /// </summary>
    public void RemoveEmployee(Employee employee)
    {
        if (!Employees.Contains(employee))
        {
            throw new InvalidOperationException("Employee not found.");
        }

        Employees.Remove(employee);
    }

    /// <summary>
    /// Adds department.
    /// </summary>
    public void AddDepartment(Department department)
    {
        if (department == null)
        {
            throw new ArgumentNullException(nameof(department));
        }

        Departments.Add(department);
    }

    /// <summary>
    /// Adds position.
    /// </summary>
    public void AddPosition(Position position)
    {
        if (position == null)
        {
            throw new ArgumentNullException(nameof(position));
        }

        Positions.Add(position);
    }

    /// <summary>
    /// Returns all employees.
    /// </summary>
    public List<Employee> GetAllEmployees()
    {
        return Employees;
    }

    /// <summary>
    /// Sorts employees by first name.
    /// </summary>
    public List<Employee> SortEmployeesByFirstName()
    {
        return Employees
            .OrderBy(e => e.FirstName)
            .ToList();
    }

    /// <summary>
    /// Sorts employees by last name.
    /// </summary>
    public List<Employee> SortEmployeesByLastName()
    {
        return Employees
            .OrderBy(e => e.LastName)
            .ToList();
    }

    /// <summary>
    /// Sorts employees by salary.
    /// </summary>
    public List<Employee> SortEmployeesBySalary()
    {
        return Employees
            .OrderByDescending(e => e.Position.Salary)
            .ToList();
    }

    /// <summary>
    /// Returns top 5 attractive positions.
    /// </summary>
    public List<Position> GetTopPositions()
    {
        return Positions
            .OrderByDescending(p => p.Salary / p.WorkingHoursPerMonth)
            .Take(5)
            .ToList();
    }

    /// <summary>
    /// Returns most profitable employee for position.
    /// </summary>
    public Employee? GetMostProfitableEmployee(Position position)
    {
        return Employees
            .Where(e => e.Position == position)
            .OrderByDescending(
                e => e.Projects.Sum(p => p.Budget) /
                     Math.Max(e.WorkExperience, 1))
            .FirstOrDefault();
    }
    
    /// <summary>
    /// Updates employee data.
    /// </summary>
    public void UpdateEmployee(
        Guid employeeId,
        string newFirstName,
        string newLastName,
        int newWorkExperience)
    {
        var employee = Employees.FirstOrDefault(
            e => e.Id == employeeId);

        if (employee == null)
        {
            throw new InvalidOperationException(
                "Employee not found.");
        }

        employee.FirstName = newFirstName;
        employee.LastName = newLastName;
        employee.WorkExperience = newWorkExperience;
    }
    
    /// <summary>
    /// Returns employee by identifier.
    /// </summary>
    public Employee? GetEmployeeById(Guid id)
    {
        return Employees.FirstOrDefault(
            e => e.Id == id);
    }
    
    /// <summary>
    /// Returns employee projects.
    /// </summary>
    public List<Project> GetEmployeeProjects(Guid employeeId)
    {
        var employee = Employees.FirstOrDefault(
            e => e.Id == employeeId);

        if (employee == null)
        {
            throw new InvalidOperationException(
                "Employee not found.");
        }

        return employee.Projects;
    }
    
    /// <summary>
    /// Updates department name.
    /// </summary>
    public void UpdateDepartment(
        Guid departmentId,
        string newName)
    {
        var department = Departments.FirstOrDefault(
            d => d.Id == departmentId);

        if (department == null)
        {
            throw new InvalidOperationException(
                "Department not found.");
        }

        department.Name = newName;
    }
    
    /// <summary>
    /// Returns department by identifier.
    /// </summary>
    public Department? GetDepartmentById(Guid id)
    {
        return Departments.FirstOrDefault(
            d => d.Id == id);
    }
    
    /// <summary>
    /// Returns department employees.
    /// </summary>
    public List<Employee> GetDepartmentEmployees(
        Guid departmentId)
    {
        var department = Departments.FirstOrDefault(
            d => d.Id == departmentId);

        if (department == null)
        {
            throw new InvalidOperationException(
                "Department not found.");
        }

        return department.Employees;
    }
    
    /// <summary>
    /// Sorts department employees by position.
    /// </summary>
    public List<Employee> SortDepartmentEmployeesByPosition(
        Guid departmentId)
    {
        var department = Departments.FirstOrDefault(
            d => d.Id == departmentId);

        if (department == null)
        {
            throw new InvalidOperationException(
                "Department not found.");
        }

        return department.Employees
            .OrderBy(e => e.Position.Title)
            .ToList();
    }
    
    /// <summary>
    /// Sorts department employees by projects budget.
    /// </summary>
    public List<Employee>
        SortDepartmentEmployeesByProjectCost(
            Guid departmentId)
    {
        var department = Departments.FirstOrDefault(
            d => d.Id == departmentId);

        if (department == null)
        {
            throw new InvalidOperationException(
                "Department not found.");
        }

        return department.Employees
            .OrderByDescending(
                e => e.Projects.Sum(
                    p => p.Budget))
            .ToList();
    }
    
    /// <summary>
    /// Updates position data.
    /// </summary>
    public void UpdatePosition(
        Guid positionId,
        string newTitle,
        decimal newSalary)
    {
        var position = Positions.FirstOrDefault(
            p => p.Id == positionId);

        if (position == null)
        {
            throw new InvalidOperationException(
                "Position not found.");
        }

        position.Title = newTitle;
        position.Salary = newSalary;
    }
    
}

