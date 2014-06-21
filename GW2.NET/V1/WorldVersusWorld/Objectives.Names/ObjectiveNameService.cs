﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the objective names service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Objectives.Names
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.WorldVersusWorld.Objectives.Names.Contracts;

    /// <summary>Provides the default implementation of the objective names service.</summary>
    public class ObjectiveNameService : IObjectiveNameService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameService" /> class.</summary>
        public ObjectiveNameService()
            : this(new ServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ObjectiveNameService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IEnumerable<ObjectiveName> GetObjectiveNames()
        {
            return this.GetObjectiveNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IEnumerable<ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ObjectiveNameRequest { Culture = language };
            var result = this.serviceClient.Send<ObjectiveNameCollection>(serviceRequest);

            // patch missing language information
            foreach (var objectiveName in result)
            {
                objectiveName.Language = language;
            }

            return result;
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync()
        {
            return this.GetObjectiveNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetObjectiveNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language)
        {
            return this.GetObjectiveNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ObjectiveNameRequest { Culture = language };
            var t1 = this.serviceClient.SendAsync<ObjectiveNameCollection>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // patch missing language information
                        foreach (var objectiveName in result)
                        {
                            objectiveName.Language = language;
                        }

                        return result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<ObjectiveName>>(task => task.Result, cancellationToken);

            return t2;
        }
    }
}