using HRDepartment.Domain.Interfaces;

namespace HRDepartment.Domain.Models;

/// <summary>
/// Represents department.
/// </summary>
public class Department : IEntity
{
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets department name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets employees list.
    /// </summary>
    public List<Employee> Employees { get; set; }

    public Department(string name)
    {
        Name = name;
        Employees = new List<Employee>();
    }
}