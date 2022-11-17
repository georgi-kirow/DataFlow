// <copyright file="AssemblyLine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow
{
    using System.Threading.Tasks.Dataflow;

    using Workflow.Models;

    /// <summary>
    /// Assembly line class.
    /// </summary>
    internal class AssemblyLine : IAssemblyLine
    {
        private readonly Random rand = new ();

        /// <inheritdoc/>
        public void ConstructAssemblyLine(IFurnitureItem newItem, int elementId)
        {
            // put item on the line
            var putItemInLine = new TransformBlock<IFurnitureItem, IFurnitureItem>(item =>
            {
                Console.WriteLine($"===== Step #1 - ({elementId}) ============================================");
                Console.WriteLine("     1.Put item on the line and start moving on.");

                return new FurnitureItem(10, 10);
            });

            // make a screenshots
            var takePhotos = new TransformBlock<IFurnitureItem, IFurnitureItem>(item =>
            {
                Console.WriteLine($"===== Step #2 - ({elementId}) ============================================");
                Console.WriteLine("     1. Element reach the sensor on the begining of the camera.");

                var photos = new List<IBarcodePhotos>();
                int ii = 1;

                Console.WriteLine("     2. Starting shoot pictures.");
                do
                {
                    // simulate get picture delay
                    Console.WriteLine($"        Take ({ii}) picture.");
                    Thread.Sleep(100);

                    item.BarcodePhotos.Add(TakeOnePhoto());
                }
                while (ReachEndOfElement() || ii++ > 6);
                Console.WriteLine($"        3. {ii - 1} pictures are taken.");

                return item;
            });

            var consolidateBarcodeImages = new TransformBlock<IFurnitureItem, IFurnitureItem>(item =>
            {
                Console.WriteLine($"===== Step #3 - ({elementId}) ============================================");
                Console.WriteLine("     1. Try to consolidate all pictures and get barcodes from the API.");

                // simulate logic for consolidating the barcode images and get one barcode and onr template.
                // here we request the API for pictures.
                Thread.Sleep(6000);

                Console.WriteLine("     2. Barcode's are taken.");

                return item;
            });

            // check barcodes in DB
            var checkBarcodesOnDb = new TransformBlock<IFurnitureItem, IFurnitureItem>(item =>
            {
                Console.WriteLine($"===== Step #4 - ({elementId}) ============================================");
                Console.WriteLine("     1. Try to check barcode and template in the DB");
                item.ExsistsInDb = rand.Next(2) == 0;

                return item;
            });

            // check barcodes in DB
            var putOnTheEnd = new TransformBlock<IFurnitureItem, IFurnitureItem>(item =>
            {
                Console.WriteLine($"===== Step #5 - ({elementId}) ============================================");
                Console.WriteLine("     1. All is OK and the detail go out from the picture process. Go to the end of the line.");
                Thread.Sleep(100);

                return item;
            });

            var endOfLine = new ActionBlock<IFurnitureItem>(item =>
            {
                Console.WriteLine($"===== Step #6 - ({elementId}) ============================================");
                Console.WriteLine("     1. Element is removed from the line and object is destroyed.");
                item.Dispose();
            });

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            // put item on the line then start take the pictures.
            putItemInLine.LinkTo(takePhotos, linkOptions);
            takePhotos.LinkTo(consolidateBarcodeImages, linkOptions);
            consolidateBarcodeImages.LinkTo(checkBarcodesOnDb, linkOptions);
            checkBarcodesOnDb.LinkTo(putOnTheEnd, linkOptions);
            putOnTheEnd.LinkTo(endOfLine, linkOptions);

            putItemInLine.Post(newItem);
            putItemInLine.Complete();
            endOfLine.Completion.Wait();
        }

        // take one photo.
        private IBarcodePhotos TakeOnePhoto()
        {
            Thread.Sleep(1000);

            return new BarcodePhoto(3, 3);
        }

        // check PLC for the end of the element.
        private bool ReachEndOfElement()
        {
            return rand.Next(2) == 0;
        }
    }
}
