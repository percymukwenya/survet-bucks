using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyParticipationController : ControllerBase
    {
        private readonly ISurveyParticipationService _surveyParticipationService;

        public SurveyParticipationController(ISurveyParticipationService surveyParticipationService)
        {
            _surveyParticipationService = surveyParticipationService;
        }

        [HttpGet("GetSurveyParticipation")]
        public async Task<ActionResult> GetSurveyParticipation([FromQuery] int id)
        {
            return Ok(await _surveyParticipationService.GetSurveyParticipation(id));
        }

        [HttpGet("GetSurveyParticipations")]
        public async Task<ActionResult> GetSurveyParticipations()
        {
            return Ok(await _surveyParticipationService.GetSurveyParticipations());
        }

        [HttpPost("AddSurveyParticipation")]
        public async Task<ActionResult> AddSurveyParticipation([FromBody] AddSurveyParticipationRequest request)
        {
            await _surveyParticipationService.AddSurveyParticipation(request);

            return Ok();
        }

        [HttpPut("UpdateSurveyParticipation")]
        public async Task<ActionResult> UpdateSurveyParticipation([FromBody] UpdateSurveyParticipationRequest request)
        {
            await _surveyParticipationService.UpdateSurveyParticipation(request);

            return NoContent();
        }

        [HttpDelete("DeleteSurveyParticipation")]
        public async Task<ActionResult> DeleteSurveyParticipation([FromQuery][Required] int id)
        {
            await _surveyParticipationService.DeleteSurveyParticipation(id);

            return NoContent();
        }
    }
}
