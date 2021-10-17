using MovieRatingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRatingApi.Dto
{
    public class MediaDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public int TypeId { get; set; }

        public MediaType Type { get; set; }

        public List<Actor> Actors { get; set; }
    }
}
