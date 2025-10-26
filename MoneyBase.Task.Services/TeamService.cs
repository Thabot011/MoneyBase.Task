using Mapster;
using MoneyBase.Contracts.Team;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TeamService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<TeamDto> GetTeamByShiftAsync(Contracts.Team.ShiftType shift, CancellationToken cancellationToken = default)
        {
            var teams = await _repositoryManager.TeamRepository.GetTeamByShiftAsync(shift.Adapt<Domain.Entities.ShiftType>(), cancellationToken);
            var teamsDto = teams.Adapt<TeamDto>();
            return teamsDto;
        }
    }
}
