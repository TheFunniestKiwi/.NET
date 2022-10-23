using System.ComponentModel.DataAnnotations;

namespace Lab_5.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tytuł nie może być pusty")] [MaxLength(50, ErrorMessage = "Tytuł nie może być dłuższy niż 50 znaków")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Opis nie może być pusty")]
        [UIHint("LongText")]
        public string Description { get; set; }
        [Range(1,5, ErrorMessage = "Ocena musi zawierać się w przedziale 1-5")]
        [UIHint("Stars")]
        public int Rating { get; set; }
        [UIHint("Trailer")]
        public string? TrailerLink { get; set; }

        public Genre Genre { get; set; }
    }
}
