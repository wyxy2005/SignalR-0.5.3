﻿using System.Collections.Generic;

namespace SignalR
{
    /// <summary>
    /// Represents a result of 
    /// </summary>
    public struct MessageResult
    {
        private static readonly List<Message> _emptyList = new List<Message>();

        /// <summary>
        /// Gets an <see cref="IList{Message}"/> associated with the result.
        /// </summary>
        public IList<Message> Messages { get; private set; }

        /// <summary>
        /// Gets a cursor representing the caller state.
        /// </summary>
        public string LastMessageId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResult"/> struc.
        /// </summary>
        /// <param name="lastMessageId">Gets a cursor representing the caller state.</param>
        public MessageResult(string lastMessageId)
            : this(_emptyList, lastMessageId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResult"/> struc.
        /// </summary>
        /// <param name="messages">The list of messages associated with this <see cref="MessageResult"/>.</param>
        /// <param name="lastMessageId">Gets a cursor representing the caller state.</param>
        public MessageResult(IList<Message> messages, string lastMessageId)
            : this()
        {
            Messages = messages;
            LastMessageId = lastMessageId;
        }
    }
}
