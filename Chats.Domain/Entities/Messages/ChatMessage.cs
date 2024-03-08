using Chats.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.Domain.Entities.Messages
{
    public class ChatMessage : Monitoring
    {
        public int Id { get; set; }

        public ChatMessageState State { get; set; }
        public string StateId { get; set; }

        public ChatMessageType Type { get; set; }
        public string TypeId { get; set; }

        public ChatMessageSpecification Specification { get; set; }
        public string SpecificationId { get; set; }

        public int SourceId { get; set; }

        public int OwnerId { get; set; }

        public string FullText { get; set; }
        public string ShortText { get; set; }

        public int LikesCount { get; set; }
        public int DisLikesCount { get; set; }

        public int SearchPoints { get; set; }
    }
}
