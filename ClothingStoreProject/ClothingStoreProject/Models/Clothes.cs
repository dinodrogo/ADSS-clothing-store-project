using System.ComponentModel.DataAnnotations;
namespace ClothingStoreProject.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}