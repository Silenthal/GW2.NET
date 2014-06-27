﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of map floors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a collection of map floors.</summary>
    [CollectionDataContract]
    [JsonArray(ItemConverterType = typeof(UnknownFloorConverter))]
    public class FloorCollection : ServiceContractList<Floor>
    {
        /// <summary>Initializes a new instance of the <see cref="FloorCollection" /> class.</summary>
        public FloorCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FloorCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public FloorCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FloorCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public FloorCollection(IEnumerable<Floor> collection)
            : base(collection)
        {
        }
    }
}