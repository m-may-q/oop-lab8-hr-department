using HRDepartment.Domain.Interfaces;

namespace HRDepartment.Domain.Models;

/// <summary>
/// Represents employee.
/// </summary>
public class Employee : Person, IEntity
{
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets salary account number.
    /// </summary>
    public string SalaryAccountNumber { get; set; }

    /// <summary>
    /// Gets or sets work experience.
    /// </summary>
    public int WorkExperience { get; set; }

    /// <summary>
    /// Gets or sets department.
    /// </summary>
    public Department Department { get; set; }

    /// <summary>
    /// Gets or sets employee position.
    /// </summary>
    public Position Position { get; set; }

    /// <summary>
    /// Gets or sets personal file.
    /// </summary>
    public PersonalFile PersonalFile { get; set; }

    /// <summary>
    /// Gets or sets projects list.
    /// </summary>
    public List<Project> Projects { get; set; }

    public Employee(
        string firstName,
        string lastName,
        string salaryAccountNumber,
        int workExperience,
        Department department,
        Position position,
        PersonalFile personalFile)
        : base(firstName, lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be empty.");
        }

        if (workExperience < 0)
        {
            throw new ArgumentException("Work experience cannot be negative.");
        }

        SalaryAccountNumber = salaryAccountNumber;
        WorkExperience = workExperience;
        Department = department;
        Position = position;
        PersonalFile = personalFile;

        Projects = new List<Project>();
    }

    /// <summary>
    /// Returns employee information.
    /// </summary>
    public override string ToString()
    {
        return $"{FirstName} {LastName} | " +
               $"Department: {Department.Name} | " +
               $"Position: {Position.Title} | " +
               $"Salary: {Position.Salary}";
    }
}