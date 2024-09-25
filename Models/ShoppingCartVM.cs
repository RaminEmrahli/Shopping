using NuGet.Configuration;

namespace Shopping.Models
{
    public class ShoppingCartVM
    {
        public List<CardItem> CardItems { get; set; } = new List<CardItem>();
        public double Total { get; set; }
    }
}
