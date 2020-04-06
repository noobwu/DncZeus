using Noob.Extensions;
using NUnit.Framework;
using System;
using System.Globalization;

namespace Noob.NUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Date_Test()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            //https://docs.microsoft.com/zh-cn/dotnet/api/system.datetime.parseexact?view=netframework-4.8
            string dateString = "2019-12-22T18:12:10+08:00";
            string format = "yyyy-MM-ddTHH:mm:ss+08:00";

            DateTime utcDateTime = DateTime.ParseExact("2019-12-22T18:12:10+08:00",
                                 "yyyy-MM-ddTHH:mm:ss+08:00",
                                provider);
            try
            {
                var result = DateTime.ParseExact(dateString, format, provider);
                Console.WriteLine("{0} converts to {1}.", dateString, result.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", dateString);
            }
            try
            {
                var result = DateTime.ParseExact(dateString, DateTimeExtensions.UtcDateTimeFormat, provider);
                Console.WriteLine("UtcDateTimeFormat,{0} converts to {1}.", dateString, result.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("UtcDateTimeFormat,{0} is not in the correct format.", dateString);
            }
            string DateTimeFormatTicksUtcOffset = "yyyy-MM-ddTHH:mm:ss.fffffffzzz";  //30
            Console.WriteLine($"now:{DateTime.Now.ToString(DateTimeFormatTicksUtcOffset)}");
            Assert.Pass();
        }
    }
}