using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class Blog
{
    public int IdBlog { get; set; }

    public int IdUser { get; set; }

    public string? Titile { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }

    public string? Img { get; set; }

    public DateTime? WriteDate { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
