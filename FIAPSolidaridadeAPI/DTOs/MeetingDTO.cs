namespace FIAPSolidaridadeAPI.DTOs
{
    public class MeetingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public string Location { get; set; }
        // Outros campos relevantes para a reunião
    }
}
