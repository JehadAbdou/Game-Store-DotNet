using System;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints
{
    public static class UserEndpoint
    {
        public static RouteGroupBuilder MapUserEndpoints (this WebApplication app){
            var group = app.MapGroup("users");

            group.MapGet("/",async(GameStoreContext dbContext)=>await dbContext.Users.Select(user => user.ToUserDto()).AsNoTracking().ToListAsync());
            
            group.MapGet("/{id:int}", async (int id, GameStoreContext dbContext) =>
{
    var user = await dbContext.Users
                              .Where(u => u.Id == id)
                              .Select(u => u.ToUserDto())
                              .AsNoTracking()
                              .FirstOrDefaultAsync();

    if (user == null)
    {
        return Results.NotFound($"User with Id {id} not found.");
    }

    return Results.Ok(user);
});

group.MapGet("/email/{email}", async (string email, GameStoreContext dbContext) =>
{
    var user = await dbContext.Users
                              .Where(u => u.Email == email)
                              .Select(u => u.ToUserDto())
                              .AsNoTracking()
                              .FirstOrDefaultAsync();

    if (user == null)
    {
        return Results.NotFound($"User with email {email} not found.");
    }

    return Results.Ok(user);
});

  group.MapPost("/",async(GameStoreContext dbContext ,CreateUserDto newUser)=>{
     User user =  new User{
        Username = newUser.UserName,
        Email = newUser.Email,
        Password = newUser.Password,
        
    };
await dbContext.Users.AddAsync(user);
await dbContext.SaveChangesAsync();

return Results.Ok(user);
  });          
            
            
            
            group.MapPost("/api/login", async (LoginDto loginDto, GameStoreContext dbContext) =>
{
    var user = await dbContext.Users
                              .Where(u => u.Email == loginDto.Email)
                              .FirstOrDefaultAsync();

    if (user == null || loginDto.Password!=user.Password)
    {
        return Results.BadRequest(new { message = "Invalid email or password" });
    }

    // Generate a JWT token or handle successful login logic
    // Assuming you have a JWT generation method

    return Results.Ok(new { user });
});

            
            
            
            
            
            return group;

            
        }
    }
}