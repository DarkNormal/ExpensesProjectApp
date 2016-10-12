using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesProjectMaster.Models.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsReceptionist { get; set; }
        [ForeignKey("Team")]
        public int TeamID { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

        public virtual ICollection<Project> Manages { get; set; }


    }
}
