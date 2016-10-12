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
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpenseID { get; set; }
        [Required]
        [Display(Name = "Expense Amount")]
        [Range(0.0, 5000)]
        public decimal ActualAmount { get; set; }
        [Required]
        public Currency Currency { get; set; }
        [Required]
        public Category Category { get; set; }
        public bool Rechargeable { get; set; }
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        [DefaultValue("Pending")]
        [Display(Name = "Status")]
        public Status ApprovalStatus { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Project")]
        [Display(Name = "Project Number")]
        public int ProjectNo { get; set; }
        public virtual Project Project { get; set; }
    }


}