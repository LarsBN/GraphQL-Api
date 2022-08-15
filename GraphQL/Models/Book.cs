using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Book
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        public string Genre { get; set; }



        [Required]
        public int AuthorId { get; set; }


        public Author Author { get; set; }

    }
}
