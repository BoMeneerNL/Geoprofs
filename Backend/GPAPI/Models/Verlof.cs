using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GPAPI.Models
{
    public class Verlof
    {
        [Key]
        public int VerlofID { get; set; }
        [JsonIgnore]
        public Medewerker Medewerker { get; set; }
        public int MedewerkerId { get; set; }
        public uint Van { get; set; }
        public uint Tot { get; set; }
    }
}
