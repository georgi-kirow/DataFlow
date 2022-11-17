// <copyright file="IConsumer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow.Dataflow
{
    using System.Threading.Tasks.Dataflow;

    using Workflow.Models;

    /// <summary>
    /// Message consumer interface.
    /// </summary>
    internal interface IConsumer
    {
        /// <summary>
        /// Consume message asyncronously.
        /// </summary>
        /// <param name="source">Consumer source.</param>
        /// <returns>Void.</returns>
        Task ConsumeAsync(ISourceBlock<IFurnitureItem> source);
    }
}
