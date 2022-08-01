using Backend.Model;
using System.Collections.Generic;

namespace Backend.Services.Adapter
{
    public interface IMovieStarsAdapter
    {
        IEnumerable<MovieStarDto> GetMovieStarList(IEnumerable<MovieStarParsed> movieStars);
        IEnumerable<MovieStarDto> GetActors(IEnumerable<MovieStarParsed> movieStars);
        IEnumerable<MovieStarDto> GetChineseActressesBornSince1996(IEnumerable<MovieStarParsed> movieStars);
    }
}
