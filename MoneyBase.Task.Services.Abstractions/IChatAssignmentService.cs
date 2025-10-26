using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBase.Services.Abstractions
{
    public interface IChatAssignmentService
    {
        Task<bool> AssignChatAsync(Guid chatId, CancellationToken cancellationToken);
    }
}
