using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Medewerker
    {
        [Key]
        public int MedewerkerID { get; set; }
        public bool IsAdmin { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
    }
}
