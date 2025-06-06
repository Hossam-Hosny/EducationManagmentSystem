using Faculty_Student.Application.Extensions;
using Faculty_Student.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Cookies")
                    .AddCookie("Cookies", options =>
                    {
                        options.LoginPath = "/Auth/Login";
                        options.LogoutPath = "/Auth/Logout";
                        options.AccessDeniedPath = "/Auth/AccessDenied";
                        options.Cookie.HttpOnly = true;
                        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    });
builder.Services.AddAuthorization();


// Adding Infrastructure Layer to IOC
builder.Services.AddInfrastructure();

// Adding Application Layer to IOC
builder.Services.AddApplication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
