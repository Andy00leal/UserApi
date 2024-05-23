namespace UserApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }
        
        public required int Id_country { get; set; }
    }
}
