namespace IsTakipSistemi.Models
{
    public class RaporModel
    {
        public List<WorksLeftJoinModel> Works { get; set; }

        public List<People> People { get; set; }
    }
}
