using VivesBlog.Api.Installers;
using VivesBlog.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.InstallOpenAPi();
builder.Services.InstallEntityFramework();
builder.Services.InstallAuthentication(builder.Configuration);
builder.Services.InstallServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var database = scope.ServiceProvider.GetRequiredService<VivesBlogDbContext>();
    database.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
