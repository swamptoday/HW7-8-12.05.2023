using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourFinances.Models
{
    public class TransactionsViewModel
    {
        public List<CategoryViewModel> Transactions { get; set; }
        public DateTime SelectedMonth { get; set; }
    }
}
