using System;
using System.Collections.Generic;

namespace StudentEntityFirstApproach.Models;

public partial class EmployeeDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? RollNumber { get; set; }

    public string? Country { get; set; }
}
