using System;
using System.Collections.Generic;

namespace IZ.MovemberApp.Models
{
    public class Post
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }


        public ICollection<Rating> Ratings { get; set; }
    }

}
