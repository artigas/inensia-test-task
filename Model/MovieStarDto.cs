using Backend.Helpers;

namespace Backend.Model
{
    public class MovieStarDto
    {
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }

        public MovieStarDto(MovieStarParsed movieStarParsed)
        {
            FullName = $"{movieStarParsed.Name} {movieStarParsed.Surname}";
            Sex = movieStarParsed.Sex;
            Nationality = movieStarParsed.Nationality;
            Age = movieStarParsed.dateOfBirth.CalculateAgeFromDateOfBirth();
        }

        public override string ToString()
        {
            return $"{FullName}\n" + $"{Sex}\n" + $"{Nationality}\n" + $"{Age} years old\n\n";
        }
    }
}
