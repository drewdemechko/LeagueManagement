using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;

namespace TournamentWizard.Models
{
    public class LeagueTournament
    {
        [Key]
        public int Id { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual League League { get; set; }
        public virtual List<LeagueCompetitor> Competitors { get; set; }
    }
}
