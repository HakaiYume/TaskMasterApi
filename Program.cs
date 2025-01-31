using TaskMasterApi.Data;
using TaskMasterApi.Data.Models;
using TaskMasterApi.Services;
using TaskMasterApi.Interfaces;
using TaskMasterApi.Api;

var builder = WebApplication.CreateBuilder(args);

//Cors
var MyOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyOrigins, policy => {
        policy.WithOrigins("http://localhost:3000");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
    });
});

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Settings
builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection("GmailSettings"));
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
builder.Services.Configure<WhatsapSettings>(builder.Configuration.GetSection("WhatsapSettings"));

//DB
builder.Services.AddSqlServer<TaskMasterBdContext>(builder.Configuration.GetConnectionString("BDConection"));

//SignalR
builder.Services.AddSignalR();
builder.Services.AddHostedService<ServerNotifier>();

//Services
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ISendEmailService, SendEmailService>();
builder.Services.AddTransient<ISaveDocumentsService, SaveDocumentsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//cords
app.UseCors(MyOrigins);

app.UseHttpsRedirection();

app.MapControllers();

//Hub
app.MapHub<NotificationHub>("/Notifications");

app.Run();