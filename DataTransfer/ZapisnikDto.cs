namespace StudentskaWebAPI.DataTransfer
{
    public class ZapisnikDto
    {
        public int IdStudenta { get; set; }

        public int IdIspita { get; set; }

        public double Ocena { get; set; }

        public string? Bodovi { get; set; }
    }
}
