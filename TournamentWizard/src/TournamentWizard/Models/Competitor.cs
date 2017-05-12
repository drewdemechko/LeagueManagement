using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWizard.Models
{
    public class Competitor
    {
        [Key]
        public int Id { get; set; }
        public Tournament Tournament { get; set; }
        public string Name { get; set; }
    }
}
