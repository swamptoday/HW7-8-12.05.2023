using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourFinances.Domain.Repositories.Abstract;

namespace YourFinances.Domain
{
    public class DataManager
    {
        public ICategoriesRepository Categories { get; set; }
        public ITransactionsRepository Transactions { get; set; }

        public DataManager(ICategoriesRepository categoriesRepository, ITransactionsRepository transactionsRepository)
        {
            Categories = categoriesRepository;
            Transactions = transactionsRepository;
        }
    }
}
