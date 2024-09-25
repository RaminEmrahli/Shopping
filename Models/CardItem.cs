using Shopping.Entities;

namespace Shopping.Models
{
    public class CardItem
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
