using System.ComponentModel.DataAnnotations;

namespace ProiectRetele.Models
{
    public class Programare
    {
        public int ID { get; set; }
        [Display(Name = "Data si ora")]
        public DateTime Data { get; set; }
        public int ID_Masina { get; set; }
        public int ID_Mecanic { get; set; }
        public ICollection<Factura>? Facturi { get; set; }
        public Masina? Masina { get; set; }
        public Mecanic? Mecanic { get; set; }
    }
}
