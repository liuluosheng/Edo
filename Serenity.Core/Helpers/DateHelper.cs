﻿using System;
using System.Globalization;

namespace Serenity
{
    public static class DateHelper
    {
        /// <summary>
        ///   ISO Date and Time Format (up to milliseconds).</summary>
        public static string ISODateTimeFormatUTC =
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

        /// <summary>
        ///   ISO Date and Time Format (up to milliseconds).</summary>
        public static string ISODateTimeFormatLocal =
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff";

        private static string[] _isoDateTimeFormats = {
           "yyyy'-'MM'-'dd",
           "yyyy'-'MM'-'dd'T'HH':'mm",
           "yyyy'-'MM'-'dd'T'HH':'mmK",
           "yyyy'-'MM'-'dd'T'HH':'mm'Z'",
           "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
           "yyyy'-'MM'-'dd'T'HH':'mm':'ssK",
           "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'",
           "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff",
           "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK",
           "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"
       };

        /// <summary>
        ///   Tries to parse an ISO 8601 date-time string.</summary>
        /// <param name="value">
        ///   String to be parsed</param>
        /// <param name="date">
        ///   Parameter to return parsed date-time value in.</param>
        /// <returns>
        ///   True if string is a valid ISO8601 date-time string.</returns>
        public static bool TryParseISO8601DateTime(this string value, out DateTime date)
        {
            return DateTime.TryParseExact(value, _isoDateTimeFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out date);
        }

        /// <summary>
        ///   Returns one of "dmy", "ymd", "mdy" date element order depending on current culture.</summary>
        /// <returns>
        ///   Active date element order.</returns>
        public static DateElementOrder CurrentDateElementOrder
        {
            get
            {
                return DateElementOrderFor(CultureInfo.CurrentCulture
                    .DateTimeFormat.ShortDatePattern);
            }
        }

        public static DateElementOrder DateElementOrderFor(string shortDatePattern)
        {
            int m = shortDatePattern.IndexOf('M');
            if (shortDatePattern.IndexOf('y') < m)
                return DateElementOrder.YearMonthDay;
            if (m < shortDatePattern.IndexOf('d'))
                return DateElementOrder.MonthDayYear;

            return DateElementOrder.DayMonthYear;
        }

        private static string[] _dateOrderString = new string[] {
           "dmy",
           "mdy",
           "ymd"
       };

        private static string[] _defaultDateFormat = new string[] {
           "dd/MM/yyyy",
           "MM/dd/yyyy",
           "yyyy/MM/dd"
       };

        private static string[] _defaultDateTimeFormat = new string[] {
           "dd/MM/yyyy HH:mm:ss",
           "MM/dd/yyyy HH:mm:ss",
           "yyyy/MM/dd HH:mm:ss"
       };

        /// <summary>
        ///   Gets date order string (one of "dmy", "ymd", "mdy") for a specified order.</summary>
        /// <param name="order">
        ///   Order</param>
        /// <returns>
        ///   Date order string</returns>
        public static string DateOrderString(DateElementOrder order)
        {
            return _dateOrderString[(int)order];
        }

        /// <summary>
        ///   Gets defalt date format for specified order.</summary>
        /// <param name="order">
        ///   Order</param>
        /// <returns>
        ///   One of "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd".</returns>
        public static string DefaultDateFormat(DateElementOrder order)
        {
            return _defaultDateFormat[(int)order];
        }

        /// <summary>
        ///   Gets defalt date time format for specified order.</summary>
        /// <param name="order">
        ///   Order</param>
        /// <returns>
        ///   One of "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy/MM/dd HH:mm:ss".</returns>       
        public static string DefaultDateTimeFormat(DateElementOrder order)
        {
            return _defaultDateTimeFormat[(int)order];
        }

        /// <summary>
        ///   Gets default date format for current culture.</summary>
        public static string CurrentDateFormat
        {
            get { return _defaultDateFormat[(int)CurrentDateElementOrder]; }
        }

        /// <summary>
        ///   Gets default date time format for current culture.</summary>
        public static string CurrentDateTimeFormat
        {
            get { return _defaultDateTimeFormat[(int)CurrentDateElementOrder]; }
        }
    }
}