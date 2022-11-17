// <copyright file="IFurnitureItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow.Models
{
    /// <summary>
    /// Furniture interface.
    /// </summary>
    internal interface IFurnitureItem : IDisposable
    {
        /// <summary>
        /// Gets Width of the furniture.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets Heigth of the furniture.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets or sets a value indicating whether element is in the DB.
        /// </summary>
        bool ExsistsInDb { get; set; }

        /// <summary>
        /// Gets or sets barcode photos list.
        /// </summary>
        IList<IBarcodePhotos> BarcodePhotos { get; set; }
    }
}
