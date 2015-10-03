﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoinChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an amount of coins.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to an amount of coins.</summary>
    public class CoinChatLink : ChatLink
    {
        /// <summary>Gets or sets the quantity.</summary>
        public int Quantity { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var stream = new CoinChatLinkConverter().Convert(this, null);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return string.Format("[&{0}]", Convert.ToBase64String(buffer));
        }
    }
}