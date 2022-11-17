// <copyright file="BarcodePhoto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow.Models
{
    /// <inheritdoc/>
    internal class BarcodePhoto : IBarcodePhotos
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodePhoto"/> class.
        /// Construct barcode photo.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public BarcodePhoto(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <inheritdoc/>
        public int Width { get; set; }

        /// <inheritdoc/>
        public int Height { get; set; }
    }
}
