
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Web.Middleware;
using Chatty.Blogs.Web;
using Chatty.Blogs.Web.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;
using Chatty.Blogs.Web.Transformers;

var builder = WebApplication.CreateBuilder(args);

// Setup DI Modules
Modules.RegisterBlogsWebModule(builder.Services);

// Setup Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Setup Cookie Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
		options.SlidingExpiration = true;
		options.AccessDeniedPath = "/Forbidden/";
		options.LoginPath = "/admin/login";
	});

builder.Services.AddSession();

// Setup SqlSugar ORM
builder.Services.AddSqlSugarContext(builder.Configuration);

// Slugify Urls
builder.Services.AddRouting(option =>
{
    option.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
    option.LowercaseUrls = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
})
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddMemoryCache();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("zh-CN"),
        new CultureInfo("en-US"),
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "zh-CN", uiCulture: "zh-CN");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

}); ;

var app = builder.Build();

// Apply Localization
var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/error/{0}");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// RedirectMiddleware must before UseAuthorization
app.UseMiddleware<RedirectMiddleware>();

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};
app.UseCookiePolicy(cookiePolicyOptions);

app.MapControllerRoute(
	name: "areaRoute",
	pattern: "{area:exists:slugify}/{controller:slugify}/{action:slugify=Index}/{id?}");

app.MapControllerRoute(
    name: "admin_not_found",
    pattern: "admin/{*url}",
    defaults: new { controller = "Home", action = "NotFound404", area = "Admin" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");

app.Run();
