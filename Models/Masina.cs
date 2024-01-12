using System.Security.Policy;

namespace ProiectRetele.Models
{
    public class Masina
    {
        public int ID { get; set; }
        public string NumarInmatriculare { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public int AnFabricatie { get; set; }
        public int ID_Client { get; set; }
        public Client? Client { get; set; }
    }
}
