namespace GameStore.Contracts
{
    public class GameDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public GameDTO(Guid id, string name, string genre, decimal price, DateOnly releaseDate)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Price = price;
            ReleaseDate = releaseDate;
        }
    }
}
