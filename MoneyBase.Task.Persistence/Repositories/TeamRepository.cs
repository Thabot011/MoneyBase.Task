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
        public async Task<Team> GetTeamByShiftAsync(TimeOnly currentTime, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Teams.Include(t => t.Shift).Include(t => t.Agents).ThenInclude(a => a.Chats).Where(t => t.Shift.StartTime <= currentTime && t.Shift.EndTime >= currentTime).AsSplitQuery().AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Team> GetTeamByShiftAsync(ShiftType shiftType, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Teams.Include(t => t.Shift).Include(t => t.Agents).ThenInclude(a => a.Chats).Where(t => t.Shift.ShiftType == shiftType).AsSplitQuery().AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }
    }
}
