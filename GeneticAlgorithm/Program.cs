using System;
using System.Collections.Generic;
using static System.Math;

namespace GeneticAlgorithm
{
    public class Program
    {
        public const int POPULATION_SIZE = 100;
        public const int NUMBER_OF_GENERATIONS = 40;
        public const double CROSSOVER_RATE = 0.65;
        public const double MUTATION_RATE = 0.008;

        public static void Main()
        {
            List<Chromosome> population = new();
            population.AddRange(ChromosomeGenerator.InitializePopulation(POPULATION_SIZE));

            foreach (var chromosome in population)
            {
                Console.WriteLine(chromosome);
                //Console.WriteLine($"X: {chromosome.X} Y: {chromosome.Y}");
                //Console.WriteLine($"X: {chromosome.X.ToDecimal()} Y: {chromosome.Y.ToDecimal()}");
                Console.WriteLine($"{chromosome.Fitness}\n");
            }
        }
    }
}
