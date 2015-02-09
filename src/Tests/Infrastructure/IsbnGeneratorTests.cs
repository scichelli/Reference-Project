namespace Headspring.Labs.Tests.Infrastructure
{
    using System;
    using Tests;

    public class IsbnGeneratorTests
    {
        [DeveloperTool]
        public void GenerateTenValidISBNs()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GenerateISBN());
            }
        }

        private string GenerateISBN()
        {
            return "978-0-306-40615-7";
        }
    }
}