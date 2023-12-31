﻿using MediatR;
using WebAPI.Application.Queries.UserQueries;
using WebAPI.Database;
using WebAPI.Database.Entities;
using WebAPI.Repositories;
using WebAPI.Repositoties;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
    cfg.Lifetime = ServiceLifetime.Scoped;
});
services.AddDbContext<MyDbContext>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IRequestHandler<GetUsersQuery, List<User>>, GetUsersQueryHandler>();



services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
