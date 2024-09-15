using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;
namespace GameStore.Api.Endpoints;
    public static class GameEndpoints
    {
 

public static RouteGroupBuilder MapGamesEndpoint(this WebApplication app){

var group = app.MapGroup("games").WithParameterValidation();


group.MapGet("/", async (GameStoreContext dbContext) => await  dbContext.Games.Include(game =>game.Genre).Select(game => game.ToGameSummeryDto()).AsNoTracking().ToListAsync()  );


group.MapGet("/{id}",async (int id,GameStoreContext dbContext) => { Game? game = await dbContext.Games.FindAsync(id);

return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
}).WithName("GetGame");

group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
{
  

    // Create a new game entity
    Game game = newGame.ToEntity();
   

    // Add the game to the database
    dbContext.Games.Add(game);
    await dbContext.SaveChangesAsync();



      return Results.Created($"/games/{game.Id}", game.ToGameDetailsDto());}

);
    



group.MapPut("/{id}",async(int id,UpdateGameDto UpdatedGame,GameStoreContext dbContext)=>{
     Game? Game = await dbContext.Games.FindAsync(id);

   if(Game == null){
    return Results.NotFound();
   }

     dbContext.Entry(Game).CurrentValues.SetValues(UpdatedGame.ToEntity(id));
    
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});




group.MapDelete("/{id}", async(int id,GameStoreContext dbContext)=>{
   await dbContext.Games.Where(game => game.Id == id)
    .ExecuteDeleteAsync();
    return Results.NoContent();
});
   




return group;     
}
  
}
    
