using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("GameStore"),
        new MySqlServerVersion(new Version(8, 0, 39)) 
    ));

builder.Services.AddCors(options => {
    options.AddPolicy("AllowFrontend",policy =>{
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



var app = builder.Build();
app.UseCors("AllowFrontend");
app.MapGamesEndpoint();
app.MapGenresEndPoint();

// await app.MigrateDBAsync();

app.Run();


