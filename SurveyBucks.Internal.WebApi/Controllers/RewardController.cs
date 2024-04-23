using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;

        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpGet("GetReward")]
        public async Task<ActionResult> GetReward([FromQuery][Required] int id)
        {
            return Ok(await _rewardService.GetReward(id));
        }

        [HttpGet("GetRewards")]
        public async Task<ActionResult> GetRewards()
        {
            return Ok(await _rewardService.GetRewards());
        }

        [HttpPost("AddReward")]
        public async Task<ActionResult> AddReward([FromBody] AddRewardRequest request)
        {
            await _rewardService.AddReward(request);
            return Ok();
        }

        [HttpPut("UpdateReward")]
        public async Task<ActionResult> UpdateReward([FromBody] UpdateRewardRequest request)
        {
            await _rewardService.UpdateReward(request);

            return NoContent();
        }

        [HttpDelete("DeleteReward")]
        public async Task<ActionResult> DeleteReward([FromQuery][Required] int id)
        {
            await _rewardService.DeleteReward(id);

            return NoContent();
        }
    }
}
