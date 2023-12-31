using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Display(Name = "Publication Year")]
        [Range(1000, 3000, ErrorMessage = "Please enter a valid year")]
        public int? PublicationYear { get; set; }

        public string Description { get; set; }

        [Display(Name = "Categories")]
        public List<string> Categories { get; set; }
    }
}
