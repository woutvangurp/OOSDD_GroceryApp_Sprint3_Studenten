﻿using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories {
    public class GroceryListItemsRepository : IGroceryListItemsRepository {
        private readonly List<GroceryListItem> groceryListItems;

        public GroceryListItemsRepository() {
            groceryListItems = [
                new GroceryListItem(1, 1, 1, 3),
                new GroceryListItem(2, 1, 2, 1),
                new GroceryListItem(3, 1, 3, 4),
                new GroceryListItem(4, 2, 1, 2),
                new GroceryListItem(5, 2, 2, 5),
            ];
        }

        public List<GroceryListItem> GetAll() {
            return groceryListItems;
        }

        public List<GroceryListItem> GetAllOnGroceryListId(int id) {
            return groceryListItems.Where(g => g.GroceryListId == id).ToList();
        }

        public GroceryListItem Add(GroceryListItem item) {
            int newId = groceryListItems.Max(g => g.Id) + 1;
            item.Id = newId;
            groceryListItems.Add(item);
            return Get(item.Id) ?? throw new NullReferenceException(nameof(item));
        }

        public GroceryListItem? Get(int id) => groceryListItems.FirstOrDefault(g => g.Id == id) ?? null;
        public GroceryListItem? Delete(GroceryListItem item) {
            GroceryListItem? toDelItem = groceryListItems.Find(g => g.Id == item.Id)
                                         ?? throw new NullReferenceException();
            groceryListItems.Remove(toDelItem);
            return toDelItem;
        }

        public GroceryListItem? Update(GroceryListItem item) {
            GroceryListItem listItem = Get(item.Id) ?? throw new NullReferenceException();
            listItem.Amount = item.Amount;
            return listItem;
        }

    }
}
