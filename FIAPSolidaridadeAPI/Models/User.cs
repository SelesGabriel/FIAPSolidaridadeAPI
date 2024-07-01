using FIAPSolidaridadeAPI.Models;

namespace FIAPSolidaridadeAPI.DTOs
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string[] Areas { get; set; }
        public UserType UserType { get; set; }
        public Address BindingAddress { get; set; }
    }

    public enum UserType
    {
        Admin,
        Volunteer,

    }
}
