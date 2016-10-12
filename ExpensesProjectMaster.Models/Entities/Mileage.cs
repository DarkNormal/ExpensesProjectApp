using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpensesProjectMaster.Models.Entities
{
    public class Mileage : Expense
    {
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "From")]
        public string FromLocation { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "To")]
        public string ToLocation { get; set; }
        public int Country { get; set; }
        public decimal Distance { get; set; }
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
    }
}
