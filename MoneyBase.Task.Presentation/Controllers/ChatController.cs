using Microsoft.AspNetCore.Mvc;
using MoneyBase.Contracts.Chat;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Presentation.Controllers
{
    [ApiController]
    [Route("api/chats")]
    public class ChatController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public ChatController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateChat([FromBody] AddChatDto model)
        {
            await _serviceManager.ChatService.AddChatAsync(model);
            return Ok();
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetChatStatus([FromRoute] Guid chatId)
        {

            return Ok();
        }
    }
}
