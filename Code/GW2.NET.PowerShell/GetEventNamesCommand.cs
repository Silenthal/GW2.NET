﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.PS.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;

    using GW2DotNET.Common;
    using GW2DotNET.V1.DynamicEvents;

    [Cmdlet(VerbsCommon.Get, "EventNames", DefaultParameterSetName = "All")]
    public class GetEventNamesCommand : ServiceCmdlet
    {
        private IDynamicEventNameService service;

        [Parameter]
        public CultureInfo Culture { get; set; }


        [Parameter(Position = 0, ParameterSetName = "ById")]
        public Guid[] Id { get; set; }

        [Parameter(Position = 0, ParameterSetName = "ByName")]
        public string[] Name { get; set; }

        /// <summary>Provides a one-time, preprocessing functionality for the cmdlet.</summary>
        /// <param name="serviceClient">A service client.</param>
        protected override void BeginProcessing(IServiceClient serviceClient)
        {
            this.service = new DynamicEventService(serviceClient);
        }

        /// <summary>Provides a record-by-record processing functionality for the cmdlet.</summary>
        protected override void ProcessRecord()
        {
            // Configure the language (default: English)
            var culture = this.Culture ?? CultureInfo.GetCultureInfo("en");

            // Try to get dynamic event names
            try
            {
                // Get the event names from the service
                var dynamicEventNames = this.service.GetDynamicEventNames(culture);

                switch (ParameterSetName)
                {
                    case "ById":
                        dynamicEventNames = dynamicEventNames.Where(pair => this.Id.Contains(pair.Key)).ToDictionary(pair => pair.Key, pair => pair.Value);
                        break;
                    case "ByName":
                        dynamicEventNames = dynamicEventNames.Where(pair => this.Name.Contains(pair.Value.Name, StringComparer.Create(culture, true))).ToDictionary(pair => pair.Key, pair => pair.Value);
                        break;
                }

                // Write the collection to the pipeline
                this.WriteObject(dynamicEventNames);
            }
            catch (ServiceException serviceException)
            {
                // Write a fatal error that indicates a service error
                this.ThrowTerminatingError(new ErrorRecord(serviceException, "ServiceError", ErrorCategory.ResourceUnavailable, null));
            }
            catch (WebException webException)
            {
                // Write a fatal error that indicates a connection error
                this.ThrowTerminatingError(new ErrorRecord(webException, "ConnectionError", ErrorCategory.ConnectionError, null));
            }
        }

    }
}
