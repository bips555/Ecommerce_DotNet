using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_DotNet.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name  { get; set; }
        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
