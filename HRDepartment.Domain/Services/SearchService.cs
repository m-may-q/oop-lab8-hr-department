using HRDepartment.Domain.Models;

namespace HRDepartment.Domain.Services;

/// <summary>
/// Represents search service.
/// </summary>
public class SearchService
{
    /// <summary>
    /// Searches employees by keyword.
    /// </summary>
    public List<Employee> SearchEmployees(
        List<Employee> employees,
        string keyword)
    {
        keyword = keyword.ToLower();

        return employees
            .Where(e =>
                e.FirstName.ToLower().Contains(keyword) ||
                e.LastName.ToLower().Contains(keyword) ||
                e.Department.Name.ToLower().Contains(keyword) ||
                e.Position.Title.ToLower().Contains(keyword))
            .ToList();
    }

    /// <summary>
    /// Searches projects by keyword.
    /// </summary>
    public List<Project> SearchProjects(
        List<Project> projects,
        string keyword)
    {
        keyword = keyword.ToLower();

        return projects
            .Where(p => p.Name.ToLower().Contains(keyword))
            .ToList();
    }

    /// <summary>
    /// Performs advanced employee search.
    /// </summary>
    public List<Employee> AdvancedEmployeeSearch(
        List<Employee> employees,
        string? lastName,
        string? accountNumber)
    {
        return employees
            .Where(e =>
                (string.IsNullOrWhiteSpace(lastName) ||
                 e.LastName == lastName) &&

                (string.IsNullOrWhiteSpace(accountNumber) ||
                 e.SalaryAccountNumber == accountNumber))
            .ToList();
    }
    
    /// <summary>
    /// Performs global search.
    /// </summary>
    public List<string> GlobalSearch(
        List<Employee> employees,
        List<Project> projects,
        List<Department> departments,
        List<Position> positions,
        string keyword)
    {
        keyword = keyword.ToLower();

        var results = new List<string>();

        results.AddRange(
            employees
                .Where(e =>
                    e.FirstName.ToLower().Contains(keyword) ||
                    e.LastName.ToLower().Contains(keyword))
                .Select(e =>
                    $"Employee: {e.FirstName} {e.LastName}"));

        results.AddRange(
            projects
                .Where(p =>
                    p.Name.ToLower().Contains(keyword))
                .Select(p =>
                    $"Project: {p.Name}"));

        results.AddRange(
            departments
                .Where(d =>
                    d.Name.ToLower().Contains(keyword))
                .Select(d =>
                    $"Department: {d.Name}"));

        results.AddRange(
            positions
                .Where(p =>
                    p.Title.ToLower().Contains(keyword))
                .Select(p =>
                    $"Position: {p.Title}"));

        return results;
    }
    
}