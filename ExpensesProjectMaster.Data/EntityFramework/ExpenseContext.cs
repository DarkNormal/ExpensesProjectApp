using ExpensesProjectMaster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesProjectMaster.Data.EntityFramework
{
    public class ExpenseContext : DbContext
    {
        public DbSet<Expense> Expense { get; set; }
    }
}
