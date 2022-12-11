using System;
using System.Collections.Generic;

namespace ProjetMVC.Models;

public partial class Service
{
    public int Idservice { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
