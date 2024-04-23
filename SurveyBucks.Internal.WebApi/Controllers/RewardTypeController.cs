using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardTypeController : ControllerBase
    {
        private readonly IRewardTypeService _rewardTypeService;

        public RewardTypeController(IRewardTypeService rewardTypeService)
        {
            _rewardTypeService = rewardTypeService;
        }

        [HttpGet("GetRewardType")]
        public async Task<ActionResult> GetRewardType([FromQuery][Required] int id)
        {
            return Ok(await _rewardTypeService.GetRewardType(id));
        }

        [HttpGet("GetRewardTypes")]
        public async Task<ActionResult> GetRewardTypes()
        {
            return Ok(await _rewardTypeService.GetRewardTypes());
        }

        [HttpPost("AddRewardType")]
        public async Task<ActionResult> AddRewardType([FromBody] AddRewardTypeRequest request)
        {
            await _rewardTypeService.AddRewardType(request);
            return Ok();
        }

        [HttpPut("UpdateRewardType")]
        public async Task<ActionResult> UpdateRewardType([FromBody] UpdateRewardTypeRequest request)
        {
            await _rewardTypeService.UpdateRewardType(request);

            return NoContent();
        }

        [HttpDelete("DeleteRewardType")]
        public async Task<ActionResult> DeleteRewardType([FromQuery][Required] int id)
        {
            await _rewardTypeService.DeleteRewardType(id);

            return NoContent();
        }
    }
}
