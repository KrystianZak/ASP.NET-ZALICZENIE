using LibrarySystem.Models;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Inne właściwości autora

        public ICollection<Book> Books { get; set; }
    }
}
