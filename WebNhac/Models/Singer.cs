using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class Singer
{
    public int IdSinger { get; set; }

    public string? Name { get; set; }

    public bool? Sex { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Nationality { get; set; }

    public string? Avatar { get; set; }

    public string? CoverImg { get; set; }

    public string? History { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();

    public virtual ICollection<Mv> Mvs { get; set; } = new List<Mv>();
}
