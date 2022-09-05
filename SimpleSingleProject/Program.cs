using SimpleSingleProject.Api;
using SimpleSingleProject.Commands;
using SimpleSingleProject.Infrastructure;
using SimpleSingleProject.Queries;
using SimpleSingleProject.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// data
services.AddSingleton<IDataContext, DataContext>();

// repositories
services
    .AddScoped<IBookQueriesRepository, BookQueriesRepository>()
    .AddScoped<IBookCommandsRepository, BookCommandsRepository>();

// queries and commands
services
    .AddScoped<IBookQueries, BookQueries>()
    .AddScoped<IBookCommands, BookCommands>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app
    .MapGetBooks()
    .MapGetBook()
    .MapPostBook();

app.Run();
