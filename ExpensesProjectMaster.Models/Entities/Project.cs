using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesProjectMaster.Models.Entities
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Project")]
        public string Name { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<Employee> PortfolioDirectors { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

    }
}
