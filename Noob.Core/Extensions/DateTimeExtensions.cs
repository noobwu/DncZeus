// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="DateTimeExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;

namespace Noob.Extensions
{
    /// <summary>
    /// A fast, standards-based, serialization-issue free DateTime serializer.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// The local time zone
        /// </summary>
        internal static TimeZoneInfo LocalTimeZone = GetLocalTimeZoneInfo();
        /// <summary>
        /// Gets the local time zone information.
        /// </summary>
        /// <returns>TimeZoneInfo.</returns>
        public static TimeZoneInfo GetLocalTimeZoneInfo()
        {
            try
            {
                return TimeZoneInfo.Local;
            }
            catch (Exception)
            {
                return TimeZoneInfo.Utc; //Fallback for Mono on Windows.
            }
        }
        /// <summary>
        /// The unix epoch
        /// </summary>
        public const long UnixEpoch = 621355968000000000L;
        /// <summary>
        /// The unix epoch
        /// </summary>
        public static long UnixEpochSecond = 621355968000000000L/TimeSpan.TicksPerSecond;
        /// <summary>
        /// The unix epoch date time UTC
        /// </summary>
        private static readonly DateTime UnixEpochDateTimeUtc = new DateTime(UnixEpoch, DateTimeKind.Utc);
        /// <summary>
        /// The unix epoch date time unspecified
        /// </summary>
        private static readonly DateTime UnixEpochDateTimeUnspecified = new DateTime(UnixEpoch, DateTimeKind.Unspecified);
        /// <summary>
        /// The minimum date time UTC
        /// </summary>
        private static readonly DateTime MinDateTimeUtc = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// The XSD date time format
        /// </summary>
        public const string XsdDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";               //29
        /// <summary>
        /// The XSD date time format3 f
        /// </summary>
        public const string XsdDateTimeFormat3F = "yyyy-MM-ddTHH:mm:ss.fffZ";                 //25
        /// <summary>
        /// The XSD date time format seconds
        /// </summary>
        public const string XsdDateTimeFormatSeconds = "yyyy-MM-ddTHH:mm:ssZ";                //21       
        /// <summary>
        /// The date time format ticks UTC offset
        /// </summary>
        public const string DateTimeFormatTicksUtcOffset = "yyyy-MM-ddTHH:mm:ss.fffffffzzz";  //30
        /// <summary>
        /// The minimum XSD date time format seconds
        /// </summary>
        public const string MinXsdDateTimeFormatSeconds = "0001-01-01T00:00:00Z";
        /// <summary>
        /// Froms the unix time.
        /// </summary>
        /// <param name="unixTime">The unix time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTime(this int unixTime)
        {
            return UnixEpochDateTimeUtc + TimeSpan.FromSeconds(unixTime);
        }

        /// <summary>
        /// Froms the unix time.
        /// </summary>
        /// <param name="unixTime">The unix time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTime(this double unixTime)
        {
            return UnixEpochDateTimeUtc + TimeSpan.FromSeconds(unixTime);
        }

        /// <summary>
        /// Froms the unix time.
        /// </summary>
        /// <param name="unixTime">The unix time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTime(this long unixTime)
        {
            return UnixEpochDateTimeUtc + TimeSpan.FromSeconds(unixTime);
        }

        /// <summary>
        /// Converts to unixtimemsalt.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int64.</returns>
        public static long ToUnixTimeMsAlt(this DateTime dateTime)
        {
            return (dateTime.ToStableUniversalTime().Ticks - UnixEpoch) / TimeSpan.TicksPerMillisecond;
        }

        /// <summary>
        /// Converts to unixtimems.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int64.</returns>
        public static long ToUnixTimeMs(this DateTime dateTime)
        {
            var universal = ToDateTimeSinceUnixEpoch(dateTime);
            return (long)universal.TotalMilliseconds;
        }

        /// <summary>
        /// Converts to unixtime.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int64.</returns>
        public static long ToUnixTime(this DateTime dateTime)
        {
            return (dateTime.ToDateTimeSinceUnixEpoch().Ticks) / TimeSpan.TicksPerSecond;
        }

        /// <summary>
        /// Converts to datetimesinceunixepoch.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>TimeSpan.</returns>
        private static TimeSpan ToDateTimeSinceUnixEpoch(this DateTime dateTime)
        {
            var dtUtc = dateTime;
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                dtUtc = dateTime.Kind == DateTimeKind.Unspecified && dateTime > DateTime.MinValue && dateTime < DateTime.MaxValue
                    ? DateTime.SpecifyKind(dateTime.Subtract(LocalTimeZone.GetUtcOffset(dateTime)), DateTimeKind.Utc)
                    : dateTime.ToStableUniversalTime();
            }

