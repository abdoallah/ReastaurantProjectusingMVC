using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "minimum character is 3")]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "must but a price for this product")]
        [RegularExpression(pattern: @"[0-9]{1,}", ErrorMessage = "must be a number")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = " Description is required")]

        public string Description { get; set; }
        [Required(ErrorMessage = "food can be tested by it's image . image is required")]
        public string Image { get; set; }
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public Category Category { get; set; }




    }
}
