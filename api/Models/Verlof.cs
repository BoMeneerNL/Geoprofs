using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Verlof
    {
        [Key]
        public int VerlofID { get; set; }
        public string VerlofOmscrijving { get; set; }
        //use as timestamp
        public uint Van { get; set; }
        //use as timestamp
        public uint Tot { get; set; }
        public byte Status { get; set; }
        
    }
}
