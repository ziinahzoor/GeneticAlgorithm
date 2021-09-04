using System;

namespace GeneticAlgorithm
{
    public class Program
    {
        public const int POPULATION_SIZE = 100;
        public const int NUMBER_OF_GENERATIONS = 40;

        public static void Main()
        {
            Population currentGeneration = Population.Initialize(POPULATION_SIZE);
            Population nextGeneration;

            for (int i = 0; i < NUMBER_OF_GENERATIONS; i++)
            {
                WriteGreen($"Geração: {currentGeneration.GenerationNumber} " +
                    $"| Mais Apto: {currentGeneration.Fittest.Fitness}");

                nextGeneration = currentGeneration.Mate();
                currentGeneration = nextGeneration;
            }

            WriteBlue("Última geração:\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            currentGeneration.Print();
            Console.ResetColor();
            WriteBlue($"Mais Apto: {currentGeneration.Fittest}");
        }

        private static void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void WriteBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
