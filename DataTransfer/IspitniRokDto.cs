using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.DataTransfer
{
    public class IspitniRokDto
    {
        public string Naziv { get; set; } = null!;

        public string? SkolskaGod { get; set; }

        public string? StatusRoka { get; set; }
    }
}
