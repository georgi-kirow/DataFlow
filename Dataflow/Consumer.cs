// <copyright file="Consumer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow.Dataflow
{
    using System.Threading.Tasks.Dataflow;

    using Workflow.Models;

    /// <summary>
    /// Consumer of messages.
    /// </summary>
    internal class Consumer : IConsumer
    {
        /// <inheritdoc/>
        public async Task ConsumeAsync(ISourceBlock<IFurnitureItem> source)
        {
            int ii = 0;

            while (await source.OutputAvailableAsync())
            {
                var data = await source.ReceiveAsync();

                Console.WriteLine($"#:{ii++}, Width: {data.Width} and Height: {data.Height}.");
            }

            source.Complete();
        }
    }
}
