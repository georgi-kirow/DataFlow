namespace Workflow.Models
{
    /// <summary>
    /// Barcode photo interface.
    /// </summary>
    internal interface IBarcodePhotos
    {
        /// <summary>
        /// Gets or sets width of the photo.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets or sets height of the photo.
        /// </summary>
        int Height { get; set; }
    }
}
