using API_QLDiemSV.DbContexts;
using API_QLDiemSV.IRepository;
using API_QLDiemSV.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add database context
builder.Services.AddDbContext<QLDiemSVContext>(options
    =>
options.UseSqlServer(builder.Configuration.GetConnectionString("QLDiemSVDB")));

builder.Services.AddDbContext<SVContext>(options
    =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SVDB")));

// Add automapper
builder.Services.AddAutoMapper(typeof(Program));

// Add repository
builder.Services.AddScoped<IQuyenRepository, QuyenRepository>();
builder.Services.AddScoped<IKhoaRepository, KhoaRepository>();
builder.Services.AddScoped<IGiangVienRepository, GiangVienRepository>();
builder.Services.AddScoped<IMonHocRepository, MonHocRepository>();
builder.Services.AddScoped<ILopTinChiRepository, LopTinChiRepository>();
builder.Services.AddScoped<ILopSvRepository, LopSvRepository>();
builder.Services.AddScoped<ISinhVienRepository, SinhVienRepository>();
builder.Services.AddScoped<IBangDiemRepository, BangDiemRepository>();


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
