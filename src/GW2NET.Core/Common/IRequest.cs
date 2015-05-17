﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>Provides the interface for service requests.</summary>
    [ContractClass(typeof(ContractClassForIRequest))]
    public interface IRequest
    {
        /// <summary>Gets the resource path.</summary>
        /// <exception cref="ArgumentNullException">The value is a null reference.</exception>
        string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        IEnumerable<KeyValuePair<string, string>> GetParameters();

        /// <summary>Gets additional path segments for the targeted resource.</summary>
        /// <returns>A collection of path segments.</returns>
        IEnumerable<string> GetPathSegments();
    }
}