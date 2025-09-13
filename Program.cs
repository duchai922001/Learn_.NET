using Learn_Net.DAL.Data;
using Learn_Net.Repositories;
using Learn_Net.Services;
using Learn_Net.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------ CẤU HÌNH DỊCH VỤ (Services) ------------------

// 1. Đăng ký DbContext và kết nối MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// 2. Đăng ký service cho User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IWriteRepository, WriteRepository>();
builder.Services.AddScoped<IWriteService, WriteService>();

builder.Services.AddScoped<IUserWriteRepository, UserWriteRepository>();
builder.Services.AddScoped<IUserWriteService, UserWriteService>();


builder.Services.AddScoped<IJwtService, JwtService>();

// 3. Đăng ký dịch vụ Controller (API Controller)
builder.Services.AddControllers();

// 4. Đăng ký Swagger (tài liệu API tự động)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ------------------ CẤU HÌNH ỨNG DỤNG (Middleware) ------------------

var app = builder.Build();

// 5. Nếu môi trường đang chạy là Development thì bật Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6. Chuyển hướng HTTP -> HTTPS
app.UseHttpsRedirection();

// 7. Middleware xác thực & phân quyền
app.UseAuthorization();

// 8. Map route cho Controller
app.MapControllers();

// 9. Chạy ứng dụng
app.Run();
