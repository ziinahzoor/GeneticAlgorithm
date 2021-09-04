using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public static class ChromosomeGenerator
    {
        private const int NUMBER_OF_GENES = 44;

        public static IEnumerable<Chromosome> InitializePopulation(int populationSize)
        {
            for (int i = 0; i < populationSize; i++)
            {
                yield return ChromosomeGenerator.Generate();
            }
        }

        private static Chromosome Generate()
        {
            int[] chromosome = new int[NUMBER_OF_GENES];
            Random randomGene = new((int)DateTime.Now.Ticks);

            for (int i = 0; i < NUMBER_OF_GENES; i++)
            {
                chromosome[i] = randomGene.Next(0, 2);
            }

            return new Chromosome(string.Join(string.Empty, chromosome));
        }
    }
}
