// <copyright file="IProducer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow.Dataflow
{
    using System.Threading.Tasks.Dataflow;

    using Workflow.Models;

    /// <summary>
    /// Producer messages interface.
    /// </summary>
    internal interface IProducer
    {
        /// <summary>
        /// Produce message.
        /// </summary>
        /// <param name="target">Target block.</param>
        void Produce(ITargetBlock<IFurnitureItem> target);
    }
}
