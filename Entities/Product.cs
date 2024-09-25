using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Brand { get; set; }
        public double Price { get; set; }
        public string? Features { get; set; }
        public string ImageUrl { get; set; }
        public int StockCount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped,Required]
        public IFormFile File { get; set; }

    }
}
