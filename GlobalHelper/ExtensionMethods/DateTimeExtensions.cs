using System;

namespace GlobalHelper.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Formats a DateTime object into something like this: January 26th, 2018 at 2:19pm
        /// </summary>
        /// <param name="dateTime">DateTime object to process</param>
        /// <param name="includeTime">Choose to include the time, or not, in the result</param>
        /// <returns>The formatted DateTime in a string</returns>
        public static string ToEnglishFormattedDateTime(this DateTime dateTime, bool includeTime)
        {
            string dateSuffix = "<sup>th</sup>";
            switch (dateTime.Day)
            {
                case 1:
                case 21:
                case 31:
                    dateSuffix = "<sup>st</sup>";
                    break;
                case 2:
                case 22:
                    dateSuffix = "<sup>nd</sup>";
                    break;
                case 3:
                case 23:
                    dateSuffix = "<sup>rd</sup>";
                    break;
            }
            
            var dateFmt = $"{dateTime:MMMM} {dateTime:%d}{dateSuffix}, {dateTime:yyyy} at {dateTime:%h}:{dateTime:mm}{dateTime.ToString("tt").ToLower()}";

            if (!includeTime)
            {
                dateFmt = $"{dateTime:MMMM} {dateTime:%d}{dateSuffix}, {dateTime:yyyy}";
            }

            return dateFmt;
        }

        /// <summary>
        /// Formats a DateTime object into something like this: 2018-07-16T19:20:30.45Z
        /// </summary>
        /// <param name="dateTime">DateTime object to process</param>
        /// <returns>The formatted DateTime in a string</returns>
        public static string ToW3CDate(this DateTime dateTime) => dateTime.ToUniversalTime().ToString("s") + "Z";

        /// <summary>
        /// Retrieves the current quarter of the year
        /// </summary>
        /// <param name="fromDate">DateTime object to process</param>
        /// <returns>An int representing the current quarter of the year</returns>
        public static int GetQuarter(this DateTime fromDate) => (fromDate.Month - 1) / 3 + 1;

        /// <summary>
        /// Returns the number of remaining days before reaching a certain date
        /// </summary>
        /// <param name="value">DateTime object from which the count starts</param>
        /// <param name="endDateTime">DateTime object which represents the end date</param>
        /// <returns>The number of remaining days before</returns>
        public static string ToDaysUntil(this DateTime value, DateTime endDateTime)
        {
            var ts = new TimeSpan(endDateTime.Ticks - value.Ticks);
            var delta = ts.TotalSeconds;

            if (delta < 60)
            {
                return ts.Seconds == 1 ? @"one second" : ts.Seconds + @" seconds";
            }
            if (delta < 120)
            {
                return @"a minute";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + @" minutes";
            }
            if (delta < 5400) // 90 * 60
            {
                return @"an hour";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + @" hours";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return @"yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + @" days";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? @"one month" : months + @" months";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? @"one year" : years + @" years";
        }

        /// <summary>
        /// Inserts a "0" character before the day and the month if they are strictly inferior to 10.
        /// Example: 582017 => 05082017
        /// </summary>
        /// <param name="date">The DateTime object</param>
        /// <returns>The new date in a string formatted as JJMMAAAA</returns>
        public static string AddZeroInDate(DateTime date)
        {
            string day = date.Day < 10 ? "0" + date.Day : date.Day.ToString();
            string month = date.Month < 10 ? "0" + date.Month : date.Month.ToString();
            string year = date.Year.ToString();

            return $"{day}{month}{year}";
        }
    }
}
