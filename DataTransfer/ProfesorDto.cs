namespace StudentskaWebAPI.DataTransfer
{
    public class ProfesorDto
    {
        public string Ime { get; set; } = null!;

        public string Prezime { get; set; } = null!;

        public string? Zvanje { get; set; }

        public DateTime? DatumZap { get; set; }
    }
}
