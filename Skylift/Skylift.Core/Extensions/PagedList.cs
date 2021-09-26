using System.Collections.Generic;

namespace Skylift.Core.Extensions
{
    /// <summary>
    /// Paged List
    /// </summary>
    /// <typeparam name="T">List of values</typeparam>
    public class PagedList<T>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the total record count.
        /// </summary>
        /// <value>
        /// The total record count.
        /// </value>
        public int TotalRecordCount { get; set; }
    }
}