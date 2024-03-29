using API_SinhVien.DbContexts;
using API_SinhVien.IRepository;
using API_SinhVien.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<SVContext>(options
    =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SVDB")));

// Add automapper
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddScoped<ISinhVienRepo, SinhVienRepo>();
builder.Services.AddScoped<IBangDiemRepo, BangDiemRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
