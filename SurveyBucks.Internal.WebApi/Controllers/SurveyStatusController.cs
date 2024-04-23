using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyStatusController : ControllerBase
    {
        private readonly ISurveyStatusService _surveyStatusService;

        public SurveyStatusController(ISurveyStatusService surveyStatusService)
        {
            _surveyStatusService = surveyStatusService;
        }

        [HttpGet("GetSurveyStatus")]
        public async Task<ActionResult> GetSurveyStatus([FromQuery] int id)
        {
            return Ok(await _surveyStatusService.GetSurveyStatus(id));
        }

        [HttpGet("GetSurveyStatuses")]
        public async Task<ActionResult> GetSurveyStatuses()
        {
            return Ok(await _surveyStatusService.GetSurveyStatuses());
        }

        [HttpPost("AddSurveyStatus")]
        public async Task<ActionResult> AddSurveyStatus([FromBody] AddSurveyStatusRequest request)
        {
            await _surveyStatusService.AddSurveyStatus(request);

            return Ok();
        }

        [HttpPut("UpdateSurveyStatus")]
        public async Task<ActionResult> UpdateSurveyStatus([FromBody] UpdateSurveyStatusRequest request)
        {
            await _surveyStatusService.UpdateSurveyStatus(request);

            return NoContent();
        }

        [HttpDelete("DeleteSurveyStatus")]
        public async Task<ActionResult> DeleteSurveyStatus([FromQuery][Required] int id)
        {
            await _surveyStatusService.DeleteSurveyStatus(id);

            return NoContent();
        }
    }
}
