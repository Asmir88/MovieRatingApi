using System.Collections.Generic;

namespace MovieRatingApi.Models
{
    public class Actor : BaseModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public ICollection<ActorMedia> ActorMedias { get; set; }
    }
}
