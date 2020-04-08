using AutoMapper;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noob.Extensions
{
    /// <summary>
    /// Class AutoMapExtensions.
    /// </summary>
    public static class AutoMapExtensions
    {
        /// <summary>
        ///使用AutoMapper将从源对象到现有目标对象的映射
        ///在调用此方法之前，对象之间必须有映射。
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            if (source == null)
            {
                return default(TDestination);
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map(source, destination);
        }

        /// <summary>
        ///使用AutoMapper将从源对象到现有目标对象的映射
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, MapperConfiguration config)
        {
            if (source == null)
            {
                return default(TDestination);
            }
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }


        /// <summary>
        ///使用AutoMapper将从源对象到现有目标对象的映射
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <returns></returns>
        public static TDestination AutoMapTo<TSource, TDestination>(this TSource source)
        {
            if (source == null)
            {
                return default(TDestination);
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }
    }
    /// <summary>
    /// Class IntUtcTimeTypeConverter.
    /// Implements the <see cref="AutoMapper.ITypeConverter{System.String, System.Int32?}" />
    /// </summary>
    /// <seealso cref="AutoMapper.ITypeConverter{System.String, System.Int32?}" />
    public class IntUtcTimeTypeConverter : ITypeConverter<string, int?>
    {

        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public int?  Convert(string source, int? destination, ResolutionContext context)
        {
            return (int)(source?.UtcTimeToUnixTime());
        }
    }
    /// <summary>
    /// Class NullableUtcTimeTypeConverter.
    /// Implements the <see cref="AutoMapper.ITypeConverter{System.String, System.DateTime?}" />
    /// </summary>
    /// <seealso cref="AutoMapper.ITypeConverter{System.String, System.DateTime?}" />
    public class NullableUtcTimeTypeConverter : ITypeConverter<string, DateTime?>
    {

        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public DateTime? Convert(string source, DateTime? destination, ResolutionContext context)
        {
            var dateTime= source?.UtcTimeToNullableDateTime();
            if (dateTime.HasValue && dateTime.Value == DateTime.MinValue)
            {
                return null;
            }
            return dateTime;
        }
    }
    /// <summary>
    /// Class NullableUtcTimeTypeConverter.
    /// Implements the <see cref="AutoMapper.ITypeConverter{System.String, System.DateTime?}" />
    /// </summary>
    /// <seealso cref="AutoMapper.ITypeConverter{System.String, System.DateTime?}" />
    public class UtcTimeTypeConverter : ITypeConverter<DateTime, DateTime>
    {
        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public DateTime Convert(DateTime source, DateTime destination, ResolutionContext context)
        {
            if (source < DateTimeExtensions.MinDateTime)
            {
                return DateTimeExtensions.MinDateTime;
            }
            return source;
        }
    }
}
