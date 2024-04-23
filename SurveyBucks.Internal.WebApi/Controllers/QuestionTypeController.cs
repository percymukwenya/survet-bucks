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
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeService _questionTypeService;

        public QuestionTypeController(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        [HttpGet("GetQuestionType")]
        public async Task<ActionResult> GetQuestionType([FromQuery] int id)
        {
            return Ok(await _questionTypeService.GetQuestionType(id));
        }

        [HttpGet("GetQuestionTypes")]
        public async Task<ActionResult> GetQuestionTypes()
        {
            return Ok(await _questionTypeService.GetQuestionTypes());
        }

        [HttpPost("AddQuestionType")]
        public async Task<ActionResult> AddQuestionType([FromBody] AddQuestionTypeRequest request)
        {
            await _questionTypeService.AddQuestionType(request);

            return Ok();
        }

        [HttpPut("UpdateQuestionType")]
        public async Task<ActionResult> UpdateQuestionType([FromBody] UpdateQuestionTypeRequest request)
        {
            await _questionTypeService.UpdateQuestionType(request);

            return NoContent();
        }

        [HttpDelete("DeleteQuestionType")]
        public async Task<ActionResult> DeleteQuestionType([FromQuery][Required] int id)
        {
            await _questionTypeService.DeleteQuestionType(id);

            return NoContent();
        }
    }
}
