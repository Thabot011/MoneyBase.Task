using Microsoft.EntityFrameworkCore;
using MoneyBase.Domain.Entities;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Persistence.Database;

namespace MoneyBase.Persistence.Repositories
{
    internal sealed class TeamRepository : ITeamRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public TeamRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
        public async Task<Team> GetTeamByShiftAsync(ShiftType shift, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Teams.AsQueryable().Include(t => t.Shift).Include(t => t.Agents).ThenInclude(a => a.Chats).FirstOrDefaultAsync(t => t.Shift.ShiftType == shift, cancellationToken);
        }
    }
}
