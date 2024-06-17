using DistributeurCafé.Config;
using DistributeurCafé.Interface;
using DistributeurCafé.Models;
using Microsoft.Extensions.Options;

namespace DistributeurCafé.Services
{
    public class DistribService : IDistribService
    {
        private readonly Dictionary<string, Ingredient> _ingredients;
        private readonly List<Drink> _drinks;

        public DistribService(IOptions<DataConfig> config)
        {
            _ingredients = config.Value.Ingredients.ToDictionary(i => i.Name);
            _drinks = config.Value.Drinks;
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
