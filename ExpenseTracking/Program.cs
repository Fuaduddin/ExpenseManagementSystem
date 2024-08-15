using ExpenseTracking.IinterFace;
using ExpenseTracking.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

///////// Connection String & Register Start /////
//builder.Services.AddScoped<IClassService, ClassService>();
//builder.Services.AddScoped<ISQLQuires, SQLQuires>();
builder.Services.AddScoped<ILoginSingup, LoginSingup>();
void Configuration(IServiceCollection services)
{
    services.AddControllers();
    services.AddSingleton<IConfiguration>();
    services.AddMvc().AddRazorPagesOptions(options =>
    {
        options.Conventions.AddPageRoute("Home/Index", "");
    });
}
///////// Connection String & Register END /////
