using Fuel.Price.Qld.Db;
using Fuel.Price.Qld.Jobs;
using Fuel.Price.Qld.Options;
using Fuel.Price.Qld.Service;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<HashAlgorithm>(serviceProvider => SHA256.Create());
builder.Services.AddOptions<DiagnosticsOptions>().Bind(builder.Configuration.GetSection("Diagnostics"));
builder.Services.AddOptions<QueenslandGovAPIOptions>().Bind(builder.Configuration.GetSection("QueenslandGovAPI"));
builder.Services.AddHangfire(
                config => config
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(builder.Configuration.GetConnectionString("Hangfire")));
builder.Services.AddHangfireServer();
builder.Services.AddDbContext<FuelPriceQldDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FuelPriceQldDb")));
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<IBrandSearchService, BrandSearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard(
                options: new DashboardOptions
                {
                    Authorization = new[]
                    {
                        new BasicAuthAuthorizationFilter(
                            new BasicAuthAuthorizationFilterOptions
                            {
                                Users = new[]
                                {
                                    new BasicAuthAuthorizationUser
                                    {
                                        Login = builder.Configuration.GetSection("DiagnosticsKey").Value,
                                        PasswordClear = builder.Configuration.GetSection("DiagnosticsKey").Value
                                    }
                                }
                            })
                    }
                });

var manager = new RecurringJobManager();
manager.AddOrUpdate<BrandJob>(nameof(BrandJob), job => job.Execute(), Cron.Hourly(0));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
