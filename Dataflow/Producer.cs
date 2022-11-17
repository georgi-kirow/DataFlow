// <copyright file="Producer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow.Dataflow
{
    using System;
    using System.Threading.Tasks.Dataflow;

    using Workflow.Models;

    /// <summary>
    /// Message producer.
    /// </summary>
    internal class Producer : IProducer
    {
        /// <inheritdoc/>
        public void Produce(ITargetBlock<IFurnitureItem> target)
        {
            var rand = new Random();

            var element = new FurnitureItem(rand.Next(10, 100), rand.Next(20, 50));

            target.Post(element);

            //target.Complete();
        }
    }
}
