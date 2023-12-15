using System.ComponentModel.DataAnnotations;

namespace OOOFood
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public int number { get; set; }
        public string list_products { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }
        public string adress { get; set; }
        public string FCs { get; set; }
        public int status_id { get; set; }
    }
}