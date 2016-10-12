using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesProjectMaster.Models.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [ForeignKey("V1Entity")]
        public int V1EntityId { get; set; }
        public virtual V1Entity V1Entity { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
