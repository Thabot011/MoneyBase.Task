using MoneyBase.Contracts.Team;

namespace MoneyBase.Services.Abstractions
{
    public interface ITeamService
    {
        Task<TeamDto> GetTeamByShiftAsync(TimeOnly currentTime, CancellationToken cancellationToken = default);
        Task<TeamDto> GetTeamByShiftAsync(Contracts.Shift.ShiftType shiftType, CancellationToken cancellationToken = default);

    }
}
