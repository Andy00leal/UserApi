namespace UserApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required int Telephone { get; set; }

        public required string Address { get; set; }

        public required int Id_country { get; set; }

        public required int Id_department { get; set; }

        public required int Id_municipality { get; set; }
    }
}
