using Assignment8.APIUtils;
using Assignment8.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<Assignment8Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment8Context")));

builder.Services.AddScoped<IMovieRepo,MovieRepoEF>();

builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapEndPoints();
app.Run();
