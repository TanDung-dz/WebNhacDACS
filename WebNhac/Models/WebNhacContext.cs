using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebNhac.Models;

public partial class WebNhacContext : DbContext
{
    public WebNhacContext()
    {
    }

    public WebNhacContext(DbContextOptions<WebNhacContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminPlayList> AdminPlayLists { get; set; }

    public virtual DbSet<AdminPlayListEntry> AdminPlayListEntries { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Music> Musics { get; set; }

    public virtual DbSet<MusicType> MusicTypes { get; set; }

    public virtual DbSet<Mv> Mvs { get; set; }

    public virtual DbSet<PersonalPlayList> PersonalPlayLists { get; set; }

    public virtual DbSet<PersonalPlayListEntry> PersonalPlayListEntries { get; set; }

    public virtual DbSet<Singer> Singers { get; set; }

    public virtual DbSet<SlideShow> SlideShows { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-79UVCQ2;Database=WebNhac;Trusted_Connection=True;TrustServerCertificate= true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admin__89472E955DE7D369");

            entity.ToTable("Admin");

            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Permission).HasColumnName("permission");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AdminPlayList>(entity =>
        {
            entity.HasKey(e => e.IdPlaylist).HasName("PK__AdminPla__666FAF7584A75F0D");

            entity.ToTable("AdminPlayList");

            entity.Property(e => e.IdPlaylist).HasColumnName("id_playlist");
            entity.Property(e => e.CreateDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.AdminPlayLists)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdminPlay__id_ad__5441852A");
        });

        modelBuilder.Entity<AdminPlayListEntry>(entity =>
        {
            entity.HasKey(e => new { e.IdMusic, e.IdPlaylist }).HasName("PK__AdminPla__69876381F75C9C64");

            entity.ToTable("AdminPlayList_Entry");

            entity.Property(e => e.IdMusic).HasColumnName("id_music");
            entity.Property(e => e.IdPlaylist).HasColumnName("id_playlist");
            entity.Property(e => e.AddDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("add_date");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Order).HasColumnName("order");

            entity.HasOne(d => d.IdMusicNavigation).WithMany(p => p.AdminPlayListEntries)
                .HasForeignKey(d => d.IdMusic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdminPlay__id_mu__5535A963");

            entity.HasOne(d => d.IdPlaylistNavigation).WithMany(p => p.AdminPlayListEntries)
                .HasForeignKey(d => d.IdPlaylist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdminPlay__id_pl__5629CD9C");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor).HasName("PK__Author__7411B254F793D7FD");

            entity.ToTable("Author");

            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.Avattar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("avattar");
            entity.Property(e => e.Birthday)
                .HasColumnType("smalldatetime")
                .HasColumnName("birthday");
            entity.Property(e => e.CoverImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cover_img");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.History)
                .HasColumnType("ntext")
                .HasColumnName("history");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(255)
                .HasColumnName("nationality");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Sex).HasColumnName("sex");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.IdBlog).HasName("PK__Blog__D920E861EA69A078");

            entity.ToTable("Blog");

            entity.Property(e => e.IdBlog).HasColumnName("id_blog");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Titile)
                .HasMaxLength(255)
                .HasColumnName("titile");
            entity.Property(e => e.WriteDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("write_date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Blog__id_user__571DF1D5");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.IdHistory).HasName("PK_History_1");

            entity.ToTable("History");

            entity.Property(e => e.IdHistory).HasColumnName("id_history");
            entity.Property(e => e.IdMusic).HasColumnName("id_music");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.ListenedDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("listened_date");

            entity.HasOne(d => d.IdMusicNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdMusic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Music1");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_User1");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__68A1D9DBCABD1C57");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("id_menu");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Menu__id_admin__59FA5E80");
        });

        modelBuilder.Entity<Music>(entity =>
        {
            entity.HasKey(e => e.IdMusic).HasName("PK__Music__2FE199764E915393");

            entity.ToTable("Music");

            entity.Property(e => e.IdMusic).HasColumnName("id_music");
            entity.Property(e => e.CountListened).HasColumnName("count_listened");
            entity.Property(e => e.Fille)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fille");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdMusictype).HasColumnName("id_musictype");
            entity.Property(e => e.IdSinger).HasColumnName("id_singer");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Lyric)
                .HasColumnType("ntext")
                .HasColumnName("lyric");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.PublishDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("publish_date");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Music__id_admin__5AEE82B9");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Music__id_author__5BE2A6F2");

            entity.HasOne(d => d.IdMusictypeNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdMusictype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Music__id_musict__5CD6CB2B");

            entity.HasOne(d => d.IdSingerNavigation).WithMany(p => p.Musics)
                .HasForeignKey(d => d.IdSinger)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Music__id_singer__5DCAEF64");
        });

