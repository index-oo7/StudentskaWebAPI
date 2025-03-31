namespace StudentskaWebAPI.DataTransfer
{
    public class PredmetDto
    {
        public int IdProfesora { get; set; }

        public string Naziv { get; set; } = null!;

        public int Espb { get; set; }

        public string? Status { get; set; }
    }
}
