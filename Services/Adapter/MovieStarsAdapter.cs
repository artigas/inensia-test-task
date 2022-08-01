using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Services.Adapter
{
    public class MovieStarsAdapter : IMovieStarsAdapter
    {
        public IEnumerable<MovieStarDto> GetActors(IEnumerable<MovieStarParsed> movieStars)
        {
            return movieStars
                .Where(x => x.Sex == "Male")
                .Select(x => new MovieStarDto(x));
        }

        public IEnumerable<MovieStarDto> GetChineseActressesBornSince1996(IEnumerable<MovieStarParsed> movieStars)
        {
            return movieStars
                .Where(x => x.Nationality == "China" && x.Sex == "Female" && x.dateOfBirth >= new DateTime(1996, 1, 1))
                .Select(x => new MovieStarDto(x));
        }

        public IEnumerable<MovieStarDto> GetMovieStarList(IEnumerable<MovieStarParsed> movieStars)
        {
            return movieStars.Select(x => new MovieStarDto(x));
        }
    }
}
