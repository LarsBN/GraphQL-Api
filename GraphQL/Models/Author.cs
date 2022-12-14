using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Author
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }


        public int? Age { get; set; }


        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
