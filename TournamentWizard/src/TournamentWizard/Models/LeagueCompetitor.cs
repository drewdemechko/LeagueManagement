using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWizard.Models
{
    public class LeagueCompetitor
    {
        [Key]
        public int Id { get; set; }
        public virtual LeagueTeam Team { get; set; }
    }
}
