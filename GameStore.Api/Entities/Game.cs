
namespace GameStore.Api.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string?  Image_url { get; set; }
        public string? Description { get; set; }
        public int GenreId  { get; set; }
        public Genre? Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? VideoId { get; set; }
    }
}