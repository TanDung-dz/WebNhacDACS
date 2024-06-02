using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? Hide { get; set; }

    public string? Link { get; set; }

    public int? Permission { get; set; }

    public virtual ICollection<AdminPlayList> AdminPlayLists { get; set; } = new List<AdminPlayList>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();

    public virtual ICollection<SlideShow> SlideShows { get; set; } = new List<SlideShow>();
}
