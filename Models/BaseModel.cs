using System.ComponentModel.DataAnnotations;

namespace MovieRatingApi.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
