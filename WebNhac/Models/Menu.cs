using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Name { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public int IdAdmin { get; set; }

    public virtual Admin IdAdminNavigation { get; set; } = null!;
}
