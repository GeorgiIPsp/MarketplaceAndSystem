using System;
using System.Collections.Generic;

namespace Marketplace.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public DateOnly? DateDismissal { get; set; }

    public int IdAdministrator { get; set; }

    public int WarehouseId { get; set; }

    public virtual Administrator IdAdministratorNavigation { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual Warehouse Warehouse { get; set; } = null!;

    public virtual ICollection<WorkLog> WorkLogs { get; set; } = new List<WorkLog>();
}
