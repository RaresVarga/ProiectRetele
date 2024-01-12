namespace ProiectRetele.Models
{
    public class Mecanic
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public ICollection<Programare>? Programari { get; set; }

    }
}
