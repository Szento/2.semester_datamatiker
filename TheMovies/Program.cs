using System;

namespace TheMovies
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Skriv kædens navn: ");
            string name = Console.ReadLine() ?? "";

            ChainRepository repo = new ChainRepository();
            int id = repo.AddChain(name);

            Console.WriteLine($"Chain gemt med ID: {id}");
            Console.ReadKey();
        }
    }
}