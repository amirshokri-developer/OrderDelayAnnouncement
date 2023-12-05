using OrderDelayAnnouncement.API.Extensions;
using OrderDelayAnnouncement.Application;
using OrderDelayAnnouncement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureAPI(builder.Configuration);



var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

public partial class Program { }
