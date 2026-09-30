using System;
using System.Collections.Generic;

namespace DormAPI.Database.EF.Scaffolding;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int EmployeeTypeId { get; set; }

    public int PersonId { get; set; }

    public virtual EmployeeType EmployeeType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
