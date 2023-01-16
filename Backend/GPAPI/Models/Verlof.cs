using System.ComponentModel.DataAnnotations;

namespace GPAPI.Models
{
    public class Verlof
    {
        [Key]
        public int VerlofID { get; set; }
        public int TeamID { get; set; }
        public ulong MedewerkerID { get; set; }
        public uint Van { get; set; }
        public uint Tot { get; set; }
        public byte Status { get; set; }
        public string RedenVerzoek { get; set; }
        public string RedenAntwoord { get; set; }
    }
}
