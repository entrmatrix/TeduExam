using System;
using System.Collections.Generic;
using System.Text;
using TeduExam.Core.Entities;

namespace TeduExam.Core.Interfaces
{
    /// <summary>
    /// This interface is used to mark the owner of an object.
    /// </summary>
    public interface IHasOwner
    {
        /// <summary>
        /// The Person instance this object belongs to.
        /// </summary>
        ApplicationUser Owner { get; set; }
    }
}
