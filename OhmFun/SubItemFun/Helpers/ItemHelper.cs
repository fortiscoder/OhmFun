using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubItemFun.Models;

namespace SubItemFun
{
    public class ItemHelper
    {
        #region Instance variables
        private readonly IEnumerable<Item> _items;
        #endregion
        #region Constructors
        public ItemHelper()
        {
            // initializing the list here to make it cleaner
            List<Item> items = new List<Item>();
            items.Add(new Item
            {
                ItemNumber = "1",
                Name = "First",
                Items = new List<Item>
                {
                    new Item
                    {
                        ItemNumber = "1.1",
                        Name = "First Item SubItem 1",
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemNumber = "1.1.1",
                                Name = "First item Third layer first subitem item 1"
                            },
                            new Item
                            {
                                ItemNumber = "1.1.2",
                                Name = "First item Third layer first subitem item 2"
                            }
                        }
                    },
                    new Item
                    {
                        ItemNumber = "1.2",
                        Name = "First Item SubItem 2",
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemNumber = "1.2.1",
                                Name = "First item Third layer second subitem item 1"
                            },
                        }
                    }
                }
            });
            items.Add(new Item
            {
                ItemNumber = "2",
                Name = "Second",
                Items = new List<Item>
                {
                    new Item
                    {
                        ItemNumber = "2.1",
                        Name = "Second Item SubItem 1",
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemNumber = "2.1.1",
                                Name = "Second item Third layer first subitem item 1"
                            },
                            new Item
                            {
                                ItemNumber = "2.1.2",
                                Name = "Second item Third layer first subitem item 2"
                            }
                        }
                    },
                    new Item
                    {
                        ItemNumber = "2.2",
                        Name = "Second Item SubItem 2",
                        Items = new List<Item>
                        {
                            new Item
                            {
                                ItemNumber = "2.2.1",
                                Name = "Second item Third layer second subitem item 1"
                            },
                        }
                    }
                }
            });
            _items = items;
        }
        #endregion
        #region Public Methods
        public SubItemSummary[] GetSubItemSummary(string itemNumber)
        {
            // Get the item
            var item = _items.Where(x => x.ItemNumber == itemNumber).FirstOrDefault();
            if (item == null) return new SubItemSummary[] { }; // empty array

            List<SubItemSummary> summary = new List<SubItemSummary>();

            RecurseItem(item, summary);

            return summary.ToArray();
        }
        #endregion
        #region Private Methods
        private void RecurseItem(Item item, List<SubItemSummary> summary)
        {
            summary.Add(
                new SubItemSummary
                {
                    Name = item.Name,
                    Count = item.Items?.Count() ?? 0
                });

            if (item.Items == null) return;
            foreach(var subItem in item.Items)
            {
                RecurseItem(subItem, summary);
            }
            
        }
        #endregion

    }
}
