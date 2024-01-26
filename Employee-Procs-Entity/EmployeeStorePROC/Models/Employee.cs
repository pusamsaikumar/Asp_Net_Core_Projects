using System;
using System.Collections.Generic;

namespace EmployeeStorePROC.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateofBirth { get; set; }

    public string Email { get; set; } = null!;

    public double Salary { get; set; }
}
