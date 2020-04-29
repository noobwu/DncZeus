// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="CrossCuttingConcerns.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Noob.Aspects
{
    /// <summary>
    /// Class CrossCuttingConcerns.
    /// </summary>
    public static class CrossCuttingConcerns
    {
        //TODO: Move these constants to their own assemblies!

        /// <summary>
        /// The auditing
        /// </summary>
        public const string Auditing = "Auditing";
        /// <summary>
        /// The unit of work
        /// </summary>
        public const string UnitOfWork = "UnitOfWork";
        /// <summary>
        /// The feature checking
        /// </summary>
        public const string FeatureChecking = "FeatureChecking";

        /// <summary>
        /// Adds the applied.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="concerns">The concerns.</param>
        /// <exception cref="ArgumentNullException">concerns</exception>
        public static void AddApplied(object obj, params string[] concerns)
        {
            if (concerns.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(concerns), $"{nameof(concerns)} should be provided!");
            }

            (obj as IAvoidDuplicateCrossCuttingConcerns)?.AppliedCrossCuttingConcerns.AddRange(concerns);
        }

        /// <summary>
        /// Removes the applied.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="concerns">The concerns.</param>
        /// <exception cref="ArgumentNullException">concerns</exception>
        public static void RemoveApplied(object obj, params string[] concerns)
        {
            if (concerns.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(concerns), $"{nameof(concerns)} should be provided!");
            }

            var crossCuttingEnabledObj = obj as IAvoidDuplicateCrossCuttingConcerns;
            if (crossCuttingEnabledObj == null)
            {
                return;
            }

            foreach (var concern in concerns)
            {
                crossCuttingEnabledObj.AppliedCrossCuttingConcerns.RemoveAll(c => c == concern);
            }
        }

        /// <summary>
        /// Determines whether the specified object is applied.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="concern">The concern.</param>
        /// <returns><c>true</c> if the specified object is applied; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">
        /// obj
        /// or
        /// concern
        /// </exception>
        public static bool IsApplied([NotNull] object obj, [NotNull] string concern)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (concern == null)
            {
                throw new ArgumentNullException(nameof(concern));
            }

            return (obj as IAvoidDuplicateCrossCuttingConcerns)?.AppliedCrossCuttingConcerns.Contains(concern) ?? false;
        }

        /// <summary>
        /// Applyings the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="concerns">The concerns.</param>
        /// <returns>IDisposable.</returns>
        public static IDisposable Applying(object obj, params string[] concerns)
        {
            AddApplied(obj, concerns);
            return new DisposeAction(() =>
            {
                RemoveApplied(obj, concerns);
            });
        }

        /// <summary>
        /// Gets the applieds.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String[].</returns>
        public static string[] GetApplieds(object obj)
        {
            var crossCuttingEnabledObj = obj as IAvoidDuplicateCrossCuttingConcerns;
            if (crossCuttingEnabledObj == null)
            {
                return new string[0];
            }

            return crossCuttingEnabledObj.AppliedCrossCuttingConcerns.ToArray();
        }
    }
}