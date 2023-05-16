using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourFinances.Domain.Entities
{
    public class Transaction
    {
        [Required]
        [Key]
        public int transaction_id { get; set; }
        [Required]
        public int category_id { get; set; }

        [ForeignKey("category_id")]
        public virtual Category Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal cost { get; set; }
        [Required]
        public DateTime date { get; set; }
        public string comment { get; set; }
    }
}
