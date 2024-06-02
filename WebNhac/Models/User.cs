using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? Hide { get; set; }

    public string? Link { get; set; }

    public int? Permission { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<PersonalPlayList> PersonalPlayLists { get; set; } = new List<PersonalPlayList>();
}
