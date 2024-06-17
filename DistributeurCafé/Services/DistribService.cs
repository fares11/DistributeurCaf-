using DistributeurCafé.Interface;
using DistributeurCafé.Models;

namespace DistributeurCafé.Services
{
    public class DistribService : IDistribService
    {
        private readonly Dictionary<string, Ingredient> _ingredients;
        private readonly List<Drink> _drinks;

        public DistribService()
        {
            _ingredients = new Dictionary<string, Ingredient>
            {
                { "Lait en poudre", new Ingredient { Name = "Lait en poudre", PricePerDose = 0.10m } },
                { "Eau", new Ingredient { Name = "Eau", PricePerDose = 0.05m } },
                { "Café", new Ingredient { Name = "Café", PricePerDose = 0.30m } },
                { "Chocolat", new Ingredient { Name = "Chocolat", PricePerDose = 0.40m } },
                { "Thé", new Ingredient { Name = "Thé", PricePerDose = 0.30m } }
            };

            _drinks = new List<Drink>
            {
                new Drink { Name = "Espresso", Ingredients = new Dictionary<string, int> { { "Eau", 2 }, { "Café", 1 } } },
                new Drink { Name = "Lait", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 2 }, { "Eau", 1 } } },
                new Drink { Name = "Capuccino", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 2 }, { "Eau", 1 }, { "Café", 1 }, { "Chocolat", 1 } } },
                new Drink { Name = "Chocolat chaud", Ingredients = new Dictionary<string, int> { { "Chocolat", 3 }, { "Eau", 2 } } },
                new Drink { Name = "Café au lait", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 1 }, { "Eau", 2 }, { "Café", 1 } } },
                new Drink { Name = "Mokaccino", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 1 }, { "Eau", 2 }, { "Café", 1 }, { "Chocolat", 2 } } },
                new Drink { Name = "Thé", Ingredients = new Dictionary<string, int> { { "Eau", 2 }, { "Thé", 1 } } }
            };

            CalculateDrinkPrices();
        }

        private void CalculateDrinkPrices()
        {
            foreach (var drink in _drinks)
            {
                decimal cost = drink.Ingredients.Sum(i => _ingredients[i.Key].PricePerDose * i.Value);
                drink.Price = (double)(cost * 1.30m); //30% de marge
            }
        }

        public List<Drink> GetDrinks()
        {
            return _drinks;
        }
    }
}
