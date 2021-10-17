namespace MovieRatingApi.Models
{
    public class ActorMedia : BaseModel
    {
        public int MediaId { get; set; }
        public Media Media { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
