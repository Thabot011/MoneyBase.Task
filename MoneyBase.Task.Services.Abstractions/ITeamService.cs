using MoneyBase.Contracts.Team;

namespace MoneyBase.Services.Abstractions
{
    public interface ITeamService
    {
        Task<TeamDto> GetTeamByShiftAsync(ShiftType shift, CancellationToken cancellationToken = default);
    }
}
