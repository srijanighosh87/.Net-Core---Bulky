using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        string Description { get; set; }
        [Required]
        string ISBN { get; set; }
        [Required]
        string Auhor { get; set; }
        [Required]
        [Display(Name = "price for 1-50")]
        [Range(1,1000)]
        double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        double Price50 { get; set; }
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        double Price100 { get; set; }
        //[Required]
        //Category category { get; set; }
    }
}
