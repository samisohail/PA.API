using System;

namespace API.Common
{
    public interface IDateTimeHelper
    {
        DateTime GetCurrentDate();
        bool IsValidDate(string valueToCheckAsDate);
        bool IsValidDate(object objToCheckAsDate);
    }
}
