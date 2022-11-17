// <copyright file="IAssemblyLine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Workflow
{
    using Workflow.Models;

    /// <summary>
    /// Assembly line interface.
    /// </summary>
    internal interface IAssemblyLine
    {
        /// <summary>
        /// Construct assembly line.
        /// </summary>
        /// <param name="newItem">New furniture item.</param>
        /// <param name="elementId">Element id.</param>
        void ConstructAssemblyLine(IFurnitureItem newItem, int elementId);
    }
}
