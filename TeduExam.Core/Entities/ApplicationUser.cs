using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeduExam.Core.Entities
{
   public  class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public DateTime? BirthDay { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string Avatar { get; set; }

        public decimal Balance { get; set; }

        public bool? Gender { get; set; }
    }
}
