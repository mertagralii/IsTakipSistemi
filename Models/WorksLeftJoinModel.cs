namespace IsTakipSistemi.Models
{
    public class WorksLeftJoinModel
    {
        public int WorkId { get; set; }

        public string Title { get; set; }

        public int WorksDurumId { get; set; }

        public int CalisanId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int DurumId { get; set; }

        public string Durum { get; set; }

        public int PeopleId { get; set; }

        public string AdiSoyadi { get; set; }
    }
}
