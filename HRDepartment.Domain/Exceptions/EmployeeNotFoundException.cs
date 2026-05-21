namespace HRDepartment.Domain.Exceptions;

/// <summary>
/// Represents employee not found exception.
/// </summary>
public sealed class EmployeeNotFoundException
    : Exception
{
    public EmployeeNotFoundException()
        : base("Employee not found.")
    {
    }
}
