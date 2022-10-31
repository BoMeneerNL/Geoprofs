﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GPAPI.Models
{
    public enum MedewerkerType
    {
        Directie,
        Teammanager,
        Medewerker
    }
    public class Medewerker
    {
        [Key]
        public int MedewerkerID { get; set; }
        public bool IsAdmin { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        [JsonIgnore]
        public List<Verlof> Verlofs { get; set; }
        public int Medewerker
        public Team Team { get; set; }
    }
}
