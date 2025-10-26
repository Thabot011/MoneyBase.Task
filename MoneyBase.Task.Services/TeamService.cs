using Mapster;
using MoneyBase.Contracts.Team;
using MoneyBase.Domain.Entities;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TeamService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<TeamDto> GetTeamByShiftAsync(TimeOnly currentTime, CancellationToken cancellationToken = default)
        {
            var teams = await _repositoryManager.TeamRepository.GetTeamByShiftAsync(currentTime, cancellationToken);
            var teamsDto = teams.Adapt<TeamDto>();
            return teamsDto;
        }

        public async Task<TeamDto> GetTeamByShiftAsync(Contracts.Shift.ShiftType shiftType, CancellationToken cancellationToken = default)
        {
            var teams = await _repositoryManager.TeamRepository.GetTeamByShiftAsync((Domain.Entities.ShiftType)shiftType, cancellationToken);
            var teamsDto = teams.Adapt<TeamDto>();
            return teamsDto;
        }
    }
}
