using Microsoft.AspNetCore.Http;
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
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("GetSurvey")]
        public async Task<ActionResult> GetSurvey([FromQuery] int id)
        {
            return Ok(await _surveyService.GetSurvey(id));
        }

        [HttpGet("GetSurveys")]
        public async Task<ActionResult> GetSurveys()
        {
            return Ok(await _surveyService.GetSurveys());
        }

        [HttpPost("AddSurvey")]
        public async Task<ActionResult> AddSurvey([FromBody] AddSurveyRequest request)
        {
            await _surveyService.AddSurvey(request);

            return Ok();
        }

        [HttpPut("UpdateSurvey")]
        public async Task<ActionResult> UpdateSurvey([FromBody] UpdateSurveyRequest request)
        {
            await _surveyService.UpdateSurvey(request);

            return NoContent();
        }

        [HttpDelete("DeleteSurvey")]
        public async Task<ActionResult> DeleteSurvey([FromQuery][Required] int id)
        {
            await _surveyService.DeleteSurvey(id);

            return NoContent();
        }
    }
}
