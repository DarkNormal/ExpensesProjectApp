using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesProjectMaster.Models.Entities
{
    public class Reimbursement : Expense
    {
        [Display(Name="Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; }
    }
}
