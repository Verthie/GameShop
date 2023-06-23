using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category")]
        public string ?Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display Order for category must be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
