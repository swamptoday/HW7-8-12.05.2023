using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourFinances.Domain.Entities
{
    public class Category
    {
        [Required]
        [Key]
        public int category_id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
