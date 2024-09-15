namespace GameStore.Api.Models
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? VideoId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
