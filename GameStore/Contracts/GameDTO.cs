namespace GameStore.Contracts
{
    public class GameDTO(Guid id, string name, string genre, decimal price, DateOnly releaseDate)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Genre { get; set; } = genre;
        public decimal Price { get; set; } = price;
        public DateOnly ReleaseDate { get; set; } = releaseDate;
    }
}
