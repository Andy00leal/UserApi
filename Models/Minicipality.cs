namespace UserApi.Models
{
    public class Municipality
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int State { get; set; }

        public required int Id_department { get; set; }
    }
}
