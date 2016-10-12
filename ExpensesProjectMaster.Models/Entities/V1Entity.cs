using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesProjectMaster.Models.Entities
{
    public class V1Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int V1EntityID { get; set; }

        public string V1EntityName { get; set; }

        public Country Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

    }
}
