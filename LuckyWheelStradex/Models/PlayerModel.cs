namespace LuckyWheelStradex.Models
{
    public class PlayerModel : Player
    {
        public static PlayerModel ConvertToPlayerResult(Player player)
        {
            return new PlayerModel {
                LotteryCode= player.LotteryCode,
                Email= player.Email,
                FullName= player.FullName,
                PhoneNumber = player.PhoneNumber,
                Result = player.Result,
                Id= player.Id,
                Status= player.Status,
            };
        }
    }
}
