namespace LuckyWheelStradex.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? LotteryCode { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Result { get; set; }
        public int Status { get; set; }
    }
}
