﻿// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-16
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-16
// ***********************************************************************
// <copyright file="ParameterRebinder.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Noob.Expressions
{
    //http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx
    /// <summary>
    /// Class ParameterRebinder.
    /// Implements the <see cref="Noob.Expressions.SqlExpressionVisitor" />
    /// </summary>
    /// <seealso cref="Noob.Expressions.SqlExpressionVisitor" />
    public class ParameterRebinder : SqlExpressionVisitor
    {
        /// <summary>
        /// The map
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterRebinder"/> class.
        /// </summary>
        /// <param name="map">The map.</param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// Replaces the parameters.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>Expression.</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        /// <summary>
        /// Visits the parameter.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>Expression.</returns>
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}