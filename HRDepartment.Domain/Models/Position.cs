using HRDepartment.Domain.Interfaces;

namespace HRDepartment.Domain.Models;

/// <summary>
/// Represents employee position.
/// </summary>
public class Position : IEntity
{
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets salary.
    /// </summary>
    public decimal Salary { get; set; }

    /// <summary>
    /// Gets or sets working hours.
    /// </summary>
    public int WorkingHoursPerMonth { get; set; }

    public Position(string title, decimal salary, int workingHoursPerMonth)
    {
        Title = title;
        Salary = salary;
        WorkingHoursPerMonth = workingHoursPerMonth;
    }
}