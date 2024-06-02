using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class Author
{
    public int IdAuthor { get; set; }

    public string? Name { get; set; }

    public bool? Sex { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Nationality { get; set; }

    public string? Avattar { get; set; }

    public string? CoverImg { get; set; }

    public string? History { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
}
