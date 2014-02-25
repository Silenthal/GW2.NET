﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PistolRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Pistols
{
    /// <summary>
    /// Represents detailed information about a pistol crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class PistolRecipe : Recipe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PistolRecipe"/> class.
        /// </summary>
        public PistolRecipe()
            : base(RecipeType.Pistol)
        {
        }
    }
}