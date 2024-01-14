using RadioactivityMonitor;
using RadioactivityMonitorApp.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var alarm = new Alarm();
app.MapGet("/api/alarm", () =>
    {
        
        alarm.Check();
        return new AlarmDto(alarm.AlarmOn, alarm.AlarmCount);
    })
    .WithName("GetRadioactivity")
    .WithOpenApi();

app.Run();