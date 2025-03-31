namespace StudentskaWebAPI.DataTransfer
{
    public class StudentDto
    {
        public string Ime { get; set; } = null!;

        public string Prezime { get; set; } = null!;

        public string? Smer { get; set; }

        public int Broj { get; set; }

        public string? GodinaUpisa { get; set; }
    }
}
