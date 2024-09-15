
namespace GameStore.Api.Dtos
{
  public record UpdateGameDto(
    string Name,
    string Image_url,
    string Description,
    decimal Price,
    DateTime ReleaseDate,
    int GenreId,
    string VideoId
    );
}