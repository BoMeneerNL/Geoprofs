using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GPAPI.Models
{
    public class Authtoken
    {
        [Key]
        public string Token { get; set; }
        public ulong MedewerkerID { get; set; }
        public ulong Expires { get; set; }

    }
}
