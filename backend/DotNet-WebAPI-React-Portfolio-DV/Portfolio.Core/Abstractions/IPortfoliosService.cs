using Portfolio.Core.Models;

namespace Portfolio.Core.Abstractions
{
    public interface IPortfoliosService
    {
        public Task<List<PortfolioModel>> Get();
        public Task<int> Create(PortfolioModel portfolio);
        public Task<int> Update(int id, string name, string surname, string description);
        public Task<int> Delete(int id);
    }
}
