using CachingSystem.Exceptions;
using CachingSystem.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CachingSystem.EvictionPolicy
{
    public class LRUEvictionPolicy<Key> : IEvicetionPolicy<Key>
    {
        private DoublyLinkedList<Key> dll;
        private Dictionary<Key, DoublyLinkedListNode<Key>> nodeMap;

        public LRUEvictionPolicy()
        {
            this.dll = new DoublyLinkedList<Key>();
            this.nodeMap = new Dictionary<Key, DoublyLinkedListNode<Key>>();
        }
        public Key Evict()
        {
            var evictedNode = dll.GetFirstNode();
            if (evictedNode == null)
                throw new NotFoundException("No key for eviction");

            dll.DetachNode(evictedNode);
            nodeMap.Remove(evictedNode.Val);
            return evictedNode.Val;
        }

        public void KeyAccessed(Key key)
        {
            if (!nodeMap.ContainsKey(key))
            {
                var node = new DoublyLinkedListNode<Key>(key);
                dll.AttachNodeAtLast(node);
                nodeMap.Add(key, node);
                return;
            }

            var existingNode = nodeMap[key];
            dll.DetachNode(existingNode);
            dll.AttachNodeAtLast(existingNode);
        }
    }
}
