using JediKnight.Business;
using JediKnightControl;
using Microsoft.EntityFrameworkCore;
using MissionControl.Business;
using MissionControl.Data;
using MissionControl.Message;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MissionValidator>();
builder.Services.AddScoped<MissionRepository>();
builder.Services.AddScoped<JediKnightValidator>();
builder.Services.AddScoped<JediKnightRepository>();

builder.Services.AddSingleton<IConnection>(sp =>
{
    var factory = new ConnectionFactory()
    {
        HostName = "localhost", // Or read from configuration
        Port = 5672
    };
    return factory.CreateConnection();
});

builder.Services.AddSingleton<RabbitMQService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



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
