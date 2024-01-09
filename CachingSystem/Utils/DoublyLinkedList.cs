using System;
using System.Collections.Generic;
using System.Text;

namespace CachingSystem.Utils
{
    public class DoublyLinkedListNode<E>
    {
        public E Val;
        public DoublyLinkedListNode<E> Next;
        public DoublyLinkedListNode<E> Prev;
        public DoublyLinkedListNode(E val)
        {
            this.Val = val;
            this.Next = null;
            this.Prev = null;
        }
    } 
    public class DoublyLinkedList<E>
    {
        public DoublyLinkedListNode<E> Head;
        public DoublyLinkedListNode<E> Tail;

        public void DetachNode(DoublyLinkedListNode<E> node)
        {
            if(node == Head && Head == Tail)
            {
                Head = null;
                Tail = null;
                return;
            }

            if(node == Tail)
            {
                Tail = Tail.Prev;
                Tail.Next = null;
                return;
            }

            if(node == Head)
            {
                Head = Head.Next;
                Head.Prev = null;
                return;
            }

            node.Next.Prev = node.Prev;
            node.Prev.Next = node.Next;
            node.Next = null;
            node.Prev = null;
            return;
        }

        public void AttachNodeAtLast(DoublyLinkedListNode<E> node)
        {
            if(Head == null && Head == Tail)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            node.Prev = Tail;
            Tail = Tail.Next;
            return;
        }

        public DoublyLinkedListNode<E> GetFirstNode()
        {
            return Head;
        }
    }
}
