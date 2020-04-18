// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ValueObject.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.Domain.Values
{
    //Inspired from https://docs.microsoft.com/zh-cn/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    /// <summary>
    /// Class ValueObject.
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns>IEnumerable&lt;System.Object&gt;.</returns>
        protected abstract IEnumerable<object> GetAtomicValues();

        /// <summary>
        /// Values the equals.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ValueEquals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject other = (ValueObject)obj;

            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
    }
}
