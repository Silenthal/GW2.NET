﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderFileRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for an in-game asset.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    using System.Drawing.Imaging;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Core.Common;

    /// <summary>Represents a request for an in-game asset.</summary>
    public class RenderFileRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="RenderFileRequest"/> class.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        public RenderFileRequest(IRenderable file, ImageFormat imageFormat)
            : base(CreateFileResource(file, imageFormat))
        {
        }

        /// <summary>Gets the path that points to the specified file.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The file path.</returns>
        private static string CreateFileResource(IRenderable file, ImageFormat imageFormat)
        {
            Preconditions.EnsureNotNull(paramName: "file", value: file);
            Preconditions.EnsureNotNull(paramName: "imageFormat", value: imageFormat);

            return string.Format("file/{0}/{1}.{2}", file.FileSignature, file.FileId, GetExtension(imageFormat));
        }

        /// <summary>Gets a file extension for the specified image format.</summary>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>The extension.</returns>
        private static string GetExtension(ImageFormat imageFormat)
        {
            if (object.Equals(imageFormat, ImageFormat.Jpeg))
            {
                return @"jpg";
            }

            return imageFormat.ToString().ToLowerInvariant();
        }
    }
}