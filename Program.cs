using CNB.Services;
using DC.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Služby
builder.Services.AddControllers();
builder.Services.AddHttpClient<ICoindeskService, CoindeskService>();
builder.Services.AddScoped<ISavedService, SavedService>();

builder.Services.AddHttpClient<ICoindeskService, CoindeskService>()
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSwagger", policy =>
    {
        policy.WithOrigins("https://localhost:7123")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 🔧 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔧 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSwagger");
app.UseAuthorization();
app.MapControllers();

app.Run();