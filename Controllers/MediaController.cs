using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRatingApi.Data;
using MovieRatingApi.Models;
using System;
using System.Collections.Generic;

namespace MovieRatingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly MovieRatingApiContext _context;

        private readonly ILogger<MediaController> _logger;

        public MediaController(ILogger<MediaController> logger, MovieRatingApiContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Media> Get()
        {
            return _context.Medias;
        }
    }
}
