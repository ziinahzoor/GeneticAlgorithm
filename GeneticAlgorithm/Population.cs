using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Population
    {
        private const int NUMBER_OF_GENES = 44;
        private const double CROSSOVER_RATE = 0.65;

        private Population() { }

        private static bool IsInitialized { get; set; }

        private int GenerationNumber { get; set; }

        public List<Chromosome> Individuals { get; private set; } = new();

        public Chromosome Fittest { get => Individuals.Find(c => c.Fitness == Individuals.Max(c => c.Fitness)); }

        public static Population Initialize(int populationSize)
        {
            Population population = new();

            if (!IsInitialized)
            {
                for (int i = 0; i < populationSize; i++)
                {
                    population.Individuals.Add(RandomGenerator.GenerateChromosome(NUMBER_OF_GENES));
                }

                IsInitialized = true;
                population.GenerationNumber = 1;
                return population;
            }

            throw new Exception("População já foi inicializada");
        }

        public Population Mate()
        {
            double[] fitnesses = new double[Individuals.Count];
            Population nextGeneration = new();
            nextGeneration.GenerationNumber = GenerationNumber + 1;

            void InitializeFitnesses()
            {
                double sum = 0;

                for (int i = 0; i < Individuals.Count; i++)
                {
                    sum += Individuals.ElementAt(i).Fitness;
                    fitnesses[i] = sum;
                }
            }

            Chromosome SpinRoulette()
            {
                double randomNum = RandomGenerator.GetDouble(0, fitnesses.Max());

                int i;
                for (i = 0; randomNum > fitnesses[i]; i++) ;

                return Individuals.ElementAt(i);
            }

            InitializeFitnesses();

            while (nextGeneration.Individuals.Count < Individuals.Count)
            {
                int crossoverPoint = RandomGenerator.GetInt(1, NUMBER_OF_GENES);

                Chromosome parent1 = SpinRoulette();
                Chromosome parent2 = SpinRoulette();
                Chromosome child1;
                Chromosome child2;

                if (RandomGenerator.GetDouble(0, 1) <= CROSSOVER_RATE)
                {
                    child1 = parent1.Crossover(crossoverPoint, parent2);
                    child2 = parent2.Crossover(crossoverPoint, parent1);
                }
                else
                {
                    child1 = parent1;
                    child2 = parent2;
                }

                child1.Mutate();
                child2.Mutate();

                nextGeneration.Individuals.Add(child1);
                nextGeneration.Individuals.Add(child2);
            }

            if (nextGeneration.Individuals.Count < Individuals.Count)
            {
                nextGeneration.KillUnfittest();
            }

            nextGeneration.KillUnfittest();
            nextGeneration.Individuals.Add(Fittest);

            return nextGeneration;
        }

        public void KillUnfittest()
        {
            Individuals.Remove(Individuals.Find(c => c.Fitness == Individuals.Min(c => c.Fitness)));
        }

        public void Print()
        {
            Console.WriteLine($"Geração {GenerationNumber}:\n");
            foreach (Chromosome chromosome in Individuals)
            {
                Console.WriteLine(chromosome);
                Console.WriteLine($"X: {chromosome.X} Y: {chromosome.Y}");
                Console.WriteLine($"X: {chromosome.X.ToDecimal()} Y: {chromosome.Y.ToDecimal()}");
                Console.WriteLine($"{chromosome.Fitness}\n");
            }
        }
    }
}