        modelBuilder.Entity<MusicType>(entity =>
        {
            entity.HasKey(e => e.IdMusictype).HasName("PK__MusicTyp__7E98DBE4BE3CA07D");

            entity.ToTable("MusicType");

            entity.Property(e => e.IdMusictype).HasColumnName("id_musictype");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
        });

        modelBuilder.Entity<Mv>(entity =>
        {
            entity.HasKey(e => e.IdMv).HasName("PK__MV__01488BAE6FB73E39");

            entity.ToTable("MV");

            entity.Property(e => e.IdMv).HasColumnName("id_mv");
            entity.Property(e => e.CountView).HasColumnName("count_view");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.IdSinger).HasColumnName("id_singer");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.PublishDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("publish_date");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");
            entity.Property(e => e.YtbLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ytb_link");

            entity.HasOne(d => d.IdSingerNavigation).WithMany(p => p.Mvs)
                .HasForeignKey(d => d.IdSinger)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MV__id_singer__5EBF139D");
        });

        modelBuilder.Entity<PersonalPlayList>(entity =>
        {
            entity.HasKey(e => e.IdPlaylist).HasName("PK__Personal__666FAF75FE3B4D60");

            entity.ToTable("PersonalPlayList");

            entity.Property(e => e.IdPlaylist).HasColumnName("id_playlist");
            entity.Property(e => e.CreateDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.PersonalPlayLists)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PersonalP__id_us__5FB337D6");
        });

        modelBuilder.Entity<PersonalPlayListEntry>(entity =>
        {
            entity.HasKey(e => new { e.IdMusic, e.IdPlaylist }).HasName("PK__Personal__69876381DB95BB2F");

            entity.ToTable("PersonalPlayList_Entry");

            entity.Property(e => e.IdMusic).HasColumnName("id_music");
            entity.Property(e => e.IdPlaylist).HasColumnName("id_playlist");
            entity.Property(e => e.AddDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("add_date");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Order).HasColumnName("order");

            entity.HasOne(d => d.IdMusicNavigation).WithMany(p => p.PersonalPlayListEntries)
                .HasForeignKey(d => d.IdMusic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PersonalP__id_mu__60A75C0F");

            entity.HasOne(d => d.IdPlaylistNavigation).WithMany(p => p.PersonalPlayListEntries)
                .HasForeignKey(d => d.IdPlaylist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PersonalP__id_pl__619B8048");
        });

        modelBuilder.Entity<Singer>(entity =>
        {
            entity.HasKey(e => e.IdSinger).HasName("PK__Singer__4D87DB3DFE92BECF");

            entity.ToTable("Singer");

            entity.Property(e => e.IdSinger).HasColumnName("id_singer");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Birthday)
                .HasColumnType("smalldatetime")
                .HasColumnName("birthday");
            entity.Property(e => e.CoverImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cover_img");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.History)
                .HasColumnType("ntext")
                .HasColumnName("history");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(255)
                .HasColumnName("nationality");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Sex).HasColumnName("sex");
        });

        modelBuilder.Entity<SlideShow>(entity =>
        {
            entity.HasKey(e => e.IdSlideshow).HasName("PK__SlideSho__E13A25E8B995F369");

            entity.ToTable("SlideShow");

            entity.Property(e => e.IdSlideshow).HasColumnName("id_slideshow");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Text)
                .HasMaxLength(255)
                .HasColumnName("text");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.SlideShows)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SlideShow__id_ad__628FA481");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__D2D146373F11C128");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Permission).HasColumnName("permission");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
