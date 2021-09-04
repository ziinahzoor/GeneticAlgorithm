using System;
using System.Linq;
using static System.Math;

namespace GeneticAlgorithm
{
    public class Chromosome
    {
        private static readonly int[] DOMAIN = { -100, 100 };

        public string Genes { get; }

        public string X { get => string.Join(string.Empty, Genes.Take(Size / 2)); }

        public string Y { get => string.Join(string.Empty, Genes.Skip(Size / 2)); }

        public double Fitness { get => GetFitness();  }

        public int Size { get => Genes.Length; }

        public Chromosome(string genes)
        {
            Genes = genes;
        }

        private double GetFitness()
        {
            double Normalize(long base10Number)
            {
                double multiplied =
                    Abs(DOMAIN[0] - DOMAIN[1]) / (Pow(2, Size / 2) - 1);

                var x = base10Number * multiplied;
                var y = DOMAIN.Min();

                return (base10Number * multiplied) + DOMAIN.Min();
            }

            double ApplyFunction(double x, double y)
            {
                var numerator = Pow(Sin(Sqrt(Pow(x, 2) + Pow(y, 2))), 2) - 0.5;
                var denominator = Pow(1 + (0.001 * (Pow(x, 2) + Pow(y, 2))), 2);

                return Round(0.5 - (numerator/ denominator), 5);
            }

            double x = Normalize(X.ToDecimal());
            double y = Normalize(Y.ToDecimal());

            return ApplyFunction(x, y);
        }

        public override string ToString() => Genes;
    }
}
