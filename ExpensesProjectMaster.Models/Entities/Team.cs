using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesProjectMaster.Models.Entities
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        public Practice Practice { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }
}
