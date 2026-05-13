using HRDepartment.Domain.Models;
using HRDepartment.Domain.Services;

var hrManager = new HRManager();
var searchService = new SearchService();

var isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("HR DEPARTMENT SYSTEM");
    Console.WriteLine("1. Add employee");
    Console.WriteLine("2. Remove employee");
    Console.WriteLine("3. Update employee");
    Console.WriteLine("4. Show all employees");
    Console.WriteLine("5. Show employee details");
    Console.WriteLine("6. Sort employees by first name");
    Console.WriteLine("7. Sort employees by last name");
    Console.WriteLine("8. Sort employees by salary");
    Console.WriteLine("9. Search employees");
    Console.WriteLine("10. Global search");
    Console.WriteLine("11. Show top positions");
    Console.WriteLine("0. Exit");

    Console.WriteLine();

    Console.Write("Choose option: ");

    var choice = Console.ReadLine();

    Console.WriteLine();

    switch (choice)
    {
        case "1":
            AddEmployee(hrManager);
            break;

        case "2":
            RemoveEmployee(hrManager);
            break;

        case "3":
            UpdateEmployee(hrManager);
            break;

        case "4":
            ShowEmployees(hrManager);
            break;

        case "5":
            ShowEmployeeDetails(hrManager);
            break;

        case "6":
            SortByFirstName(hrManager);
            break;

        case "7":
            SortByLastName(hrManager);
            break;

        case "8":
            SortBySalary(hrManager);
            break;

        case "9":
            SearchEmployees(hrManager, searchService);
            break;

        case "10":
            GlobalSearch(hrManager, searchService);
            break;

        case "11":
            ShowTopPositions(hrManager);
            break;

        case "0":
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void AddEmployee(HRManager hrManager)
{
    Console.Write("First name: ");
    var firstName = Console.ReadLine();

    Console.Write("Last name: ");
    var lastName = Console.ReadLine();

    Console.Write("Salary account number: ");
    var accountNumber = Console.ReadLine();

    Console.Write("Work experience: ");
    var workExperience = int.Parse(Console.ReadLine()!);

    Console.Write("Department name: ");
    var departmentName = Console.ReadLine();

    Console.Write("Position title: ");
    var positionTitle = Console.ReadLine();

    Console.Write("Salary: ");
    var salary = decimal.Parse(Console.ReadLine()!);

    Console.Write("Working hours per month: ");
    var workingHours = int.Parse(Console.ReadLine()!);

    Console.Write("Address: ");
    var address = Console.ReadLine();

    Console.Write("Phone number: ");
    var phoneNumber = Console.ReadLine();

    var department = new Department(departmentName!);

    var position = new Position(
        positionTitle!,
        salary,
        workingHours);

    var personalFile = new PersonalFile(
        DateTime.Now,
        address!,
        phoneNumber!);

    var employee = new Employee(
        firstName!,
        lastName!,
        accountNumber!,
        workExperience,
        department,
        position,
        personalFile);

    Console.Write("How many projects?: ");

    var projectCount = int.Parse(Console.ReadLine()!);

    for (var i = 0; i < projectCount; i++)
    {
        Console.Write("Project name: ");
        var projectName = Console.ReadLine();

        Console.Write("Project budget: ");
        var projectBudget =
            decimal.Parse(Console.ReadLine()!);

        var project = new Project(
            projectName!,
            projectBudget);

        employee.Projects.Add(project);
    }

    hrManager.AddDepartment(department);
    hrManager.AddPosition(position);
    hrManager.AddEmployee(employee);

    department.Employees.Add(employee);

    Console.WriteLine();
    Console.WriteLine("Employee added successfully.");
}

static void RemoveEmployee(HRManager hrManager)
{
    ShowEmployees(hrManager);

    Console.WriteLine();

    Console.Write("Enter employee id: ");

    var id = Guid.Parse(Console.ReadLine()!);

    var employee = hrManager.GetEmployeeById(id);

    if (employee == null)
    {
        Console.WriteLine("Employee not found.");
        return;
    }

    hrManager.RemoveEmployee(employee);

    Console.WriteLine("Employee removed.");
}

static void UpdateEmployee(HRManager hrManager)
{
    ShowEmployees(hrManager);

    Console.WriteLine();

    Console.Write("Employee id: ");

    var id = Guid.Parse(Console.ReadLine()!);

    Console.Write("New first name: ");
    var firstName = Console.ReadLine();

    Console.Write("New last name: ");
    var lastName = Console.ReadLine();

    Console.Write("New work experience: ");
    var workExperience =
        int.Parse(Console.ReadLine()!);

    hrManager.UpdateEmployee(
        id,
        firstName!,
        lastName!,
        workExperience);

    Console.WriteLine("Employee updated.");
}

static void ShowEmployees(HRManager hrManager)
{
    foreach (var employee in hrManager.GetAllEmployees())
    {
        Console.WriteLine(
            $"{employee.Id} | {employee}");
    }
}

static void ShowEmployeeDetails(HRManager hrManager)
{
    ShowEmployees(hrManager);

    Console.WriteLine();

    Console.Write("Employee id: ");

    var id = Guid.Parse(Console.ReadLine()!);

    var employee = hrManager.GetEmployeeById(id);

    if (employee == null)
    {
        Console.WriteLine("Employee not found.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine($"Name: {employee.FirstName}");
    Console.WriteLine($"Last name: {employee.LastName}");
    Console.WriteLine(
        $"Account: {employee.SalaryAccountNumber}");
    Console.WriteLine(
        $"Department: {employee.Department.Name}");
    Console.WriteLine(
        $"Position: {employee.Position.Title}");
    Console.WriteLine(
        $"Experience: {employee.WorkExperience}");

    Console.WriteLine();
    Console.WriteLine("PROJECTS:");

    foreach (var project in employee.Projects)
    {
        Console.WriteLine(
            $"{project.Name} | {project.Budget}");
    }
}

static void SortByFirstName(HRManager hrManager)
{
    foreach (var employee
             in hrManager.SortEmployeesByFirstName())
    {
        Console.WriteLine(employee);
    }
}

static void SortByLastName(HRManager hrManager)
{
    foreach (var employee
             in hrManager.SortEmployeesByLastName())
    {
        Console.WriteLine(employee);
    }
}

static void SortBySalary(HRManager hrManager)
{
    foreach (var employee
             in hrManager.SortEmployeesBySalary())
    {
        Console.WriteLine(employee);
    }
}

static void SearchEmployees(
    HRManager hrManager,
    SearchService searchService)
{
    Console.Write("Keyword: ");

    var keyword = Console.ReadLine();

    var result =
        searchService.SearchEmployees(
            hrManager.Employees,
            keyword!);

    Console.WriteLine();

    foreach (var employee in result)
    {
        Console.WriteLine(employee);
    }
}

static void GlobalSearch(
    HRManager hrManager,
    SearchService searchService)
{
    Console.Write("Keyword: ");

    var keyword = Console.ReadLine();

    var allProjects =
        hrManager.Employees
            .SelectMany(e => e.Projects)
            .ToList();

    var result =
        searchService.GlobalSearch(
            hrManager.Employees,
            allProjects,
            hrManager.Departments,
            hrManager.Positions,
            keyword!);

    Console.WriteLine();

    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}

static void ShowTopPositions(HRManager hrManager)
{
    foreach (var position
             in hrManager.GetTopPositions())
    {
        Console.WriteLine(
            $"{position.Title} | " +
            $"Salary: {position.Salary}");
    }
}