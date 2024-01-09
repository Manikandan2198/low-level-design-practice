using CachingSystem.EvictionPolicy;
using CachingSystem.Exceptions;
using CachingSystem.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CachingSystem
{
    public class Cache<Key,Value>
    {
        private IStorage<Key,Value> Storage { get; set; }
        private IEvicetionPolicy<Key> EvicetionPolicy { get; set; }

        public Cache(IStorage<Key, Value> storage, IEvicetionPolicy<Key> evicetionPolicy)
        {
            this.Storage = storage;
            this.EvicetionPolicy = evicetionPolicy;
        }

        public void Put(Key key, Value value)
        {
            try
            {
                this.Storage.Add(key, value);
                this.EvicetionPolicy.KeyAccessed(key);
            }
            catch(StorageFullException e)
            {
                var evictedKey = this.EvicetionPolicy.Evict();
                this.Storage.Remove(evictedKey);
                this.Storage.Add(key,value);
                this.EvicetionPolicy.KeyAccessed(key);
            }
        }

        public Value Get(Key key)
        {
            try
            {
                var cachedValue = this.Storage.Get(key);
                this.EvicetionPolicy.KeyAccessed(key);
                return cachedValue;
            }
            catch(NotFoundException e)
            {
                return default(Value);
            }
        }
    }
}
