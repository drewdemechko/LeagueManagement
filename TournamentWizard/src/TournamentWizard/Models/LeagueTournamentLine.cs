using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWizard.Models
{
    public class LeagueTournamentLine
    {
        [Key]
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public virtual LeagueCompetitor Competitor { get; set; }
        public virtual LeagueTournament Tournament { get; set; }
    }
}
