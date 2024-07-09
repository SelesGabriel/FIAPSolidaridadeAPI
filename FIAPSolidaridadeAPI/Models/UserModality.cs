
namespace FIAPSolidaridadeAPI.Models
{
    public class UserModality
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ModalityId { get; set; }
        public Modality Modality { get; set; }
    }
}
