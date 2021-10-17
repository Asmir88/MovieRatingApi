using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRatingApi.Models
{
    public class Media : BaseModel
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public MediaType Type { get; set; }

        public ICollection<ActorMedia> ActorMedias { get; set; }
    }
}
