using Portfolio.Core.Abstractions;
using Portfolio.Core.Models;

namespace Portfolio.Application.Services
{
    public class PortfolioService : IPortfoliosService
    {
        private readonly IPortfoliosRepository _portfoliosRepository;

        public PortfolioService(IPortfoliosRepository portfoliosRepository)
        {
            _portfoliosRepository = portfoliosRepository;
        }

        public async Task<int> Create(PortfolioModel portfolio)
        {
            return await _portfoliosRepository.Create(portfolio);
        }

        public async Task<int> Delete(int id)
        {
            return await _portfoliosRepository.Delete(id);
        }

        public async Task<List<PortfolioModel>> Get()
        {
            return await _portfoliosRepository.Get();
        }

        public async Task<int> Update(int id, string name, string surname, string description)
        {
            return await _portfoliosRepository.Update(id, name, surname, description);
        }
    }
}