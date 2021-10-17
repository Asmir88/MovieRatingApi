using Microsoft.EntityFrameworkCore;
using MovieRatingApi.Models;

namespace MovieRatingApi.Data
{
    public class MovieRatingApiContext : DbContext
    {
        public MovieRatingApiContext(DbContextOptions<MovieRatingApiContext> options)
            : base(options)
        {
        }

        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMedia> ActorMedias { get; set; }
    }
}
