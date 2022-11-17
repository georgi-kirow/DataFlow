using System.Threading.Tasks.Dataflow;

using Workflow;
using Workflow.Models;

var rand = new Random();

void AssemblyLineWorflow()
{

    // transport item on the line.
    var transportOnLine = new TransformBlock<IFurnitureItem, IFurnitureItem>(item =>
    {
        return item;
    });

    // check item in DB
    var checkFurnitureInDB = new TransformBlock<IFurnitureItem, IFurnitureItem>(item =>
    {
        item.ExsistsInDb = rand.Next(2) == 0;

        return item;
    });

    // check item in DB
    var proceedFromKuka = new ActionBlock<IFurnitureItem>(item =>
    {
        // if (checked is item in the DB)
        if (item.ExsistsInDb)
        {
            Console.WriteLine($"Item with width: {item.Width} and height: {item.Height} is processed from Kuka.");
        }
        else
        {
            Console.WriteLine($"This item is not on the DB.");
        }
    });

    var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

    transportOnLine.LinkTo(checkFurnitureInDB, linkOptions);
    checkFurnitureInDB.LinkTo(proceedFromKuka, linkOptions);

    transportOnLine.Post(new FurnitureItem(rand.Next(10, 100), rand.Next(20, 50)));
    transportOnLine.Complete();
    checkFurnitureInDB.Completion.Wait();
    Console.WriteLine("==============================");
}

// Parallel.For(0, 100, (i) => { AssemblyLineWorflow(); });

var assemblyLine = new AssemblyLine();
for (int i = 0; i < 1; i++)
{
    assemblyLine.ConstructAssemblyLine(new FurnitureItem(10, 10), i); // rand.Next(10, 99));
}

// Parallel.For(0, 10, (i) => { assemblyLine.ConstructAssemblyLine(new FurnitureItem(10, 10), rand.Next(10, 99)); });