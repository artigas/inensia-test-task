using Backend.Helpers;
using Backend.Model;
using Backend.Services.Adapter;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Backend.Services
{
    public class MovieStarsApplicationService : IMovieStarsApplicationService
    {
        private ILog _logger;
        private IMovieStarsAdapter _movieStarsAdapter;
        private readonly IEnumerable<MovieStarParsed> _movieStarsParsedList;

        public MovieStarsApplicationService(ILog logger, IMovieStarsAdapter movieStarsAdapter)
        {
            _logger = logger;

            _movieStarsAdapter = movieStarsAdapter;
            _movieStarsParsedList = ParseMovieStarsListFromFile();
        }

        public void Run()
        {
            var userChoice = 0;

            while (userChoice == 0)
                userChoice = DisplayMenu();

            switch (userChoice)
            {
                case 1:
                    PrintMovieStarsList();
                    return;
                case 2:
                    PrintChineseActresses();
                    return;
                case 3:
                    PrintAverageAgeOfActors();
                    return;
                case 4:
                    Console.WriteLine("Exiting...");
                    Thread.Sleep(1000);
                    return;
                default:
                    break;
            }
        }
        private int DisplayMenu()
        {
            Console.WriteLine(
                "----------\n" +
                "Movie Stars Menu\n" +
                "----------\n\n" +
                "1. Show full list of movie stars\n" +
                "2. Show chinese actresses born since 1996\n" +
                "3. Calculate average age of actors\n" +
                "4. Exit\n\n");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int result) && result <= 4 && result > 0)
                return result;
            else
            {
                Console.WriteLine("\nERROR: This option is not available!\n");
                return 0;
            }
        }

        private void PrintAverageAgeOfActors()
        {
            var movieStarsList = _movieStarsAdapter
                .GetActors(_movieStarsParsedList);

            var averageAge = Convert.ToInt32(movieStarsList
                .ToList()
                .Select(x => x.Age)
                .Average()
            );

            Console.Write($"Average age of actors: {averageAge}");
            Console.ReadKey();
            return;
        }

        private void PrintChineseActresses()
        {
            var movieStarsList = _movieStarsAdapter
                .GetChineseActressesBornSince1996(_movieStarsParsedList);

            movieStarsList
                .ToList()
                .ForEach(i => Console.Write(i.ToString()));

            Console.ReadKey();
            return;
        }

        private void PrintMovieStarsList()
        {
            var movieStarsList = _movieStarsAdapter
                .GetMovieStarList(_movieStarsParsedList);

            movieStarsList
                .ToList()
                .ForEach(i => Console.Write(i.ToString()));

            Console.ReadKey();
            return;
        }

        private IEnumerable<MovieStarParsed> ParseMovieStarsListFromFile()
        {
            string projectSourcePath = ProjectSourcePath.Value;

            if (string.IsNullOrEmpty(projectSourcePath))
            {
                var argumentNullException = new ArgumentNullException($"Project source path cannot be determined.");
                _logger.Error(argumentNullException.Message, argumentNullException);
                throw argumentNullException;
            }

            string filePath = Path.Combine(projectSourcePath, "input.txt");

            if (!File.Exists(filePath))
            {
                var fileNotFoundException = new FileNotFoundException("File input.txt not found!");
                _logger.Error(fileNotFoundException.Message, fileNotFoundException);
                throw fileNotFoundException;
            }

            string content = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<MovieStarParsed>>(content);
        }

    }
}
