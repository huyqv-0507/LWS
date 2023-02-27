using LuckyWheelStradex.Contexts;
using LuckyWheelStradex.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuckyWheelStradex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly LuckyWheelStradexContext _context;
        public PlayersController(LuckyWheelStradexContext context)
        {
            _context = context;
        }
        [HttpPost("/api/Players/Apply")]
        public IActionResult ApplyPlayer(PlayerModel playerModel)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var player = _context.Players.FirstOrDefault(_ => _.PhoneNumber.Equals(playerModel.PhoneNumber) && _.Status.Equals(1));
#pragma warning restore CS8604 // Possible null reference argument.
            if (player != null)
            {
                return BadRequest("Số điện thoại này đã quay thưởng");
            }
            var playersContext = _context.Add(new Player() {
                LotteryCode= playerModel.LotteryCode,
                PhoneNumber = playerModel.PhoneNumber,
                Email= playerModel.Email,
                FullName= playerModel.FullName,
            });
            _context.SaveChanges();
            if (playersContext != null)
            {
                return Ok(playerModel);
            }
            else
            {
                return StatusCode(500, playerModel);
            }
        }
        [HttpPost("/api/Players/Update")]
        public IActionResult UpdateLuckyWheel([FromQuery] string phoneNumber, [FromQuery] string result)
        {
            var player = _context.Players.FirstOrDefault(_ => _.PhoneNumber.Equals(phoneNumber) && _.Status.Equals(0));
            if (player != null)
            {
                player.Result = result;
                player.Status = 1;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return StatusCode(400, phoneNumber);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var playersDb = _context.Players.Where(_ => _.Status.Equals(1) || _.Status.Equals("1")).ToList();
            return Ok(playersDb.ConvertAll(new Converter<Player, PlayerModel>(PlayerModel.ConvertToPlayerResult)));
        }
    }
}
