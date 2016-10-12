using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpensesProjectMaster.Models.Entities
{
    public class PerDiem : Expense
    {
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Location { get; set; }
        public decimal Rate { get; set; }
    }
}
