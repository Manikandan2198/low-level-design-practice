using CachingSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CachingSystem.Storage
{
    public class DictionaryBasedStorage<Key, Value> : IStorage<Key, Value>
    {
        private IDictionary<Key, Value> CacheStorage { get; set; }
        private int Capacity { get; set; }
        public DictionaryBasedStorage(int capacity)
        {
            this.CacheStorage = new Dictionary<Key, Value>();
            this.Capacity = capacity;

        }
        public void Add(Key key, Value value)
        {
            if (this.IsStorageFull())
                throw new StorageFullException("Storage is full");

            this.CacheStorage.Add(key, value);
        }

        public Value Get(Key key)
        {
            if (!this.CacheStorage.ContainsKey(key))
                throw new NotFoundException("Key not found");

            return this.CacheStorage[key];
        }

        public void Remove(Key key)
        {
            if (!this.CacheStorage.ContainsKey(key))
                throw new NotFoundException("Key not found");

            this.CacheStorage.Remove(key);
        }

        private bool IsStorageFull()
        {
            return this.CacheStorage.Count == this.Capacity;
        }
    }
}
