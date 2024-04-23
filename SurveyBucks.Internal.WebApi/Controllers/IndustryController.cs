using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Services.Contract;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryService _industryService;

        public IndustryController(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        [HttpGet("GetIndustry")]
        public async Task<ActionResult> GetIndustry([FromQuery] int id)
        {
            return Ok(await _industryService.GetIndustry(id));
        }

        [HttpGet("GetIndustries")]
        public async Task<ActionResult> GetIndustries()
        {
            return Ok(await _industryService.GetIndustries());
        }

        [HttpPost("AddIndustry")]
        public async Task<ActionResult> AddIndustry([FromBody] AddIndustryRequest request)
        {
            await _industryService.AddIndustry(request);

            return Ok();
        }

        [HttpPut("UpdateIndustry")]
        public async Task<ActionResult> UpdateIndustry([FromBody] UpdateIndustryRequest request)
        {
            await _industryService.UpdateIndustry(request);

            return NoContent();
        }

        [HttpDelete("DeleteIndustry")]
        public async Task<ActionResult> DeleteIndustry([FromQuery][Required] int id)
        {
            await _industryService.DeleteIndustry(id);

            return NoContent();
        }
    }
}
