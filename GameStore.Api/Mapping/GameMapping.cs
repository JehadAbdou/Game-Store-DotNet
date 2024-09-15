using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game ){

          return new Game()
    {
        Name = game.Name,
        GenreId = game.GenreId,
        Price = game.Price,
        Description = game.Description,
        VideoId = game.VideoId,
        Image_url = game.Image_url,
        ReleaseDate = game.ReleaseDate,
        
    };  }



 public static Game ToEntity(this UpdateGameDto game,int id ){

          return new Game()
    {   Id = id,
        Name = game.Name,
        GenreId = game.GenreId,
        Price = game.Price,
        Description = game.Description,
        VideoId = game.VideoId,
        Image_url = game.Image_url,
        ReleaseDate = game.ReleaseDate,
        
    };  }










  public static GameSummeryDto ToGameSummeryDto(this Game game){

 return new (
               game.Id,
               game.Name,
               game.Image_url,
               game.Description,
               game.Price,
               game.VideoId,
               game.ReleaseDate,
               game.Genre.Name

);



  }
public static GameDetailsDto ToGameDetailsDto(this Game game){

 return new (
               game.Id,
               game.Name,
               game.Image_url,
               game.Description,
               game.Price,
               game.VideoId,
               game.ReleaseDate,
               game.GenreId

);



  }
  

    }
}