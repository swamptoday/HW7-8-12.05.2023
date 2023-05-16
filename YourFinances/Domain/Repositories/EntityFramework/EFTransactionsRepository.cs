using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourFinances.Domain.Entities;
using YourFinances.Domain.Repositories.Abstract;

namespace YourFinances.Domain.Repositories.EntityFramework
{
    public class EFTransactionsRepository : ITransactionsRepository
    {
        private readonly AppDbContext context;

        public EFTransactionsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Transaction> GetTransactions()
        {
            return context.Transactions;
        }
        public IQueryable<Transaction> GetTransactionsWithCategories()
        {
            return context.Transactions
                    .Include(t => t.Category);
        }
        public Transaction GetTransactionById(int id)
        {
            return context.Transactions.FirstOrDefault(x => x.transaction_id == id);
        }
        public void SaveTransaction(Transaction entity)
        {
            if (entity.transaction_id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteTransaction(int id)
        {
            context.Transactions.Remove(new Transaction() { transaction_id = id });
            context.SaveChanges();
        }
    }
}
