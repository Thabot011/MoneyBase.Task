using MoneyBase.Domain.Entities;

namespace MoneyBase.Domain.RepositoryInterfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamByShiftAsync(TimeOnly currentTime, CancellationToken cancellationToken = default);
        Task<Team> GetTeamByShiftAsync(ShiftType shiftType, CancellationToken cancellationToken = default);
    }
}
