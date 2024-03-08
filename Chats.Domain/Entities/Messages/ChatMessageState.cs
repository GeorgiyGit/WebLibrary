using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.Domain.Entities.Messages
{
    public class ChatMessageState
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<ChatMessage> Messages { get; set; } = new HashSet<ChatMessage>();
    }
}
