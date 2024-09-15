using System;
using GameStore.Api.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints
{
    public static class GenreEndPoitnts
    {
        public static RouteGroupBuilder MapGenresEndPoint(this WebApplication app){


            var group = app.MapGroup("genres");

            group.MapGet("/",async(GameStoreContext dbContext) => await dbContext.Genres.Select(genre =>genre.ToGenreDto()).AsNoTracking().ToListAsync());

            return group;
        }
    }
}