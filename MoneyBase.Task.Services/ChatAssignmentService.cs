using MoneyBase.Contracts.Chat;
using MoneyBase.Contracts.Team;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Services
{
    public class ChatAssignmentService : IChatAssignmentService
    {
        private readonly IServiceManager _serviceManager;

        public ChatAssignmentService(IServiceManager serviceManager) => _serviceManager = serviceManager;
        public async Task<bool> AssignChatAsync(Guid chatId, CancellationToken cancellationToken)
        {
            var chat = await _serviceManager.ChatService.GetChatById(chatId, cancellationToken);


            var team = await _serviceManager.TeamService.GetTeamByShiftAsync(TimeOnly.FromDateTime(DateTime.UtcNow), cancellationToken);
            chat = await TryAssignChat(team, chat, cancellationToken);

            if (chat.ChatStatus != ChatStatus.Assigned)
            {
                var overflowTeam = await _serviceManager.TeamService.GetTeamByShiftAsync(Contracts.Shift.ShiftType.Overflow, cancellationToken);
                chat = await TryAssignChat(overflowTeam, chat, cancellationToken);
            }
            return chat.ChatStatus == ChatStatus.Assigned;
        }


        private async Task<ChatDto> TryAssignChat(TeamDto team, ChatDto chat, CancellationToken cancellationToken)
        {
            foreach (var agent in team.Agents.OrderBy(x => x.AgentType))
            {
                if (agent.Chats.Where(x=>x.ChatStatus!=ChatStatus.Inactive).Count() < agent.MaxChats)
                {
                    chat = await _serviceManager.ChatService.ChangeStatus(chat, ChatStatus.Assigned, agent.Id, cancellationToken);
                    break;
                }
            }
            return chat;
        }
    }
}
