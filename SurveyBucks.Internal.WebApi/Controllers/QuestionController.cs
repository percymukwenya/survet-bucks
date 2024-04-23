using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("GetQuestion")]
        public async Task<ActionResult> GetQuestion([FromQuery] int id)
        {
            return Ok(await _questionService.GetQuestion(id));
        }

        [HttpGet("GetQuestions")]
        public async Task<ActionResult> GetQuestions()
        {
            return Ok(await _questionService.GetQuestions());
        }

        [HttpPost("AddQuestion")]
        public async Task<ActionResult> AddQuestion([FromBody] AddQuestionRequest request)
        {
            await _questionService.AddQuestion(request);
            return Ok();
        }

        [HttpPut("UpdateQuestion")]
        public async Task<ActionResult> UpdateQuestion([FromBody] UpdateQuestionRequest request)
        {
            await _questionService.UpdateQuestion(request);
            return NoContent();
        }

        [HttpDelete("DeleteQuestion")]
        public async Task<ActionResult> DeleteQuestion([FromQuery][Required] int id)
        {
            await _questionService.DeleteQuestion(id);

            return NoContent();
        }
    }
}
