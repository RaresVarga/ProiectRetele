using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ProiectRetele.Models
{
    public class Masina
    {
        public int ID { get; set; }
        [Display(Name = "Numar de inmatriculare")]
        public string NumarInmatriculare { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        [Display(Name = "Anul fabricatiei")]
        public int AnFabricatie { get; set; }
        public int ID_Client { get; set; }
        public Client? Client { get; set; }
        public ICollection<Programare>? Programari { get; set; }
    }
}
