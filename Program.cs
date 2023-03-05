using AutoMapper;
using WebApi.Data;
using WebApi.Helpers;
using WebApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

//activar cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                                    builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()));

builder.Services.AddDbContext<DataContext>();


//automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();


//añado al cor
app.UseHsts();

app.UseHttpsRedirection();
app.UseCors("AllowWebApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
