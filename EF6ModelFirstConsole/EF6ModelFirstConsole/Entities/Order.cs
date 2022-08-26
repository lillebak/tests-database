using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlLiteInNET6.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Info { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public Customer BoughtByCustomer { get; set; }
    }
}
