using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourFinances.Domain.Entities;

namespace YourFinances.Domain.Repositories.Abstract
{
    public interface ITransactionsRepository
    {
        IQueryable<Transaction> GetTransactions();
        IQueryable<Transaction> GetTransactionsWithCategories();
        Transaction GetTransactionById(int id);
        void SaveTransaction(Transaction entity);
        void DeleteTransaction(int id);
    }
}
