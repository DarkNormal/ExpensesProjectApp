using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpensesProjectMaster.Models.Entities
{
    public class Receipt : Reimbursement
    {
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
