using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWizard.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEvent { get; set; }
        public bool HasCompetitorsFromLeague { get; set; }
    }
}
