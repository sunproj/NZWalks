using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Added by Sunil
builder.Services.AddDbContext<dbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalksConn"));
});

// Added by Sunil
builder.Services.AddScoped<IRegionRepo, RegionRepo>();

// Added by Sunil
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
