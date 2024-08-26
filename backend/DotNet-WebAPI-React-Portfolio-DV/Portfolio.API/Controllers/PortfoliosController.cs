using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Contracts;
using Portfolio.Core.Abstractions;
using Portfolio.Core.Models;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfoliosService _portfoliosService;

        public PortfoliosController(IPortfoliosService portfoliosService)
        {
            _portfoliosService = portfoliosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PortfoliosResponse>>> GetPortfolios()
        {
            var portfolios = await _portfoliosService.Get();
            var response = portfolios.Select(x => new PortfoliosResponse(x.Id, x.Name, x.Surname, x.Description));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePortfolio([FromBody] PortfoliosRequest request)
        {
            var (portfolio, error) = PortfolioModel.Create(
                0,
                request.Name,
                request.Surname,
                request.Description);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var requestId = await _portfoliosService.Create(portfolio);
            return Ok(requestId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdatePortfolio(int id, [FromBody] PortfoliosRequest request)
        {
            var (portfolio, error) = PortfolioModel.Create(
                0,
                request.Name,
                request.Surname,
                request.Description);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var requestId = await _portfoliosService.Update(id, portfolio.Name, portfolio.Surname, portfolio.Description);
            return Ok(requestId);
        } 

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeletePortfolio(int id)
        {
            var requestId = await _portfoliosService.Delete(id);
            return Ok(requestId);
        }
    }
}