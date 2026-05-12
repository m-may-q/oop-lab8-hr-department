using HRDepartment.Domain.Interfaces;

namespace HRDepartment.Domain.Models;

/// <summary>
/// Represents company project.
/// </summary>
public class Project : IEntity
{
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets project name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets project budget.
    /// </summary>
    public decimal Budget { get; set; }

    public Project(string name, decimal budget)
    {
        Name = name;
        Budget = budget;
    }
}