namespace Geoprofs.Classes
{
    public class User
    {
        public int personeelid { get; set; }
        public int rankid { get; set; }
        public string personeelsnaam { get; set; }

        public User()
        {
            personeelid = 0;
            rankid = 0;
            personeelsnaam = "NIET INGELOGD";
        }
    }
}
