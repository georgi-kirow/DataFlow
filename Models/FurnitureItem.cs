namespace Workflow.Models
{
    /// <summary>
    /// Furniture item.
    /// </summary>
    internal class FurnitureItem : IFurnitureItem
    {
        private readonly int width;
        private readonly int height;

        private bool exsistsInDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="FurnitureItem"/> class.
        /// </summary>
        /// <param name="width">Width of the element.</param>
        /// <param name="height">Height of the element.</param>
        public FurnitureItem(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <inheritdoc/>
        public int Width => width;

        /// <inheritdoc/>
        public int Height => height;

        /// <inheritdoc/>
        public bool ExsistsInDb
        {
            get => exsistsInDb;
            set => exsistsInDb = value;
        }

        /// <inheritdoc/>
        public IList<IBarcodePhotos> BarcodePhotos { get; set; } = new List<IBarcodePhotos>();

        /// <summary>
        /// Free used resources.
        /// </summary>
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
