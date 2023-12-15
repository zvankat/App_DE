using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace OOOFood
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public int discount { get; set; }   
        public int category { get; set; }

    }
}