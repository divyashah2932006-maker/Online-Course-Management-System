using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => { o.LoginPath = "/Account/Login"; });

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite("Data Source=courses.db"));

var app = builder.Build();

// Add the demonstration catalogue once; existing courses and enrollments are preserved.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await CourseSeeder.SeedAsync(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();   // must come BEFORE UseAuthorization
app.UseAuthorization();

// custom route (Phase 1 requirement)
app.MapControllerRoute(
    name: "courses",
    pattern: "courses/list",
    defaults: new { controller = "Course", action = "Index" });

// default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();