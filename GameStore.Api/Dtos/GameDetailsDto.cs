
namespace GameStore.Api.Dtos;


public record GameDetailsDto(
int Id,
string Name,
string Image_url,
string Description,
decimal Price,
string VideoId,
DateTime ReleaseDate,
int GenreId);


