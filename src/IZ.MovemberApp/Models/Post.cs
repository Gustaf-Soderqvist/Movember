using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IZ.MovemberApp.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public int AuthorId { get; set; }

        // Navigation property
        public Author Author { get; set; }
    }
}
