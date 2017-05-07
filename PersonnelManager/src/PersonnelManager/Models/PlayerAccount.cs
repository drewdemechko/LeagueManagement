using System.ComponentModel.DataAnnotations;

namespace PersonnelManager.Models
{
    public class PlayerAccount
    {
        [Key]
        public int Id { get; set; }
        public virtual Account Account { get; set; }
        public virtual Player Player { get; set; }
    }
}
