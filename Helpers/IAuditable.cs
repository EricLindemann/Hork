using System;

namespace Hork_Api.Helpers
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}