using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Models
{
    public class CoachAccount
    {
        [Key]
        public int Id { get; set; }
        public virtual Account Account { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
