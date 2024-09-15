using GameStore.Api.Entities;

namespace GameStore.Api.Dtos

   {
    public record GameSummeryDto(
    int Id,
    string Name,
    string Image_url,
    string Description,
    decimal Price,
    string VideoId,
    DateTime ReleaseDate,
    string Genre);
   
}

