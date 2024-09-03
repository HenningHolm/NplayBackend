using NPlay.Data.Enitites;
using NPlay.Shared.Models.Settings;
using Microsoft.EntityFrameworkCore;
using NplayBackend.Data;
using NplayBackend.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("NplayDb") ?? throw new InvalidOperationException("Connection string not found.");
builder.Services.AddDbContext<NplayDbContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Allow all origins, methods and headers, this is just for development purposes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
               builder => builder.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<NplayDbContext>();

builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["GoogleAuth:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["GoogleAuth:ClientSecret"];

    })
    .AddFacebook(facebookOptions =>
    {
        facebookOptions.AppId = builder.Configuration["FacebookAuth:AppId"];
        facebookOptions.AppSecret = builder.Configuration["FacebookAuth:AppSecret"];
    });

builder.Services.Configure<OrganisationSettings>(builder.Configuration.GetSection("OrganisationSettings"));
builder.Services.AddApplicationTypes(builder.Configuration);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None; // Eller SameSiteMode.Lax
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Nødvendig hvis du bruker None
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
