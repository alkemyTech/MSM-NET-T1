<<<<<<< HEAD
using Wall_Net.DataAccess;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.EntityFrameworkCore;
using Wall_Net.DataAccess;
>>>>>>> 549320672e00e3f0116488caf7f84c60b51d855c
using Wall_Net.Repositories;
using Wall_Net.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
builder.Services.AddDbContext<Wall_Net_DbContext>();

builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRolesServices, RolesServices>();

builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<IAccountServices, AccountServices>();

=======
// Add DbContextConf
builder.Services.AddDbContext<Wall_Net_DbContext>
    (options => options.UseInMemoryDatabase("WallNetDb"));

// Add Interfaces
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
>>>>>>> 549320672e00e3f0116488caf7f84c60b51d855c

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
