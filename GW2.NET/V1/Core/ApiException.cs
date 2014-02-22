﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiException.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Represents an API error.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1"/> for more information regarding API errors.
    /// </remarks>
    public class ApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="details">The error details.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ApiException(ErrorResponse details, Exception innerException = null)
            : base(Preconditions.EnsureNotNull(paramName: "details", value: details).Text, innerException)
        {
            this.Details = details;
        }

        /// <summary>
        /// Gets the error details.
        /// </summary>
        public ErrorResponse Details { get; private set; }
    }
}