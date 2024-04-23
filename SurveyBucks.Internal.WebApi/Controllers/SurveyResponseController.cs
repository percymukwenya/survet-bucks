using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyResponseController : ControllerBase
    {
        private readonly ISurveyResponseService _surveyResponseService;

        public SurveyResponseController(ISurveyResponseService surveyResponseService)
        {
            _surveyResponseService = surveyResponseService;
        }

        [HttpGet("GetSurveyResponse")]
        public async Task<ActionResult> GetSurveyResponse([FromQuery] int id)
        {
            return Ok(await _surveyResponseService.GetSurveyResponse(id));
        }

        [HttpGet("GetSurveyResponses")]
        public async Task<ActionResult> GetSurveyResponses()
        {
            return Ok(await _surveyResponseService.GetSurveyResponses());
        }

        [HttpPost("AddSurveyResponse")]
        public async Task<ActionResult> AddSurveyResponse([FromBody] AddSurveyResponseRequest request)
        {
            await _surveyResponseService.AddSurveyResponse(request);

            return Ok();
        }

        [HttpPut("UpdateSurveyResponse")]
        public async Task<ActionResult> UpdateSurveyResponse([FromBody] UpdateSurveyResponseRequest request)
        {
            await _surveyResponseService.UpdateSurveyResponse(request);

            return NoContent();
        }

        [HttpDelete("DeleteSurveyResponse")]
        public async Task<ActionResult> DeleteSurveyResponse([FromQuery][Required] int id)
        {
            await _surveyResponseService.DeleteSurveyResponse(id);

            return NoContent();
        }
    }
}
