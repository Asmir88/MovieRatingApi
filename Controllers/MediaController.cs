using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRatingApi.Data;
using MovieRatingApi.Models;
using System.Linq;
using System.Collections.Generic;
using MovieRatingApi.Dto;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System;

namespace MovieRatingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly MovieRatingApiContext _context;

        public MediaController(MovieRatingApiContext context)
        {
            _context = context;
        }

        [HttpGet("{text?}")]
        public IEnumerable<MediaDto> Get(string text)
        {
            var mediaList = _context.Medias.Select(m => new MediaDto()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ReleaseDate = m.ReleaseDate,
                Rating = m.Rating,
                Type = m.Type,
                Actors = m.ActorMedias.Select(x => x.Actor).ToList()
            }).OrderByDescending(x => x.Rating);

            if (string.IsNullOrEmpty(text))
            {
                return mediaList;
            }
            else
            {
                var filteredMedia  = FilteringAccordingToRating(mediaList, text.ToLower());
                filteredMedia = filteredMedia.Count() > 0 ? filteredMedia : FilterAccordingToYear(mediaList, text.ToLower());
                return filteredMedia.Count() > 0 ? filteredMedia : FilterOutMedias(mediaList, text);
            }
        }

        private List<MediaDto> FilteringAccordingToRating(IQueryable<MediaDto> mediaList, string text)
        {
            var match = Regex.Match(text, @"less than (\d) star(s*?)");

            if (match.Success)
            {
                var starValue = match.Groups[1].Value;
                return mediaList.Where(x => x.Rating < double.Parse(starValue)).ToList();
            }

            match = Regex.Match(text, @"greater than (\d) star(s*?)");

            if (match.Success)
            {
                var starValue = match.Groups[1].Value;
                return mediaList.Where(x => x.Rating > double.Parse(starValue)).ToList();
            }

            match = Regex.Match(text, @"(\d) star(s*?)");

            if (match.Success)
            {
                var starValue = match.Groups[1].Value;
                return mediaList.Where(x => x.Rating == double.Parse(starValue)).ToList();
            }

            // if nothing was found-filtered, return original list
            return new List<MediaDto>();
        }

        private List<MediaDto> FilterAccordingToYear(IQueryable<MediaDto> mediaList, string text)
        {
            var match = Regex.Match(text, @"before (\d\d\d\d)");

            if (match.Success)
            {
                var yearValue = match.Groups[1].Value;
                return mediaList.Where(x => x.ReleaseDate.Year < double.Parse(yearValue)).ToList();
            }

            match = Regex.Match(text, @"after (\d\d\d\d)");

            if (match.Success)
            {
                var yearValue = match.Groups[1].Value;
                return mediaList.Where(x => x.ReleaseDate.Year > double.Parse(yearValue)).ToList();
            }

            match = Regex.Match(text, @"older than (\d+) year(s*?)");

            if (match.Success)
            {
                var yearValue = match.Groups[1].Value;
                var currentDate = DateTime.Now;
                return mediaList.Where(x => x.ReleaseDate.Year < currentDate.Year - double.Parse(yearValue)).ToList();
            }

            match = Regex.Match(text, @"younger than (\d+) year(s*?)");

            if (match.Success)
            {
                var yearValue = match.Groups[1].Value;
                var currentDate = DateTime.Now;
                return mediaList.Where(x => x.ReleaseDate.Year > currentDate.Year - double.Parse(yearValue)).ToList();
            }

            // if nothing was found-filtered, return original list
            return new List<MediaDto>();
        }

        private List<MediaDto> FilterOutMedias(IEnumerable<MediaDto> mediaList, string text)
        {
            var filteredMedia = new List<MediaDto>();

            foreach (var media in mediaList)
            {
                if (ContainsText(media, text.ToLower()))
                {
                    filteredMedia.Add(media);
                }
            }

            return filteredMedia.ToList();
        }

        private bool ContainsText(MediaDto media, string text)
        {
            string searchedExpression = text.ToLower();
            var containsText = media.Title.ToLower().Contains(searchedExpression) ||
                media.Description.ToLower().Contains(searchedExpression) ||
                media.Actors.Where(x => new List<string>() { x.Name.ToLower(), x.Surname.ToLower(), x.Name.ToLower() + " " + x.Surname.ToLower() }.ToList().Any(searchedExpression.Contains)).Any();

            return containsText;
        }

        [HttpPost("rate/{id}")]
        public double Post(int id, RatingDto rating)
        {
            var ratingValue = new Rating() {
                MediaId = id,
                Value = rating.Value
            };

            _context.Ratings.Add(ratingValue);
            _context.SaveChanges();

            var mediaRatings = _context.Ratings.Where(x => x.MediaId == id);
            var averageRating = mediaRatings.Sum(x => x.Value) / mediaRatings.Count();

            var media = _context.Medias.FirstOrDefault(x => x.Id == id);
            media.Rating = averageRating;

            _context.Medias.Update(media);
            _context.SaveChanges();

            return averageRating;
        }
    }
}
