using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        //Generic List of pooled Items
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
        // Generic Object class
        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
        // Generic Functions
        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.Item;
                }
            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Child class has no implementation for this virtual fucntion");
        }
    }
}
