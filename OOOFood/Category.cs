using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOOFood
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int category_id { get; set; } 
        public string category_name { get; set; }
    }
}