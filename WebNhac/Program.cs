using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebNhac.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString =
builder.Configuration.GetConnectionString("WebNhacConnection");
builder.Services.AddDbContext<WebNhacContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
AddCookie(options =>
{
    options.Cookie.Name = "WebnhacCookie";
    options.LoginPath = "/User/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "trang-chu",
        pattern: "trang-chu",
        defaults: new { controller = "Home", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "bai-hat",
        pattern: "bai-hat",
        defaults: new { controller = "AllMusic", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "bang-xep-hang",
        pattern: "bang-xep-hang",
        defaults: new { controller = "Rank", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "bai-hat",
        pattern: "bai-hat/{slug}-{id}",
        defaults: new { controller = "Music", action = "Index" }
    );
    endpoints.MapControllerRoute(
     name: "dang-ky",
     pattern: "dang-ky",
     defaults: new { controller = "User", action = "Register" }
     );
    endpoints.MapControllerRoute(
         name: "dang-nhap",
         pattern: "dang-nhap",
         defaults: new { controller = "User", action = "Login" }
         );
    endpoints.MapControllerRoute(
         name: "thong-tin",
         pattern: "thong-tin",
         defaults: new { controller = "User", action = "Info" }
         );
    endpoints.MapControllerRoute(
         name: "sua-thong-tin",
         pattern: "sua-thong-tin",
         defaults: new { controller = "User", action = "EditInfo" }
         );
    endpoints.MapControllerRoute(
         name: "dang-xuat",
         pattern: "dang-xuat",
         defaults: new { controller = "User", action = "Logout" }
         );
    endpoints.MapControllerRoute(
         name: "quan-tri",
         pattern: "quan-tri",
         defaults: new { controller = "Admin", action = "Index" }
         );
    endpoints.MapControllerRoute(
         name: "quan-tri-nhac",
         pattern: "quan-tri-nhac",
         defaults: new { controller = "Admin", action = "QLNhac" }
         );
    endpoints.MapControllerRoute(
         name: "quan-tri-danh-muc",
         pattern: "quan-tri-danh-muc",
         defaults: new { controller = "Admin", action = "QLDanhmuc" }
         );
    endpoints.MapControllerRoute(
         name: "quan-tri-MV",
         pattern: "quan-tri-MV",
         defaults: new { controller = "Admin", action = "QLMV" }
         );
    endpoints.MapControllerRoute(
         name: "quan-tri-user",
         pattern: "quan-tri-user",
         defaults: new { controller = "Admin", action = "QLNguoidung" }
         );
    endpoints.MapControllerRoute(
        name: "playlist",
        pattern: "playlist",
        defaults: new { controller = "Playlist", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "nghe-playlist",
        pattern: "nghe-playlist/{slug}-{id}",
        defaults: new { controller = "PlaylistEntry", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "xem-mv",
        pattern: "xem-mv/{slug}-{id}",
        defaults: new { controller = "MV", action = "Index" }
    );
    endpoints.MapControllerRoute
    (
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
