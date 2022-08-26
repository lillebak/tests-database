using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlLiteInNET6.Entities
{
    public class Customer
    {
        public Customer(string name, string address)
        {
            Name = name;
            Address = address;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
