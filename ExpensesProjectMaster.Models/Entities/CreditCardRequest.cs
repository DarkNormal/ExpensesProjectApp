using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpensesProjectMaster.Models.Entities
{
    public class CreditCardRequest : Expense 
    {
        public int CreditCardRequestID { get; set; }
    }
}
