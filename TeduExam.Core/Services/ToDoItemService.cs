using TeduExam.Core.Events;
using TeduExam.Core.Interfaces;

namespace TeduExam.Core.Services
{
    public class ToDoItemService : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            // Do Nothing
        }
    }
}
