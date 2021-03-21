using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubItemFun.Models
{
    /// <summary>
    /// Represents an item
    /// </summary>
    public class Item
    {
        #region Properties
        /// <summary>
        /// Item number
        /// </summary>
        public string ItemNumber { get; set; }
        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Sub items
        /// </summary>
        public IEnumerable<Item> Items { get; set; }

        #endregion
    }
    /// <summary>
    /// Subitem Summary
    /// </summary>
    public class SubItemSummary
    {
        #region Properties
        /// <summary>
        /// Name of subitem
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Count of subitems
        /// </summary>
        public int Count { get; set; }
        #endregion
    }
}
