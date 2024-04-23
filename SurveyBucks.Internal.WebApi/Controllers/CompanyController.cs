using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Models.Request;
using SurveyBucks.Internal.Application.Models.Response;
using SurveyBucks.Internal.Application.Services.Contract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetCompany")]
        public async Task<ActionResult<CompanyDetailResponse>> GetCompany([FromQuery] int id)
        {
            return Ok(await _companyService.GetCompany(id));
        }

        [HttpGet("GetCompanies")]
        public async Task<ActionResult<IReadOnlyList<CompanyListResponse>>> GetCompanies()
        {
            return Ok(await _companyService.GetCompanies());
        }

        [HttpPost("AddCompany")]
        public async Task<ActionResult> AddCompany([FromBody] AddCompanyRequest request)
        {
            await _companyService.AddCompany(request);

            return Ok();
        }

        [HttpPut("UpdateCompany")]
        public async Task<ActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request)
        {
            await _companyService.UpdateCompany(request);

            return NoContent();
        }

        [HttpDelete("DeleteCompany")]
        public async Task<ActionResult> DeleteCompany([FromQuery][Required] int id)
        {
            await _companyService.DeleteCompany(id);

            return NoContent();
        }
    }
}
