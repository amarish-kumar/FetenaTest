using System;

namespace Fetena.Models
{
    internal interface IDateTimeStamp
    {
        DateTime DateAdded { get; set; }
        DateTime DateModified { get; set; }

    }
}