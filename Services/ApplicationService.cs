using log4net;
using System;
using System.Threading;

namespace Backend.Services
{
    public class ApplicationService : IApplicationService
    {
        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit
        IMovieStarsApplicationService _movieStarsAppService;
        IAccountingApplicationService _accountingAppService;
        ILog _logger;

        public ApplicationService(ILog logger, IMovieStarsApplicationService movieStarsAppService, IAccountingApplicationService accountingAppService)
        {
            _logger = logger;

            _movieStarsAppService = movieStarsAppService;
            _accountingAppService = accountingAppService;
        }

        public void Run()
        {
            int userChoice = 0;

            while (userChoice == 0)
                userChoice = DisplayMenu();

            switch (userChoice)
            {
                case 1:
                    _movieStarsAppService.Run();
                    return;
                case 2:
                    _accountingAppService.Run();
                    return;
                case 3:
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
                "Main Menu\n" +
                "----------\n\n" +
                "1. Movie Stars\n" +
                "2. Calculate Net Salary\n" +
                "3. Exit\n\n");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int result) && result <= 3 && result > 0)
                return result;
            else
            {
                Console.WriteLine("\nERROR: This option is not available!\n");
                return 0;
            }
        }
    }
}
