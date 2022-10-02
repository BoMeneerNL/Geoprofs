using System.ComponentModel.DataAnnotations;

namespace GPAPI.Models
{
    public class Authtoken
    {
        [Key]
        public string Token { get; set; }
        public Medewerker Medewerker { get; set; }
        public ulong Expires { get; set; }

    }
}
