﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the items service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items
{
    /// <summary>Provides the interface for the items service.</summary>
    public interface IItemService : IItemDiscoveryService, IItemDetailsService
    {
    }
}