
using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;

        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private const double CaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string FlourType
        {
            get { return flourType;}
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        private double Weight
        {
            get { return weight;} 
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double TotalCalories => CalculateCalories();

        private double CalculateCalories()
        {
            double firstModifier = 0;
            double secondModifier = 0;

            if (FlourType.ToLower() == "white")
            {
                firstModifier = White;
            }
            else
            {
                firstModifier = Wholegrain;
            }

            if (BakingTechnique.ToLower() == "crispy")
            {
                secondModifier = Crispy;
            }

            else if (BakingTechnique.ToLower() == "chewy")
            {
                secondModifier = Chewy;
            }

            else
            {
                secondModifier = Homemade;
            }

            return (CaloriesPerGram * Weight) * firstModifier * secondModifier;
        }
    }
}
