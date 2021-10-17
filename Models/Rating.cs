using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRatingApi.Models
{
    public class Rating : BaseModel
    {
        public double Value { get; set; }
        public int MediaId { get; set; }

        [ForeignKey("MediaId")]
        public Media Media { get; set; }
    }
}
