using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionResponseChoiceController : ControllerBase
    {
        private readonly IQuestionResponseChoiceService _questionResponseChoiceService;

        public QuestionResponseChoiceController(IQuestionResponseChoiceService questionResponseChoiceService)
        {
            _questionResponseChoiceService = questionResponseChoiceService;
        }

        [HttpGet("GetQuestionResponseChoicesByQuestionId")]
        public async Task<ActionResult> GetQuestionResponseChoicesByQuestionId([FromQuery] int questionId)
        {
            return Ok(await _questionResponseChoiceService.GetQuestionResponseChoicesByQuestionId(questionId));
        }

        [HttpPost("AddQuestionResponseChoice")]
        public async Task<ActionResult> AddQuestionResponseChoice([FromBody] AddQuestionResponseChoiceRequest request)
        {
            await _questionResponseChoiceService.AddQuestionResponseChoice(request);

            return Ok();
        }

        [HttpPut("UpdateQuestionResponseChoice")]
        public async Task<ActionResult> UpdateQuestionResponseChoice([FromBody] UpdateQuestionResponseChoiceRequest request)
        {
            await _questionResponseChoiceService.UpdateQuestionResponseChoice(request);

            return NoContent();
        }

        [HttpDelete("DeleteQuestionResponseChoice")]
        public async Task<ActionResult> DeleteQuestionResponseChoice([FromQuery][Required] int id)
        {
            await _questionResponseChoiceService.DeleteQuestionResponseChoice(id);

            return NoContent();
        }
    }
}
