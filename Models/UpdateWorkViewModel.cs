namespace IsTakipSistemi.Models
{
    public class UpdateWorkViewModel
    {
        public Works Work { get; set; }
        public List<People> People { get; set; }

        public List<Status> Status { get; set; }
    }
}
