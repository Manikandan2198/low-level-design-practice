using CachingSystem.EvictionPolicy;
using CachingSystem.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CachingSystem.Factory
{
    public class CacheFactory
    {
        public Cache<Key,Value> DefaultCache<Key,Value>(int capacity)
        {
            return new Cache<Key, Value>(new DictionaryBasedStorage<Key, Value>(capacity), new LRUEvictionPolicy<Key>());
        }
    }
}
