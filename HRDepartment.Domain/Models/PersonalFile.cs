namespace HRDepartment.Domain.Models;

/// <summary>
/// Represents personal employee file.
/// </summary>
public class PersonalFile
{
    /// <summary>
    /// Gets or sets hire date.
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    /// Gets or sets address.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets phone number.
    /// </summary>
    public string PhoneNumber { get; set; }

    public PersonalFile(DateTime hireDate, string address, string phoneNumber)
    {
        HireDate = hireDate;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}