using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Abstractions;
using Portfolio.Core.Models;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess.Repositories
{
    public class PortfoliosRepository : IPortfoliosRepository
    {
        private readonly PortfolioDbContext _context;

        public PortfoliosRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<List<PortfolioModel>> Get()
        {
            var portfolioEntities = await _context.Portfolios
                .AsNoTracking()
                .ToListAsync();

            var portfolios = portfolioEntities
                .Select(x => PortfolioModel.Create(x.Id, x.Name, x.Surname, x.Description).portfolio)
                .ToList();

            return portfolios;
        }

        public async Task<int> Create(PortfolioModel portfolio)
        {
            var entity = new PortfolioEntity()
            {
                Id = portfolio.Id,
                Name = portfolio.Name,
                Surname = portfolio.Surname,
                Description = portfolio.Description
            };

            await _context.Portfolios.AddAsync(entity);
            await _context.SaveChangesAsync();

            return portfolio.Id;
        }

        public async Task<int> Update(int id, string name, string surname, string description)
        {
            await _context.Portfolios
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Surname, b => surname)
                    .SetProperty(b => b.Description, b => description));

            return id;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Portfolios
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}