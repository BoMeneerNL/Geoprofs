using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GPAPI.Models
{
    public class Authtoken
    {
        [Key]
        public string Token { get; set; }
        [JsonIgnore]
        public Medewerker Medewerker { get; set; }
        public int MedewerkerId { get; set; }
        public ulong Expires { get; set; }

    }
}
