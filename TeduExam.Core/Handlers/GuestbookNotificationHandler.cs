using System;
using System.Linq;
using TeduExam.Core.Entities;
using TeduExam.Core.Events;
using TeduExam.Core.Interfaces;
using TeduExam.Core.Specifications;

namespace TeduExam.Core.Handlers
{
    public class GuestbookNotificationHandler : IHandle<EntryAddedEvent>
    {
        private readonly IGuestbookRepository _guestbookRepository;
        private readonly IMessageSender _messageSender;

        public GuestbookNotificationHandler(IGuestbookRepository guestbookRepository,
            IMessageSender messageSender)
        {
            _guestbookRepository = guestbookRepository;
            _messageSender = messageSender;
        }

        public void Handle(EntryAddedEvent entryAddedEvent)
        {
            var emailsToNotify = _guestbookRepository.ListEntries(
                new GuestbookNotificationPolicy(entryAddedEvent.GuestbookId))
                .Select(e => e.EmailAddress);
            foreach (var emailAddress in emailsToNotify)
            {
                string messageBody = "{entry.EmailAddress} left new message {entry.Message}";
                _messageSender.SendGuestbookNotificationEmail(emailAddress, messageBody);
            }
        }
    }
}