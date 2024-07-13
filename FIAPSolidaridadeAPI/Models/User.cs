
namespace FIAPSolidaridadeAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string?[] Areas { get; set; }
        public string Cep { get; set; }
        public string Region { get; set; }

    }

}
