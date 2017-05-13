using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWizard.Models
{
    public class LeagueTournamentLines
    {
        [Key]
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public virtual LeagueCompetitor Competitor { get; set; }
    }
}
