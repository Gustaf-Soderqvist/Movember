using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IZ.MovemberApp.Models
{
    public class Rating
    {

        public int RateId { get; set; }
        public int PostId { get; set; }
        public string Email { get; set; }
    }
}
