﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the map floor service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Floors
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Maps.Floors.Contracts;

    /// <summary>Provides the default implementation of the map floor service.</summary>
    public class MapFloorService : IMapFloorService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapFloorService" /> class.</summary>
        public MapFloorService()
            : this(new ServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapFloorService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapFloorService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continentId, int floor)
        {
            return this.GetMapFloor(continentId, floor, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continentId, int floor, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new MapFloorRequest { ContinentId = continentId, Floor = floor, Culture = language };
            var result = this.serviceClient.Send<Floor>(serviceRequest);

            // patch missing floor information
            result.ContinentId = continentId;
            result.FloorNumber = floor;

            // patch missing language information
            result.Language = language;

            return result;
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor)
        {
            return this.GetMapFloorAsync(continentId, floor, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken cancellationToken)
        {
            return this.GetMapFloorAsync(continentId, floor, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CultureInfo language)
        {
            return this.GetMapFloorAsync(continentId, floor, language, CancellationToken.None);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The floor number.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continentId, int floor, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new MapFloorRequest { ContinentId = continentId, Floor = floor, Culture = language };
            var t1 = this.serviceClient.SendAsync<Floor>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // patch missing floor information
                        result.ContinentId = continentId;
                        result.FloorNumber = floor;

                        // patch missing language information
                        result.Language = language;

                        return result;
                    }, 
                cancellationToken);

            return t1;
        }
    }
}