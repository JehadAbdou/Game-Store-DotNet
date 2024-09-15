


namespace GameStore.Api.Dtos
{
    public record CreateGameDto(
    string Name,
    string Image_url,
    string Description,
    decimal Price,
    DateTime ReleaseDate,
    int GenreId,
    string VideoId
    );
    
}