using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRatingApi.Dto
{
    public class RatingDto
    {
        public int MediaId { get; set; }

        public int Value { get; set; }
    }
}
