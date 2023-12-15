using System.ComponentModel.DataAnnotations;

namespace OOOFood
{
    public class Status
    {
        [Key]
        public int status_id { get; set; }
        public string status_name { get; set; }
    }
}