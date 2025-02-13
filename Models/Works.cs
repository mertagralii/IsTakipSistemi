
namespace IsTakipSistemi.Models
{
    public class Works
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int StatusId { get; set; }

        public int CalisanId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
