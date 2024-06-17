namespace DistributeurCafé.Models
{
    public class Drink
    {
        public string? Name { get; set; }
        public Dictionary<string, int> Ingredients { get; set; }
        public double Price { get; set; }
    }
}
