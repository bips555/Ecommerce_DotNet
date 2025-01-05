using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ecommerce_Net_Temp_Razor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
