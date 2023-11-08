using Wall_Net.DataAccess;
using Wall_Net.Repositories;
using Wall_Net.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
builder.Services.AddDbContext<WallNetDbContext>();

builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRolesServices, RolesServices>();

<<<<<<< HEAD
builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<IAccountServices, AccountServices>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
=======
builder.Services.AddScoped<IFixedTermDepositRepository,FixedTermDepositRepository>();
builder.Services.AddScoped<IFixedTermDepositServices,FixedTermDepositServices>();
>>>>>>> Arreglos a  Fixed y Roles
=======
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRolesServices, RolesServices>();

builder.Services.AddScoped<IFixedTermDepositRepository,FixedTermDepositRepository>();
builder.Services.AddScoped<IFixedTermDepositServices,FixedTermDepositServices>();
>>>>>>> 7ae75bb34c73a270af1cd199585890ab00a6d164

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
