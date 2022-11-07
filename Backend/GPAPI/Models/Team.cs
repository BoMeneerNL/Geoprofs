using System.ComponentModel.DataAnnotations;

namespace GPAPI.Models
{
    public class Team
    {
        [Key]
        public ulong TeamID { get; set; }
        public string Naam { get; set; }
    }
}
