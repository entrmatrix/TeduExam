using System.Collections.Generic;
using TeduExam.Core.Entities;

namespace TeduExam.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestbookName { get; set; }
        public List<GuestbookEntry> PreviousEntries { get; } = new List<GuestbookEntry>();

        public GuestbookEntry NewEntry { get; set; }
    }
}