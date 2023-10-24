using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<IDestinationRepository, DestinationRepository>();
builder.Services.AddTransient<IDestinationService, DestinationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    //endpoints.MapRazorPages();
});

app.Run();
