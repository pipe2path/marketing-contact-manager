using API.Middleware;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CMContext>(opt => 
{ 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});  
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// exception middleware added for unhandled exceptions
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseCors();

app.Run();
