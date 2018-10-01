using System;

namespace API.Common
{
    public class DateTimeHelper : IDateTimeHelper
    {
        private static DateTimeHelper _Instance = new DateTimeHelper();

        public static DateTimeHelper Instance
        {
            get
            {
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        public DateTimeHelper()
        {
        }

        public virtual DateTime GetCurrentDate()
        {
            return DateTime.UtcNow;
        }
        public virtual bool IsValidDate(string valueToCheckAsDate)
        {
            DateTime dateTime;
            return DateTime.TryParse(valueToCheckAsDate, out dateTime);
        }
        public virtual bool IsValidDate(object objToCheckAsDate)
        {
            try
            {
                Convert.ToDateTime(objToCheckAsDate);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}

