using MoneyBase.Domain.Entities;

namespace MoneyBase.Domain.RepositoryInterfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamByShiftAsync(ShiftType shift, CancellationToken cancellationToken = default);
    }
}
