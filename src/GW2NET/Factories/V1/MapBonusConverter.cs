﻿// <copyright file="MapBonusConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Converters;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    public class MapBonusConverterFactory : ITypeConverterFactory<MapBonusDTO, MapBonus>
    {
        public IConverter<MapBonusDTO, MapBonus> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "bloodlust":
                    return new BloodlustConverter();
                default:
                    return new UnknownMapBonusConverter();
            }
        }
    }
}