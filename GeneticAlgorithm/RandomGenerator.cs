using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public static class RandomGenerator
    {
        private static Random RandomGen { get; } = new Random((int)DateTime.Now.Ticks);

        public static int GetInt(int min, int max) =>
            RandomGen.Next(min, max);

        public static double GetDouble(double min, double max) =>
            (RandomGen.NextDouble() * (max - min)) + min;

        public static Chromosome GenerateChromosome(int numberOfGenes)
        {
            int[] chromosome = new int[numberOfGenes];

            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosome[i] = GetInt(0, 2);
            }

            return new Chromosome(string.Join(string.Empty, chromosome));
        }
    }
}
