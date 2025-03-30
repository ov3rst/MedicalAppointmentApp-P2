using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("AppClient", options =>
{
    options.BaseAddress = new Uri("http://localhost:5291/api/");
    options.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddSingleton<IAppHttpClient, AppHttpClient>();

//builder.Services.AddDbContext<AppointmentDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
