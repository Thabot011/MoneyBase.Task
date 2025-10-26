using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MoneyBase.Contracts.Chat;
using MoneyBase.Persistence.Consumers;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Presentation.Controllers
{
    [ApiController]
    [Route("api/chats")]
    public class ChatController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IRequestClient<StartSessionCommand> _client;
        public ChatController(IServiceManager serviceManager, IRequestClient<StartSessionCommand> client)
        {
            _serviceManager = serviceManager;
            _client = client;
        }
        [HttpPost]
        public async Task<IActionResult> CreateChat([FromBody] AddChatDto model)
        {
            ChatDto chat = await _serviceManager.ChatService.AddChatAsync(model);
            var res = await _client.GetResponse<StartSessionResult>(new StartSessionCommand(chat.Id), timeout: RequestTimeout.After(h: 1));
            if (res.Message.IsAssigned)
            {
                return Ok(chat.Id);
            }
            return BadRequest("No Agent available");
        }

        [HttpGet("{chatId:guid}/status")]
        public async Task<IActionResult> Status([FromRoute] Guid chatId)
        {
            ChatDto chat = await _serviceManager.ChatService.GetChatById(chatId);
            if (chat == null)
            {
                return NotFound(new { message = $"Session with ID {chatId} not found" });
            }
            if (chat.ChatStatus == ChatStatus.Inactive)
            {
                await _serviceManager.ChatService.ChangeStatus(chat, ChatStatus.Active, chat.AgentId);
            }
            await _serviceManager.ChatService.UpdateLastPollDate(chat);
            return Ok(chat);
        }
    }
}
