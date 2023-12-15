using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OOOFood
{
    [Table("Users")]
    public class User : DbContext
    {
        [Key]
        public int id { get; set; }
        public string FCs { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int role_id { get; set; }

    }
}