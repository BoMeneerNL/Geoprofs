﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GPAPI.Models
{
    public class Verlof
    {
        [Key]
        public int VerlofID { get; set; }
        public ulong MedewerkerID { get; set; }
        public uint Van { get; set; }
        public uint Tot { get; set; }
        public byte Status { get; set; }
        public string Reden { get; set; }
    }
}