            var universal = dtUtc.Subtract(UnixEpochDateTimeUtc);
            return universal;
        }

        /// <summary>
        /// Converts to unixtimems.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns>System.Int64.</returns>
        public static long ToUnixTimeMs(this long ticks)
        {
            return (ticks - UnixEpoch) / TimeSpan.TicksPerMillisecond;
        }

        /// <summary>
        /// Froms the unix time ms.
        /// </summary>
        /// <param name="msSince1970">The ms since1970.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTimeMs(this double msSince1970)
        {
            return UnixEpochDateTimeUtc + TimeSpan.FromMilliseconds(msSince1970);
        }

        /// <summary>
        /// Froms the unix time ms.
        /// </summary>
        /// <param name="msSince1970">The ms since1970.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTimeMs(this long msSince1970)
        {
            return UnixEpochDateTimeUtc + TimeSpan.FromMilliseconds(msSince1970);
        }

        /// <summary>
        /// Froms the unix time ms.
        /// </summary>
        /// <param name="msSince1970">The ms since1970.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTimeMs(this long msSince1970, TimeSpan offset)
        {
            return DateTime.SpecifyKind(UnixEpochDateTimeUnspecified + TimeSpan.FromMilliseconds(msSince1970) + offset, DateTimeKind.Local);
        }

        /// <summary>
        /// Froms the unix time ms.
        /// </summary>
        /// <param name="msSince1970">The ms since1970.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTimeMs(this double msSince1970, TimeSpan offset)
        {
            return DateTime.SpecifyKind(UnixEpochDateTimeUnspecified + TimeSpan.FromMilliseconds(msSince1970) + offset, DateTimeKind.Local);
        }

        /// <summary>
        /// Froms the unix time ms.
        /// </summary>
        /// <param name="msSince1970">The ms since1970.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTimeMs(string msSince1970)
        {
            long ms;
            if (long.TryParse(msSince1970, out ms)) return ms.FromUnixTimeMs();

            // Do we really need to support fractional unix time ms time strings??
            return double.Parse(msSince1970).FromUnixTimeMs();
        }

        /// <summary>
        /// Froms the unix time ms.
        /// </summary>
        /// <param name="msSince1970">The ms since1970.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromUnixTimeMs(string msSince1970, TimeSpan offset)
        {
            long ms;
            if (long.TryParse(msSince1970, out ms)) return ms.FromUnixTimeMs(offset);

            // Do we really need to support fractional unix time ms time strings??
            return double.Parse(msSince1970).FromUnixTimeMs(offset);
        }

        /// <summary>
        /// Rounds to ms.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime RoundToMs(this DateTime dateTime)
        {
            return new DateTime((dateTime.Ticks / TimeSpan.TicksPerMillisecond) * TimeSpan.TicksPerMillisecond, dateTime.Kind);
        }

        /// <summary>
        /// Rounds to second.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime RoundToSecond(this DateTime dateTime)
        {
            return new DateTime((dateTime.Ticks / TimeSpan.TicksPerSecond) * TimeSpan.TicksPerSecond, dateTime.Kind);
        }

        /// <summary>
        /// Truncates the specified time span.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="timeSpan">The time span.</param>
        /// <returns>DateTime.</returns>
        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan)
        {
            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }

        /// <summary>
        /// Converts to shortestxsddatetimestring.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.String.</returns>
        public static string ToShortestXsdDateTimeString(this DateTime dateTime)
        {
            return ToShortestXsdDateTimeString(dateTime);
        }


        /// <summary>
        /// Determines whether [is equal to the second] [the specified other date time].
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="otherDateTime">The other date time.</param>
        /// <returns><c>true</c> if [is equal to the second] [the specified other date time]; otherwise, <c>false</c>.</returns>
        public static bool IsEqualToTheSecond(this DateTime dateTime, DateTime otherDateTime)
        {
            return dateTime.ToStableUniversalTime().RoundToSecond().Equals(otherDateTime.ToStableUniversalTime().RoundToSecond());
        }

        /// <summary>
        /// Converts to timeoffsetstring.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns>System.String.</returns>
        public static string ToTimeOffsetString(this TimeSpan offset, string seperator = "")
        {
            var hours = Math.Abs(offset.Hours).ToString(CultureInfo.InvariantCulture);
            var minutes = Math.Abs(offset.Minutes).ToString(CultureInfo.InvariantCulture);
            return (offset < TimeSpan.Zero ? "-" : "+")
                + (hours.Length == 1 ? "0" + hours : hours)
                + seperator
                + (minutes.Length == 1 ? "0" + minutes : minutes);
        }

        /// <summary>
        /// Froms the time offset string.
        /// </summary>
        /// <param name="offsetString">The offset string.</param>
        /// <returns>TimeSpan.</returns>
        public static TimeSpan FromTimeOffsetString(this string offsetString)
        {
            if (!offsetString.Contains(":"))
                offsetString = offsetString.Insert(offsetString.Length - 2, ":");

            offsetString = offsetString.TrimStart('+');

            return TimeSpan.Parse(offsetString);
        }

        /// <summary>
        /// Converts to stableuniversaltime.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToStableUniversalTime(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc)
                return dateTime;
            if (dateTime == DateTime.MinValue)
                return MinDateTimeUtc;

            return dateTime.ToUniversalTime();
        }

        /// <summary>
        /// FMTs the sortable date.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>System.String.</returns>
        public static string FmtSortableDate(this DateTime from)
        {
            return from.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// FMTs the sortable date time.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>System.String.</returns>
        public static string FmtSortableDateTime(this DateTime from)
        {
            return from.ToString("u");
        }

        /// <summary>
        /// Lasts the monday.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>DateTime.</returns>
        public static DateTime LastMonday(this DateTime from)
        {
            var mondayOfWeek = from.Date.AddDays(-(int)from.DayOfWeek + 1);
            return mondayOfWeek;
        }

        /// <summary>
        /// Starts the of last month.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>DateTime.</returns>
        public static DateTime StartOfLastMonth(this DateTime from)
        {
            return new DateTime(from.Date.Year, from.Date.Month, 1).AddMonths(-1);
        }

        /// <summary>
        /// Ends the of last month.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>DateTime.</returns>
        public static DateTime EndOfLastMonth(this DateTime from)
        {
            return new DateTime(from.Date.Year, from.Date.Month, 1).AddDays(-1);
        }

        /// <summary>
        /// Converts to xsddatetimestring.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.String.</returns>
        public static string ToXsdDateTimeString(DateTime dateTime)
        {
            return System.Xml.XmlConvert.ToString(dateTime.ToStableUniversalTime(), XsdDateTimeFormat);
        }

        /// <summary>
        /// Converts to localxsddatetimestring.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.String.</returns>
        public static string ToLocalXsdDateTimeString(DateTime dateTime)
        {
            return System.Xml.XmlConvert.ToString(dateTime, XsdDateTimeFormat);
        }

        /// <summary>
        /// Parses the XSD date time.
        /// </summary>
        /// <param name="dateTimeStr">The date time string.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ParseXsdDateTime(string dateTimeStr)
        {
            return System.Xml.XmlConvert.ToDateTimeOffset(dateTimeStr).DateTime;
        }

        /// <summary>
        /// The UTC date time format
        /// </summary>
        public const string UtcDateTimeFormat = "yyyy-MM-ddTHH:mm:sszzz"; //UTC
        /// <summary>
        /// Parses the date time.
        /// </summary>
        /// <param name="dateTimeStr">The date time string(2019-12-22T18:12:10+08:00).</param>
        /// <returns>DateTime.</returns>
        public static DateTime ParseUtcDateTime(string dateTimeStr)
        {
            return DateTime.ParseExact(dateTimeStr, UtcDateTimeFormat, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns>System.Int64.</returns>
        public static long GetUnixTime()
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTime.Now.Kind);
            return Convert.ToInt64((DateTime.Now - start).TotalSeconds);
        }
        /// <summary>
        /// Dates the time to unix timestamp.
        /// </summary>
        /// <param name="dateTimeStr">The date time string.</param>
        /// <returns>System.Int32.</returns>
        public static long UtcTimeToUnixTime(this string dateTimeStr)
        {
            if (string.IsNullOrWhiteSpace(dateTimeStr))
            {
                return UnixEpochSecond;
            }
            DateTime utcDateTime = ParseUtcDateTime(dateTimeStr);
            return ToUnixTime(utcDateTime);
        }
        /// <summary>
        /// Dates the time to unix timestamp.
        /// </summary>
        /// <param name="dateTimeStr">The date time string.</param>
        /// <returns>System.Int32.</returns>
        public static DateTime UtcTimeToDateTime(this string dateTimeStr)
        {
            if (string.IsNullOrWhiteSpace(dateTimeStr)||dateTimeStr==MinXsdDateTimeFormatSeconds)
            {
                return DateTime.MinValue;
            }
            return ParseUtcDateTime(dateTimeStr);
        }

        /// <summary>
        /// UTCs the time to nullable date time.
        /// </summary>
        /// <param name="dateTimeStr">The date time string.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static DateTime? UtcTimeToNullableDateTime(this string dateTimeStr)
        {
            if (string.IsNullOrWhiteSpace(dateTimeStr) || dateTimeStr == MinXsdDateTimeFormatSeconds)
            {
                return null;
            }
            return ParseUtcDateTime(dateTimeStr);
        }
        /// <summary>
        /// Converts to utcdatetimestring.
        /// </summary>
        /// <param name="unixTime">The unix time.</param>
        /// <returns>System.String.</returns>
        public static string ToUtcDateTimeString(this int unixTime)
        {
            return FromUnixTime(unixTime).ToString(DateTimeExtensions.UtcDateTimeFormat);
        }

    }

}
