using GameStore.Data.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Entities
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Genre cannot exceed 30 characters.")]
        [OnlyLetters]
        public string Genre { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000.")]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Publisher cannot exceed 100 characters.")]
        public string Publisher { get; set; }

        public Game(Guid id, string name, string genre, decimal price, DateOnly releaseDate, DateTime createdAt, string description, string publisher)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Price = price;
            ReleaseDate = releaseDate;
            CreatedAt = createdAt;
            Description = description;
            Publisher = publisher;
        }
    }
}
