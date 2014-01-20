﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Tools
{
    /// <summary>
    /// Represents detailed information about a tool.
    /// </summary>
    public class ToolDetails : Details
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDetails"/> class.
        /// </summary>
        public ToolDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDetails"/> class using the specified values.
        /// </summary>
        /// <param name="type">The tool's type.</param>
        public ToolDetails(ToolType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the tool's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ToolType Type { get; set; }
        
        /// <summary>
        /// Gets or sets the tool's charges.
        /// </summary>
        [JsonProperty("charges", Order = 1)]
        public int Charges { get; set; }
    }
}