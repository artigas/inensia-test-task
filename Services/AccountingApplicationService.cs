using log4net;
using System;

namespace Backend.Services
{
    public class AccountingApplicationService : IAccountingApplicationService
    {
        private ILog _logger;

        private readonly double taxationThreshold = 1000;
        private readonly double taxPercentage = 0.1;
        private readonly double socialContributionsPercentage = 0.15;

        public AccountingApplicationService(ILog logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            try
            {
                double grossSalary = 0.00;

                while (grossSalary == 0.00)
                {
                    Console.WriteLine("Insert your net salary: ");
                    var input = Console.ReadLine();

                    if (!double.TryParse(input, out double result) && result <= 0.00)
                        continue;

                    grossSalary = result;
                }

                double netSalary = grossSalary;

                if (grossSalary > taxationThreshold)
                {
                    // 10% tax in excess above 1000
                    SustractTax(ref grossSalary, ref netSalary);

                    // Social contributions of 15%
                    SustractSocialContributions(ref grossSalary, ref netSalary);
                }

                Console.WriteLine(netSalary);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        private void SustractTax(ref double grossSalary, ref double netSalary)
        {
            double excessSalary = grossSalary - taxationThreshold;
            double tax = excessSalary * taxPercentage;

            netSalary = netSalary - tax;
        }

        private void SustractSocialContributions(ref double grossSalary, ref double netSalary)
        {
            double socialContributions = grossSalary * socialContributionsPercentage;

            netSalary = netSalary - socialContributions;
        }
    }
}
