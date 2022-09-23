namespace GPAPI.Models
{
    public class VerlofSender
    {
        public VerlofSender(string name, uint van, uint tot)
        {
            Name = name;
            Van = van;
            Tot = tot;
        }

        public string Name { get; set; }
        public uint Van { get; set; }
        public uint Tot { get; set; }
    }
}
